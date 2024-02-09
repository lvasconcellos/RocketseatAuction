using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RocketseatAuction.API.Entities
{
    [Table("items")]
    public class Item
    {
        public int Id { get; set; }

        [MaxLength(50)] public string Name { get; set; } = default!;

        [MaxLength(50)] public string Brand { get; set; } = default!;

        public int Condition { get; set; }

        public decimal BestPrice { get; set; }

        public int AuctionId { get; set; }
    }
}
