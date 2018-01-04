package md5fcf14e363261b60caefed2b12444aacb;


public class ExoPlayerVideoImplementation
	extends md5cb45d68da0a4a063a9a2b86b6adab38d.VideoPlayerImplementation
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Plugin.MediaManager.ExoPlayer.ExoPlayerVideoImplementation, Plugin.MediaManager.ExoPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ExoPlayerVideoImplementation.class, __md_methods);
	}


	public ExoPlayerVideoImplementation () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ExoPlayerVideoImplementation.class)
			mono.android.TypeManager.Activate ("Plugin.MediaManager.ExoPlayer.ExoPlayerVideoImplementation, Plugin.MediaManager.ExoPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
