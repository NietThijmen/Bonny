namespace Bony
{
    class main
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please add a directory (+file)");
                return;
            }
            string path = args[0];
            string[] paths = path.Split("/");
            int IsOnlyFileOrFileWithADiir = 0;
            if (paths[^1].Contains('.'))
            {
                IsOnlyFileOrFileWithADiir = 1;
            }
            if (paths.Length > 1)
            {
                String pathstring = "";

                for (int index = 0; index < paths.Length - IsOnlyFileOrFileWithADiir; index++)
                {
                    string t = paths[index];
                    pathstring += t;
                    try
                    {
                        if (!Directory.Exists(pathstring))
                        {
                            Directory.CreateDirectory(pathstring);
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Path cannot begin by / or ./");
                        Console.WriteLine("Correct usage is path/");
                        Console.WriteLine("Not /path/");
                    }

                    pathstring += "/";
                }

                if (IsOnlyFileOrFileWithADiir == 1)
                {
                    File.Create($"{pathstring}{paths[paths.Length - 1]}", 0);
                }
            }
            else
            {
                File.Create($"{Directory.GetCurrentDirectory()}/{paths[paths.Length - 1]}", 0);
            }
        }
    }
}