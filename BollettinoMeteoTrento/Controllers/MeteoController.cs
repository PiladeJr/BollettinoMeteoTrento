using BollettinoMeteoTrento.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BollettinoMeteoTrento.Modelli;
using Newtonsoft.Json;
using System;
using System.Reflection.Metadata;

namespace BollettinoMeteoTrento.Controllers;

public class MeteoController : Controller
    {
        private Root carica()
        {
            string url = "https://www.meteotrentino.it/protcivtn-meteo/api/front/previsioneOpenDataLocalita?localita=TRENTO";
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = client.GetAsync(url).Result)
                {
                    using (HttpContent content = response.Content)
                    {
                        string result =  content.ReadAsStringAsync().Result;
                        Root modello = JsonConvert.DeserializeObject<Root>(result);
                        return modello;

                    }
                }
            }
        }
        public IActionResult Index()
        {
            Root modello = this.carica();
            LetturaPrevisioniMeteo vm = new LetturaPrevisioniMeteo(modello);
            return View(vm);
        }
    }