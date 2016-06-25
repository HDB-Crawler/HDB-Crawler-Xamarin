using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using nsoftware.InPayPal;

namespace nsoftware.DirectpaymentDemo
{
	[Activity (Label = "DirectPayment Demo", MainLauncher = true)]
	public class MainActivity : Activity
	{
		Directpayment directpayment;
		static string apiUsername = "xtest1_1199718490_biz_api1.hotmail.com";
		static string apiPassword = "1199718508";
		static string apiSignature = "ArZVhsgMt2Xnh-0gEb7CLza-WEc8Anplrd01chp0nKBXOTWQFcUxhPZX";
		static string cardNumber = "4832419131427146";
		static string cardExpMonth = "01";
		static string cardExpYear = "2017";
		static string cardCVVData = "123";

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			directpayment = new Directpayment(this);
			directpayment.OnSSLServerAuthentication += (object sender, DirectpaymentSSLServerAuthenticationEventArgs e) => {
				e.Accept = true;
			};
			ShowMainView ();
		}

		protected void ShowMainView()
		{
			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			EditText txtFirstName = FindViewById<EditText> (Resource.Id.txtFirstName);
			EditText txtLastName = FindViewById<EditText> (Resource.Id.txtLastName);
			EditText txtAddress = FindViewById<EditText> (Resource.Id.txtAddress);
			EditText txtCity = FindViewById<EditText> (Resource.Id.txtCity);
			EditText txtState = FindViewById<EditText> (Resource.Id.txtState);
			EditText txtZip = FindViewById<EditText> (Resource.Id.txtZip);
			EditText txtIPAddress = FindViewById<EditText> (Resource.Id.txtIPAddress);
			EditText txtAmount = FindViewById<EditText> (Resource.Id.txtAmount);
			EditText txtDescription = FindViewById<EditText> (Resource.Id.txtDescription);
			Button btnConfigure = FindViewById<Button> (Resource.Id.btnConfigure);
			Button btnCardInfo = FindViewById<Button> (Resource.Id.btnCardInfo);
			Button btnAuthorize = FindViewById<Button> (Resource.Id.btnAuthorize);

			btnAuthorize.Click += (object sender, EventArgs e) => {
				try {
					directpayment.URL = "https://api-3t.sandbox.paypal.com/nvp"; // Test Server URL
					directpayment.User = apiUsername;
					directpayment.Password = apiPassword;
					directpayment.Signature = apiSignature;

					directpayment.OrderTotal = txtAmount.Text;
					directpayment.OrderDescription = txtDescription.Text;

					Card card = new Card ();
					card.CardType = CardTypes.ccVisa;
					card.Number = cardNumber;
					card.ExpMonth = Convert.ToInt32(cardExpMonth);
					card.ExpYear = Convert.ToInt32(cardExpYear);
					card.CVV = cardCVVData;
					directpayment.Card = card;

					DirectPaymentPayer payer = new DirectPaymentPayer ();
					payer.FirstName = txtFirstName.Text;
					payer.LastName = txtLastName.Text;
					payer.Street1 = txtAddress.Text;
					payer.City = txtCity.Text;
					payer.State = txtState.Text;
					payer.Zip = txtZip.Text;
					payer.IPAddress = txtIPAddress.Text;
					directpayment.Payer = payer;

					directpayment.Sale();

					ShowResultsView();

				} catch (InPayPalDirectpaymentException ex) {
					ShowMessage("Error", ex.Message);
				}
			};

			btnConfigure.Click += (object sender, EventArgs e) => {
				ShowAPIInfoView();
			};

			btnCardInfo.Click += (object sender, EventArgs e) => {
				ShowCardInfoView();
			};

		}

		protected void ShowResultsView() {
			// Set our view from the "result" layout reference
			SetContentView (Resource.Layout.Results);

			EditText txtResults = FindViewById<EditText> (Resource.Id.txtResults);
			Button btnBack = FindViewById<Button> (Resource.Id.btnBack);

			string results = "Ack  : " + directpayment.Ack + "\r\n";
			results += "Amt  : " + directpayment.Response.Amount + "\r\n";
			results += "AVS  : " + directpayment.Response.AVS + "\r\n";
			results += "CVV  : " + directpayment.Response.CVV + "\r\n";
			results += "TxnId: " + directpayment.Response.TransactionId + "\r\n";
			txtResults.Text = results;

			btnBack.Click += (object sender, EventArgs e) => {
				ShowMainView();
			};
		}

		protected void ShowAPIInfoView() 
		{
			// Set our view from the "apiinfo" layout resource
			SetContentView (Resource.Layout.Apiinfo);

			EditText txtAPIUsername = FindViewById<EditText> (Resource.Id.txtAPIUsername);
			EditText txtAPIPassword = FindViewById<EditText> (Resource.Id.txtAPIPassword);
			EditText txtAPISignature = FindViewById<EditText> (Resource.Id.txtAPISignature);
			Button btnDone = FindViewById<Button> (Resource.Id.btnDone);

			txtAPIUsername.Text = apiUsername;
			txtAPIPassword.Text = apiPassword;
			txtAPISignature.Text = apiSignature;

			btnDone.Click += (object sender, EventArgs e) => {
				apiUsername = txtAPIUsername.Text;
				apiPassword = txtAPIPassword.Text;
				apiSignature = txtAPISignature.Text;
				ShowMainView();
			};
		}

		protected void ShowCardInfoView() 
		{
			// Set our view from the "cardinfo" layout resource
			SetContentView (Resource.Layout.Cardinfo);

			EditText txtCardNumber = FindViewById<EditText> (Resource.Id.txtCardNumber);
			EditText txtExpMonth = FindViewById<EditText> (Resource.Id.txtExpMonth);
			EditText txtExpYear = FindViewById<EditText> (Resource.Id.txtExpYear);
			EditText txtCVVData = FindViewById<EditText> (Resource.Id.txtCVVData);
			Button btnDone = FindViewById<Button> (Resource.Id.btnDone);

			txtCardNumber.Text = cardNumber;
			txtExpMonth.Text = cardExpMonth;
			txtExpYear.Text = cardExpYear;
			txtCVVData.Text = cardCVVData;

			btnDone.Click += (object sender, EventArgs e) => {
				cardNumber = txtCardNumber.Text;
				cardExpMonth = txtExpMonth.Text;
				cardExpYear = txtExpYear.Text;
				cardCVVData = txtCVVData.Text;
				ShowMainView();
			};
		}

		protected void ShowMessage (String title, String message)
		{
			AlertDialog error = new AlertDialog.Builder(this).Create();
			error.SetTitle(title);
			error.SetIcon(Android.Resource.Drawable.IcDialogAlert);
			error.SetMessage(message);
			error.SetButton("OK", (s, ev) => {});
			error.Show();
		}
	}
}


