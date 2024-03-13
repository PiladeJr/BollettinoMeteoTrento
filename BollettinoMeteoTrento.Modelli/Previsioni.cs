using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BollettinoMeteoTrento.Modelli
{
    public class Previsione
    {
        public string localita { get; set; }
        public int quota { get; set; }
        public List<Giorni> giorni { get; set; }
    }
}
