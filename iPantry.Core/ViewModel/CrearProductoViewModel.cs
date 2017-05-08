using MvvmCross.Core.ViewModels;
using iPantry.Core.Models;
using iPantry.Core.Services;
using System.Windows.Input;
using MvvmCross.Platform;

namespace iPantry.Core.ViewModel
{

    //test random2
    /// All view models should inherit from MvxViewModel in MVVMCross
    public class CrearProductoViewModel : MvxViewModel
    {
        //se podra borrar porq no hace nada?
        readonly ICrearProducto _crearproducto;

        Producto _producto;
        /*
        string _nombreProducto;
        string _marcaProducto;
        string _fVencimiento;*/
        //double _cantidadProducto;

        public string NombreProducto
        {
            get { return _producto.NombreProducto; }
            set
            {
                _producto.NombreProducto = value;
                RaisePropertyChanged(() => NombreProducto);
            }
        }

        public string MarcaProducto
        {
            get { return _producto.MarcaProducto; }
            set
            {
                _producto.MarcaProducto = value;
                RaisePropertyChanged(() => MarcaProducto);
            }
        }

        public string FechaProducto
        {
            get { return _producto.FechaProducto; }
            set
            {
                _producto.FechaProducto = value;
                RaisePropertyChanged(() => FechaProducto);
            }
        }

        public double CantidadProducto
        {
            get { return _producto.CantidadProducto; }
            set
            {
                _producto.CantidadProducto = value;
                RaisePropertyChanged(() => CantidadProducto);
            }
        }

        //codigo basura, puede eliminarse ya que CrearProducto no hacen nada?
        public CrearProductoViewModel(ICrearProducto crearproducto)
        {
            _crearproducto = crearproducto;
        }

        /// Used to implement button commanding for navigation.
        public ICommand NavBack
        {
            get
            {
                return new MvxCommand(() => Close(this));
            }
        }

        public ICommand GuardarProducto
        {
            get
            {
                return new MvxCommand(() =>
                {
                    if (_producto.EsValido())
                    {
                        Mvx.Resolve<Repositorio>().CrearProducto(_producto).Wait();
                        Close(this);
                    }
                });
            }
        }

        //nose para que es esto, pero esta
        public void Init (Producto producto = null)
        {
            _producto = producto == null ? new Producto() : producto;
            RaiseAllPropertiesChanged();
        }
    }
}
