using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.UseCases.Auctions.GetCurrent
{
    public interface IGetCurrentAuctionUseCase
    {
        Auction? Execute();
    }
}
