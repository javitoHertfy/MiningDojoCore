using JavitoHertfy.MiningCodingDojo.WebApi.Application.Services.Contracts;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Linq;
using System.Threading.Tasks;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Api.HostedService
{
    public class LogOutRandomlyService : IHostedService
    {
        private readonly IMinerAppService iMinerAppService;
        public LogOutRandomlyService(IMinerAppService iMinerAppService)
        {
            this.iMinerAppService = iMinerAppService;
        }

        private Timer timer;
        private const int secondsToExecute = 5;

        public Task StartAsync(CancellationToken cancellationToken)
        {           

            this.timer = new Timer(this.SignUpRandomly, null,
                TimeSpan.FromSeconds(secondsToExecute),
                TimeSpan.FromSeconds(secondsToExecute));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private void SignUpRandomly(object state)
        {
            var miners = this.iMinerAppService.GetAsync().Result.ToList();
            var numberOfMiners = miners.Count();
            if(numberOfMiners > 0)
            {
                var random = new Random();
                var minerToBeLoggedOut = random.Next(0, numberOfMiners - 1);

                var miner = miners[minerToBeLoggedOut];

                iMinerAppService.LogOutAsync(miner.Id).Wait();
            }
        }
    }
}
