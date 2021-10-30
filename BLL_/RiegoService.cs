using System;
using System.Linq;

namespace BLL_
{
    public class RiegoService
    {

        public int GenerarRandom(int inicio, int final)
        {         
            var guid = Guid.NewGuid();
            var justNumbers = new String(guid.ToString().Where(Char.IsDigit).ToArray());
            var seed = int.Parse(justNumbers.Substring(0, 4));

            var random = new Random(seed);
            var value = random.Next(inicio, final);

            return value;
        }


        public int retorna()
        {
            return 0;
        }
     
    }
}
