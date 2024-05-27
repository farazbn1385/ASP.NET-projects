using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.net_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            double Sum = 0;
            double DTime = 0.0;
            double DValue = 0.0;
            int Count = 0;
            int ValueCount = 0;
            Info[] Main = new Info[0];
            Info[] Helper1 = new Info[Main.Length];
            Info[] Values = new Info[Count + 1];
            List<Info> DeleteList = new List<Info>();
            List<Info> DeleteHelper1 = new List<Info>();

            string Input = "a";
            while (Input != "e")
            {
                Console.Clear();
                Console.WriteLine("Add (a)");
                Console.WriteLine("Delete (d)");
                Console.WriteLine("Query (q)");
                Console.WriteLine("Exit (e)");
                Console.WriteLine();
                Console.WriteLine("what do you want to do?");
                Input = Console.ReadLine();
                Console.WriteLine();

                switch (Input)
                {
                    case "a":
                        Info In = new Info();
                        Info[] Array2 = new Info[Main.Length + 1];
                        for (int i = 0; i < Main.Length; i++)
                        {
                            Array2[i] = Main[i];
                        }
                        Console.Write("Enter the time: ");
                        if (!double.TryParse(Console.ReadLine(), out In.Time))
                        {
                            Console.WriteLine("Invalid value");
                            Console.ReadKey();
                        }

                        Console.Write("Enter the value: ");
                        if (!double.TryParse(Console.ReadLine(), out In.Value))
                        {
                            Console.WriteLine("Invalid value");
                            Console.ReadKey();
                        }

                        Array2[Main.Length] = In;
                        Main = new Info[Array2.Length];
                        Helper1 = new Info[Array2.Length];

                        for (int i = 0; i < Array2.Length; i++)
                        {
                            Main[i] = Array2[i];
                        }
                        break;
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    case "d":
                        Info Ind = new Info();
                        Console.WriteLine("Enter a time to delete");
                        if (!double.TryParse(Console.ReadLine(), out Ind.Time))
                            Console.WriteLine("Invalid value");

                        Console.WriteLine("Enter a value to delete");
                        if (!double.TryParse(Console.ReadLine(), out Ind.Value))
                            Console.WriteLine("Invalid value");

                        DeleteList.Add(Ind);

                        break;
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////       
                    case "q":
                        Console.Write("Enter the time for query: ");
                        if (!int.TryParse(Console.ReadLine(), out int Query))
                        {
                            Console.WriteLine("Invalid value");
                            Console.ReadKey();
                        }

                        foreach (var item in Main)
                        {
                            if (item.Time < Query)
                            {
                                Helper1[ValueCount] = item;
                                ValueCount++;
                            }
                        }

                        foreach (var item in DeleteList)
                        {
                            if (item.Time < Query)
                            {
                                DeleteHelper1.Add(item);
                            }
                        }

                        for (int i = 0; i < DeleteHelper1.Count; i++)
                        {
                            for (int j = 0; j < Helper1.Length; j++)
                            {
                                if (DeleteHelper1[i].Value == Helper1[j].Time)
                                {
                                    Values[Count] = Helper1[j];
                                    DTime = Helper1[j].Time;
                                    DValue = Helper1[j].Value;
                                    Count++;
                                    break;
                                }
                            }
                        }

                        Console.WriteLine();

                        //foreach (var item in Helper1)
                        //{
                        //    if (item.Time != DTime && item.Value != DValue)
                        //    {
                        //        Console.WriteLine("Time: {0} , Value: {1}", item.Time, item.Value);
                        //        Sum = Sum + item.Value;
                        //    }
                        //}

                        for (int i = 0; i < Helper1.Length; i++)
                        {
                            if (Helper1[i].Value != DValue || Helper1[i].Time != DTime)
                            {
                                Console.WriteLine("Time: {0} , Value: {1}", Helper1[i].Time, Helper1[i].Value);
                                Sum = Sum + Helper1[i].Value;
                            }
                        }

                        Console.WriteLine($"Sum of query:{Sum}");
                        Console.ReadKey();

                        double DataValue = 0;

                        for (int i = DeleteHelper1.Count - 1; i >= 0; i--)
                        {
                            for (int j = DeleteHelper1.Count - 2; j >= 0; j--)
                            {
                                if (DeleteHelper1[i].Value == DeleteHelper1[j].Time)
                                {
                                    DataValue = DeleteHelper1[j].Value;
                                    break;
                                }
                            }
                        }

                        for (int i = 0; i < Values.Length; i++)
                        {
                            if (DataValue == Values[i].Time)
                            {
                                DTime = -10000;
                                DValue = -10000;
                            }
                        }

                        Console.WriteLine();
                        Sum = 0;
                        foreach (var item in Helper1)
                        {
                            if (item.Time != DTime && item.Value != DValue)
                            {
                                Console.WriteLine("Time: {0} , Value: {1}", item.Time, item.Value);
                                Sum = Sum + item.Value;
                            }
                        }
                        Console.WriteLine($"Sum of query:{Sum}");
                        Console.ReadKey();
                        break;
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    default:
                        break;
                }
            }

        }
    }
}
