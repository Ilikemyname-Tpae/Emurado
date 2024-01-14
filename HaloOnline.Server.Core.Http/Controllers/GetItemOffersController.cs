﻿using HaloOnline.Server.Core.Http.Model.User;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Web.Http;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [RoutePrefix("UserService.svc")]
    public class GetItemOffersController : ApiController
    {
        [HttpPost]
        [Route("GetItemOffers")]
        public IHttpActionResult GetItemOffers(GetItemOffersRequest request)
        {
            try
            {
                var result = new
                {
                    GetItemOffersResult = new
                    {
                        retCode = 0,
                        data = GetItemOffersDataFromDatabase()
                    }
                };
                return Ok(result);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        private List<object> GetItemOffersDataFromDatabase()
        {
            List<object> itemOffersList = new List<object>();
            using (var connection = new SQLiteConnection("Data Source=halodb.sqlite"))
            {
                connection.Open();
                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = @"
                        SELECT
                            io.ItemId,
                            io.Requirements,
                            io.Unlocks,
                            io.UnlockedLevel,
                            io.Currency,
                            io.Price,
                            io.ExpireAt,
                            io.SalePrice,
                            io.SaleExpireAt,
                            bi.Duration AS BundleDuration,
                            bi.ItemId AS BundleItemId,
                            ol.Duration AS OfferLineDuration,
                            o.Currency AS OfferCurrency,
                            o.Price AS OfferPrice,
                            o.ExpireAt AS OfferExpireAt,
                            o.SalePrice AS OfferSalePrice,
                            o.SaleExpireAt AS OfferSaleExpireAt
                        FROM ItemOffers io
                        LEFT JOIN BundleItems bi ON io.Id = bi.OfferId
                        LEFT JOIN OfferLine ol ON io.Id = ol.OfferId
                        LEFT JOIN Offers o ON io.Id = o.OfferId";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var itemOffer = new
                            {
                                ItemId = reader["ItemId"].ToString(),
                                Requirements = new List<string>
                                {
                                    reader["Requirements"].ToString()
                                },
                                Unlocks = new List<string>
                                {
                                    reader["Unlocks"].ToString()
                                },
                                UnlockedLevel = Convert.ToInt32(reader["UnlockedLevel"]),
                                BundleItems = new List<object>(),
                                OfferLine = new List<object>()
                            };
                            if (reader["BundleDuration"] != DBNull.Value)
                            {
                                int bundleDuration = Convert.ToInt32(reader["BundleDuration"]);
                                string bundleItemId = reader["BundleItemId"].ToString();
                                var bundleItem = new
                                {
                                    Duration = bundleDuration,
                                    ItemId = bundleItemId
                                };
                                ((List<object>)itemOffer.BundleItems).Add(bundleItem);
                            }
                            if (reader["OfferLineDuration"] != DBNull.Value)
                            {
                                int offerLineDuration = Convert.ToInt32(reader["OfferLineDuration"]);
                                var offerLine = new
                                {
                                    Duration = offerLineDuration,
                                    Offers = new List<object>()
                                };
                                if (reader["OfferCurrency"] != DBNull.Value)
                                {
                                    string offerCurrency = reader["OfferCurrency"].ToString();
                                    int offerPrice = Convert.ToInt32(reader["OfferPrice"]);
                                    long offerExpireAt = Convert.ToInt64(reader["OfferExpireAt"]);
                                    int offerSalePrice = Convert.ToInt32(reader["OfferSalePrice"]);
                                    long offerSaleExpireAt = Convert.ToInt64(reader["OfferSaleExpireAt"]);
                                    var offer = new
                                    {
                                        OfferId = reader["ItemId"].ToString(),
                                        Currency = offerCurrency,
                                        Price = offerPrice,
                                        ExpireAt = offerExpireAt,
                                        Sale = new
                                        {
                                            Price = offerSalePrice,
                                            ExpireAt = offerSaleExpireAt
                                        }
                                    };
                                    ((List<object>)offerLine.Offers).Add(offer);
                                }
                                ((List<object>)itemOffer.OfferLine).Add(offerLine);
                            }
                            ((List<object>)itemOffersList).Add(itemOffer);
                        }
                    }
                }
            }
            return itemOffersList;
        }

        public class ItemOfferData
        {
            public string ItemId { get; set; }
            public string Requirements { get; set; }
            public string Unlocks { get; set; }
            public int UnlockedLevel { get; set; }
            public string Currency { get; set; }
            public int Price { get; set; }
            public long ExpireAt { get; set; }
            public List<BundleItem> BundleItems { get; set; }
            public List<OfferLine> OfferLines { get; set; }
            public List<Offer> Offers { get; set; }
        }

        public class BundleItem
        {
            public int Duration { get; set; }
            public string ItemId { get; set; }
        }

        public class OfferLine
        {
            public int Duration { get; set; }
            public List<object> Offers { get; set; }
        }

        public class Offer
        {
            public string OfferId { get; set; }
            public string Currency { get; set; }
            public int Price { get; set; }
            public long ExpireAt { get; set; }
            public Sale Sale { get; set; }
        }

        public class Sale
        {
            public int Price { get; set; }
            public long ExpireAt { get; set; }
        }
    }
}