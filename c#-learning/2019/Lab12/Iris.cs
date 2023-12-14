using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace csharplearning._2019.Lab12
{
    public enum IrisSpecies
    {
        Setosa,
        Virginica,
        [XmlEnum("Versi-color")]
        Versicolor
    }
    [Serializable]
    public class Iris
    {
        [XmlElement("sepal-length")]
        public double SepalLength {  get; set; }
        [XmlElement("sepal-width")]
        public double SepalWidth {  get; set; }
        [XmlElement("petal-length")]
        public double PetalLength {  get; set; }
        [XmlElement("petal-width")]
        public double PetalWidth {  get; set; }
        public IrisSpecies Species { get; set; }
    }
}
