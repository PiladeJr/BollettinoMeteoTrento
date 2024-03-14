using BollettinoMeteoTrento.Modelli;
using Newtonsoft.Json;
using System.ServiceModel;

namespace BollettinoMeteoTrento_.SOAP.BusinessLogic
{
    // Definizione dell'interfaccia del servizio SOAP
    [ServiceContract]
    public interface ISOAPService
    {
        // Metodo per ottenere le previsioni per un determinato giorno
        [OperationContract]
        Giorni OttieniPrevisione(string previsione);
    }

    // Implementazione del servizio SOAP
    public class SoapService : ISOAPService
    {
        // Metodo per ottenere le previsioni per un determinato giorno
        public Giorni OttieniPrevisione(string GiornoCercato)
        {
            // URL dell'API per ottenere le previsioni meteo per la località di Trento
            string uri = "https://www.meteotrentino.it/protcivtn-meteo/api/front/previsioneOpenDataLocalita?localita=TRENTO";

            // Utilizzo di HttpClient per effettuare la richiesta HTTP
            using (HttpClient client = new HttpClient())
            {
                // Invio della richiesta GET all'API e attesa della risposta
                using (HttpResponseMessage response = client.GetAsync(uri).Result)
                {
                    // Estrazione del contenuto della risposta
                    using (HttpContent content = response.Content)
                    {
                        // Lettura dei dati come stringa
                        string result = content.ReadAsStringAsync().Result;

                        // Deserializzazione della risposta JSON in un oggetto RootBollettino
                        RootBollettino modello = JsonConvert.DeserializeObject<RootBollettino>(result);

                        // Iterazione attraverso le previsioni per trovare quella corrispondente al giorno cercato
                        foreach (var previsione in modello.previsione)
                        {
                            // Restituzione della previsione del giorno cercato se trovata
                            return previsione.giorni.First(giorni => giorni.giorno.Equals(GiornoCercato));
                        }
                    }
                }
            }
            // Restituzione di null se la previsione per il giorno cercato non è stata trovata
            return null;
        }
    }
}