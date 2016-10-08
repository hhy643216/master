package md579cf2a4fa2d6296a0cdf2541733d93a8;


public class MvxFragmentHost
	extends md579cf2a4fa2d6296a0cdf2541733d93a8.MvxActionBarActivity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("AndroidLearningDemo.Droid.MvxFragmentHost, AndroidLearningDemo.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MvxFragmentHost.class, __md_methods);
	}


	public MvxFragmentHost () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MvxFragmentHost.class)
			mono.android.TypeManager.Activate ("AndroidLearningDemo.Droid.MvxFragmentHost, AndroidLearningDemo.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

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
