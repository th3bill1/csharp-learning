using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
#pragma warning disable SYSLIB0011

namespace csharplearning._2019.Lab12
{
    [Serializable]
    public class DataFrame<T>
    {
        public T[] Data;
        public T this[int a]
        {
            get { return Data[a]; }
        }
        public DataFrame(T[] data)
        { Data = data; }
        public DataFrame() { Data = Array.Empty<T>(); }
        public void ToBin(string path)
        {
            using FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            BinaryFormatter bf = new();
            bf.Serialize(fs, this);
        }
        public void ToXml(string path)
        {
            using FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write);
            XmlSerializer xs = new(typeof(DataFrame<T>));
            xs.Serialize(fs, this);
        }
    }
    internal static class DataFrame
    {
        public static DataFrame<Iris> IrisFromCsvDirectory(string dirpath)
        {
            if(!Directory.Exists(dirpath)) { return null; }
            var files = Directory.GetFiles(dirpath);
            List<Iris> irises = new();
            foreach( var file in files) 
            {
                var list = IrisCsvReader.ReadFile(file) as List<Iris>;
                if(list != null )irises.AddRange(list);
            }
            return new DataFrame<Iris>(irises.ToArray());
        }

        public static DataFrame<T> FromBin<T>(string path)
        {
            using FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new();
            return (DataFrame<T>)bf.Deserialize(fs);
        }
        public static DataFrame<T> FromXml<T>(string path)
        {
            using FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            XmlSerializer xs = new(typeof(DataFrame<T>));
            return (DataFrame<T>)xs.Deserialize(fs);
        }
    }
}
