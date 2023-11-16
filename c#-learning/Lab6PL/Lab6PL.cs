namespace csharplearning.Lab6PL
{
    internal class Lab6PL
    {
        public static void Lab()
        {
            static void PrintStage(int stage)
            {
                Console.WriteLine($"\n----------------------Stage {stage}-------------------------\n");
            }
            static void PrintSet(string name, Set set)
            {
                Console.WriteLine($"{name}: {set}, capacity {set.GetElementsArrayCapacity()}");
            }

            PrintStage(1);
            Console.WriteLine("//Tworzenie obiektów klasy Set, wypisywanie");
            Set setA = new Set(1, 2, 3, 4, 5, 5, 1);
            Set setB = new Set(2, 3, 4, 4, 3, 5, 6, 7, 7, 4, 8, 9);
            PrintSet("A", setA);
            PrintSet("B", setB);
            PrintStage(2);
            Console.WriteLine("//Suma zbiorów");
            var setSUM = setA + setB;
            PrintSet("A \u22c3 B", setSUM);

            Console.WriteLine("\n//Różnica zbiorów");
            var setDIFFAB = setA - setB;
            var setDIFFBA = setB - setA;

            PrintSet("A \\ B", setDIFFAB);
            PrintSet("B \\ A", setDIFFBA);
            PrintStage(3);
            Set emptySet = new Set();
            PrintSet("Pusty zbiór", emptySet);
            if (emptySet && setA)
                Console.WriteLine("BŁĘDNY WYNIK!");
            else Console.WriteLine("Dobrze! Tylko jeden ze zbiorów jest niepusty.");
            if (setA && setB)
                Console.WriteLine("Dobrze! Oba zbiory są niepuste.");
            else Console.WriteLine("BŁĘDNY WYNIK!");
            if (emptySet || setB)
                Console.WriteLine("Dobrze! Jeden ze zbiorów jest pusty.");
            else Console.WriteLine("BŁĘDNY WYNIK!");

            Console.WriteLine("\n//Część wspólna zbiorów");
            var setIntAB = setA & setB;
            PrintSet("A \u22c2 B", setIntAB);

            Console.WriteLine("\n//Porównanie zbiorów");
            if (setA != setB)
                Console.WriteLine("setA != setB");
            Set setADifferentButSame = new Set(4, 5, 2, 1, 1, 3);
            PrintSet("setADifferentButSame", setADifferentButSame);

            if (setA == setADifferentButSame)
                Console.WriteLine("setA == setADifferentButSame");

        }
    }
}
