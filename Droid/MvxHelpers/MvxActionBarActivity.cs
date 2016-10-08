using System;
using Cirrious.MvvmCross.Droid.Views;
using Cirrious.MvvmCross.Binding.BindingContext;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Cirrious.MvvmCross.ViewModels;
using Android.Content;

namespace AndroidLearningDemo.Droid
{
	public abstract class MvxActionBarActivity : MvxActionBarEventSourceActivity, IMvxAndroidView
	{
		protected MvxActionBarActivity()
		{
			BindingContext = new MvxAndroidBindingContext(this, this);
			this.AddEventListeners();
		}

		public object DataContext
		{
			get { return BindingContext.DataContext; }
			set { BindingContext.DataContext = value; }
		}

		public IMvxViewModel ViewModel
		{
			get { return DataContext as IMvxViewModel; }
			set
			{
				DataContext = value;
				OnViewModelSet();
			}
		}

		public IMvxBindingContext BindingContext { get; set; }

		public override void SetContentView(int layoutResId)
		{
			var view = this.BindingInflate(layoutResId, null);
			SetContentView(view);
		}

		public void MvxInternalStartActivityForResult(Intent intent, int requestCode)
		{
			base.StartActivityForResult(intent, requestCode);
		}

		protected virtual void OnViewModelSet()
		{
		}
	}
}

