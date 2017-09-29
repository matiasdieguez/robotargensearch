using System;
using ArgenSearch;

namespace robotargensearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            for (int i = 31688636; i < 31688670; i++)
            {
                Console.WriteLine("DNI: " + i);

                var persona = ArgenSearchClient.Search(i).Result;

                if (persona.Data == null)
                    return;

                var cuil = persona.Data[0];

                var datos = ArgenSearchClient.Detail(cuil).Result;

                if (datos.Data.DomicilioFiscal == null)
                    Console.WriteLine(datos.Data.Nombre);
                else
                    Console.WriteLine(datos.Data.Nombre + " " + datos.Data.DomicilioFiscal.Direccion);
            }

            Console.ReadKey();
        }
    }
}
