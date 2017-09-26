using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaCompraVenta
{
    public class Venta
    {
        protected Articulo _articuloVendido;
        protected int _cantidad;

        public Venta(Articulo articuloVendido, int cantidad)
        {
            this._articuloVendido = articuloVendido;
            this._cantidad = cantidad;
        }

        public float RetornarGanancia()
        {
            return this._articuloVendido.PrecioVenta * this._cantidad;
        }

    }
}
