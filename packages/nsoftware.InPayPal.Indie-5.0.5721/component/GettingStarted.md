## Getting Started ##

Follow the tutorial for the appropriate platform:

* [Xamarin.iOS](http://www.nsoftware.com/kb/articles/xamarin.rst#ios "Xamarin.iOS")
* [Xamarin.Android](http://www.nsoftware.com/kb/articles/xamarin.rst#android "Xamarin.Android")

All components included in the toolkit are in the namespace `nsoftware.InPayPal`.

Please see the demos included with the toolkit for examples. 

## Licensing ##

####Trial Versions#####

No special file or value is required for trial licensing. Trial licenses only require the use of the component's overloaded constructor that takes a Context object. At runtime the component will display a dialog informing the user a trial license is being used. If a Context object is not passed to the constructor the component will throw a licensing exception at runtime.

#####Android#####

For example, if your class extends the Activity class you may simply pass the "this" object to the constructor. For instance:

    public class MyClass extends Activity {
    ...
    //Within a method later in the class
    component myInstance = new component(this);

#####iOS#####

For example, if your class inherits from UIViewController you may simply pass the "this" object to the constructor. For instance:

    public partial class myViewController : UIViewController
    {
        component myInstance;

        public myViewController (IntPtr handle) : base (handle)
        {
            myInstance = new component(this);
        }

####Standard (Royalty-Free) Licensing####

The components are licensed through a .lic file that must be included in the project.

After purchasing a license visit [http://www.nsoftware.com/lic/?prod=BLN5X](http://www.nsoftware.com/lic/?prod=BLN5X) to obtain your .lic file.

To include your license in your project follow these steps:

1. Add "nsoftware.InPayPal.lic" as an existing item to your project by right-clicking the project from Xamarin Studio and selecting Add -> Add Files.
2. In the properties window for "nsoftware.InPayPal.lic" set the Build Action to Embedded Resource.

Once the file is included, you will need to rebuild your project and deploy as normal. 

## Documentation ##

* Developer Center: [www.nsoftware.com/kb/](http://www.nsoftware.com/kb/ "/n software Online Knowledge Base")
* PayPal Integrator Online Help: [http://www.nsoftware.com/kb/help/BLN5-X/](http://www.nsoftware.com/kb/help/BLN5-X/ "PayPal Integrator Online Help")

## Contact ##

* Email Support: [support@nsoftware.com](http://www.nsoftware.com/support/submit.aspx)
* Feature Requests: [www.nsoftware.com/forms/request/](http://www.nsoftware.com/forms/request/)

## Legal ##

* Terms &Conditions: [www.nsoftware.com/company/legal/terms.aspx](http://www.nsoftware.com/company/legal/terms.aspx)