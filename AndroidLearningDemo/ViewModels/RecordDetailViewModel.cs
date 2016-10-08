using System;

namespace AndroidLearningDemo
{
	public class RecordDetailViewModel : BaseViewModel
	{
		private IRecordService _recordService;
		public RecordDetailViewModel (IRecordService recordService)
		{
			_recordService = recordService;
		}

		#region View Property

		private int _recordId;

		public int RecordId {
			get { return _recordId; }
			set {
				if (_recordId != value) {
					_recordId = value;
				}
			}
		}

		private string _recordDetail;

		public string RecordDetail {
			get {
				var recordInfo = _recordService.FindRecordById (_recordId);
				return recordInfo.RecordDetail;
			}
		}
		#endregion
	}
}

