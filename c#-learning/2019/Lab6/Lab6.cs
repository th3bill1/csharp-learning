using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace csharplearning._2019.Lab6
{
    internal class Lab6
    {
        public struct Surface
        {
            public Vector Location { get; set; }
            public Vector Normal { get; set; }
            public Vector Colour { get; set; }
        }
        private static void Stage_1_1(Vector[] vectors, Vector[] colours)
        {
            foreach (Vector vector in vectors)
                Console.WriteLine($"Vector With Coordinates: {vector}");

            Console.WriteLine();

            foreach (Vector colour in colours)
                Console.WriteLine($"Colour With Values: {colour}");
        }

        private static void Stage_1_2(Vector[] vectors, Vector[] colours)
        {
            for (int i = 0; i < vectors.Length - 1; i++)
                Console.WriteLine($"Vector * Vector Multiplication: {Vector.Multiply(vectors[i], vectors[i + 1])}");

            Console.WriteLine();

            for (int i = 0; i < vectors.Length; i++)
                Console.WriteLine($"Scalar * Vector Multiplication: {Vector.Multiply(i + 1, vectors[i])}");
        }

        private static void Stage_1_3(Vector[] vectors, Vector[] colours)
        {
            foreach (Vector vector in vectors)
            {
                (float x, float y, float z) = vector;

                Console.WriteLine($"Vector With Coordinates: (X:{x,6:0.00}, Y:{y,6:0.00}, Z:{z,6:0.00})");
            }
        }

        private static void Stage_1_4(Vector[] vectors, Vector[] colours)
        {
            for (int i = 0; i < vectors.Length - 1; i++)
            {
                Vector resultVector = Vector.Subtract(vectors[i + 1], vectors[i]);

                Console.WriteLine($"Length Of Subtraction: Length({vectors[i + 1]} - {vectors[i]}) = {resultVector.Length,3:0.00}");
            }
        }


        private static void Stage_23_1(Light[] lights, Surface[] surfaces)
        {
            foreach (Surface surface in surfaces)
                foreach (Light light in lights)
                    if (light is PointLight pointLight)
                    {
                        string surfaceInfo = pointLight.IsInRange(surface, out _, out _) ? "Is In Range" : "Is Not In Range";

                        Console.WriteLine($"Surface {surface.Location} - {surfaceInfo} Of Point Light {pointLight.Location}");
                    }
        }

        private static void Stage_23_2(Light[] lights, Surface[] surfaces)
        {
            foreach (Surface surface in surfaces)
                foreach (Light light in lights)
                {
                    Vector resultColour = light.Compute(surface);

                    Console.WriteLine($"Surface {surface.Location} Has Been Affected By Light {light.Colour} - Result {resultColour}");
                }
        }

        private static void PrintLights(Light[] lights)
        {
            foreach (Light light in lights)
            {
                switch (light)
                {
                    case DirectionalLight directionalLight:
                        {
                            Console.WriteLine($"Directional Light (Intensity: {directionalLight.Intensity}, Colour: {directionalLight.Colour}, Direction: {directionalLight.Direction})");
                        }
                        break;
                    case PointLight pointLight:
                        {
                            Console.WriteLine($"Point Light (Intensity: {pointLight.Intensity}, Colour: {pointLight.Colour}, Location: {pointLight.Location}, Range: {pointLight.Range})");
                        }
                        break;
                }
            }
        }
        public static void Lab()
        {

            CultureInfo.CurrentCulture = new CultureInfo("en-US", false);

            Console.WriteLine("********************* Stage_1 (3.0 Pkt) *********************");
            {
                Vector[] vectors = new Vector[]
                {
                    new Vector(0.0f, 0.0f, 0.0f),
                    new Vector(1.0f, 0.0f, 0.0f),
                    new Vector(0.0f, 1.0f, 0.0f),
                    new Vector(0.0f, 0.0f, 1.0f),
                    new Vector(0.0f, 5.0f, 1.0f),
                    new Vector(7.5f, 2.0f, 0.5f),
                };

                Vector[] colours = new Vector[]
                {
                    new Vector(0.0f, 0.0f, 0.0f, Vector.TypeColour),
                    new Vector(1.0f, 0.0f, 0.0f, Vector.TypeColour),
                    new Vector(0.0f, 1.0f, 0.0f, Vector.TypeColour),
                    new Vector(0.0f, 0.0f, 1.0f, Vector.TypeColour),
                    new Vector(0.0f, 5.0f, 1.0f, Vector.TypeColour),
                    new Vector(1.15f, 0.25f, 0.5f, Vector.TypeColour),
                };

                Console.WriteLine(); Stage_1_1(vectors, colours);
                Console.WriteLine(); Stage_1_2(vectors, colours);
                Console.WriteLine(); Stage_1_3(vectors, colours);
                Console.WriteLine(); Stage_1_4(vectors, colours);

                Console.WriteLine();
            }

            Console.WriteLine("********************* Stage_2 (1.0 Pkt) *********************");
            Console.WriteLine("********************* Stage_3 (2.0 Pkt) *********************");
            {
                Vector colour_1 = new Vector(1.00f, 0.45f, 0.75f, Vector.TypeColour);
                Vector colour_2 = new Vector(0.25f, 0.85f, 0.05f, Vector.TypeColour);
                Vector colour_3 = new Vector(0.00f, 0.15f, 0.95f, Vector.TypeColour);

                Vector location_1 = new Vector(0.0f, 5.0f, 5.0f);
                Vector location_2 = new Vector(-10.0f, 5.0f, 5.0f);
                Vector location_3 = new Vector(-10.0f, 5.0f, 5.0f);
                Vector location_4 = new Vector(5.0f, 5.0f, -10.0f);

                Vector direction_1 = new Vector(0.0f, -1.0f, 0.0f);
                Vector direction_2 = new Vector(-1.0f, -1.0f, -1.0f);

                Light[] lights_1 = new Light[]
                {
                    new DirectionalLight(2.5f, colour_1, direction_1),
                    new DirectionalLight(0.5f, colour_3, direction_2),
                    new DirectionalLight(1.5f, colour_2, direction_2),
                    new DirectionalLight(1.0f, colour_2, direction_1),
                    new PointLight(1.50f, colour_3, location_1, 2.0f),
                    new PointLight(2.25f, colour_2, location_2, 15.0f),
                };

                Surface[] surfaces = new Surface[]
                {
                    new Surface() { Location = new Vector(0.0f, 0.0f, 0.0f), Colour = new Vector(1.0f, 0.0f, 0.0f, Vector.TypeColour), Normal = new Vector(0.0f, 1.0f, 0.0f) },
                    new Surface() { Location = new Vector(0.0f, 5.0f, 0.0f), Colour = new Vector(1.0f, 0.2f, 0.4f, Vector.TypeColour), Normal = new Vector(1.0f, 1.0f, 0.0f) },
                    new Surface() { Location = new Vector(7.5f, 0.0f, 7.5f), Colour = new Vector(0.5f, 0.0f, 0.7f, Vector.TypeColour), Normal = new Vector(0.0f, -1.0f, 0.0f) },
                    new Surface() { Location = new Vector(3.0f, 3.0f, 0.0f), Colour = new Vector(1.0f, 1.0f, 1.0f, Vector.TypeColour), Normal = new Vector(0.0f, -1.0f, 1.0f) },
                };

                Console.WriteLine(); PrintLights(lights_1);
                Console.WriteLine(); Stage_23_1(lights_1, surfaces);
                Console.WriteLine(); Stage_23_2(lights_1, surfaces);

                Console.WriteLine();
            }
        }


    }
}
