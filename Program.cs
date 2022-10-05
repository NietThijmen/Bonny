using static System.Console;
using static System.IO.Directory;
using static System.IO.File;

namespace Bony
{
    class main
    {
        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                WriteLine("Please add a directory (+file)");
                return;
            }
            string path = args[0];
            string[] paths = path.Split("/");
            int isOnlyFileOrFileWithADir = 0;
            if (paths[^1].Contains('.'))
            {
                isOnlyFileOrFileWithADir = 1;
            }
            if (paths.Length > 1)
            {
                String pathstring = "";

                for (int index = 0; index < paths.Length - isOnlyFileOrFileWithADir; index++)
                {
                    string t = paths[index];
                    pathstring += t;
                    try
                    {
                        if (!Directory.Exists(pathstring))
                        {
                            CreateDirectory(pathstring);
                        }
                    }
                    catch (Exception)
                    {
                        WriteLine("Path cannot begin by / or ./");
                        WriteLine("Correct usage is path/");
                        WriteLine("Not /path/");
                    }

                    pathstring += "/";
                }

                if (isOnlyFileOrFileWithADir == 1)
                {
                    Create($"{pathstring}{paths[^1]}", 0);
                }
            }
            else
            {
                Create($"{GetCurrentDirectory()}/{paths[^1]}", 0);
            }
        }
    }
}