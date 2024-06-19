using System.Collections.Generic;
using System.Web.Http;
using HaloOnline.Server.Core.Http.Model.User;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [RoutePrefix("UserService.svc")]
    public class GetItemOffersController : ApiController
    {
        [HttpPost]
        [Route("GetItemOffers")]
        public IHttpActionResult GetItemOffers(GetItemOffersRequest request)
        {
            var result = new
            {
                GetItemOffersResult = new
                {
                    retCode = 0,
                    data = new List<object>
            {
                new
                {
                    ItemId = "ranger_kit_offer",
                    Requirements = new List<string> { "" },
                    Unlocks = new List<string> { "" },
                    BundleItems = new List<object>
                    {
                        new
                        {
                            Duration = 0,
                                ItemId = "assault_rifle_v2"
                        }
                    },
                    UnlockedLevel = 0,
                    OfferLine = new List<object>
                    {
                        new
                        {
                            Duration = 0,
                            Offers = new List<object>
                            {
                                new
                                {
                                    OfferId = "ranger_kit_offer",
                                    Currency = "gold",
                                    Price = 0,
                                    ExpireAt = 0,
                                    Sale = new
                                    {
                                        Price = 0,
                                        ExpireAt = 0
                                    }
                                },
                            }
                        }
                    }
                },
                new
                {
                    ItemId = "sniper_kit_offer",
                    Requirements = new List<string> { "" },
                    Unlocks = new List<string> { "" },
                    BundleItems = new List<object>
                    {
                        new
                        {
                            Duration = 0,
                                ItemId = "assault_rifle_v2"
                        }
                    },
                    UnlockedLevel = 0,
                    OfferLine = new List<object>
                    {
                        new
                        {
                            Duration = 0,
                            Offers = new List<object>
                            {
                                new
                                {
                                    OfferId = "sniper_kit_offer",
                                    Currency = "gold",
                                    Price = 0,
                                    ExpireAt = 0,
                                    Sale = new
                                    {
                                        Price = 0,
                                        ExpireAt = 0
                                    }
                                },
                            }
                        }
                    }
                },
                new
                {
                    ItemId = "tactician_kit_offer",
                    Requirements = new List<string> { "" },
                    Unlocks = new List<string> { "" },
                    BundleItems = new List<object>
                    {
                        new
                        {
                            Duration = 0,
                                ItemId = "assault_rifle_v2"
                        }
                    },
                    UnlockedLevel = 0,
                    OfferLine = new List<object>
                    {
                        new
                        {
                            Duration = 0,
                            Offers = new List<object>
                            {
                                new
                                {
                                    OfferId = "tactician_kit_offer",
                                    Currency = "gold",
                                    Price = 0,
                                    ExpireAt = 0,
                                    Sale = new
                                    {
                                        Price = 0,
                                        ExpireAt = 0
                                    }
                                },
                            }
                        }
                    }
                },
                    
                        // Assault_rifles
                    new
                    {
                        ItemId = "assault_rifle_v2",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "assault_rifle_v2"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "assault_rifle_v2",
                                        Currency = "gold",
                                        Price = 75,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 75,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "assault_rifle_v2_cr",
                                        Currency = "cr",
                                        Price = 2000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 2000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "assault_rifle_v3",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "assault_rifle_v3"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "assault_rifle_v3",
                                        Currency = "gold",
                                        Price = 75,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 75,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "assault_rifle_v3_cr",
                                        Currency = "cr",
                                        Price = 2000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 2000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "assault_rifle_v5",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "assault_rifle_v5"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "assault_rifle_v5",
                                        Currency = "gold",
                                        Price = 75,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 75,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "assault_rifle_v5_cr",
                                        Currency = "cr",
                                        Price = 2000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 2000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "assault_rifle_v6",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "assault_rifle_v6"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "assault_rifle_v6",
                                        Currency = "gold",
                                        Price = 75,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 75,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "assault_rifle_v6_cr",
                                        Currency = "cr",
                                        Price = 2000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 2000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "battle_rifle",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "battle_rifle"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "battle_rifle",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "battle_rifle_cr",
                                        Currency = "cr",
                                        Price = 1400,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1400,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },

                    new
                    {
                        ItemId = "battle_rifle_v1",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "battle_rifle_v1"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "battle_rifle_v1",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "battle_rifle_v1_cr",
                                        Currency = "cr",
                                        Price = 1600,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1600,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "battle_rifle_v2",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "battle_rifle_v2"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "battle_rifle_v2",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "battle_rifle_v2_cr",
                                        Currency = "cr",
                                        Price = 1600,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1600,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "battle_rifle_v3",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "battle_rifle_v3"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "battle_rifle_v3",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "battle_rifle_v3_cr",
                                        Currency = "cr",
                                        Price = 1600,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1600,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "battle_rifle_v4",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "battle_rifle_v4"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "battle_rifle_v4",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "battle_rifle_v4_cr",
                                        Currency = "cr",
                                        Price = 1600,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1600,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "battle_rifle_v5",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "battle_rifle_v5"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "battle_rifle_v5",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "battle_rifle_v5_cr",
                                        Currency = "cr",
                                        Price = 1600,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1600,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "battle_rifle_v6",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "battle_rifle_v6"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "battle_rifle_v6",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "battle_rifle_v6_cr",
                                        Currency = "cr",
                                        Price = 1600,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1600,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "dmr_v1",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "dmr_v1"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "dmr_v1",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "dmr_v1_cr",
                                        Currency = "cr",
                                        Price = 1400,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1400,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "dmr_v2",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "dmr_v2"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "dmr_v2",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "dmr_v2_cr",
                                        Currency = "cr",
                                        Price = 1400,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1400,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "dmr_v3",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "dmr_v3"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "dmr_v3",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "dmr_v3_cr",
                                        Currency = "cr",
                                        Price = 1400,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1400,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "dmr_v4",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "dmr_v4"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "dmr_v4",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "dmr_v4_cr",
                                        Currency = "cr",
                                        Price = 1400,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1400,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "dmr_v5",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "dmr_v5"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "dmr_v5",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "dmr_v5_cr",
                                        Currency = "cr",
                                        Price = 1400,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1400,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "dmr_v6",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "dmr_v6"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "dmr_v6",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "dmr_v6_cr",
                                        Currency = "cr",
                                        Price = 1400,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1600,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                                        new
                    {
                        ItemId = "smg_v1",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "smg_v1"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "smg_v1",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "smg_v1_cr",
                                        Currency = "cr",
                                        Price = 1750,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1750,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },

                                        new
                    {
                        ItemId = "smg_v2",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "smg_v2"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "smg_v2",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "smg_v2_cr",
                                        Currency = "cr",
                                        Price = 1750,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1750,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "smg_v3",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "smg_v3"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "smg_v3",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "smg_v3_cr",
                                        Currency = "cr",
                                        Price = 1750,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1750,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "smg_v4",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "smg_v4"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "smg_v4",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "smg_v4_cr",
                                        Currency = "cr",
                                        Price = 1750,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1750,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "smg_v5",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "smg_v5"
                            }
                        },
                        UnlockedLevel = 2,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "smg_v5",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "smg_v5_cr",
                                        Currency = "cr",
                                        Price = 1750,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1750,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "smg_v6",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "smg_v6"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "smg_v6",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "smg_v6_cr",
                                        Currency = "cr",
                                        Price = 1750,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1750,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                                        new
                    {
                        ItemId = "covenant_carbine",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "covenant_carbine"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "covenant_carbine",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "covenant_carbine_cr",
                                        Currency = "cr",
                                        Price = 1400,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1400,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                                        new
                    {
                        ItemId = "covenant_carbine_v1",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "covenant_carbine_v1"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "covenant_carbine_v1",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "covenant_carbine_v1_cr",
                                        Currency = "cr",
                                        Price = 1750,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1750,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "covenant_carbine_v2",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "covenant_carbine_v2"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "covenant_carbine_v2",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "covenant_carbine_v2_cr",
                                        Currency = "cr",
                                        Price = 1750,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1750,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "covenant_carbine_v3",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "covenant_carbine_v3"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "covenant_carbine_v3",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "covenant_carbine_v3_cr",
                                        Currency = "cr",
                                        Price = 1750,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1750,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "covenant_carbine_v4",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "covenant_carbine_v4"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "covenant_carbine_v4",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "covenant_carbine_v4_cr",
                                        Currency = "cr",
                                        Price = 1750,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1750,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "covenant_carbine_v5",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "covenant_carbine_v5"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "covenant_carbine_v5",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "covenant_carbine_v5_cr",
                                        Currency = "cr",
                                        Price = 1750,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1750,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "covenant_carbine_v6",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "covenant_carbine_v6"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "covenant_carbine_v6",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "covenant_carbine_v6_cr",
                                        Currency = "cr",
                                        Price = 1750,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1750,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "plasma_rifle",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "plasma_rifle"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "plasma_rifle",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "plasma_rifle_cr",
                                        Currency = "cr",
                                        Price = 1400,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1400,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "plasma_rifle_v6",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "plasma_rifle_v6"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "plasma_rifle_v6",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "plasma_rifle_v6_cr",
                                        Currency = "cr",
                                        Price = 1750,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1750,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "magnum_v2",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "magnum_v2"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "magnum_v2",
                                        Currency = "gold",
                                        Price = 20,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 20,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "magnum_v2_cr",
                                        Currency = "cr",
                                        Price = 370,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 370,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "magnum_v3",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "magnum_v3"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "magnum_v3",
                                        Currency = "gold",
                                        Price = 20,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 20,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "magnum_v3_cr",
                                        Currency = "cr",
                                        Price = 370,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 370,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "spike_grenade",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "spike_grenade"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "spike_grenade",
                                        Currency = "gold",
                                        Price = 20,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 20,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "spike_grenade_cr",
                                        Currency = "cr",
                                        Price = 370,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 370,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "plasma_grenade",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "plasma_grenade"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "plasma_grenade",
                                        Currency = "gold",
                                        Price = 20,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 20,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "plasma_grenade_cr",
                                        Currency = "cr",
                                        Price = 370,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 370,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "vision",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "vision"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "vision",
                                        Currency = "gold",
                                        Price = 15,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 15,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "vision_cr",
                                        Currency = "cr",
                                        Price = 900,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 900,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "bombrun",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "bombrun"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "bombrun",
                                        Currency = "gold",
                                        Price = 15,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 15,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "bombrun_cr",
                                        Currency = "cr",
                                        Price = 900,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 900,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "tripmine",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "tripmine"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "tripmine",
                                        Currency = "gold",
                                        Price = 15,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 15,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "tripmine_cr",
                                        Currency = "cr",
                                        Price = 900,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 900,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "active_camo",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "active_camo"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "active_camo",
                                        Currency = "gold",
                                        Price = 15,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 15,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "active_camo_cr",
                                        Currency = "cr",
                                        Price = 900,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 900,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "power_drain",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "power_drain"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "power_drain",
                                        Currency = "gold",
                                        Price = 15,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 15,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "power_drain_cr",
                                        Currency = "cr",
                                        Price = 900,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 900,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "hologram",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "hologram"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "hologram",
                                        Currency = "gold",
                                        Price = 15,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 15,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "hologram_cr",
                                        Currency = "cr",
                                        Price = 900,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 900,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "adrenaline",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "adrenaline"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "adrenaline",
                                        Currency = "gold",
                                        Price = 12,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 12,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "adrenaline_cr",
                                        Currency = "cr",
                                        Price = 750,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 750,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "deployable_cover",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "deployable_cover"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "deployable_cover",
                                        Currency = "gold",
                                        Price = 12,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 12,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "deployable_cover_cr",
                                        Currency = "cr",
                                        Price = 750,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 750,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "concussive_blast",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "concussive_blast"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "concussive_blast",
                                        Currency = "gold",
                                        Price = 12,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 12,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "concussive_blast_cr",
                                        Currency = "cr",
                                        Price = 750,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 750,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "regenerator",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "regenerator"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "regenerator",
                                        Currency = "gold",
                                        Price = 12,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 12,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "regenerator_cr",
                                        Currency = "cr",
                                        Price = 750,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 750,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "bubble_shield",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "bubble_shield"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "bubble_shield",
                                        Currency = "gold",
                                        Price = 12,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 12,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "bubble_shield_cr",
                                        Currency = "cr",
                                        Price = 750,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 750,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "radar_jammer",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "radar_jammer"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "radar_jammer",
                                        Currency = "gold",
                                        Price = 12,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 12,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "radar_jammer_cr",
                                        Currency = "cr",
                                        Price = 750,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 750,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "revenge_shield",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "revenge_shield"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "revenge_shield",
                                        Currency = "gold",
                                        Price = 10,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 10,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "revenge_shield_cr",
                                        Currency = "cr",
                                        Price = 900,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 900,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "respawn_speed",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "respawn_speed"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "respawn_speed",
                                        Currency = "gold",
                                        Price = 10,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 10,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "respawn_speed_cr",
                                        Currency = "cr",
                                        Price = 900,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 900,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "grenade_reserve",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "grenade_reserve"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "grenade_reserve",
                                        Currency = "gold",
                                        Price = 10,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 10,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "grenade_reserve_cr",
                                        Currency = "cr",
                                        Price = 900,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 900,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "extra_battery",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "extra_battery"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "extra_battery",
                                        Currency = "gold",
                                        Price = 10,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 10,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "extra_battery_cr",
                                        Currency = "cr",
                                        Price = 900,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 900,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "vehicle_shield",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "vehicle_shield"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "vehicle_shield",
                                        Currency = "gold",
                                        Price = 10,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 10,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "vehicle_shield_cr",
                                        Currency = "cr",
                                        Price = 600,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 600,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "runner",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "runner"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "runner",
                                        Currency = "gold",
                                        Price = 10,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 10,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "runner_cr",
                                        Currency = "cr",
                                        Price = 600,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 600,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "reflex",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "reflex"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "reflex",
                                        Currency = "gold",
                                        Price = 10,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 10,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "reflex_cr",
                                        Currency = "cr",
                                        Price = 600,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 600,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "visor",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "visor"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "visor",
                                        Currency = "gold",
                                        Price = 10,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 10,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "visor_cr",
                                        Currency = "cr",
                                        Price = 600,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 600,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "charger",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "charger"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "charger",
                                        Currency = "gold",
                                        Price = 10,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 10,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "charger_cr",
                                        Currency = "cr",
                                        Price = 600,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 600,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "power_plant",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                ItemId = "power_plant"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 3600,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "power_plant",
                                        Currency = "gold",
                                        Price = 10,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 10,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "power_plant_cr",
                                        Currency = "cr",
                                        Price = 600,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 600,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "helmet_scanner",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "helmet_scanner"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "helmet_scanner",
                                        Currency = "gold",
                                        Price = 10,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 10,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "helmet_scanner_cr",
                                        Currency = "cr",
                                        Price = 600,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 600,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "helmet_chameleon",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "helmet_chameleon"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "helmet_chameleon",
                                        Currency = "gold",
                                        Price = 10,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 10,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "helmet_chameleon_cr",
                                        Currency = "cr",
                                        Price = 600,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 600,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "helmet_dutch",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "helmet_dutch"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "helmet_dutch",
                                        Currency = "gold",
                                        Price = 10,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 10,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "helmet_dutch_cr",
                                        Currency = "cr",
                                        Price = 600,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 600,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "helmet_air_assault",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "helmet_air_assault"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "helmet_air_assault",
                                        Currency = "gold",
                                        Price = 10,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 10,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "helmet_air_assault_cr",
                                        Currency = "cr",
                                        Price = 600,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 600,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "helmet_oracle",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "helmet_oracle"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "helmet_oracle",
                                        Currency = "gold",
                                        Price = 10,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 10,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "helmet_oracle_cr",
                                        Currency = "cr",
                                        Price = 600,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 600,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "helmet_juggernaut",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "helmet_juggernaut"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "helmet_juggernaut",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "helmet_juggernaut_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
new
                    {
                        ItemId = "helmet_mercenary",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "helmet_mercenary"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "helmet_mercenary",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "helmet_mercenary_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
new
                    {
                        ItemId = "helmet_hoplite",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "helmet_hoplite"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "helmet_hoplite",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "helmet_hoplite_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
new
                    {
                        ItemId = "helmet_ballista",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "helmet_ballista"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "helmet_ballista",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "helmet_ballista_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
new
                    {
                        ItemId = "helmet_omni",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "helmet_omni"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "helmet_omni",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "helmet_omni_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
new
                    {
                        ItemId = "helmet_silverback",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "helmet_silverback"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "helmet_silverback",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "helmet_silverback_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
new
                    {
                        ItemId = "helmet_widowmaker",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "helmet_widowmaker"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "helmet_widowmaker",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "helmet_widowmaker_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "helmet_spectrum",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "helmet_spectrum"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "helmet_spectrum",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "helmet_spectrum_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                                        new
                    {
                        ItemId = "helmet_orbital",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "helmet_orbital"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "helmet_orbital",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "helmet_orbital_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "helmet_gungnir",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "helmet_gungnir"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "helmet_gungnir",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "helmet_gungnir_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "helmet_hammerhead",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "helmet_hammerhead"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "helmet_hammerhead",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "helmet_hammerhead_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "helmet_strider",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "helmet_strider"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "helmet_strider",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "helmet_strider_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
new
                    {
                        ItemId = "helmet_stealth",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "helmet_stealth"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "helmet_stealth",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "helmet_stealth_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
new
                    {
                        ItemId = "helmet_renegade",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "helmet_renegade"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "helmet_renegade",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "helmet_renegade_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
new
                    {
                        ItemId = "helmet_nihard",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "helmet_nihard"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "helmet_nihard",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "helmet_nihard_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
new
                    {
                        ItemId = "helmet_gladiator",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "helmet_gladiator"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "helmet_gladiator",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "helmet_gladiator_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
new
                    {
                        ItemId = "helmet_mac",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "helmet_mac"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "helmet_mac",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "helmet_mac_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
new
                    {
                        ItemId = "helmet_shark",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "helmet_shark"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "helmet_shark",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "helmet_shark_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
new
                    {
                        ItemId = "helmet_halberd",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "helmet_halberd"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "helmet_halberd",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "helmet_halberd_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
new
                    {
                        ItemId = "helmet_cyclops",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "helmet_cyclops"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "helmet_cyclops",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "helmet_cyclops_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
new
                    {
                        ItemId = "helmet_demo",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "helmet_demo"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "helmet_demo",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "helmet_demo_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },

                    new
                    {
                        ItemId = "chest_scanner",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "chest_scanner"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "chest_scanner",
                                        Currency = "gold",
                                        Price = 10,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 10,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "chest_scanner_cr",
                                        Currency = "cr",
                                        Price = 600,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 600,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "chest_chameleon",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "chest_chameleon"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "chest_chameleon",
                                        Currency = "gold",
                                        Price = 10,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 10,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "chest_chameleon_cr",
                                        Currency = "cr",
                                        Price = 600,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 600,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "chest_dutch",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "chest_dutch"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "chest_dutch",
                                        Currency = "gold",
                                        Price = 10,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 10,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "chest_dutch_cr",
                                        Currency = "cr",
                                        Price = 600,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 600,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "chest_air_assault",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "chest_air_assault"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "chest_air_assault",
                                        Currency = "gold",
                                        Price = 10,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 10,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "chest_air_assault_cr",
                                        Currency = "cr",
                                        Price = 600,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 600,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "chest_oracle",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "chest_oracle"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "chest_oracle",
                                        Currency = "gold",
                                        Price = 10,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 10,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "chest_oracle_cr",
                                        Currency = "cr",
                                        Price = 600,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 600,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "chest_juggernaut",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "chest_juggernaut"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "chest_juggernaut",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "chest_juggernaut_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "chest_orbital",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "chest_orbital"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "chest_orbital",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "chest_orbital_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "chest_gungnir",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "chest_gungnir"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "chest_gungnir",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "chest_gungnir_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "chest_hammerhead",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "chest_hammerhead"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "chest_hammerhead",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "chest_hammerhead_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "chest_strider",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "chest_strider"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "chest_strider",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "chest_strider_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "shoulders_scanner",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "shoulders_scanner"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "shoulders_scanner",
                                        Currency = "gold",
                                        Price = 10,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 10,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "shoulders_scanner_cr",
                                        Currency = "cr",
                                        Price = 600,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 600,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "shoulders_chameleon",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "shoulders_chameleon"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "shoulders_chameleon",
                                        Currency = "gold",
                                        Price = 10,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 10,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "shoulders_chameleon_cr",
                                        Currency = "cr",
                                        Price = 600,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 600,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "shoulders_dutch",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "shoulders_dutch"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "shoulders_dutch",
                                        Currency = "gold",
                                        Price = 10,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 10,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "shoulders_dutch_cr",
                                        Currency = "cr",
                                        Price = 600,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 600,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "shoulders_air_assault",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "shoulders_air_assault"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "shoulders_air_assault",
                                        Currency = "gold",
                                        Price = 10,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 10,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "shoulders_air_assault_cr",
                                        Currency = "cr",
                                        Price = 600,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 600,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "shoulders_oracle",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "shoulders_oracle"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "shoulders_oracle",
                                        Currency = "gold",
                                        Price = 10,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 10,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "shoulders_oracle_cr",
                                        Currency = "cr",
                                        Price = 600,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 600,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "shoulders_juggernaut",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "shoulders_juggernaut"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "shoulders_juggernaut",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "shoulders_juggernaut_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                                        new
                    {
                        ItemId = "shoulders_orbital",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "shoulders_orbital"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "shoulders_orbital",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "shoulders_orbital_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "shoulders_gungnir",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "shoulders_gungnir"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "shoulders_gungnir",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "shoulders_gungnir_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "shoulders_hammerhead",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "shoulders_hammerhead"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "shoulders_hammerhead",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "shoulders_hammerhead_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "shoulders_strider",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "shoulders_strider"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "shoulders_strider",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "shoulders_strider_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "arms_scanner",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "arms_scanner"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "arms_scanner",
                                        Currency = "gold",
                                        Price = 10,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 10,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "arms_scanner_cr",
                                        Currency = "cr",
                                        Price = 600,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 600,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "arms_chameleon",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "arms_chameleon"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "arms_chameleon",
                                        Currency = "gold",
                                        Price = 10,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 10,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "arms_chameleon_cr",
                                        Currency = "cr",
                                        Price = 600,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 600,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "arms_dutch",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "arms_dutch"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "arms_dutch",
                                        Currency = "gold",
                                        Price = 10,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 10,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "arms_dutch_cr",
                                        Currency = "cr",
                                        Price = 600,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 600,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "arms_air_assault",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "arms_air_assault"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "arms_air_assault",
                                        Currency = "gold",
                                        Price = 10,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 10,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "arms_air_assault_cr",
                                        Currency = "cr",
                                        Price = 600,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 600,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "arms_oracle",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "arms_oracle"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "arms_oracle",
                                        Currency = "gold",
                                        Price = 10,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 10,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "arms_oracle_cr",
                                        Currency = "cr",
                                        Price = 600,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 600,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "arms_juggernaut",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "arms_juggernaut"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "arms_juggernaut",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "arms_juggernaut_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "arms_orbital",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "arms_orbital"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "arms_orbital",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "arms_orbital_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "arms_gungnir",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "arms_gungnir"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "arms_gungnir",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "arms_gungnir_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "arms_hammerhead",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "arms_hammerhead"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "arms_hammerhead",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "arms_hammerhead_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "arms_strider",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "arms_strider"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "arms_strider",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "arms_strider_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "legs_scanner",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "legs_scanner"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "legs_scanner",
                                        Currency = "gold",
                                        Price = 10,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 10,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "legs_scanner_cr",
                                        Currency = "cr",
                                        Price = 600,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 600,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "legs_chameleon",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "legs_chameleon"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "legs_chameleon",
                                        Currency = "gold",
                                        Price = 10,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 10,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "legs_chameleon_cr",
                                        Currency = "cr",
                                        Price = 600,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 600,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },

                    new
                    {
                        ItemId = "legs_dutch",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "legs_dutch"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "legs_dutch",
                                        Currency = "gold",
                                        Price = 10,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 10,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "legs_dutch_cr",
                                        Currency = "cr",
                                        Price = 600,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 600,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "legs_air_assault",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "legs_air_assault"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "legs_air_assault",
                                        Currency = "gold",
                                        Price = 10,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 10,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "legs_air_assault_cr",
                                        Currency = "cr",
                                        Price = 600,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 600,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "legs_oracle",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "legs_oracle"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "legs_oracle",
                                        Currency = "gold",
                                        Price = 10,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 10,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "legs_oracle_cr",
                                        Currency = "cr",
                                        Price = 600,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 600,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "legs_juggernaut",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "legs_juggernaut"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "legs_juggernaut",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "legs_juggernaut_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "chest_mercenary",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "chest_mercenary"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "chest_mercenary",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "chest_mercenary_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "arms_mercenary",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "arms_mercenary"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "arms_mercenary",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "arms_mercenary_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "shoulders_mercenary",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "shoulders_mercenary"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "shoulders_mercenary",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "shoulders_mercenary_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "legs_mercenary",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "legs_mercenary"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "legs_mercenary",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "legs_mercenary_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "chest_hoplite",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "chest_hoplite"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "chest_hoplite",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "chest_hoplite_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "arms_hoplite",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "arms_hoplite"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "arms_hoplite",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "arms_hoplite_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "shoulders_hoplite",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "shoulders_hoplite"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "shoulders_hoplite",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "shoulders_hoplite_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "legs_hoplite",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "legs_hoplite"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "legs_hoplite",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "legs_hoplite_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "chest_ballista",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "chest_ballista"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "chest_ballista",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "chest_ballista_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "arms_ballista",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "arms_ballista"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "arms_ballista",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "arms_ballista_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "shoulders_ballista",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "shoulders_ballista"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "shoulders_ballista",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "shoulders_ballista_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "legs_ballista",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "legs_ballista"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "legs_ballista",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "legs_ballista_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "chest_spectrum",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "chest_spectrum"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "chest_spectrum",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "chest_spectrum_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "arms_spectrum",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "arms_spectrum"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "arms_spectrum",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "arms_spectrum_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "shoulders_spectrum",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "shoulders_spectrum"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "shoulders_spectrum",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "shoulders_spectrum_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "legs_spectrum",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "legs_spectrum"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "legs_spectrum",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "legs_spectrum_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "chest_omni",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "chest_omni"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "chest_omni",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "chest_omni_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "arms_omni",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "arms_omni"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "arms_omni",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "arms_omni_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "shoulders_omni",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "shoulders_omni"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "shoulders_omni",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "shoulders_omni_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "legs_omni",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "legs_omni"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "legs_omni",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "legs_omni_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "chest_silverback",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "chest_silverback"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "chest_silverback",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "chest_silverback_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "arms_silverback",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "arms_silverback"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "arms_silverback",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "arms_silverback_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "shoulders_silverback",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "shoulders_silverback"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "shoulders_silverback",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "shoulders_silverback_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "legs_silverback",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "legs_silverback"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "legs_silverback",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "legs_silverback_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "chest_widowmaker",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "chest_widowmaker"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "chest_widowmaker",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "chest_widowmaker_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "arms_widowmaker",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "arms_widowmaker"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "arms_widowmaker",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "arms_widowmaker_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "shoulders_widowmaker",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "shoulders_widowmaker"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "shoulders_widowmaker",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "shoulders_widowmaker_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "legs_widowmaker",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "legs_widowmaker"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "legs_widowmaker",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "legs_widowmaker_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "legs_orbital",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "legs_orbital"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "legs_orbital",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "legs_orbital_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "legs_gungnir",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "legs_gungnir"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "legs_gungnir",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "legs_gungnir_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "legs_hammerhead",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "legs_hammerhead"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "legs_hammerhead",
                                        Currency = "gold",
                                        Price = 25,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 25,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "legs_hammerhead_cr",
                                        Currency = "cr",
                                        Price = 1500,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 1500,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "legs_strider",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "legs_strider"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "legs_strider",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "legs_strider_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "arms_stealth",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "arms_stealth"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "arms_stealth",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "arms_stealth_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "chest_stealth",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "chest_stealth"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "chest_stealth",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "chest_stealth_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "shoulders_stealth",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "shoulders_stealth"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "shoulders_stealth",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "shoulders_stealth_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "legs_stealth",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "legs_stealth"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "legs_stealth",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "legs_stealth_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "arms_renegade",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "arms_renegade"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "arms_renegade",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "arms_renegade_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "chest_renegade",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "chest_renegade"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "chest_renegade",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "chest_renegade_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "shoulders_renegade",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "shoulders_renegade"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "shoulders_renegade",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "shoulders_renegade_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "legs_renegade",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "legs_renegade"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "legs_renegade",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "legs_renegade_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "arms_nihard",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "arms_nihard"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "arms_nihard",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "arms_nihard_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "chest_nihard",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "chest_nihard"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "chest_nihard",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "chest_nihard_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "shoulders_nihard",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "shoulders_nihard"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "shoulders_nihard",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "shoulders_nihard_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "legs_nihard",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "legs_nihard"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "legs_nihard",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "legs_nihard_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "arms_gladiator",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "arms_gladiator"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "arms_gladiator",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "arms_gladiator_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "chest_gladiator",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "chest_gladiator"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "chest_gladiator",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "chest_gladiator_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "shoulders_gladiator",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "shoulders_gladiator"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "shoulders_gladiator",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "shoulders_gladiator_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "legs_gladiator",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "legs_gladiator"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "legs_gladiator",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "legs_gladiator_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "arms_mac",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "arms_mac"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "arms_mac",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "arms_mac_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "chest_mac",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "chest_mac"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "chest_mac",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "chest_mac_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "shoulders_mac",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "shoulders_mac"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "shoulders_mac",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "shoulders_mac_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "legs_mac",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "legs_mac"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "legs_mac",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "legs_mac_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "arms_shark",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "arms_shark"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "arms_shark",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "arms_shark_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "chest_shark",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "chest_shark"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "chest_shark",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "chest_shark_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "shoulders_shark",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "shoulders_shark"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "shoulders_shark",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "shoulders_shark_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "legs_shark",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "legs_shark"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "legs_shark",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "legs_shark_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "arms_halberd",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "arms_halberd"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "arms_halberd",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "arms_halberd_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "chest_halberd",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "chest_halberd"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "chest_halberd",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "chest_halberd_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "shoulders_halberd",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "shoulders_halberd"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "shoulders_halberd",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "shoulders_halberd_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "legs_halberd",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "legs_halberd"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "legs_halberd",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "legs_halberd_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "arms_cyclops",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "arms_cyclops"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "arms_cyclops",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "arms_cyclops_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "chest_cyclops",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "chest_cyclops"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "chest_cyclops",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "chest_cyclops_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "shoulders_cyclops",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "shoulders_cyclops"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "shoulders_cyclops",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "shoulders_cyclops_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "legs_cyclops",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "legs_cyclops"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "legs_cyclops",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "legs_cyclops_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "arms_demo",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "arms_demo"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "arms_demo",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "arms_demo_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "chest_demo",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "chest_demo"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "chest_demo",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "chest_demo_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "shoulders_demo",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "shoulders_demo"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "shoulders_demo",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "shoulders_demo_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                    new
                    {
                        ItemId = "legs_demo",
                        Requirements = new List<string> { "" },
                        Unlocks = new List<string> { "" },
                        BundleItems = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                ItemId = "legs_demo"
                            }
                        },
                        UnlockedLevel = 0,
                        OfferLine = new List<object>
                        {
                            new
                            {
                                Duration = 0,
                                Offers = new List<object>
                                {
                                    new
                                    {
                                        OfferId = "legs_demo",
                                        Currency = "gold",
                                        Price = 50,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 50,
                                            ExpireAt = 0
                                        }
                                    },
                                    new
                                    {
                                        OfferId = "legs_demo_cr",
                                        Currency = "cr",
                                        Price = 3000,
                                        ExpireAt = 0,
                                        Sale = new
                                        {
                                            Price = 3000,
                                            ExpireAt = 0
                                        }
                                    },
                                }
                            }
                        }
                    },
                }
                }
            };
            return Ok(result);
        }
    }
}

