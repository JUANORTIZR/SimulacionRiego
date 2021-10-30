using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Riego
    {
        public string Id { get; set; }
        public float Tiempo { get; set; }
        public float Precion { get; set; }
        public float Alcance { get; set; }
        public  string Aspersor { get; set; }

        public string Activar(Ambiente ambiente)
        {
            
            if (ambiente.Temperatura > 40 || ambiente.Humedad < 20)
            {
                    return "Riego activo, por las condiciones ambientales.\n\t\t\t\tEn este momento el riego es necesario.";
            }

            return "Riego inactivo, por las condiciones ambientales.\n\t\t\t\tEn este momento el riego no es necesario.";
        }
    }
}
