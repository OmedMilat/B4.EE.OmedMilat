package md5fcf14e363261b60caefed2b12444aacb;


public class HttpSourceFactory
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.android.exoplayer2.upstream.DataSource.Factory
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_createDataSource:()Lcom/google/android/exoplayer2/upstream/DataSource;:GetCreateDataSourceHandler:Com.Google.Android.Exoplayer2.Upstream.IDataSourceFactoryInvoker, ExoPlayer\n" +
			"";
		mono.android.Runtime.register ("Plugin.MediaManager.ExoPlayer.HttpSourceFactory, Plugin.MediaManager.ExoPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", HttpSourceFactory.class, __md_methods);
	}


	public HttpSourceFactory () throws java.lang.Throwable
	{
		super ();
		if (getClass () == HttpSourceFactory.class)
			mono.android.TypeManager.Activate ("Plugin.MediaManager.ExoPlayer.HttpSourceFactory, Plugin.MediaManager.ExoPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public com.google.android.exoplayer2.upstream.DataSource createDataSource ()
	{
		return n_createDataSource ();
	}

	private native com.google.android.exoplayer2.upstream.DataSource n_createDataSource ();

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
