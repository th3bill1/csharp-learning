#define STAGE_1
#define STAGE_2
#define STAGE_3
#define STAGE_4
#define STAGE_5
#define STAGE_6

using Microsoft.CSharp;
using System.Xml;
using System.Globalization;

namespace csharplearning._2019.Lab12
{
    public class Lab12
    {
        public static void Lab()
        {
            Console.WriteLine("### Stage 0 ###");

            Assert("Data folder is not missing",
                () => new DirectoryInfo("./data").Exists);

#if STAGE_1
            Console.WriteLine("### Stage 1 ###");

#endif
#if STAGE_2
            dynamic result;
            Console.WriteLine("### Stage 2 ###");

            result = IrisCsvReader.ReadFile("non-existing-file.csv");
            Assert("Result should be null",
                () => result is null);

            result = IrisCsvReader.ReadFile("./data/virginica.csv");
            Assert("Result should not be null", () =>
                !(result is null));
            Assert("Result should be of type IEnumerable<Iris>", () =>
                result is IEnumerable<Iris>);
            Assert("Result count should be 50", () =>
                result.Count == 50);

            AssertSpeciesIrises(result, IrisSpecies.Virginica);
#endif
#if STAGE_3
            Console.WriteLine("### Stage 3 ###");

            result = DataFrame.IrisFromCsvDirectory("./data");
            AssertIrises(result);
#endif
#if STAGE_4
            Console.WriteLine("### Stage 4 ###");
            result = DataFrame.IrisFromCsvDirectory("./data");

            Assert("Binary Serialization", () =>
            {
                result.ToBin("__student_iris.bin");
            });

            Assert("Binary Deserialization", () =>
            {
                result = DataFrame.FromBin<Iris>("__student_iris.bin");
                AssertIrises(result);
            });
#endif
#if STAGE_5
            Console.WriteLine("### Stage 5 ###");
            result = DataFrame.IrisFromCsvDirectory("./data");

            Assert("Xml Serialization", () => { result.ToXml("__student_iris.xml"); return true; });

            Assert("Xml Deserialization 1", () =>
            {
                result = DataFrame.FromXml<Iris>("__student_iris.xml");
                AssertIrises(result);
            });

#endif
#if STAGE_6
            Console.WriteLine("### Stage 6 ###");

            Assert("Xml Deserialization 2", () =>
            {
                result = DataFrame.FromXml<Iris>("./data/__iris.xml");
                AssertIrises(result);
            });
#endif
        }

        private static void Print(string message, ConsoleColor color)
        {
            var oldColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            string prefix = color == ConsoleColor.Green
                ? "OK  "
                : "FAIL";
            Console.WriteLine($"{prefix} {message}");
            Console.ForegroundColor = oldColor;
        }

        private static bool Assert(string message, Func<bool> condition, bool print = true)
        {
            try
            {
                bool result = condition();
                if (result)
                {
                    if (print)
                    {
                        Print(message, ConsoleColor.Green);
                    }
                }
                else
                {
                    Print(message, ConsoleColor.Red);
                }
                return result;
            }
            catch (Exception ex)
            {
                Print(ex?.Message, ConsoleColor.DarkMagenta);
                return false;
            }
        }

