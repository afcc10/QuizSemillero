using Quiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Quiz
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("++++++++++++ Primer punto +++++++++++++++++");
            Console.WriteLine("");
            using (var context = new Model1())
            {
                var Customers = (from c in context.Customers
                                 select c).ToList();

                foreach (var item in Customers)
                {
                    Console.WriteLine(item.CustomerID + " " + item.ContactName);
                }


                Console.WriteLine("");
                Console.WriteLine("++++++++++++ Segundo Punto +++++++++++++++++");
                Console.WriteLine("");
                Console.WriteLine("++++++++++++ Clientes con pais Germany +++++++++++++++++");
                Console.WriteLine("");

                var clientePais = (from c in context.Customers
                                   where c.Country.Equals("Germany")
                                   select c).ToList();

                foreach (var item in clientePais)
                {
                    Console.WriteLine(item.CustomerID + " " + item.ContactName);
                }



                Console.WriteLine("");
                Console.WriteLine("++++++++++++ Clientes registrados en la base de datos +++++++++++++++++");
                Console.WriteLine("");

                var cantidad = (from c in context.Customers
                                select c).Count();

                Console.WriteLine("La cantidad de clientes en la base de datos es " + cantidad);


                Console.WriteLine("");
                Console.WriteLine("++++++++++++ Nombre ciudades clientes +++++++++++++++++");
                Console.WriteLine("");

                var ciudades = (from c in context.Customers
                                select c.City).ToList().Distinct();

                Console.WriteLine("Las ciudades son ");
                foreach (var item in ciudades)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("");
                Console.WriteLine("++++++++++++ Clientes ordenados descendentemente +++++++++++++++++");
                Console.WriteLine("");

                var orden = (from c in context.Customers
                             orderby c.ContactName descending
                             select c).ToList();
                Console.WriteLine("Los clientes ordenados de forma descendente ");
                foreach (var item in orden)
                {
                    Console.WriteLine(item.ContactName);
                }

                Console.WriteLine("");
                Console.WriteLine("++++++++++++ Clientes que en su ContanctName contenga OM +++++++++++++++++");
                Console.WriteLine("");

                var content = (from c in context.Customers
                               where c.ContactName.Contains("OM")
                               select c).ToList();

                Console.WriteLine("Los clientes que contienen OM son ");
                foreach (var item in content)
                {
                    Console.WriteLine(item.ContactName);
                }

                Console.WriteLine("");
                Console.WriteLine("++++++++++++ Punto tres +++++++++++++++++");
                Console.WriteLine("");

                var productos = (from p in context.Products
                                 select p).ToList();

                Console.WriteLine("Los productos de la base de datos son ");
                foreach (var item in productos)
                {
                    Console.WriteLine(item.ProductName);
                }

                Console.WriteLine("");
                Console.WriteLine("++++++++++++ Punto cuatro +++++++++++++++++");
                Console.WriteLine("");

                var sumPrecio = (from p in context.Products
                                 group p by p.CategoryID into g
                                 select new { Categoria = g.Select(x => x.CategoryID).FirstOrDefault(),
                                     SumaPrecio = g.Sum(x => x.UnitPrice)
                                 }).ToList();


                Console.WriteLine("Los productos de la base de datos son ");
                foreach (var item in sumPrecio)
                {
                    Console.WriteLine("Categoria " + item.Categoria + " " + "Suma de precio " + item.SumaPrecio);
                }

                Console.WriteLine("");
                Console.WriteLine("++++++++++++ Promedio menor al precio unitario +++++++++++++++++");
                Console.WriteLine("");

                decimal promedio = (decimal)context.Products.Average(x => x.UnitPrice);
                var precios = context.Products.Where(x => x.UnitPrice > promedio)
                                                .Select(x => x.UnitPrice).ToList();

                Console.WriteLine("Los precios mayores al promedio son: ");
                foreach (decimal item in precios)
                {
                    Console.WriteLine("El promedio es " + decimal.Round(promedio,2) + " y es menor a " + decimal.Round(item,2));
                }
                
            }
            Console.ReadKey();

        }
    }
}
