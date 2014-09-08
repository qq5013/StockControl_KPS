using System;
namespace KPS.Model
{
	/// <summary>
	/// ��������:ʵ����(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public partial class ProcessLoggingInfo
	{
        public ProcessLoggingInfo()
		{}
		#region Model
		private int _processid;
		private DateTime? _processdate;
		private string _processcustomerunit;
		private string _processlinkman;
		private string _processtel;
		private string _processproductname;
		private string _processstandard;
		private DateTime? _processpurchasingdate;
		private string _processcontentinquired;
		private string _processhandlingsuggestion;
		private string _processserviceuser;
        private int _DataType=0;
		/// <summary>
		/// 
		/// </summary>
		public int ProcessID
		{
			set{ _processid=value;}
			get{return _processid;}
		}
		/// <summary>
		/// ʱ��
		/// </summary>
		public DateTime? ProcessDate
		{
			set{ _processdate=value;}
			get{return _processdate;}
		}
		/// <summary>
		/// �ͻ���λ
		/// </summary>
		public string ProcessCustomerUnit
		{
			set{ _processcustomerunit=value;}
			get{return _processcustomerunit;}
		}
		/// <summary>
		/// ��ϵ��
		/// </summary>
		public string Processlinkman
		{
			set{ _processlinkman=value;}
			get{return _processlinkman;}
		}
		/// <summary>
		/// �绰
		/// </summary>
		public string Processtel
		{
			set{ _processtel=value;}
			get{return _processtel;}
		}
		/// <summary>
		/// ��Ʒ����
		/// </summary>
		public string ProcessProductName
		{
			set{ _processproductname=value;}
			get{return _processproductname;}
		}
		/// <summary>
		/// ����ͺ�
		/// </summary>
		public string ProcessStandard
		{
			set{ _processstandard=value;}
			get{return _processstandard;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public DateTime? ProcessPurchasingDate
		{
			set{ _processpurchasingdate=value;}
			get{return _processpurchasingdate;}
		}
		/// <summary>
		/// ��ѯ����
		/// </summary>
		public string ProcessContentInquired
		{
			set{ _processcontentinquired=value;}
			get{return _processcontentinquired;}
		}
		/// <summary>
		/// �������
		/// </summary>
		public string ProcessHandlingSuggestion
		{
			set{ _processhandlingsuggestion=value;}
			get{return _processhandlingsuggestion;}
		}
		/// <summary>
		/// ������Ա
		/// </summary>
		public string ProcessServiceUser
		{
			set{ _processserviceuser=value;}
			get{return _processserviceuser;}
		}

        /// <summary>
        /// ��������
        /// </summary>
        public int DataType
        {
            get { return _DataType; }
            set { _DataType = value; }
        }
		#endregion Model

	}
}

