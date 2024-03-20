using BollettinoMeteoTrento.Modelli;
using Newtonsoft.Json;
using System.ServiceModel;

namespace BollettinoMeteoTrento.SOAP.BusinessLogic
{
    // Definizione dell'interfaccia del servizio SOAP
    [ServiceContract]
    public interface ISOAPService
    {
        // Metodo per ottenere le previsioni per un determinato giorno
       [OperationContract]
        Giorni OttieniPrevisione(string previsione);
     //   [OperationContract]
     //   PrevisioniBollettinoMeteoTrento OttieniPrevisione(string giornoCercato);
    }
    
    // Implementazione del servizio SOAP
    public class ServizioSOAP: ISOAPService
    {
        public Giorni OttieniPrevisione(string giornoCercato)
        {
            string uri = "https://www.meteotrentino.it/protcivtn-meteo/api/front/previsioneOpenDataLocalita?localita=TRENTO";

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.GetAsync(uri).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        string result = content.ReadAsStringAsync().Result;
                        RootBollettino modello = JsonConvert.DeserializeObject<RootBollettino>(result);
                        foreach (var previsione in modello.previsioneGiorno)
                        {
                            return previsione.ListaGiorni.First(giorni => giorni.giorno.Equals(giornoCercato, StringComparison.Ordinal));
                        }
                    }
                        
                }
            }
                return null;
        }

















        /*
        // Metodo per ottenere le previsioni per un determinato giorno
        public Giorni OttieniPrevisione(string giornoCercato)
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
                        foreach (var previsione in modello.previsioneGiorno)
                        {
                            // Restituzione della previsione del giorno cercato se trovata
                            return previsione.ListaGiorni.First(giorni => giorni.giorno.Equals(GiornoCercato));
                        }
                    }
                }
            }
            // Restituzione di null se la previsione per il giorno cercato non è stata trovata
            return null;
        }*/
    }
}