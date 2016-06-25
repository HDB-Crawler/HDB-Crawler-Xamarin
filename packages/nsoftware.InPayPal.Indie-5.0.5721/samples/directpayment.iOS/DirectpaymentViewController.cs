﻿using System;
using System.Collections;
using Foundation;
using UIKit;
using System.CodeDom.Compiler;
using System.IO;
using nsoftware.InPayPal;

namespace nsoftware.DirectpaymentDemo
{
	partial class DirectpaymentViewController : UIViewController
	{

		Directpayment directpayment;

		public DirectpaymentViewController (IntPtr handle) : base (handle)
		{
			directpayment = new Directpayment (this);
			directpayment.OnSSLServerAuthentication += (sender, e) => {
				e.Accept = true; //accept all servers by default, please update to increase security
			};
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();

			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Perform any additional setup after loading the view, typically from a nib.
			var g = new UITapGestureRecognizer (() => View.EndEditing (true));
			g.CancelsTouchesInView = false; //for iOS5
			View.AddGestureRecognizer (g);

			txtFirst.Text = "John";
			txtLast.Text = "Smith";
			txtAddress.Text = "123 Nowhere Ln.";
			txtCity.Text = "Beverly Hills";
			txtState.Text = "CA";
			txtZip.Text = "90210-0000";
			txtIPAddress.Text = "10.244.43.106";

			txtCardNumber.Text = "4832419131427146";
			txtExpMonth.Text = "01";
			txtExpYear.Text = "2017";
			txtCVV.Text = "123";

			txtTxnAmount.Text = "12.88";
			txtTxnDescription.Text = "Test Transaction";
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}

		#endregion

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue (segue, sender);
			if (segue.Identifier == "loginSegue") {
				LoginViewController destController = (LoginViewController)segue.DestinationViewController;
				destController.SetSendingController (this);
			}
		}

		public Directpayment GetDirectpayment ()
		{
			return directpayment;
		}

		partial void btnAuthorize_TouchUpInside (UIButton sender)
		{
			DirectPaymentPayer dpp = new DirectPaymentPayer ();
			dpp.FirstName = txtFirst.Text;
			dpp.LastName = txtLast.Text;
			dpp.Street1 = txtAddress.Text;
			dpp.City = txtCity.Text;
			dpp.Zip = txtZip.Text;
			dpp.IPAddress = txtIPAddress.Text;

			directpayment.Payer = dpp;

			Card card = new Card ();
			card.Number = txtCardNumber.Text;
			card.ExpMonth = Convert.ToInt32 (txtExpMonth.Text);
			card.ExpYear = Convert.ToInt32 (txtExpYear.Text);
			card.CVV = txtCVV.Text;

			directpayment.Card = card;

			directpayment.OrderTotal = txtTxnAmount.Text;
			directpayment.OrderDescription = txtTxnDescription.Text;

			try {
				directpayment.Authorize ();

				string response = "";
				response += "Ack   : " + directpayment.Ack + "\r\n";
				response += "Amt   : " + directpayment.Response.Amount + "\r\n";
				response += "AVS   : " + directpayment.Response.AVS + "\r\n";
				response += "CVV   : " + directpayment.Response.CVV + "\r\n";
				response += "TxnId : " + directpayment.Response.TransactionId + "\r\n";

				new UIAlertView ("Response:", response, null, "OK", null).Show ();
			} catch (Exception ex) {
				new UIAlertView ("Error!", ex.Message, null, "OK", null).Show ();
			}
		}

	}
}
