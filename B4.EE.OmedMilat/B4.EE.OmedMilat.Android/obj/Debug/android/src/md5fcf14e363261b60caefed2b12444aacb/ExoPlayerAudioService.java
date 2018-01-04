package md5fcf14e363261b60caefed2b12444aacb;


public class ExoPlayerAudioService
	extends md5cb45d68da0a4a063a9a2b86b6adab38d.MediaServiceBase
	implements
		mono.android.IGCUserPeer,
		com.google.android.exoplayer2.ExoPlayer.EventListener,
		com.google.android.exoplayer2.trackselection.TrackSelector.EventListener,
		com.google.android.exoplayer2.source.ExtractorMediaSource.EventListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onStartCommand:(Landroid/content/Intent;II)I:GetOnStartCommand_Landroid_content_Intent_IIHandler\n" +
			"n_onLoadingChanged:(Z)V:GetOnLoadingChanged_ZHandler:Com.Google.Android.Exoplayer2.IExoPlayerEventListenerInvoker, ExoPlayer\n" +
			"n_onPlayerError:(Lcom/google/android/exoplayer2/ExoPlaybackException;)V:GetOnPlayerError_Lcom_google_android_exoplayer2_ExoPlaybackException_Handler:Com.Google.Android.Exoplayer2.IExoPlayerEventListenerInvoker, ExoPlayer\n" +
			"n_onPlayerStateChanged:(ZI)V:GetOnPlayerStateChanged_ZIHandler:Com.Google.Android.Exoplayer2.IExoPlayerEventListenerInvoker, ExoPlayer\n" +
			"n_onPositionDiscontinuity:()V:GetOnPositionDiscontinuityHandler:Com.Google.Android.Exoplayer2.IExoPlayerEventListenerInvoker, ExoPlayer\n" +
			"n_onTimelineChanged:(Lcom/google/android/exoplayer2/Timeline;Ljava/lang/Object;)V:GetOnTimelineChanged_Lcom_google_android_exoplayer2_Timeline_Ljava_lang_Object_Handler:Com.Google.Android.Exoplayer2.IExoPlayerEventListenerInvoker, ExoPlayer\n" +
			"n_onTrackSelectionsChanged:(Lcom/google/android/exoplayer2/trackselection/TrackSelections;)V:GetOnTrackSelectionsChanged_Lcom_google_android_exoplayer2_trackselection_TrackSelections_Handler:Com.Google.Android.Exoplayer2.Trackselection.TrackSelector/IEventListenerInvoker, ExoPlayer\n" +
			"n_onLoadError:(Ljava/io/IOException;)V:GetOnLoadError_Ljava_io_IOException_Handler:Com.Google.Android.Exoplayer2.Source.ExtractorMediaSource/IEventListenerInvoker, ExoPlayer\n" +
			"";
		mono.android.Runtime.register ("Plugin.MediaManager.ExoPlayer.ExoPlayerAudioService, Plugin.MediaManager.ExoPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ExoPlayerAudioService.class, __md_methods);
	}


	public ExoPlayerAudioService () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ExoPlayerAudioService.class)
			mono.android.TypeManager.Activate ("Plugin.MediaManager.ExoPlayer.ExoPlayerAudioService, Plugin.MediaManager.ExoPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public int onStartCommand (android.content.Intent p0, int p1, int p2)
	{
		return n_onStartCommand (p0, p1, p2);
	}

	private native int n_onStartCommand (android.content.Intent p0, int p1, int p2);


	public void onLoadingChanged (boolean p0)
	{
		n_onLoadingChanged (p0);
	}

	private native void n_onLoadingChanged (boolean p0);


	public void onPlayerError (com.google.android.exoplayer2.ExoPlaybackException p0)
	{
		n_onPlayerError (p0);
	}

	private native void n_onPlayerError (com.google.android.exoplayer2.ExoPlaybackException p0);


	public void onPlayerStateChanged (boolean p0, int p1)
	{
		n_onPlayerStateChanged (p0, p1);
	}

	private native void n_onPlayerStateChanged (boolean p0, int p1);


	public void onPositionDiscontinuity ()
	{
		n_onPositionDiscontinuity ();
	}

	private native void n_onPositionDiscontinuity ();


	public void onTimelineChanged (com.google.android.exoplayer2.Timeline p0, java.lang.Object p1)
	{
		n_onTimelineChanged (p0, p1);
	}

	private native void n_onTimelineChanged (com.google.android.exoplayer2.Timeline p0, java.lang.Object p1);


	public void onTrackSelectionsChanged (com.google.android.exoplayer2.trackselection.TrackSelections p0)
	{
		n_onTrackSelectionsChanged (p0);
	}

	private native void n_onTrackSelectionsChanged (com.google.android.exoplayer2.trackselection.TrackSelections p0);


	public void onLoadError (java.io.IOException p0)
	{
		n_onLoadError (p0);
	}

	private native void n_onLoadError (java.io.IOException p0);

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
