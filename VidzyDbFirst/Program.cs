using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VidzyDbFirst
{

    public class Program
    {

        public enum Classification : byte { Silver = 0 , Gold = 1, Platinum = 2 };
        static void Main(string[] args)
        {
            var context = new VidzyEntities();
            context.AddVideo("Custom2", DateTime.Now, "Family", (byte)Classification.Gold);
            Console.WriteLine("Added");
            Console.ReadLine(); 
        }
    }

    
}
