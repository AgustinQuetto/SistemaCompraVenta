using System;
using System.Collections.Generic;

namespace SistemaCompraVenta
{
    public class Comercio
    {
        protected string _dueno;
        protected List<Articulo> _misArticulos;
        protected List<Venta> _misVentas;

        public Comercio(string dueno)
        {
            _dueno = dueno;
            _misArticulos = new List<Articulo>();
            _misVentas = new List<Venta>();

        }

        public static void MostrarArticulos(Comercio comercio)
        {
            foreach (Articulo articulo in comercio._misArticulos)
            {
                Console.WriteLine(articulo.NombreYCodigo);
            }
        }

        public static void MostrarGanancia(Comercio comercio)
        {
            double total = 0;

            foreach(Venta venta in comercio._misVentas)
            {
                total += venta.RetornarGanancia();
            }

            Console.WriteLine("Ganancia total de " + comercio._dueno + ": $" + total);
        }

        public void ComprarArticulo(Articulo articuloComprado)
        {
            bool found = false;
            foreach (Articulo articulo in this._misArticulos)
            {
                if(articulo == articuloComprado)
                {
                    articulo.Stock = articulo + articuloComprado;
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                this._misArticulos.Add(articuloComprado);
            }
        }

        public void VenderArticulo(Articulo articulo, int cantidad)
        {
            foreach (Articulo articuloFor in this._misArticulos)
            {
                if (articuloFor == articulo && articulo.HayStock(cantidad))
                {
                    articulo.Stock = articuloFor - cantidad;
                    Venta venta = new Venta(articuloFor, cantidad);
                    break;
                }
                /*else
                {
                    Console.WriteLine("No se encuentran coincidencias o no hay stock.");
                }*/
            }
                Console.WriteLine("No se encuentran coincidencias.");
        }
    }
}
