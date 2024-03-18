using SoapCore;
using BollettinoMeteoTrento.SOAP.BusinessLogic;

var builder = WebApplication.CreateBuilder(args);

builder. Services. AddSoapCore();
builder.Services.AddScoped<ISOAPService, ServizioSOAP>();

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.UseSoapEndpoint<ISOAPService>("/Service.wsdl", new SoapEncoderOptions(), SoapSerializer.XmlSerializer);
});

app.Run();

//app.MapGet("/", () => "Hello World!");


