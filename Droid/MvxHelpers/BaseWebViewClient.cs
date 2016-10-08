using Android.Webkit;

namespace AndroidLearningDemo.Droid
{			
	public class BaseWebViewClient : WebViewClient
	{
		public override bool ShouldOverrideUrlLoading (WebView view, string url)
		{
			view.LoadUrl (url);
			return true;
		}
	}
}

