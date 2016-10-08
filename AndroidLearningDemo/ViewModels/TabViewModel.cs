using System;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.CrossCore;

namespace AndroidLearningDemo
{
	public class TabViewModel : MvxViewModel
	{
		public TabViewModel ()
		{
			BaiduFragmentContents = Mvx.IocConstruct<BaiduFragmentViewModel> ();
			RecordContents = Mvx.IocConstruct<RecordListViewModel> ();
			MapFragmentContent = Mvx.IocConstruct<MapFragmentViewModel> ();
		}

		public BaiduFragmentViewModel BaiduFragmentContents { get; set; }
		public RecordListViewModel RecordContents { get; set; }
		public MapFragmentViewModel MapFragmentContent { get; set; }
	}
}

