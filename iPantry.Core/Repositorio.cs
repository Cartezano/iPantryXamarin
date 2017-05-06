using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using iPantry.Core.Models;
using SQLite;


namespace iPantry.Core
{
    class Repositorio
    {
        private readonly SQLiteAsyncConnection conn;
        //mensaje del estado, cambiar si necesario
        public string StatusMessage { get; set; }
        //dbpath cambiar si necesario
        public Repositorio (string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<Producto>().Wait();
        }

        public async Task CrearProducto(Producto producto)
        {
            try
            {
                //tres excepciones distintas? o solo una que diga rellenar datos?
                if (string.IsNullOrWhiteSpace(producto.NombreProducto) || 
                    string.IsNullOrWhiteSpace(producto.MarcaProducto) ||
                    string.IsNullOrWhiteSpace(producto.FechaProducto)) {
                    throw new Exception("Falta completar los datos pedidos");
                }
                /* if (string.IsNullOrWhiteSpace(producto.NombreProducto))
                 *      throw new Exception ("Ingrese nombre del producto");
                 * if (string.IsNullOrWhiteSpace(producto.MarcaProducto))
                 *      throw new Exception ("Ingrese la marca del producto");
                 * if (string.IsNullOrWhiteSpace(producto.FechaProducto))
                 *      throw new Exception ("Ingrese la fecha de caducidad del producto");
                 */
                //insert a la database ver bien que pasa V esto
                var result = await conn.InsertAllAsync(producto).ConfigureAwait(continueOnCapturedContext: false);
                StatusMessage = $"{result} Agregados [Nombre del producto: {producto.NombreProducto}], [Marca del producto: {producto.MarcaProducto}] y Fecha del producto {producto.FechaProducto}]";
            }
            catch (Exception ex)
            {
                StatusMessage = $"No se pudo crear porque {ex.Message}";
            }
        }
        //supuestamente al usar el core.models de iPantry deberia usar Producto.cs y preguntar por la tabla Productos ahi
        public Task<List<Producto>> ObtenerProductos()
        {
            return conn.Table<Producto>().ToListAsync();
        }

    }
}
