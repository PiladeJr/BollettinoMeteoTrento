using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BollettinoMeteoTrento.Modelli
{
    public class Root
    { 
        [JsonProperty("fonte-da-citare")]
        public string fontedacitare { get; set; }

        [JsonProperty("codice-ipa-titolare")]
        public string codiceipatitolare { get; set; }

        [JsonProperty("nome-titolare")]
        public string nometitolare { get; set; }

        [JsonProperty("codice-ipa-editore")]
        public string codiceipaeditore { get; set; }

        [JsonProperty("nome-editore")]
        public string nomeeditore { get; set; }
        public string dataPubblicazione { get; set; }
        public int idPrevisione { get; set; }
        public string evoluzione { get; set; }
        public string evoluzioneBreve { get; set; }
        public List<object> AllerteList { get; set; }
        public List<Previsione> previsione { get; set; }
    }
}
