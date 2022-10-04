
namespace Bony
{

    class main
    {

        static void Main(string[] args)
        {

            string path = args[0];
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
            
            Console.WriteLine(paths[paths.Length - 1].Contains('.') ? "Directory created successfully" : "Directory + Files created successfully!");
        }
    }
}