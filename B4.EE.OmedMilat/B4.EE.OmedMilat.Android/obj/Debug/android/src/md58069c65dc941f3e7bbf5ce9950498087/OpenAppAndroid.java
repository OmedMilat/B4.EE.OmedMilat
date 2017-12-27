package md58069c65dc941f3e7bbf5ce9950498087;


public class OpenAppAndroid
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("B4.EE.OmedMilat.Droid.OpenAppAndroid, B4.EE.OmedMilat.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", OpenAppAndroid.class, __md_methods);
	}


	public OpenAppAndroid () throws java.lang.Throwable
	{
		super ();
		if (getClass () == OpenAppAndroid.class)
			mono.android.TypeManager.Activate ("B4.EE.OmedMilat.Droid.OpenAppAndroid, B4.EE.OmedMilat.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	private java.util.ArrayList refList;
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
