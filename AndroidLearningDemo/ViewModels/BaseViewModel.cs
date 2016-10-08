using System;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.CrossCore;

namespace AndroidLearningDemo
{
	public class BaseViewModel : MvxViewModel
	{
		private IErrorHandler _errorHandler;

		public BaseViewModel ()
		{
			_errorHandler = Mvx.Resolve<IErrorHandler> ();
		}

		protected bool TryWriteDB (Action action) {
			try {
				action ();
				return true;
			} catch {
				_errorHandler.HandleGeneralError ("保存に失敗しました。");
				return false;
			}
		}

		protected ReadResult<T> TryReadDB<T> (Func<T> func)
		{
			ReadResult<T> result = new ReadResult<T> ();
			try {
				result.Value = func ();
				result.Success = true;
			} catch {
				_errorHandler.HandleGeneralError ("データの取得に失敗しました。");
				result.Success = false;
			}
			return result;
		}

		protected class ReadResult<T>
		{
			public bool Success { get; set; }

			public T Value { get; set; }
		}
	}
}

