using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace iPantry.Core.ViewModel
{
    public class MainMenuViewModel : MvxViewModel
    {
        /// Provides command-based navigation to a Bill views through
        /// the use of the iPantryViewModel.  In this example, we supply
        /// the view model with a default bill sub-total of 40, which
        /// is picked up by the overriden Init method.
        public ICommand NavigateCreateBill
        {
            get
            {
                // Navigation Note:
                // Must add following value to Assembly.cs for any Windows projects
                // [assembly: InternalsVisibleTo("Cirrious.MvvmCross")]
                return new MvxCommand(() =>
                    ShowViewModel<iPantryViewModel>());
            }
        }
    }
}