        private static bool Assert(string message, Action action)
        {
            return Assert(message, () => { action(); return true; });
        }

#if STAGE_1
        private static readonly List<Iris> IrisDataSet;
        #region 
        static Lab12()
        {
            IrisDataSet = new List<Iris>
            {
                new Iris { SepalLength = 5.1, SepalWidth = 3.5, PetalLength = 1.4, PetalWidth = .2, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 4.9, SepalWidth = 3, PetalLength = 1.4, PetalWidth = .2, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 4.7, SepalWidth = 3.2, PetalLength = 1.3, PetalWidth = .2, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 4.6, SepalWidth = 3.1, PetalLength = 1.5, PetalWidth = .2, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 5, SepalWidth = 3.6, PetalLength = 1.4, PetalWidth = .2, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 5.4, SepalWidth = 3.9, PetalLength = 1.7, PetalWidth = .4, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 4.6, SepalWidth = 3.4, PetalLength = 1.4, PetalWidth = .3, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 5, SepalWidth = 3.4, PetalLength = 1.5, PetalWidth = .2, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 4.4, SepalWidth = 2.9, PetalLength = 1.4, PetalWidth = .2, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 4.9, SepalWidth = 3.1, PetalLength = 1.5, PetalWidth = .1, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 5.4, SepalWidth = 3.7, PetalLength = 1.5, PetalWidth = .2, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 4.8, SepalWidth = 3.4, PetalLength = 1.6, PetalWidth = .2, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 4.8, SepalWidth = 3, PetalLength = 1.4, PetalWidth = .1, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 4.3, SepalWidth = 3, PetalLength = 1.1, PetalWidth = .1, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 5.8, SepalWidth = 4, PetalLength = 1.2, PetalWidth = .2, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 5.7, SepalWidth = 4.4, PetalLength = 1.5, PetalWidth = .4, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 5.4, SepalWidth = 3.9, PetalLength = 1.3, PetalWidth = .4, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 5.1, SepalWidth = 3.5, PetalLength = 1.4, PetalWidth = .3, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 5.7, SepalWidth = 3.8, PetalLength = 1.7, PetalWidth = .3, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 5.1, SepalWidth = 3.8, PetalLength = 1.5, PetalWidth = .3, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 5.4, SepalWidth = 3.4, PetalLength = 1.7, PetalWidth = .2, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 5.1, SepalWidth = 3.7, PetalLength = 1.5, PetalWidth = .4, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 4.6, SepalWidth = 3.6, PetalLength = 1, PetalWidth = .2, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 5.1, SepalWidth = 3.3, PetalLength = 1.7, PetalWidth = .5, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 4.8, SepalWidth = 3.4, PetalLength = 1.9, PetalWidth = .2, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 5, SepalWidth = 3, PetalLength = 1.6, PetalWidth = .2, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 5, SepalWidth = 3.4, PetalLength = 1.6, PetalWidth = .4, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 5.2, SepalWidth = 3.5, PetalLength = 1.5, PetalWidth = .2, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 5.2, SepalWidth = 3.4, PetalLength = 1.4, PetalWidth = .2, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 4.7, SepalWidth = 3.2, PetalLength = 1.6, PetalWidth = .2, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 4.8, SepalWidth = 3.1, PetalLength = 1.6, PetalWidth = .2, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 5.4, SepalWidth = 3.4, PetalLength = 1.5, PetalWidth = .4, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 5.2, SepalWidth = 4.1, PetalLength = 1.5, PetalWidth = .1, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 5.5, SepalWidth = 4.2, PetalLength = 1.4, PetalWidth = .2, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 4.9, SepalWidth = 3.1, PetalLength = 1.5, PetalWidth = .2, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 5, SepalWidth = 3.2, PetalLength = 1.2, PetalWidth = .2, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 5.5, SepalWidth = 3.5, PetalLength = 1.3, PetalWidth = .2, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 4.9, SepalWidth = 3.6, PetalLength = 1.4, PetalWidth = .1, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 4.4, SepalWidth = 3, PetalLength = 1.3, PetalWidth = .2, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 5.1, SepalWidth = 3.4, PetalLength = 1.5, PetalWidth = .2, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 5, SepalWidth = 3.5, PetalLength = 1.3, PetalWidth = .3, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 4.5, SepalWidth = 2.3, PetalLength = 1.3, PetalWidth = .3, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 4.4, SepalWidth = 3.2, PetalLength = 1.3, PetalWidth = .2, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 5, SepalWidth = 3.5, PetalLength = 1.6, PetalWidth = .6, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 5.1, SepalWidth = 3.8, PetalLength = 1.9, PetalWidth = .4, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 4.8, SepalWidth = 3, PetalLength = 1.4, PetalWidth = .3, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 5.1, SepalWidth = 3.8, PetalLength = 1.6, PetalWidth = .2, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 4.6, SepalWidth = 3.2, PetalLength = 1.4, PetalWidth = .2, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 5.3, SepalWidth = 3.7, PetalLength = 1.5, PetalWidth = .2, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 5, SepalWidth = 3.3, PetalLength = 1.4, PetalWidth = .2, Species = IrisSpecies.Setosa },
                new Iris { SepalLength = 7, SepalWidth = 3.2, PetalLength = 4.7, PetalWidth = 1.4, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 6.4, SepalWidth = 3.2, PetalLength = 4.5, PetalWidth = 1.5, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 6.9, SepalWidth = 3.1, PetalLength = 4.9, PetalWidth = 1.5, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 5.5, SepalWidth = 2.3, PetalLength = 4, PetalWidth = 1.3, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 6.5, SepalWidth = 2.8, PetalLength = 4.6, PetalWidth = 1.5, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 5.7, SepalWidth = 2.8, PetalLength = 4.5, PetalWidth = 1.3, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 6.3, SepalWidth = 3.3, PetalLength = 4.7, PetalWidth = 1.6, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 4.9, SepalWidth = 2.4, PetalLength = 3.3, PetalWidth = 1, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 6.6, SepalWidth = 2.9, PetalLength = 4.6, PetalWidth = 1.3, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 5.2, SepalWidth = 2.7, PetalLength = 3.9, PetalWidth = 1.4, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 5, SepalWidth = 2, PetalLength = 3.5, PetalWidth = 1, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 5.9, SepalWidth = 3, PetalLength = 4.2, PetalWidth = 1.5, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 6, SepalWidth = 2.2, PetalLength = 4, PetalWidth = 1, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 6.1, SepalWidth = 2.9, PetalLength = 4.7, PetalWidth = 1.4, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 5.6, SepalWidth = 2.9, PetalLength = 3.6, PetalWidth = 1.3, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 6.7, SepalWidth = 3.1, PetalLength = 4.4, PetalWidth = 1.4, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 5.6, SepalWidth = 3, PetalLength = 4.5, PetalWidth = 1.5, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 5.8, SepalWidth = 2.7, PetalLength = 4.1, PetalWidth = 1, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 6.2, SepalWidth = 2.2, PetalLength = 4.5, PetalWidth = 1.5, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 5.6, SepalWidth = 2.5, PetalLength = 3.9, PetalWidth = 1.1, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 5.9, SepalWidth = 3.2, PetalLength = 4.8, PetalWidth = 1.8, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 6.1, SepalWidth = 2.8, PetalLength = 4, PetalWidth = 1.3, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 6.3, SepalWidth = 2.5, PetalLength = 4.9, PetalWidth = 1.5, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 6.1, SepalWidth = 2.8, PetalLength = 4.7, PetalWidth = 1.2, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 6.4, SepalWidth = 2.9, PetalLength = 4.3, PetalWidth = 1.3, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 6.6, SepalWidth = 3, PetalLength = 4.4, PetalWidth = 1.4, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 6.8, SepalWidth = 2.8, PetalLength = 4.8, PetalWidth = 1.4, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 6.7, SepalWidth = 3, PetalLength = 5, PetalWidth = 1.7, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 6, SepalWidth = 2.9, PetalLength = 4.5, PetalWidth = 1.5, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 5.7, SepalWidth = 2.6, PetalLength = 3.5, PetalWidth = 1, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 5.5, SepalWidth = 2.4, PetalLength = 3.8, PetalWidth = 1.1, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 5.5, SepalWidth = 2.4, PetalLength = 3.7, PetalWidth = 1, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 5.8, SepalWidth = 2.7, PetalLength = 3.9, PetalWidth = 1.2, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 6, SepalWidth = 2.7, PetalLength = 5.1, PetalWidth = 1.6, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 5.4, SepalWidth = 3, PetalLength = 4.5, PetalWidth = 1.5, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 6, SepalWidth = 3.4, PetalLength = 4.5, PetalWidth = 1.6, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 6.7, SepalWidth = 3.1, PetalLength = 4.7, PetalWidth = 1.5, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 6.3, SepalWidth = 2.3, PetalLength = 4.4, PetalWidth = 1.3, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 5.6, SepalWidth = 3, PetalLength = 4.1, PetalWidth = 1.3, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 5.5, SepalWidth = 2.5, PetalLength = 4, PetalWidth = 1.3, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 5.5, SepalWidth = 2.6, PetalLength = 4.4, PetalWidth = 1.2, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 6.1, SepalWidth = 3, PetalLength = 4.6, PetalWidth = 1.4, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 5.8, SepalWidth = 2.6, PetalLength = 4, PetalWidth = 1.2, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 5, SepalWidth = 2.3, PetalLength = 3.3, PetalWidth = 1, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 5.6, SepalWidth = 2.7, PetalLength = 4.2, PetalWidth = 1.3, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 5.7, SepalWidth = 3, PetalLength = 4.2, PetalWidth = 1.2, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 5.7, SepalWidth = 2.9, PetalLength = 4.2, PetalWidth = 1.3, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 6.2, SepalWidth = 2.9, PetalLength = 4.3, PetalWidth = 1.3, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 5.1, SepalWidth = 2.5, PetalLength = 3, PetalWidth = 1.1, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 5.7, SepalWidth = 2.8, PetalLength = 4.1, PetalWidth = 1.3, Species = IrisSpecies.Versicolor },
                new Iris { SepalLength = 6.3, SepalWidth = 3.3, PetalLength = 6, PetalWidth = 2.5, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 5.8, SepalWidth = 2.7, PetalLength = 5.1, PetalWidth = 1.9, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 7.1, SepalWidth = 3, PetalLength = 5.9, PetalWidth = 2.1, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 6.3, SepalWidth = 2.9, PetalLength = 5.6, PetalWidth = 1.8, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 6.5, SepalWidth = 3, PetalLength = 5.8, PetalWidth = 2.2, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 7.6, SepalWidth = 3, PetalLength = 6.6, PetalWidth = 2.1, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 4.9, SepalWidth = 2.5, PetalLength = 4.5, PetalWidth = 1.7, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 7.3, SepalWidth = 2.9, PetalLength = 6.3, PetalWidth = 1.8, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 6.7, SepalWidth = 2.5, PetalLength = 5.8, PetalWidth = 1.8, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 7.2, SepalWidth = 3.6, PetalLength = 6.1, PetalWidth = 2.5, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 6.5, SepalWidth = 3.2, PetalLength = 5.1, PetalWidth = 2, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 6.4, SepalWidth = 2.7, PetalLength = 5.3, PetalWidth = 1.9, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 6.8, SepalWidth = 3, PetalLength = 5.5, PetalWidth = 2.1, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 5.7, SepalWidth = 2.5, PetalLength = 5, PetalWidth = 2, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 5.8, SepalWidth = 2.8, PetalLength = 5.1, PetalWidth = 2.4, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 6.4, SepalWidth = 3.2, PetalLength = 5.3, PetalWidth = 2.3, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 6.5, SepalWidth = 3, PetalLength = 5.5, PetalWidth = 1.8, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 7.7, SepalWidth = 3.8, PetalLength = 6.7, PetalWidth = 2.2, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 7.7, SepalWidth = 2.6, PetalLength = 6.9, PetalWidth = 2.3, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 6, SepalWidth = 2.2, PetalLength = 5, PetalWidth = 1.5, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 6.9, SepalWidth = 3.2, PetalLength = 5.7, PetalWidth = 2.3, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 5.6, SepalWidth = 2.8, PetalLength = 4.9, PetalWidth = 2, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 7.7, SepalWidth = 2.8, PetalLength = 6.7, PetalWidth = 2, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 6.3, SepalWidth = 2.7, PetalLength = 4.9, PetalWidth = 1.8, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 6.7, SepalWidth = 3.3, PetalLength = 5.7, PetalWidth = 2.1, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 7.2, SepalWidth = 3.2, PetalLength = 6, PetalWidth = 1.8, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 6.2, SepalWidth = 2.8, PetalLength = 4.8, PetalWidth = 1.8, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 6.1, SepalWidth = 3, PetalLength = 4.9, PetalWidth = 1.8, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 6.4, SepalWidth = 2.8, PetalLength = 5.6, PetalWidth = 2.1, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 7.2, SepalWidth = 3, PetalLength = 5.8, PetalWidth = 1.6, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 7.4, SepalWidth = 2.8, PetalLength = 6.1, PetalWidth = 1.9, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 7.9, SepalWidth = 3.8, PetalLength = 6.4, PetalWidth = 2, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 6.4, SepalWidth = 2.8, PetalLength = 5.6, PetalWidth = 2.2, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 6.3, SepalWidth = 2.8, PetalLength = 5.1, PetalWidth = 1.5, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 6.1, SepalWidth = 2.6, PetalLength = 5.6, PetalWidth = 1.4, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 7.7, SepalWidth = 3, PetalLength = 6.1, PetalWidth = 2.3, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 6.3, SepalWidth = 3.4, PetalLength = 5.6, PetalWidth = 2.4, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 6.4, SepalWidth = 3.1, PetalLength = 5.5, PetalWidth = 1.8, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 6, SepalWidth = 3, PetalLength = 4.8, PetalWidth = 1.8, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 6.9, SepalWidth = 3.1, PetalLength = 5.4, PetalWidth = 2.1, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 6.7, SepalWidth = 3.1, PetalLength = 5.6, PetalWidth = 2.4, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 6.9, SepalWidth = 3.1, PetalLength = 5.1, PetalWidth = 2.3, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 5.8, SepalWidth = 2.7, PetalLength = 5.1, PetalWidth = 1.9, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 6.8, SepalWidth = 3.2, PetalLength = 5.9, PetalWidth = 2.3, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 6.7, SepalWidth = 3.3, PetalLength = 5.7, PetalWidth = 2.5, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 6.7, SepalWidth = 3, PetalLength = 5.2, PetalWidth = 2.3, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 6.3, SepalWidth = 2.5, PetalLength = 5, PetalWidth = 1.9, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 6.5, SepalWidth = 3, PetalLength = 5.2, PetalWidth = 2, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 6.2, SepalWidth = 3.4, PetalLength = 5.4, PetalWidth = 2.3, Species = IrisSpecies.Virginica },
                new Iris { SepalLength = 5.9, SepalWidth = 3, PetalLength = 5.1, PetalWidth = 1.8, Species = IrisSpecies.Virginica }
            };
        }
        #endregion
#endif

#if STAGE_2
        private static void AssertIrises(dynamic irises)
        {
            foreach (IrisSpecies species in Enum.GetValues(typeof(IrisSpecies)))
            {
                AssertIrises(
                    (irises.Data as IEnumerable<Iris>).Where(x => (x as Iris)?.Species == species).ToList(),
                    IrisDataSet.Where(x => x.Species == species).ToList(),
                    species
                );
            }
        }

