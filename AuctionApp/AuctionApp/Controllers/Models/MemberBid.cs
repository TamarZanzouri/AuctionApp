using System;
namespace AuctionApp.Controllers.Models
{
    public class MemberBid
    {
        public int MemberId { get; set; }
        public int ItemId { get; set; }
        public int BidAmount { get; set; }

        public MemberBid()
        {
        }
    }
}
