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

            foreach (Venta venta in comercio._misVentas)
            {
                total += venta.RetornarGanancia();
            }

            Console.WriteLine("Ganancia total de " + comercio._dueno + ": $" + total);
        }

        public void ComprarArticulo(Articulo articuloComprado)
        {
            int found = 0;
            foreach (Articulo articulo in this._misArticulos)
            {
                if (articulo == articuloComprado)
                {
                    articulo.Stock = articulo + articuloComprado;
                    found = 1;
                    break;
                }
            }

            if (found == 0)
            {
                this._misArticulos.Add(articuloComprado);
            }
        }

        public void VenderArticulo(Articulo articulo, int cantidad)
        {
            int flag = 0;
            foreach (Articulo articuloFor in this._misArticulos)
            {
                if (articuloFor == articulo)
                {
                    if (articulo.HayStock(cantidad))
                    {
                        flag = 1;
                        articulo.Stock = articuloFor - cantidad;
                        Venta venta = new Venta(articuloFor, cantidad);
                        this._misVentas.Add(venta);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("El siguiente producto no tiene stock para la venta:");
                        Console.WriteLine(articulo.NombreYCodigo);
                    }
                }
                /*else
                {
                    Console.WriteLine("No se encuentran coincidencias o no hay stock.");
                }*/
            }
            if (flag == 0)
            {
                Console.WriteLine("El siguiente producto no existe.");
                Console.WriteLine(articulo.NombreYCodigo);
            }
        }
    }
}
