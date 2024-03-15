using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPark
{
    public class Park
    {
        // Propriedades baseadas em endereços espanhóis
        public string Street { get; set; } // Calle
        public string Number { get; set; } // Número
        public string AdditionalInfo { get; set; } // Información adicional
        public string City { get; set; } // Ciudad
        public string Province { get; set; } // Provincia
        public string ZIPCODE { get; set; } // Código Postal
        public string Country { get; set; } = "España"; // País, predefinido como España
    }
}
