using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JavitoHertfy.MiningCodingDojo.WebApi.Infrastructure.Database.Implementations
{
    public class DatabaseFactory : IDatabaseFactory
    {
        private readonly IOptionsMonitor<PostDbOptions> iPostDbOptions;

        public DatabaseFactory(IOptionsMonitor<PostDbOptions> iPostDbOptions)
        {
            this.iPostDbOptions = iPostDbOptions ?? throw new ArgumentNullException(nameof(iPostDbOptions));
        }

        public IPostDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<PostDbContext>()
                   .UseSqlServer(this.iPostDbOptions.CurrentValue.ConnectionString)
                   .Options;

            var result = new PostDbContext(options);
            return result;
        }
    }
}
