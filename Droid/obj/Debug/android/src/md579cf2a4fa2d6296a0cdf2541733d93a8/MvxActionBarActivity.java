package md579cf2a4fa2d6296a0cdf2541733d93a8;


public abstract class MvxActionBarActivity
	extends md579cf2a4fa2d6296a0cdf2541733d93a8.MvxActionBarEventSourceActivity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_setContentView:(I)V:GetSetContentView_IHandler\n" +
			"";
		mono.android.Runtime.register ("AndroidLearningDemo.Droid.MvxActionBarActivity, AndroidLearningDemo.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", MvxActionBarActivity.class, __md_methods);
	}


	public MvxActionBarActivity () throws java.lang.Throwable
	{
		super ();
		if (getClass () == MvxActionBarActivity.class)
			mono.android.TypeManager.Activate ("AndroidLearningDemo.Droid.MvxActionBarActivity, AndroidLearningDemo.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void setContentView (int p0)
	{
		n_setContentView (p0);
	}

	private native void n_setContentView (int p0);

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
