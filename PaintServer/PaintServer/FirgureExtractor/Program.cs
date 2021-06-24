//using System;
//using System.IO;
//using Team_Project_Paint.Class.OperationWithFigures;

//namespace Team_Project_Paint
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            Console.WriteLine("Hello World!");

//            StreamReader sr = new StreamReader("jsonall.json");
//            string s = sr.ReadToEnd();
//            sr.Close();

//            var jl = new JsonLogic();
//            jl.JsonDeserialize(s);
//            var list = jl.JsonList;

//            foreach (var f in list)
//            {
//                //Console.WriteLine($"{f.Name} {f.Thickness.ToString()} {f.Location?.X.ToString()} {f.Location.Y?.ToString()}");
//                Console.WriteLine($"{f.Name} {f.Thickness.ToString()}");

//            }
//        }
//    }
//}
