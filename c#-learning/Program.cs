namespace csharplearning
{
    internal static class Programming3
    {
        static void Main()
        {
            Console.WriteLine("Welcome to Programming 3 labs solution database");
            int lab_num = 1;
            while(lab_num!=0)
            {
                Console.WriteLine("\nPlease select a lab to run:");
                Console.WriteLine("0. Leave");
                Console.WriteLine("5. Lab 5");
                Console.WriteLine("6. Lab 6");
                Console.WriteLine("16. Lab 6PL");
                lab_num = int.TryParse(Console.ReadLine(), out lab_num) ? lab_num : 0;
                switch (lab_num)
                {
                    case 0:
                        Console.WriteLine("See you next time!"); break;
                    case 5:
                        Lab5.Lab5.Lab();
                        break;
                    case 6:
                        Lab6.Lab6.Lab();
                        break;
                    case 16:
                        Lab6PL.Lab6PL.Lab();
                        break;
                    case 17:
                        _2019.Lab6.Lab6.Lab();
                        break;
                    case 18:
                        _2019.Lab9.Lab9.Lab();
                        break;
                    default:
                        Console.WriteLine("No such lab");
                        break;
                }
            }     
        }
    }
}