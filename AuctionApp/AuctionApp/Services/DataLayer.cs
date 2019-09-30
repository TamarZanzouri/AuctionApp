using System;
using Microsoft.Extensions.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using Dapper;
using AuctionApp.Controllers.Models;
using System.Collections.Generic;
using System.Linq;

namespace AuctionApp.Services
{
    public class DataLayer
    {
        private static IConfiguration _configuration;
        public DataLayer(IConfiguration configuration)
        {
            if(configuration != null)
                _configuration = configuration;
        }

        public List<int> GetMemberBids(int memberId)
        {
            var sql = @"select ProductId from MemberToBid
                        Inner join Product on Product.Id = MemberToBid.ProductId
                        where memberId = @MemeberId and Product.EndDate is not NULL";

            var result = new List<int>();

            try
            {
                using(var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();

                    result = connection.Query<int>(sql, new {
                        MemeberId = memberId
                    }).ToList();

                }
            }
            catch(Exception ex)
            {
                throw;
            }
            return result;
        }

        public List<Product> GetProducts()
        {
            var result = new List<Product>();
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    var sql = @"SELECT Id, Name, Image, EndDate  
                                           FROM Product
                                           WHERE EndDate >= getdate() OR EndDate is null";
                    connection.Open();

                    result = connection.Query<Product>(sql,
                                            new
                                            {
                                            }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return result;
        }

        public void UpdateMemberBid(MemberBid memberBid)
        {
            string sql = "INSERT INTO MemberToBid (MemberId, ProductId, BidAmount, ActiveFrom) Values (@MemberId, @ProductId, @BidAmount, getdate());";
            try
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = connection.Execute(sql, new
                    {
                        memberBid.MemberId,
                        ProductId = memberBid.ItemId,
                        memberBid.BidAmount
                    });

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
