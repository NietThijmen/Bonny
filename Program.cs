
namespace Bony
{

    class main 
    {

        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("You need to specify a dir (+ file)");

            }
            else
            {


                string path = args[0];
                if (string.IsNullOrEmpty(path))
                {
                    Console.WriteLine("You need to specify a dir (+ file)");
                }
                else
                {


                    string[] paths = path.Split('/');
                    String pathstring = "";
                    int amount = paths[paths.Length - 1].Contains('.') ? 1 : 0;
                    for (var i = 0; i < paths.Length - amount; i++)
                    {


                        pathstring += paths[i];
                        if (!Directory.Exists(pathstring))
                        {
                            Directory.CreateDirectory(pathstring);
                        }

                        pathstring += "/";



                    }
                    if (paths[paths.Length - 1].Contains('.'))
                    {
                        File.Create(pathstring + "/" + paths[^1], 0);
                    }

                    Console.WriteLine($"Directory (+ Files) created successfully! {pathstring}");
                }
            }
        }
    }
}