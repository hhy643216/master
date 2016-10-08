package androidlearningdemo.droid.views;


public class TabView
	extends md579cf2a4fa2d6296a0cdf2541733d93a8.MvxFragmentHost
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onKeyDown:(ILandroid/view/KeyEvent;)Z:GetOnKeyDown_ILandroid_view_KeyEvent_Handler\n" +
			"";
		mono.android.Runtime.register ("AndroidLearningDemo.Droid.Views.TabView, AndroidLearningDemo.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", TabView.class, __md_methods);
	}


	public TabView () throws java.lang.Throwable
	{
		super ();
		if (getClass () == TabView.class)
			mono.android.TypeManager.Activate ("AndroidLearningDemo.Droid.Views.TabView, AndroidLearningDemo.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public boolean onKeyDown (int p0, android.view.KeyEvent p1)
	{
		return n_onKeyDown (p0, p1);
	}

	private native boolean n_onKeyDown (int p0, android.view.KeyEvent p1);

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
