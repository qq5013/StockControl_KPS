using System;
using System.Collections.Generic;
using System.Text;

namespace KPS.UIBLL
{
    /// <summary>
    /// 公共文件处理类
    /// </summary>
    public class CommonFileManager
    {
        private static CommonFileManager manager = new CommonFileManager();
        public static CommonFileManager Instance
        {
            get
            {
                return manager;
            }
        }

        /// <summary>
        /// 创建临时文件并返回路径
        /// </summary>
        /// <param name="strData"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string CreateTempFile(string strData, string fileName)
        {
            try
            {
                string strPath = System.IO.Path.GetTempPath()+ fileName;
                if (System.IO.File.Exists(strPath))//若存在则删除
                {
                    System.IO.File.Delete(strPath);
                }

                System.IO.StreamWriter filestream = System.IO.File.CreateText(strPath);
                filestream.Write(strData);
                filestream.Close();
                filestream.Dispose();
                return strPath;
            }
            catch (Exception ex)
            {
            }
            return null;
        }
    }
}
