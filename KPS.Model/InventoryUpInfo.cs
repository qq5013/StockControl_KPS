using System;
using System.Collections.Generic;
using System.Text;

namespace KPS.Model
{
    /// <summary>
    /// 库存更新状态信息
    /// </summary>
    public enum InventoryUpState
    {
       /// <summary>
       /// 处理成功
       /// </summary>
       Succed,
       /// <summary>
       /// 相关产品记录不存在(产品名称+厂家+注册证号+批号)
       /// </summary>
       ProductNoExt,
       /// <summary>
       /// 库存不足，无法生存销售记录
       /// </summary>
       ProductLacking,
       /// <summary>
       /// 系统处理异常，失败
       /// </summary>
       SysTemError
    }
}
