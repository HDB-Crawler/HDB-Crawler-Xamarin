// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using System;
using Foundation;
using UIKit;
using System.CodeDom.Compiler;

namespace nsoftware.DirectpaymentDemo
{
	[Register ("DirectpaymentViewController")]
	partial class DirectpaymentViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton btnAuthorize { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtAddress { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtCardNumber { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtCity { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtCVV { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtExpMonth { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtExpYear { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtFirst { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtIPAddress { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtLast { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtState { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtTxnAmount { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtTxnDescription { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField txtZip { get; set; }

		[Action ("btnAuthorize_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void btnAuthorize_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (btnAuthorize != null) {
				btnAuthorize.Dispose ();
				btnAuthorize = null;
			}
			if (txtAddress != null) {
				txtAddress.Dispose ();
				txtAddress = null;
			}
			if (txtCardNumber != null) {
				txtCardNumber.Dispose ();
				txtCardNumber = null;
			}
			if (txtCity != null) {
				txtCity.Dispose ();
				txtCity = null;
			}
			if (txtCVV != null) {
				txtCVV.Dispose ();
				txtCVV = null;
			}
			if (txtExpMonth != null) {
				txtExpMonth.Dispose ();
				txtExpMonth = null;
			}
			if (txtExpYear != null) {
				txtExpYear.Dispose ();
				txtExpYear = null;
			}
			if (txtFirst != null) {
				txtFirst.Dispose ();
				txtFirst = null;
			}
			if (txtIPAddress != null) {
				txtIPAddress.Dispose ();
				txtIPAddress = null;
			}
			if (txtLast != null) {
				txtLast.Dispose ();
				txtLast = null;
			}
			if (txtState != null) {
				txtState.Dispose ();
				txtState = null;
			}
			if (txtTxnAmount != null) {
				txtTxnAmount.Dispose ();
				txtTxnAmount = null;
			}
			if (txtTxnDescription != null) {
				txtTxnDescription.Dispose ();
				txtTxnDescription = null;
			}
			if (txtZip != null) {
				txtZip.Dispose ();
				txtZip = null;
			}
		}
	}
}
