using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncOOP
{
    class Program
    {
        static void Main(string[] args)
        {

            //Watcher watcher = Watcher.CreateAsync().GetAwaiter().GetResult();

            Watcher watcher = Watcher.CreateAsync().GetAwaiter().GetResult();

            Console.WriteLine(watcher.Bytes);

            Console.WriteLine(watcher.Content);

            Console.ReadLine();

        }
    }
}
