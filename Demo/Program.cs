using System;
using System.Threading.Tasks;

namespace Demo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.Write("Type 1 to run the full demo, 2 to run the KeyVault demo: ");
            var program = Console.ReadLine();

            switch (program)
            {
                case "1":
                    await FullDemo.Run();
                    break;

                case "2":
                    await KeyVaultDemo.Run();
                    break;

                default:
                    Console.WriteLine("Invalid input.");
                    await Main(default);
                    break;
            }
        }
    }
}