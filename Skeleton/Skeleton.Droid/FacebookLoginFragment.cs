using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Support.V4.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Facebook.Login.Widget;
using Xamarin.Facebook;
using Xamarin.Facebook.Login;
using Java.Lang;

namespace Skeleton.Droid
{
    public class FacebookLoginFragment : Fragment, IFacebookCallback
    {
        ICallbackManager callbackManager;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            /*
            FacebookSdk.SdkInitialize(Context);
            callbackManager = CallbackManagerFactory.Create();
            LoginButton loginButton = View.FindViewById<LoginButton>(Resource.Id.login_button);
            loginButton.RegisterCallback(callbackManager, this);
            */
        }

        LoginButton loginButton;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            FacebookSdk.SdkInitialize(Context);
            View view = inflater.Inflate(Resource.Layout.FacebookLogin, container, false);
            // view.FindViewById<LoginButton>(Resource.Id.login_button);
            callbackManager = CallbackManagerFactory.Create();
            loginButton = view.FindViewById<LoginButton>(Resource.Id.login_button);
            loginButton.RegisterCallback(callbackManager, this);

            return view;
        }

        public void OnCancel()
        {
            // throw new NotImplementedException();
        }

        public void OnError(FacebookException p0)
        {
            // throw new NotImplementedException();
        }

        public void OnSuccess(Java.Lang.Object p0)
        {
            // throw new NotImplementedException();
        }
    }
}