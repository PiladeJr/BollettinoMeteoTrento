using BollettinoMeteoTrento.Modelli;

namespace BollettinoMeteoTrento.ViewModels
{
    public class LetturaPrevisioniMeteo
    {
        // Proprietà pubblica chiamata 'modello' di tipo Root, rappresenta il modello o la struttura dati delle previsioni meteo
        public Root modello { get; set; }

        // Costruttore della classe che accetta un parametro di tipo Root chiamato 'modello'
        public LetturaPrevisioniMeteo(Root modello)
        {
            // Inizializzazione della proprietà 'modello' con il valore passato come parametro nel costruttore
            this.modello = modello;
        }
    }
}
