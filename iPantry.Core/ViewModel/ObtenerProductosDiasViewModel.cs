using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using iPantry.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace iPantry.Core.ViewModel
{
    public class ObtenerProductosDiasViewModel : MvxViewModel
    {
        public List<Producto> TodosLosProductos { get; set; }

        public ICommand NavBack
        {
            get
            {
                return new MvxCommand(() => Close(this));
            }
        }

        public void Init()
        {
            Task<List<Producto>> result = Mvx.Resolve<Repositorio>().ObtenerProductosDias();
            result.Wait();
            TodosLosProductos = result.Result;
        }




    }
}