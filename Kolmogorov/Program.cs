using System;
using Extreme.Statistics;
using Extreme.Statistics.Distributions;
using Extreme.Statistics.Tests;
using Extreme.Mathematics;

namespace Extreme.Numerics.QuickStart.CSharp
{
    class Kolmogorov
    {
        [STAThread]
        static void Main(string[] args)
        {
            //
            // Prueba de Kolmogorov-Smirnov
            //

            Console.WriteLine("\nPrueba de Kolmogorov-Smirnov");

            // Muestra de 25 numeros aleatorios

            LognormalDistribution logNormal = new LognormalDistribution(0, 1);
            WeibullDistribution weibull = new WeibullDistribution(2, 1);

            // Generamos las muestras
            var logNormalSample = logNormal.Sample(25);

            // Construimos la prueba de Kolmogorov smirnov:
            var ksTest = new OneSampleKolmogorovSmirnovTest(logNormalSample, weibull);
            Console.WriteLine(logNormalSample);
            Console.WriteLine("\n");
            Console.WriteLine(ksTest + "\n");

            // Podemos obtener el valor del estadístico de prueba a través de la propiedad Statistic
            // el valor P correspondiente a través de la propiedad Probability:
            Console.WriteLine("Test statistic: {0:F4}", ksTest.Statistic);
            Console.WriteLine("P-value:        {0:F4}", ksTest.PValue);

            // Ahora podemos imprimir los resultados de la prueba:
            Console.WriteLine("Rechazar la Hipotesis nula? {0}",
                ksTest.Reject() ? "si" : "no");
            Console.ReadLine();
        }
    }
}
