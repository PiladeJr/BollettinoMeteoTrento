using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BollettinoMeteoTrento.Modelli;
using Newtonsoft.Json;
using System;
using System.Reflection.Metadata;
using BollettinoMeteoTrento.Servizi;
using BollettinoMeteoTrento.ViewModels;

namespace BollettinoMeteoTrento.Controllers;

public class MeteoController : Controller
    {
        public async Task <IActionResult> LetturaBollettinoTrento()
        {
            List <PrevisioniBollettinoMeteoTrento> listaDatiMeteo = LetturaDati.Lettura().Result;
            MeteoLetturaBollettinoTrentoVM vm = new MeteoLetturaBollettinoTrentoVM();
            { 
                vm.modello = listaDatiMeteo;
            }
            return View(vm);
        }
        
    }