using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iPantry.Core.Models;
using SQLite;

//instalar sql-net-pcl nugget para usar SQLite supuestamente
namespace iPantry.Core
{
    public class Repositorio
    {
        private readonly SQLiteAsyncConnection conn;
        //mensaje del estado, cambiar si necesario
        public string StatusMessage { get; set; }
        //dbpath cambiar si necesario
        public Repositorio(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<Producto>().Wait();
        }

        public async Task CrearProducto(Producto producto)
        {
            try
            {
                //double para el cantidadproducto de producto.cs
                //double CantidadProducto = (producto.CantidadProducto);
                //cuatro excepciones distintas? o solo una que diga rellenar datos?
                //if (string.IsNullOrWhiteSpace(producto.NombreProducto) |
                //    string.IsNullOrWhiteSpace(producto.MarcaProducto) |
                //    string.IsNullOrWhiteSpace(producto.FechaProducto) |
                //    CantidadProducto == 0)
                //{
                //    throw new Exception("Falta completar los datos pedidos");
                //}
                /* if (string.IsNullOrWhiteSpace(producto.NombreProducto))
                 *      throw new Exception ("Ingrese nombre del producto");
                 * if (string.IsNullOrWhiteSpace(producto.MarcaProducto))
                 *      throw new Exception ("Ingrese la marca del producto");
                 * if (string.IsNullOrWhiteSpace(producto.FechaProducto))
                 *      throw new Exception ("Ingrese la fecha de caducidad del producto");
                 */
                //insert a la database ver bien que pasa V esto
                System.Diagnostics.Debug.WriteLine("Producto = "+producto.idProducto);
                System.Diagnostics.Debug.WriteLine("Nombre = " + producto.NombreProducto);
                System.Diagnostics.Debug.WriteLine("Marca = " + producto.MarcaProducto);
                System.Diagnostics.Debug.WriteLine("Fecha = " + producto.FechaProducto);
                System.Diagnostics.Debug.WriteLine("Cantidad = " + producto.CantidadProducto);
                var result = await conn.InsertAsync(producto).ConfigureAwait(continueOnCapturedContext: false);
                StatusMessage = $"Finalizado con resultado = {result} ({ResultCode(result)})";
                System.Diagnostics.Debug.WriteLine(StatusMessage);
            }
            catch (Exception ex)
            {
                StatusMessage = $"No se pudo crear porque {ex.Message}";
                System.Diagnostics.Debug.WriteLine(StatusMessage);
            }
        }
        //supuestamente al usar el core.models de iPantry deberia usar Producto.cs y preguntar por la tabla Productos ahi
        public Task<List<Producto>> ObtenerProductos()
        {
            return conn.Table<Producto>().ToListAsync();
        }

        private string ResultCode(int Codigo)
        {
            int codigo = Codigo;
            String mensaje = null;

            switch (codigo)
            {
                case 0:
                    mensaje = "SQLITE_OK - Successful result";
                    break;
                case 1:
                    mensaje = "SQLITE_ERROR - SQL error or missing database";
                    break;
                case 2:
                    mensaje = "SQLITE_INTERNAL - Internal logic error in SQLite";
                    break;
                case 3:
                    mensaje = "SQLITE_PERM - Access permission denied";
                    break;
                case 4:
                    mensaje = "SQLITE_ABORT - Callback routine requested an abort";
                    break;
                case 5:
                    mensaje = "SQLITE_BUSY - The database file is locked";
                    break;
                case 6:
                    mensaje = "";
                    break;
                case 7:
                    mensaje = "";
                    break;
                case 8:
                    mensaje = "";
                    break;
                case 9:
                    mensaje = "";
                    break;
            }

            return mensaje;
        }
    }
}