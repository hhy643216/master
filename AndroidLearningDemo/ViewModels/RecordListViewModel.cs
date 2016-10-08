using System;
using System.Collections.Generic;
using Cirrious.MvvmCross.ViewModels;

namespace AndroidLearningDemo
{
	public class RecordListViewModel : BaseViewModel
	{
		private IRecordService _recordService;

		public RecordListViewModel (IRecordService recordService)
		{
			_recordService = recordService;
		}

		#region View Property

		private List<RecordDto> _recordList;

		public List<RecordDto> RecordList {
			get {
				var result = TryReadDB<List<RecordDto>> (() => {
					return _recordService.FindAllRecords ();
				});

				if (result.Success) {
					return result.Value;
				}
				return null;
			}
			set { 
				if (_recordList != value) {
					_recordList = value;
					RaisePropertyChanged (() => RecordList);
				}
			}
		}
		#endregion

		#region Command

		private MvxCommand<RecordDto> _itemSelectedCommand;

		public System.Windows.Input.ICommand ItemSelectedCommand {
			get { 
				_itemSelectedCommand = _itemSelectedCommand ?? new MvxCommand<RecordDto> (item => {
					ShowViewModel<RecordViewModel> (new {recordId = item.RecordId});
				});
				return _itemSelectedCommand;
			}
		}

		#endregion

		#region

		public void SaveRecord (string recordText)
		{
			TryWriteDB (() => {
				_recordService.InsertRecord (recordText);
			});
		}
		#endregion
	}
}