using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using iPantry.Core.Services;

namespace iPantry.Core
{
    /// Main App class inherits from MvxApplication
    /// - Registers the interfaces and implementations the app uses.
    /// - Registers which ViewModel the App will show when it starts.
    /// - Controls how ViewModels are locate, most solutions will use default implementation supplied by MvxApplication.
    public class App : MvxApplication
    {
        /// Setup IoC registrations.
        public App()
        {
            // Whenever Mvx.Resolve is used, a new instance of Calculation is provided.
            Mvx.RegisterType<ICrearProducto, CrearProducto>();
            var calcExample = Mvx.Resolve<ICrearProducto>();

            // Tells the MvvmCross framework that whenever any code requests an IMvxAppStart reference,
            // the framework should return that same appStart instance.
            var appStart = new CustomAppStart();
            Mvx.RegisterSingleton<IMvxAppStart>(appStart);

            // Another option is to utilize a default App Start object with 
            // var appStart = new MvxAppStart<TipViewModel>();
        }
    }
}
