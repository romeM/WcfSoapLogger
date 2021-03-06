﻿using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Configuration;
using System.ServiceModel.Description;
using CommonService;
using WcfSoapLogger.EncodingExtension;

namespace Service
{
    static class Program
    {
        private static void Main() {
            Console.Title = "ExampleEpsilon.Service";
     
            const string baseAddress  ="http://localhost:5580/weatherService";
            var serviceHost = new ServiceHost(typeof(WeatherServiceEurope), new Uri(baseAddress));

            serviceHost.Description.Behaviors.Find<ServiceDebugBehavior>().IncludeExceptionDetailInFaults = true;

            var metadataBehavior = new ServiceMetadataBehavior();
            metadataBehavior.HttpGetEnabled = true;
            serviceHost.Description.Behaviors.Add(metadataBehavior);

            serviceHost.AddServiceEndpoint(ServiceMetadataBehavior.MexContractName, MetadataExchangeBindings.CreateMexHttpBinding(), "mex");

            string logPath = @"C:\SoapLog\Epsilon\Service";
            string useCustomHandler = Boolean.FalseString;

            CustomBinding customBinding = new CustomBinding();
            customBinding.Elements.Add(new LoggingBindingElement(logPath, useCustomHandler));
            customBinding.Elements.Add(new HttpTransportBindingElement());

            serviceHost.AddServiceEndpoint(typeof(IWeatherService), customBinding, "");


            try
            {
                serviceHost.Open();
            }
            catch (AddressAccessDeniedException)
            {
                Console.WriteLine("ERROR. Please run this application with needed rights.");
                throw;
            }

            Console.WriteLine("Service started.");

            Console.WriteLine("Press Enter to stop.");
            Console.ReadLine();

            Console.WriteLine("Service is stopping...");
            serviceHost.Close();

            Console.WriteLine("Service stopped.");
            Console.WriteLine();
        }
    }
}
