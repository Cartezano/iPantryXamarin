using Android.App;
using MvvmCross.Droid.Views;

namespace iPantry.UI.Droid.Views
{
    [Activity(Label = "CrearProductoView", NoHistory = true)]
    public class CrearProductoView : MvxActivity
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.vCrearProducto);
        }
    }
}