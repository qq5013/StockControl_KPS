using System;
using System.Collections.Generic;

using System.Text;

namespace KPS.UIModels
{
    /// <summary>
    /// 登录状态
    /// </summary>
    public enum LoginStateEnum
    {
        /// <summary>
        /// 用户名不存在
        /// </summary>
        NoExt,
        /// <summary>
        /// 用户名或密码错误
        /// </summary>
        Error,
        /// <summary>
        /// 用户名密码正确
        /// </summary>
        Correct
    }
}
