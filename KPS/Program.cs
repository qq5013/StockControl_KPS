using System;
using System.Collections.Generic;

using System.Windows.Forms;
using System.Configuration;
namespace KPS
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
 
            LoginFrm login = new LoginFrm();
            //NewLoginFrm login = new NewLoginFrm();
            DialogResult _result = login.ShowDialog();
            if (_result == DialogResult.OK)
            {
                Application.Run(new MainFrm());
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
