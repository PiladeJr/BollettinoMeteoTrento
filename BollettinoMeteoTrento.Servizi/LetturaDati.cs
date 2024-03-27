using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BollettinoMeteoTrento.Modelli;

namespace BollettinoMeteoTrento.Servizi
{
    public  class LetturaDati
    {
        public async Task<List<PrevisioniBollettinoMeteoTrento>> Lettura()
        {
            string result = "";
            List<PrevisioniBollettinoMeteoTrento> lista = new List<PrevisioniBollettinoMeteoTrento>();
            string Uri = "https://www.meteotrentino.it/protcivtn-meteo/api/front/previsioneOpenDataLocalita?localita=TRENTO";
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync(Uri))
                {
                    using (HttpContent content = response.Content)
                    {
                        result = await content.ReadAsStringAsync();
                    }
                }
            }

            RootBollettino bollettino = JsonConvert.DeserializeObject<RootBollettino>(result);
            foreach (Previsione previsione in bollettino.previsione)
            {
                foreach (Giorni giorno in previsione.giorni)
                {
                    foreach (Fasce fascia in giorno.fasce)
                    {
                        PrevisioniBollettinoMeteoTrento output = new PrevisioniBollettinoMeteoTrento()
                        {
                            giorno = giorno.giorno,
                            descIcona = fascia.descIcona,
                            fascia = fascia.fasciaPer,
                            tMinGiorno = giorno.tMinGiorno,
                            tMaxGiorno = giorno.tMaxGiorno,
                            icona = fascia.icona,
                            iconaVentoQuota = fascia.iconaVentoQuota,
                            descVentoIntQuota = fascia.descVentoIntQuota,
                            descPrecProb = fascia.descPrecProb
                        };
                        lista.Add(output);
                    }
                }
            }
            return lista;
        }

    }

}
