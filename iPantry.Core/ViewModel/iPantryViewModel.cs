using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using iPantry.Core.Services;
using System.Windows.Input;

namespace iPantry.Core.ViewModel
{
    /// All view models should inherit from MvxViewModel in MVVMCross
    public class iPantryViewModel : MvxViewModel
    {
        /// Used to implement button commanding for navigation.
        public ICommand NavBack
        {
            get
            {
                return new MvxCommand(() => Close(this));
            }
        }
    }
}
