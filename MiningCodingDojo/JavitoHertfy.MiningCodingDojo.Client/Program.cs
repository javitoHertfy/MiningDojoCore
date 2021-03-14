using System;
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

        static void Main(string[] args)
        {
            var totalQuantity = 0;
            var shouldContinue = true;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var client = new RestClient("http://mining.azurewebsites.net/");
            SignUp(client);           
            do
            {
                var quantity = Mine(client);
                if(quantity > 0)
                {
                    Save(client, quantity);
                    totalQuantity += quantity;
                }                    
                if (totalQuantity > 500)
                {
                    stopwatch.Stop();
                    shouldContinue = false;
                }                    

            } while (shouldContinue);

            Console.WriteLine($"It took {stopwatch.ElapsedMilliseconds} to mine 1000");
        }       
        private static bool SignUp(RestClient client)
        {
            var requestSignUp = new RestRequest($"api/miner/signup/{minerId}", DataFormat.Json);
            var responseSignUp = default(IRestResponse);

            do
            {
                responseSignUp = client.Put(requestSignUp);
                if (responseSignUp.IsSuccessful)
                {
                    if (bool.Parse(responseSignUp.Content))
                        Console.WriteLine("Now I am in the mine!");
                }
                else
                {
                    Console.WriteLine("Something went wrong entering in the mine");
                }

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
                    var gold = int.Parse(responseMine.Content);
                    Console.WriteLine($"Uray! I mined {gold}");
                    return gold;
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
            
            requestSave.AddQueryParameter("quantity", quantity.ToString());

            var responseSave = default(IRestResponse);
            do
            {
                responseSave = client.Put(requestSave);
                if (responseSave.IsSuccessful)
                {
                    Console.WriteLine($"Now {quantity} gold is in my pocket!!");
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

    public class MinerResponse
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Handicap { get; set; }
        public bool IsLogged { get; set; }
    }
     

}
