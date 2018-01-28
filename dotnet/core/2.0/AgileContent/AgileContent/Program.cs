using System;

namespace AgileContent
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ex 1
            new Core.Sibling().GetBiggestSibling(355);

            //Ex 2
            if (args.Length == 2)
            {
                if (new Core.CDN().Converter("MINHA CDN", args[0], args[1]))
                    Console.WriteLine($"{args[1]} wrote sucessfully");
            }
            else
            {
                var target = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\AgileContentCDN.txt";

                if (new Core.CDN().Converter("MINHA CDN", "https://s3.amazonaws.com/uux-itaas-static/minha-cdn-logs/input-01.txt", target))
                    Console.WriteLine($"{target} wrote sucessfully");
            }
        }
    }
}
