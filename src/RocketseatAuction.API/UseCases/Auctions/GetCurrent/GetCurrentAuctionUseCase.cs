using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Data;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.UseCases.Auctions.GetCurrent
{
    public class GetCurrentAuctionUseCase : IGetCurrentAuctionUseCase
    {
        private readonly AuctionDbContext dbContext;
        private readonly ILogger<GetCurrentAuctionUseCase> logger;

        public GetCurrentAuctionUseCase(
            AuctionDbContext dbContext,
            ILogger<GetCurrentAuctionUseCase> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }

        public Auction? Execute()
        {
            var result = this.dbContext
                .Auctions
                .Include(auction => auction.Items)
                .OrderByDescending(auction => auction.Starts)
                .FirstOrDefault();

            if (result is not null)
            {
                this.logger.LogInformation("Auction found: {0}", result.Name);
            }

            return result;
        }
    }
}