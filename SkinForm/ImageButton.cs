using System;
using System.Drawing;
using System.Drawing.Imaging;
namespace CSharpWin
{

    public class ImageButton : IDisposable
    {
        private SkinForm _ParentControl;
        private Bitmap TitleImage;

        public event EventHandler Click;

        public ImageButton(Rectangle size, SkinForm Parent)
        {
            this._Size = size;
            _ParentControl = Parent;


            if (_ParentControl.Renderer is IPSSkinRender)
            {
                TitleImage = ((IPSSkinRender)_ParentControl.Renderer).TitleImage;
            }

            if (TitleImage != null)
            {
                _Image = TitleImage.Clone(size, TitleImage.PixelFormat);
                _OverImage = Brightness(_Image,25);
            }
        }

        private Rectangle _Size;
        public Rectangle Size
        {
            get
            {
                return _Size;
            }
            set
            {
                _Size = value;
            }
        }

        public Bitmap _Image;
        public Bitmap Image
        {
            get
            {
                return _Image;
            }
            set
            {
                _Image = value;
            }
        }

        private Bitmap _OverImage;
        public Bitmap OverImage
        {
            get
            {
                return _OverImage;
            }
            set
            {
                _OverImage = value;
            }
        }

        private Bitmap _ClickImage;
        public Bitmap ClickImage
        {
            get
            {
                return _ClickImage;
            }
            set
            {
                _ClickImage = value;
            }
        }

        public Rectangle GetButtonRectangle()
        {
            int x = (int)((float)this._ParentControl.CaptionRect.Width * (float)this._Size.X / (float)TitleImage.Width );
            int y = (int)((float)this._ParentControl.CaptionRect.Height * (float)this._Size.Y / (float)TitleImage.Height);

            int width = (int)((float)this._Size.Width * ((float)this._ParentControl.CaptionRect.Width) / (float)TitleImage.Width);
            int height = (int)((float)this._Size.Height * (float)this._ParentControl.CaptionRect.Height / (float)TitleImage.Height);
           
            return new Rectangle(x, y, width, height);

        }

        public void MouseClick()
        {
            Graphics g = this._ParentControl.CreateGraphics();

            try
            {
                if (this._ClickImage != null)
                {
                    g.DrawImage(this._ClickImage, GetButtonRectangle());
                }

                if (this.Click != null)
                {
                    this.Click(this, null);
                }

                if (this._Image != null)
                {
                    g.DrawImage(this._Image, GetButtonRectangle());
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            finally
            {
                g.Dispose();
            }
        }


        public Bitmap Brightness(Bitmap b, int nBrightness)
        {

            Bitmap bRetrun = (Bitmap)b.Clone();

            if (nBrightness < -255 || nBrightness > 255)
                return null;

            BitmapData bmData = bRetrun.LockBits(new Rectangle(0, 0, bRetrun.Width, bRetrun.Height), ImageLockMode.ReadWrite,
            bRetrun.PixelFormat);
            int stride = bmData.Stride;
            System.IntPtr Scan0 = bmData.Scan0;

            int nVal = 0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                int nOffset = stride - bRetrun.Width * 3;
                int nWidth = bRetrun.Width * 3;

                for (int y = 0; y < bRetrun.Height; y++)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {

                        nVal = (int)(p[0] + nBrightness);

                        if (nVal < 0) nVal = 0;

                        if (nVal > 255) nVal = 255;

                        p[0] = (byte)nVal;

                        ++p;

                    }

                    p += nOffset;

                }

            }



            bRetrun.UnlockBits(bmData);

            return bRetrun;

        }

        public void MouseMove(int ScreenX, int ScreenY)
        {
            if (GetButtonRectangle().Contains(ScreenX, ScreenY))
            {

                //if (!isMovingState)
                //{
                    isMovingState = true;
                    Draw();
                //}
                //else
                //{
                //    isMovingState = true;
                //}
                
                   
            }
            else
            {
                //if (isMovingState)
                //{
                    isMovingState = false;
                    Draw();
                //}
                //else
                //{
                //    isMovingState = false;
                //}
            }
        }

        private bool isMovingState = false;
        public void Draw(int ScreenX, int ScreenY)
        {
            lock (this)
            {
                Graphics g = this._ParentControl.CreateGraphics();

                try
                {
                    if (GetButtonRectangle().Contains(ScreenX, ScreenY) && !isMovingState)
                    {
                        if (_OverImage != null)
                        {
                            g.DrawImage(this._OverImage, GetButtonRectangle());
                        }
                        isMovingState = true;
                    }
                    else
                    {
                        if (_Image != null && isMovingState)
                        {
                            g.DrawImage(this._Image, GetButtonRectangle());
                        }
                        isMovingState = false;
                    }
                }
                finally
                {
                    g.Dispose();
                }
            }
        }

        public void Draw()
        {
            lock (this)
            {
                Graphics g = this._ParentControl.CreateGraphics();

                try
                {
                    if (isMovingState)
                    {
                        if (_OverImage != null)
                        {
                            g.DrawImage(this._OverImage, GetButtonRectangle());
                        }
                    }
                    else
                    {
                        if (_Image != null)
                        {
                            g.DrawImage(this._Image, GetButtonRectangle());
                        }
                    }
                }
                finally
                {
                    g.Dispose();
                }
            }
        }

        #region IDisposable ≥…‘±

        public void Dispose()
        {
            if (this._OverImage != null) this._OverImage.Dispose();
            if (this._Image != null) this._Image.Dispose();
            if (this.ClickImage != null) this._ClickImage.Dispose();


        }

        #endregion
    }
}