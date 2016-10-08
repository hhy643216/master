
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;
using Cirrious.MvvmCross.Binding.Droid.BindingContext;
using Android.Webkit;

namespace AndroidLearningDemo.Droid.Views
{
	public class BaiduFragmentView : MvxFragment
	{
		private View _view;
		private WebView _webView;
		private WebViewClient _webViewClient;

		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView (inflater, container, savedInstanceState);

			var parentView = Activity as TabView;
			if (parentView != null) {
				parentView.Title = "パイトゥ";
			}

			_view = this.BindingInflate (Resource.Layout.Baidu, null);

			InitWebView ();

			return _view;
		}

		private void InitWebView ()
		{
			_webView = _view.FindViewById<WebView> (Resource.Id.BaiduView);
			_webView.Settings.JavaScriptEnabled = true;

			_webViewClient = new BaseWebViewClient ();

			_webView.SetWebViewClient (_webViewClient);

			_webView.LoadUrl ("http://www.baidu.com");
		}
	}
}
	