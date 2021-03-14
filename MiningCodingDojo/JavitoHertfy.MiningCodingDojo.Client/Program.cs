using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace JavitoHertfy.MiningCodingDojo.Client
{
    public class Program
    {
        private static string minerId = "0b361510-6f7b-43fb-99eb-f7c4b188f10a";
        private static int totalQuantity = 0;
        static void Main(string[] args)
        {
          
            var shouldContinue = true;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var client = new RestClient("http://mining.azurewebsites.net/");
            SignUp(client);           

            do
            {
                var quantity = Mine(client);
                if (quantity > 0)
                {
                    Save(client, quantity);
                    totalQuantity += quantity;
                }
                if (totalQuantity > 500)
                {
                    stopwatch.Stop();
                    shouldContinue = false;
                    Console.WriteLine($"It took {stopwatch.ElapsedMilliseconds} to mine 500");
                }

            } while (shouldContinue);

        }       
        private static bool SignUp(RestClient client)
        {
            var requestSignUp = new RestRequest($"api/miner/signup/{minerId}", DataFormat.Json);
            var responseSignUp = default(IRestResponse);
            do
            {
                responseSignUp = client.Put(requestSignUp);                

            } while (responseSignUp.IsSuccessful);

            return true;
           
        }
        private static int Mine(RestClient client)
        {
            var requestMine = new RestRequest($"/api/GoldMine/Dig/0b361510-6f7b-43fb-99eb-f7c4b188f10a", DataFormat.Json);    
            var responseMine = default(IRestResponse);
            do
            {
                responseMine = client.Put(requestMine);
                if (responseMine.IsSuccessful)
                {                                     
                    return int.Parse(responseMine.Content); ;
                }
                else
                    if(responseMine.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                        SignUp(client);

            } while (!responseMine.IsSuccessful);

            return 0;

        }
        private static int Save(RestClient client, int quantity)
        {
            var requestSave = new RestRequest($"/api/Miner/SaveGold/0b361510-6f7b-43fb-99eb-f7c4b188f10a?quantity={quantity}", DataFormat.Json);
            var responseSave = default(IRestResponse);
            do
            {
                responseSave = client.Put(requestSave);
                if (responseSave.IsSuccessful)
                {                    
                    return quantity;
                }
                else
                    if (responseSave.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                        SignUp(client);

            } while (!responseSave.IsSuccessful);

            return 0;

        }
    }

    public class Miner
    {
        public string Name { get; set; }
    } 

}
