using BollettinoMeteoTrento.Modelli;
using Newtonsoft.Json;
using System.ServiceModel;
using BollettinoMeteoTrento.Servizi;
using System.Globalization;

namespace BollettinoMeteoTrento.SOAP.BusinessLogic
{
    // Definizione dell'interfaccia del servizio SOAP
    [ServiceContract]
    public interface ISOAPService
    {
        [OperationContract]
        List<PrevisioniBollettinoMeteoTrento> ricerca(string giornoCercato);
    }

    // Implementazione del servizio SOAP
    public class ServizioSOAP : ISOAPService
    {
        public List<PrevisioniBollettinoMeteoTrento> ricerca(string giornoCercato)
        {
            // Lista che conterrà i risultati della ricerca
            List<PrevisioniBollettinoMeteoTrento> listaTotale = new List<PrevisioniBollettinoMeteoTrento>();
            LetturaDati servizi = new LetturaDati();

            // Esegui la chiamata asincrona per ottenere i dati di previsione meteo
            listaTotale = servizi.Lettura().Result;

            // Controlla se la data cercata è stata fornita
            if (!string.IsNullOrEmpty(giornoCercato))
            {
                // Filtra i risultati per trovare le previsioni per la data cercata
                List<PrevisioniBollettinoMeteoTrento> listaGiornoCercato =
                    listaTotale.Where(p => p.giorno.Equals(giornoCercato)).ToList();

                // Restituisci le previsioni trovate
                return listaGiornoCercato;
            }
            else
            {
                // Se la data cercata non è stata fornita, restituisci tutte le previsioni
                return listaTotale;
            }
        }
    }
}