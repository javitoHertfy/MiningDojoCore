using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Api.HostedService
{
    public class LogOutRandomlyService : IHostedService
    {
        private Timer timer;
        private const int secondsToExecute = 10;

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
            Console.WriteLine("Executed");
        }
    }
}
