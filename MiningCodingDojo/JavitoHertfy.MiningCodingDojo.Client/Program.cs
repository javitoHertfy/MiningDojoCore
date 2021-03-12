using System;
using System.Net.Http;
using System.Threading;
using Newtonsoft.Json;
using RestSharp;

namespace JavitoHertfy.MiningCodingDojo.Client
{
    public class Program
    {
        private static string minerId = "0b361510-6f7b-43fb-99eb-f7c4b188f10a";

        static void Main(string[] args)
        {
            Console.WriteLine("Initializing miner!");

            var client = new RestClient("http://mining.azurewebsites.net/");

            if (string.IsNullOrWhiteSpace(minerId))
            {
                var request = new RestRequest("api/miner", DataFormat.Json);
                request.AddJsonBody(new Miner() { Name = "Javi" });
                client.Post(request);
            }
            do
            {
                if (!GetMiner(client, minerId))                
                    SignUp(client);                  
                
                var quantity = Mine(client);
                Save(client, quantity);
                Thread.Sleep(2000);
                
            } while (true);
           

        }

        public static  bool GetMiner(RestClient client, string minerId)
        {
            var requestGet = new RestRequest($"api/miner/{minerId}", DataFormat.Json);        
            var responseSignUp = client.Get(requestGet);

            var miner = JsonConvert.DeserializeObject<MinerResponse>(responseSignUp.Content);
            if (!miner.IsLogged)
                Console.WriteLine("Uppss I haven't logged into the mine");
            return responseSignUp.IsSuccessful && miner.IsLogged;
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
            var requestMine = new RestRequest($"/api/GoldMine/Dig/{minerId}", DataFormat.Json);
            

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
                    Console.WriteLine("Something went wrong in the mine...");
                SignUp(client);

            } while (!responseMine.IsSuccessful);

            return 0;

        }

        private static int Save(RestClient client, int quantity)
        {
            var requestSave = new RestRequest($"/api/Miner/SaveGold/{minerId}", DataFormat.Json);
            
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
                    Console.WriteLine("Something went wrong in my pocket...");
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
