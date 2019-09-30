using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AuctionApp.Controllers.Models;
using AuctionApp.Services;
using Microsoft.Extensions.Configuration;

namespace AuctionApp.Controllers
{
    [ApiController]
    [Route("api/Auction")]
    public class AuctionController : ControllerBase
    {
        private static IConfiguration _configuration;
        private static DataLayer dataLayer;

        public AuctionController(IConfiguration configuration)
        {
            _configuration = configuration;
            dataLayer = new DataLayer(_configuration);
        }
            // GET: api/values
            [HttpGet]
        public List<Product> Get()
        {
            return dataLayer.GetProducts();
        }

        [Route("GetMemberBids")]
        [HttpGet]
        public IActionResult GetMemberBids(int id)
        {
            return new JsonResult(new { memberBids = dataLayer.GetMemberBids(id) });
        }

        [HttpGet("{id}")]
        public List<int> Get(int id)
        {
            return dataLayer.GetMemberBids(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]MemberBid memberBid)
        {
            dataLayer.UpdateMemberBid(memberBid);
        }
    }
}
