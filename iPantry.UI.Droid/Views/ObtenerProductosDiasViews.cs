using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace iPantry.UI.Droid.Views
{
    [Activity(Label = "Listado de productos dias", NoHistory = true)]
    public class ObtenerProductosDiasView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.View_ObtenerProductos);
        }
    }
}