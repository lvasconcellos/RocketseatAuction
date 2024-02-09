using Microsoft.AspNetCore.Mvc;
using RocketseatAuction.API.Entities;
using RocketseatAuction.API.UseCases.Auctions.GetCurrent;

namespace RocketseatAuction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuctionController : ControllerBase
    {
        private readonly IGetCurrentAuctionUseCase useCase;
        private readonly ILogger<AuctionController> logger;

        public AuctionController(
            IGetCurrentAuctionUseCase useCase,
            ILogger<AuctionController> logger)
        {
            this.useCase = useCase;
            this.logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(Auction), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetCurrentAuction()
        {
            this.logger.LogInformation("Getting current auction");

            var result = this.useCase.Execute();

            if (result != null)
            {
                return this.Ok(result);
            }

            this.logger.LogInformation("No auction found");
            return this.NoContent();
        }
    }
}
