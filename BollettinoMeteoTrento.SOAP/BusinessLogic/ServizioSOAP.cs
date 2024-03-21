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
        List<PrevisioniBollettinoMeteoTrento> ricerca(string giornoCercato, DateOnly giornoCercato2);
    }

    // Implementazione del servizio SOAP
    public class ServizioSOAP : ISOAPService
    {
        public List<PrevisioniBollettinoMeteoTrento> ricerca(string giornoCercato, DateOnly giornoCercato2)
        {
            // Lista che conterrà i risultati della ricerca
            List<PrevisioniBollettinoMeteoTrento> listaTotale = new List<PrevisioniBollettinoMeteoTrento>();

            // Esegui la chiamata asincrona per ottenere i dati di previsione meteo
            listaTotale = BollettinoMeteoTrento.Servizi.LetturaDati.Lettura().Result;

            // Controlla se la data cercata è stata fornita
            if (!string.IsNullOrEmpty(giornoCercato2.ToString()))
            {
                // Filtra i risultati per trovare le previsioni per la data cercata
                List<PrevisioniBollettinoMeteoTrento> listaGiornoCercato =
                    listaTotale.Where(p => p.giorno.Equals(giornoCercato2.ToString())).ToList();

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