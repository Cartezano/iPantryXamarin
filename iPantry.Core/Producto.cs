using SQLite;
using System;

//utilizando iPantryDB de Trello, cambiar si necesario

namespace iPantry.Core.Models  //cambiar por el core de la aplicacion
{
    [Table(nameof(Productos))]  //basado en iPantryDB
    public class Producto       //Cambiar si es necesario
    {
        //id del producto (idProducto)
        [PrimaryKey, AutoIncrement]
        public int idProducto { get; set; }

        //nombre del producto
        [NotNull, MaxLength(20)]
        public string NombreProducto { get; set; }

        //marca del producto
        [NotNull, MaxLength(20)]
        public string MarcaProducto { get; set; }

        //fecha de vencimiento, deberia estar en string?
        [NotNull, MaxLength(20)]
        public string FechaProducto { get; set; }

        public Producto()
        {
            NombreProducto = string.Empty;
            MarcaProducto = string.Empty;
            FechaProducto = string.Empty;
        }
        //validador que no existan vacios
        public bool EsValido()
        {
            return (!String.IsNullOrWhiteSpace(NombreProducto) &&
                    !String.IsNullOrWhiteSpace(MarcaProducto) &&
                    !String.IsNullOrWhiteSpace(FechaProducto));
        }
    }
}
