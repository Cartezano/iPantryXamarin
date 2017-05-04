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
        readonly ICrearProducto _crearproducto;
        string _nombreProducto;
        string _marcaProducto;
        string _fVencimiento;
        double _cantidadProducto;


        /// Used to implement button commanding for navigation.
        public ICommand NavBack
        {
            get
            {
                return new MvxCommand(() => Close(this));
            }
        }

        public string NombreProducto
        {
            get
            {
                return _nombreProducto;
            }

            set
            {
                _nombreProducto = value;
                RaisePropertyChanged(() => NombreProducto);
            }
        }

        public string MarcaProducto
        {
            get
            {
                return _marcaProducto;
            }

            set
            {
                _marcaProducto = value;
                RaisePropertyChanged(() => MarcaProducto);
            }
        }

        public string FVencimiento
        {
            get
            {
                return _fVencimiento;
            }

            set
            {
                _fVencimiento = value;
                RaisePropertyChanged(() => FVencimiento);
            }
        }

        public double CantidadProducto
        {
            get
            {
                return _cantidadProducto;
            }

            set
            {
                _cantidadProducto = value;
                RaisePropertyChanged(() => CantidadProducto);
            }
        }

        public iPantryViewModel(ICrearProducto crearproducto)
        {
            _crearproducto = crearproducto;
        }
    }
}
