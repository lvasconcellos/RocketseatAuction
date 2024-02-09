using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RocketseatAuction.API.Entities
{
    public class Auction
    {
        public int Id { get; set; }

        [MaxLength(50)] public string Name { get; set; } = default!;

        public DateTime Starts { get; set; }

        public DateTime Ends { get; set; }

        public List<Item> Items { get; set; } = [];
    }
}
