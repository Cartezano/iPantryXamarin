using Android.App;
using MvvmCross.Droid.Views;

namespace iPantry.UI.Droid
{
    [Activity(Label = "My App", MainLauncher = true, NoHistory = true, Icon = "@drawable/icon")]
    public class SplashScreenActivity : MvxSplashScreenActivity
    {
        public SplashScreenActivity() : base(Resource.Layout.View_SplashScreen)
        {

        }
    }
}