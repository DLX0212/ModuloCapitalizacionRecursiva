using System;

namespace CalculoDepreciacion
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("CÁLCULO DE DEPRECIACIÓN (SALDO DECRECIENTE)");

            // Entrada del valor original de compra
            Console.Write("Ingrese el valor original del activo (V): $");
            if (!decimal.TryParse(Console.ReadLine(), out decimal valorOriginal) || valorOriginal < 0)
            {
                Console.WriteLine("Error: El valor original de compra debe ser un número positivo.");
                return;
            }

            // Entrada de la tasa de depreciación anual
            Console.Write("Ingrese la tasa de depreciación anual en % (d): ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal tasaDepreciacion) || tasaDepreciacion < 0 || tasaDepreciacion > 100)
            {
                Console.WriteLine("Error: La tasa de depreciación debe ser un porcentaje válido entre 0 y 100.");
                return;
            }

            // Entrada de los años de vida util
            Console.Write("Ingrese los años de vida util transcurridos (t): ");
            if (!int.TryParse(Console.ReadLine(), out int anios) || anios < 0)
            {
                // Validacion para no permitir años negativos
                Console.WriteLine("Error de validación: Los años transcurridos no pueden ser negativos.");
                return;
            }

            // Ejecución de la logica recursiva
            decimal valorResidual = CalcularDepreciacionRecursiva(valorOriginal, tasaDepreciacion, anios);

            // Salida con formato de dos decimales para representar valores monetarios
            Console.WriteLine("\n RESULTADO");
            Console.WriteLine($"El valor contable del activo después de {anios} años es: ${valorResidual:F2}");
        }

   
        static decimal CalcularDepreciacionRecursiva(decimal v, decimal d, int t)
        {
            // El Caso Base (Estado Básico)
            // Si el tiempo transcurrido es 0 (t=0), el valor es igual al costo original.
            if (t == 0)
            {
                return v;
            }

            // El Caso Recursivo (Estado Recursivo)
            // Se invoca la función a sí misma pasando el año anterior (t-1).
            decimal valorAnterior = CalcularDepreciacionRecursiva(v, d, t - 1);

            // Factor de retención de valor: r = (1 - d/100)
            decimal factorRetencion = 1 - (d / 100m);

            // V(t) = V(t-1) * (1 - d/100)
            return valorAnterior * factorRetencion;
        }
    }
}