using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using iPantry.Core.ViewModel;

namespace iPantry.Core
{
    /// This class is used to customize how the application starts
    /// and which view is loaded on start.
    class CustomAppStart : MvxNavigatingObject, IMvxAppStart
    {
        /// Hint can take command-line startup parameters, and then pass them to the called view models.
        public void Start(object hint = null)
        {
            // ShowViewModel is a core navigation mechanism in MvvmCross.
            // for now, just start the regular MainMenuViewModel view.
            ShowViewModel<MainMenuViewModel>();
        }
    }
}
