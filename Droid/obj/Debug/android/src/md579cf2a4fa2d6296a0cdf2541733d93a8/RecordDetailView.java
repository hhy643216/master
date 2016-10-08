package md579cf2a4fa2d6296a0cdf2541733d93a8;


public class RecordDetailView
	extends md5a8f025a8cad3d863cfc102eacf93dc45.MvxFragment
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreateView:(Landroid/view/LayoutInflater;Landroid/view/ViewGroup;Landroid/os/Bundle;)Landroid/view/View;:GetOnCreateView_Landroid_view_LayoutInflater_Landroid_view_ViewGroup_Landroid_os_Bundle_Handler\n" +
			"n_onResume:()V:GetOnResumeHandler\n" +
			"";
		mono.android.Runtime.register ("AndroidLearningDemo.Droid.RecordDetailView, AndroidLearningDemo.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", RecordDetailView.class, __md_methods);
	}


	public RecordDetailView () throws java.lang.Throwable
	{
		super ();
		if (getClass () == RecordDetailView.class)
			mono.android.TypeManager.Activate ("AndroidLearningDemo.Droid.RecordDetailView, AndroidLearningDemo.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public android.view.View onCreateView (android.view.LayoutInflater p0, android.view.ViewGroup p1, android.os.Bundle p2)
	{
		return n_onCreateView (p0, p1, p2);
	}

	private native android.view.View n_onCreateView (android.view.LayoutInflater p0, android.view.ViewGroup p1, android.os.Bundle p2);


	public void onResume ()
	{
		n_onResume ();
	}

	private native void n_onResume ();

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