        private static void AssertSpeciesIrises(dynamic irises, IrisSpecies species)
        {
            var groundTruth = IrisDataSet.Where(x => x.Species == species).ToList();
            AssertIrises(irises, groundTruth, species);
        }

        private static void AssertIrises(dynamic irises, List<Iris> groundTruth, IrisSpecies species)
        {
            int fails = 0;
            bool invalidCount = false;

            for (int i = 0; i < groundTruth.Count; i++)
            {
                try { var zig = irises[i]; }
                catch (ArgumentOutOfRangeException)
                {
                    Assert($"{species} irises should have {groundTruth.Count} elements. Irises have {i} elements.", () => false, false);
                    invalidCount = true;
                    break;
                }
                if (!Assert($"Iris #{i} should not be null", () => !(irises[i] is null), false)) { fails++; }
                if (!Assert($"Iris #{i} SepalLength - Expected {groundTruth[i].SepalLength}. Is {irises[i].SepalLength}.", 
                    () => irises[i].SepalLength == groundTruth[i].SepalLength, false)) { fails++; }
                if (!Assert($"Iris #{i} SepalWidth - Expected {groundTruth[i].SepalWidth}. Is {irises[i].SepalWidth}.", 
                    () => irises[i].SepalWidth == groundTruth[i].SepalWidth, false)) { fails++; }
                if (!Assert($"Iris #{i} PetalLength - Expected {groundTruth[i].PetalLength}. Is {irises[i].PetalLength}.", 
                    () => irises[i].PetalLength == groundTruth[i].PetalLength, false)) { fails++; }
                if (!Assert($"Iris #{i} PetalWidth - Expected {groundTruth[i].PetalWidth}. Is {irises[i].PetalWidth}.", 
                    () => irises[i].PetalWidth == groundTruth[i].PetalWidth, false)) { fails++; }
                if (!Assert($"Iris #{i} Species should be correct",
                    () => irises[i].Species == groundTruth[i].Species, false)) { fails++; }
            }

            try
            {
                var zig = irises[groundTruth.Count];
                invalidCount = true;
                Assert($"{species} irises should have {groundTruth.Count} elements. Irises have over {groundTruth.Count} elements.", () => false, false);
            }
            catch (ArgumentOutOfRangeException)
            {
            }

            if (fails == 0 && !invalidCount)
            {
                Print($"{species} irises checking", ConsoleColor.Green);
            }
            else
            {
                if (fails != 0)
                {
                    Print($"{species} irises checking. {fails} fails", ConsoleColor.Red);
                }
                if (invalidCount)
                {
                    Print($"{species} irises checking. Incorrect number of elements", ConsoleColor.Red);
                }
            }
        }
#endif


    }
}
