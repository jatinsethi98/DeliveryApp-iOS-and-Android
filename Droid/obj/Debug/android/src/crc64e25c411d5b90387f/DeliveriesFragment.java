package crc64e25c411d5b90387f;


public class DeliveriesFragment
	extends androidx.fragment.app.ListFragment
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("DeliveryApp.Droid.DeliveriesFragment, DeliveryApp.Droid", DeliveriesFragment.class, __md_methods);
	}


	public DeliveriesFragment ()
	{
		super ();
		if (getClass () == DeliveriesFragment.class)
			mono.android.TypeManager.Activate ("DeliveryApp.Droid.DeliveriesFragment, DeliveryApp.Droid", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
