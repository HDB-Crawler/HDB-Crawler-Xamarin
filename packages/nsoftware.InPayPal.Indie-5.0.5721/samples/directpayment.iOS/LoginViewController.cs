using System;
using Foundation;
using UIKit;
using System.CodeDom.Compiler;

namespace nsoftware.DirectpaymentDemo
{
	partial class LoginViewController : UIViewController
	{
		DirectpaymentViewController sendingController;

		public LoginViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Perform any additional setup after loading the view, typically from a nib.
			var g = new UITapGestureRecognizer(() => View.EndEditing(true));
			g.CancelsTouchesInView = false; //for iOS5
			View.AddGestureRecognizer(g);

			txtUser.Text = "xtest1_1199718490_biz_api1.hotmail.com";
			txtPassword.Text = "1199718508";
			txtSignature.Text = "ArZVhsgMt2Xnh-0gEb7CLza-WEc8Anplrd01chp0nKBXOTWQFcUxhPZX";
		}

		public void SetSendingController(DirectpaymentViewController newController){
			sendingController = newController;
		}

		partial void btnDone_TouchUpInside (UIButton sender)
		{
			sendingController.GetDirectpayment().URL = "https://api-3t.sandbox.paypal.com/nvp"; //Test server URL
			sendingController.GetDirectpayment().User = txtUser.Text;
			sendingController.GetDirectpayment().Password = txtPassword.Text;
			sendingController.GetDirectpayment().Signature = txtSignature.Text;
			DismissViewController(true, null);
		}
	}
}
