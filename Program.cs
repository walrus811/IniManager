using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IniParser;
using IniParser.Model;

namespace Ray
{
    class Program
    {
        static void Main(string[] args)
        {
            string iniPath = "./test.ini";
            var ini = new IniManager(iniPath);

            var data = new Dictionary<string, string>
            {
                {"babo" , "a" },
                {"hey" , "you" },
            };

            //write test
            //if (ini.Write(data) && ini.Read())
            //{
            //    Console.WriteLine(ini.Data["df"]);
            //}

            if (ini.Read())
            {
                Console.WriteLine(ini.Data["port"]);
            }

            Console.ReadKey();

        }
    }
}
