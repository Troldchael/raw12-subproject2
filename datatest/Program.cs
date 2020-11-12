using System;
using DataServiceLib;
using DataServiceLib.Framework;

namespace datatest
{
    class Program
    {
        static void Main(string[] args)
        {
            IDataService ds = new DataService();

            

            Console.WriteLine(ds.DeleteUser(1));
        }
    }
}
