package md540915161cd0e2fffa218edb8e3fbb6fe;


public class ItemListHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Skeleton.Droid.ItemListHolder, Skeleton.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ItemListHolder.class, __md_methods);
	}


	public ItemListHolder (android.view.View p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == ItemListHolder.class)
			mono.android.TypeManager.Activate ("Skeleton.Droid.ItemListHolder, Skeleton.Droid, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "Android.Views.View, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
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
