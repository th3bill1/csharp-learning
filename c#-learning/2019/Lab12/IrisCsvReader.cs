using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharplearning._2019.Lab12
{
    internal static class IrisCsvReader
    {
        public static IEnumerable<Iris>? ReadFile(string filepath)
        {
            if (!File.Exists(filepath)) return null;
            using StreamReader sr = new(filepath);
            var columns = sr.ReadLine().Split(',');
            string[] columnNames = { "\"variety\"", "\"sepal.length\"", "\"sepal.width\"", "\"petal.length\"", "\"petal.width\"" };
            var indexes = new int[columnNames.Length];
            for (int i = 0; i<columnNames.Length; i++) 
            {
                indexes[i] = Array.IndexOf(columns, columnNames[i]);
                if (indexes[i] == -1) return null;
            }
            List<Iris> value = new();
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                var values = s.Split(",");
                IrisSpecies variety = (IrisSpecies)Enum.Parse(typeof(IrisSpecies),values[indexes[0]][1..^1]);
                double sepal_length = 0, sepal_width = 0, petal_length = 0, petal_width = 0;
                sepal_length = double.Parse(values[indexes[1]], CultureInfo.InvariantCulture);
                sepal_width = double.Parse(values[indexes[2]], CultureInfo.InvariantCulture);
                petal_length = double.Parse(values[indexes[3]], CultureInfo.InvariantCulture);
                petal_width = double.Parse(values[indexes[4]], CultureInfo.InvariantCulture);
                Iris iris = new() { Species = variety, SepalLength = sepal_length, SepalWidth = sepal_width, PetalLength = petal_length, PetalWidth = petal_width };
                value.Add(iris);
            }
            return value;
        }
    }
}
