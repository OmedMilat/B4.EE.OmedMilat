package md54fbadf704a96a26cb70379ca5ed625bd;


public class SystemSetting
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("B4.EE.OmedMilat.Droid.Services.SystemSetting, B4.EE.OmedMilat.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", SystemSetting.class, __md_methods);
	}


	public SystemSetting () throws java.lang.Throwable
	{
		super ();
		if (getClass () == SystemSetting.class)
			mono.android.TypeManager.Activate ("B4.EE.OmedMilat.Droid.Services.SystemSetting, B4.EE.OmedMilat.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
