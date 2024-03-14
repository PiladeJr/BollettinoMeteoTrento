using BollettinoMeteoTrento.Modelli;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BollettinoMeteoTrento_.SOAP.BusinessLogic
{

    [ServiceContract]
    public interface ISOAPService
    {
        [OperationContract]
        Giorni OttieniPrevisione(string data);
    }

    public class SoapService : ISOAPService
    {
        public Giorni OttieniPrevisione(string data)
        {
            string uri = "https://www.meteotrentino.it/protcivtn-meteo/api/front/previsioneOpenDataLocalita?localita=TRENTO";
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.GetAsync(uri).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        string result = content.ReadAsStringAsync().Result;
                        Root modello = JsonConvert.DeserializeObject<Root>(result);
                        foreach (var previsione in modello.previsione)
                        {
                            return previsione.giorni.First(giorni => giorni.giorno.Equals(data));
                        }
                    }
                }
            }
            return null;
        }
    }
}