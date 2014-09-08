using System;
using System.Collections.Generic;

using System.Text;

namespace KPS.UIModels
{
    /// <summary>
    /// 表单录入类型
    /// </summary>
    public enum EntryType
    {
        /// <summary>
        /// 1.诊断试剂购进
        /// </summary>
        ZDSJGJ,
        /// <summary>
        /// 2.验收(产品采购记录)
        /// </summary>
        YS,
        /// <summary>
        /// 3.存储
        /// </summary>
        CC,
        /// <summary>
        ///  4.销售(诊断试剂售出)
        /// </summary>
        XS,
        /// <summary>
        /// 5.出库
        /// </summary>
        CK,
        /// <summary>
        /// 6.退换货 
        /// </summary>
        SH,
        /// <summary>
        /// 其它：7.不合格品记录
        /// </summary>
        BHGPJL,
        /// <summary>
        /// 其它：8.不良事件
        /// </summary>
        BLSJ,
        /// <summary>
        /// 9.质量跟踪
        /// </summary>
        ZLGZ,
        /// <summary>
        ///10.库存查询
        /// </summary>
        Inventory
    }
}
