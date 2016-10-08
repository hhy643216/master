using System;
using System.Collections.Generic;
using Cirrious.CrossCore;

namespace AndroidLearningDemo
{
	public class RecordViewModel : BaseViewModel
	{
		private IRecordService _recordService;
		public RecordViewModel (IRecordService recordService)
		{
			_recordService = recordService;
		}

		public void Init (int recordId) {
			_recordId = recordId;

			_recordDetailViewModelList = new List<RecordDetailViewModel> ();

			var viewModelCount = RecordCount < 3 ? RecordCount : 3;
			if (_recordId == 1)
			{
				for (int i = 0; i < viewModelCount; i++)
				{
					RecordDetailViewModel recordDetailViewModel = Mvx.IocConstruct<RecordDetailViewModel>();
					RefreshRecordDetail(recordDetailViewModel, _recordId + i);
					_recordDetailViewModelList.Add(recordDetailViewModel);
				}
			}
			else if (_recordId == RecordCount)
			{
				for (int i = 0; i < viewModelCount; i++)
				{
					RecordDetailViewModel recordDetailViewModel = Mvx.IocConstruct<RecordDetailViewModel>();
					var startModel = viewModelCount == 2 ? _recordId - 1 : _recordId - 2;
					RefreshRecordDetail(recordDetailViewModel, startModel + i);
					_recordDetailViewModelList.Add(recordDetailViewModel);
				}
			}
			else {
				for (int i = 0; i < viewModelCount; i++)
				{
					RecordDetailViewModel recordDetailViewModel = Mvx.IocConstruct<RecordDetailViewModel>();
					RefreshRecordDetail(recordDetailViewModel, _recordId - 1 + i);
					_recordDetailViewModelList.Add(recordDetailViewModel);
				}
			}


		}

		#region View Property

		private List<RecordDetailViewModel> _recordDetailViewModelList;

		public List<RecordDetailViewModel> RecordDetailViewModelList { 
			get { return _recordDetailViewModelList; }
			set { 
				_recordDetailViewModelList = value;
			}
		}

		public List<int> RecordIdList {
			get {
				return GetRecordIdList ();
			}
		}

		private int _recordId;

		public int RecordId {
			get { return _recordId; }
			set {
				if (_recordId != value) {
					_recordId = value;
				}
			}
		}
		#endregion

		public int RecordCount {
			get { 
				return _recordService.FindAllRecords ().Count;
			}
		}

		private List<int> GetRecordIdList ()
		{
			List<RecordDto> allRecord = _recordService.FindAllRecords ();

			List<int> recordIdList = null;
			if (allRecord != null && allRecord.Count != 0) {
				recordIdList = new List<int> ();
				foreach (RecordDto record in allRecord) {
					recordIdList.Add (record.RecordId);
				}
			}
			return recordIdList;
		}

		public void RefreshRecordDetail(RecordDetailViewModel viewModel, int index)
		{
			var recordInfo = _recordService.FindRecordById (index);
			viewModel.RecordId = recordInfo.Id;
		}
	}
}

