using SoapCore;
using BollettinoMeteoTrento.SOAP.BusinessLogic;

var builder = WebApplication.CreateBuilder(args);

builder. Services. AddSoapCore();
builder.Services.AddScoped<ISoapService, SoapService>0);

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.UseSoapEndpoint<ISOAPService>("/Service.wsdl", new SoapEncoderOptions(), SoapSerializer.XmlSerializer);
});

app.Run();

//app.MapGet("/", () => "Hello World!");

app.Run();
