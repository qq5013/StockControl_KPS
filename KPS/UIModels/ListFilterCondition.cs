using System;
using System.Collections.Generic;

using System.Text;

namespace KPS.UIModels
{
    /// <summary>
    /// 筛选条件
    /// </summary>
    public class ListFilterCondition
    {
        private string filterText;
        /// <summary>
        /// 筛选文字
        /// </summary>
        public string FilterText
        {
            get { return filterText; }
            set { filterText = value; }
        }
        private DateTime startTime;
        /// <summary>
        /// 记录时间范围，开始时间
        /// </summary>
        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }
        private DateTime endTime;
        /// <summary>
        /// 记录时间范围，结束时间
        /// </summary>
        public DateTime EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }
    }
}
