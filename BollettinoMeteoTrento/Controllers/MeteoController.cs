using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BollettinoMeteoTrento.Modelli;
using Newtonsoft.Json;
using System;
using System.Reflection.Metadata;
using BollettinoMeteoTrento.Servizi;
using BollettinoMeteoTrento.ViewModels;
using BollettinoMeteoTrento.SOAP.BusinessLogic;




namespace BollettinoMeteoTrento.Controllers;

public class MeteoController : Controller
{
    [HttpGet("/LetturaBollettinoTrento")]
    public async Task<IActionResult> LetturaBollettinoTrento()
    {
        LetturaDati letturaDati = new LetturaDati();
        List<PrevisioniBollettinoMeteoTrento> listaDatiMeteo = letturaDati.Lettura().Result;
        MeteoLetturaBollettinoTrentoVM vm = new MeteoLetturaBollettinoTrentoVM();
        {
            vm.modello = listaDatiMeteo;
        }
        return View(vm);
    }

}