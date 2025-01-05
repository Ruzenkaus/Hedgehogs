using System.Diagnostics;

namespace Ezh
{
    internal class Program
    {
        delegate int TransformColors(int[] population, int targetColor);

        static Dictionary<int, TransformColors> colorTransformers;
        

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int[] population = { 2, 2, 2 }; // Початкова популяція.
            int targetColor = 1; // Бажаний колір.

            // Використання сінглтона.
            IColorTransformer transformer = ColorTransformer.Instance;

            Stopwatch stopwatch = Stopwatch.StartNew();
            int result = transformer.Transform(population, targetColor);
            stopwatch.Stop();

            Console.WriteLine(result >= 0
                ? $"Мінімальна кількість зустрічей: {result}"
                : "Трансформація неможлива");
            Console.WriteLine($"Час виконання: {stopwatch.ElapsedMilliseconds} ms");

        }

    }
}
