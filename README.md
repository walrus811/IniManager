# IniManager
Windows ini file manager class. It can be used for reading and writing ini files easily. :wink:

How to use 
------------------
```ini
test.ini
# if you don't set ip address, it's considered as localhost(127.0.0.1)
#ip = 127.0.0.1
port = 8080
id = Ray
password = anything

```

```C#
    class Program
    {
        static void Main(string[] args)
        {
            string iniPath = "./test.ini"; 
            var ini = new IniManager(iniPath); //First of all, make instance with ini file path.
            // var ini = new IniManager(iniPath, ';'); //or you can set comment character, default one is '#'
            

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
                //output : 8080
            }

            Console.ReadKey();
        }
    }
```
