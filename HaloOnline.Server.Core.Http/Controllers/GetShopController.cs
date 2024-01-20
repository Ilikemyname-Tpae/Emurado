using System.Collections.Generic;
using System.Web.Http;
using Newtonsoft.Json;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [RoutePrefix("UserService.svc")]
    public class GetShopController : ApiController
    {
        [HttpPost]
        [Route("GetShop")]
        public IHttpActionResult GetShop(GetShopResponse request)
        {
            var result = new
            {
                GetShopResult = new
                {
                    retCode = 0,
                    data = new List<ShopData>
                    {
                        // Just like the note i made in armors, weapons contain cut weapons wasnt accessible in-game,
                        // ill re-add them later on.
                        new ShopData
                        {
                            Name = "weapon",
                            Type = "weapon",
                            Race = 1,
                            Sections = new List<ShopSection>
                            {
                                new ShopSection
                                {
                                    Name = "carousel_weapon_primary",
                                    Shelves = new List<ShopShelf>
                                    {
                                        new ShopShelf
                                        {
                                            Name = "assault_rifle_cat",
                                            IsHot = false,
                                            IsSale = false,
                                            Items = new List<string>
                                            {
                                                "assault_rifle",
                                                "assault_rifle_v2",
                                                "assault_rifle_v3",
                                                "assault_rifle_v6"
                                            }
                                        },
                                        new ShopShelf
                                        {
                                            Name = "battle_rifle_cat",
                                            IsHot = false,
                                            IsSale = false,
                                            Items = new List<string>
                                            {
                                                "battle_rifle",
                                                "battle_rifle_v1",
                                                "battle_rifle_v2",
                                                "battle_rifle_v3",
                                                "battle_rifle_v4",
                                                "battle_rifle_v5",
                                                "battle_rifle_v6"
                                            }
                                        },
                                        new ShopShelf
                                        {
                                            Name = "dmr_cat",
                                            IsHot = false,
                                            IsSale = false,
                                            Items = new List<string>
                                            {
                                                "dmr",
                                                "dmr_v1",
                                                "dmr_v2",
                                                "dmr_v3",
                                                "dmr_v4",
                                                "dmr_v5",
                                                "dmr_v6"
                                            }
                                        },
                                        new ShopShelf
                                        {
                                            Name = "smg_cat",
                                            IsHot = false,
                                            IsSale = false,
                                            Items = new List<string>
                                            {
                                                "smg",
                                                "smg_v2",
                                                "smg_v3",
                                                "smg_v4",
                                                "smg_v6"
                                            }
                                        },
                                        new ShopShelf
                                        {
                                            Name = "carbine_cat",
                                            IsHot = false,
                                            IsSale = false,
                                            Items = new List<string>
                                            {
                                                "covenant_carbine",
                                                "covenant_carbine_v1",
                                                "covenant_carbine_v2",
                                                "covenant_carbine_v3",
                                                "covenant_carbine_v4",
                                                "covenant_carbine_v5",
                                                "covenant_carbine_v6"
                                            }
                                        },
                                        new ShopShelf
                                        {
                                            Name = "plasma_rifle_cat",
                                            IsHot = false,
                                            IsSale = false,
                                            Items = new List<string>
                                            {
                                                "plasma_rifle",
                                                "plasma_rifle_v6"
                                            }
                                        }
                                    }
                                },
                                new ShopSection
                                {
                                    Name = "carousel_weapon_secondary",
                                    Shelves = new List<ShopShelf>
                                    {
                                        new ShopShelf
                                        {
                                            Name = "magnum_cat",
                                            IsHot = false,
                                            IsSale = false,
                                            Items = new List<string>
                                            {
                                                "magnum",
                                                "magnum_v2",
                                                "magnum_v3"
                                            }
                                        }
                                    }
                                },
                                new ShopSection
                                {
                                    Name = "carousel_weapon_grenades",
                                    Shelves = new List<ShopShelf>
                                    {
                                        new ShopShelf
                                        {
                                            Name = "grenade_cat",
                                            IsHot = false,
                                            IsSale = false,
                                            Items = new List<string>
                                            {
                                                "frag_grenade",
                                                "plasma_grenade",
                                                "spike_grenade"
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        new ShopData
                        {
                            Name = "tactical_packages_shop",
                            Type = "consumable",
                            Race = 1,
                            Sections = new List<ShopSection>
                            {
                                new ShopSection
                                {
                                    Name = "section_loadouts",
                                    Shelves = new List<ShopShelf>
                                    {
                                        new ShopShelf
                                        {
                                            Name = "consumables_offensive",
                                            IsHot = false,
                                            IsSale = false,
                                            Items = new List<string>
                                            {
                                                "vision",
                                                "bombrun",
                                                "tripmine",
                                                "active_camo",
                                                "power_drain",
                                                "hologram"
                                            }
                                        },
                                        new ShopShelf
                                        {
                                            Name = "consumables_defensive",
                                            IsHot = false,
                                            IsSale = false,
                                            Items = new List<string>
                                            {
                                                "adrenaline",
                                                "deployable_cover",
                                                "concussive_blast",
                                                "regenerator",
                                                "bubble_shield",
                                                "radar_jammer"
                                            }
                                        },
                                        new ShopShelf
                                        {
                                            Name = "consumables_support",
                                            IsHot = false,
                                            IsSale = false,
                                            Items = new List<string>
                                            {
                                                "revenge_shield",
                                                "respawn_speed",
                                                "grenade_reserve",
                                                "extra_battery",
                                                "vehicle_shield",
                                                "runner",
                                                "reflex",
                                                "visor",
                                                "charger",
                                                "power_plant"
                                            }
                                        }
                                    }
                                }
                            }
                        },
                        new ShopData
                        {
                            Name = "career_shop",
                            Type = "career",
                            Race = 3,
                            Sections = new List<ShopSection>
                            {
                                new ShopSection
                                {
                                    Name = "Ranger",
                                    Shelves = new List<ShopShelf>
                                    {
                                        new ShopShelf
                                        {
                                            Name = "shelf_bundles_start_f_kits",
                                            IsHot = false,
                                            IsSale = false,
                                            Items = new List<string>
                                            {
                                            }
                                        }
                                    }
                                },
                                new ShopSection
                                {
                                    Name = "Sniper",
                                    Shelves = new List<ShopShelf>
                                    {
                                        new ShopShelf
                                        {
                                            Name = "shelf_bundles_start_f_kits",
                                            IsHot = false,
                                            IsSale = false,
                                            Items = new List<string>
                                            {
                                            }
                                        }
                                    }
                                },
                                new ShopSection
                                {
                                    Name = "Tactician",
                                    Shelves = new List<ShopShelf>
                                    {
                                        new ShopShelf
                                        {
                                            Name = "shelf_bundles_start_f_kits",
                                            IsHot = false,
                                            IsSale = false,
                                            Items = new List<string>
                                            {
                                            }
                                        }
                                    }
                                }
                            }
                        },

                        // Will have to add the rest of the armors according to the original list
                        // (i may add armors from newer versions of H:O.
new ShopData
{
    Name = "armors",
    Type = "armor",
    Race = 1,
    Sections = new List<ShopSection>
    {
        new ShopSection
        {
            Name = "carousel_armor_helmet",
            Shelves = new List<ShopShelf>
            {
                new ShopShelf
                {
                    Name = "carousel_armor_standard",
                    IsHot = false,
                    IsSale = false,
                    Items = new List<string>
                    {
                        "helmet_scanner",
                        "helmet_chameleon",
                        "helmet_dutch",
                        "helmet_air_assault",
                        "helmet_oracle"
                    }
                },
                new ShopShelf
                {
                    Name = "carousel_armor_premium",
                    IsHot = false,
                    IsSale = false,
                    Items = new List<string>
                    {
                        "helmet_juggernaut",
                        "helmet_spectrum",
                        "helmet_orbital",
                        "helmet_gungnir",
                        "helmet_hammerhead"
                    }
                },
                new ShopShelf
                {
                    Name = "carousel_armor_platinum",
                    IsHot = false,
                    IsSale = false,
                    Items = new List<string>
                    {
                        "helmet_strider",
                    }
                }
            }
        },
        new ShopSection
        {
            Name = "carousel_armor_chest",
            Shelves = new List<ShopShelf>
            {
                new ShopShelf
                {
                    Name = "carousel_armor_standard",
                    IsHot = false,
                    IsSale = false,
                    Items = new List<string>
                    {
                        "chest_scanner",
                        "chest_chameleon",
                        "chest_dutch",
                        "chest_air_assault",
                        "chest_oracle"
                    }
                },
                new ShopShelf
                {
                    Name = "carousel_armor_premium",
                    IsHot = false,
                    IsSale = false,
                    Items = new List<string>
                    {
                        "chest_juggernaut",
                        "chest_spectrum",
                        "chest_orbital",
                        "chest_gungnir",
                        "chest_hammerhead"
                    }
                },
                new ShopShelf
                {
                    Name = "carousel_armor_platinum",
                    IsHot = false,
                    IsSale = false,
                    Items = new List<string>
                    {
                        "chest_strider"
                    }
                }
            }
        },
        new ShopSection
        {
            Name = "carousel_armor_shoulder",
            Shelves = new List<ShopShelf>
            {
                new ShopShelf
                {
                    Name = "carousel_armor_standard",
                    IsHot = false,
                    IsSale = false,
                    Items = new List<string>
                    {
                        "shoulders_scanner",
                        "shoulders_chameleon",
                        "shoulders_dutch",
                        "shoulders_air_assault",
                        "shoulders_oracle"
                    }
                },
                new ShopShelf
                {
                    Name = "carousel_armor_premium",
                    IsHot = false,
                    IsSale = false,
                    Items = new List<string>
                    {
                        "shoulders_juggernaut",
                        "shoulders_spectrum",
                        "shoulders_orbital",
                        "shoulders_gungnir",
                        "shoulders_hammerhead"
                    }
                },
                new ShopShelf
                {
                    Name = "carousel_armor_platinum",
                    IsHot = false,
                    IsSale = false,
                    Items = new List<string>
                    {
                        "shoulders_strider",
                    }
                }
            }
        },
        new ShopSection
        {
            Name = "carousel_armor_arms",
            Shelves = new List<ShopShelf>
            {
                new ShopShelf
                {
                    Name = "carousel_armor_standard",
                    IsHot = false,
                    IsSale = false,
                    Items = new List<string>
                    {
                        "arms_scanner",
                        "arms_chameleon",
                        "arms_dutch",
                        "arms_air_assault",
                        "arms_oracle"
                    }
                },
                new ShopShelf
                {
                    Name = "carousel_armor_premium",
                    IsHot = false,
                    IsSale = false,
                    Items = new List<string>
                    {
                        "arms_juggernaut",
                        "arms_spectrum",
                        "arms_orbital",
                        "arms_gungnir",
                        "arms_hammerhead"
                    }
                },
                new ShopShelf
                {
                    Name = "carousel_armor_platinum",
                    IsHot = false,
                    IsSale = false,
                    Items = new List<string>
                    {
                        "arms_strider"
                    }
                }
            }
        },
        new ShopSection
        {
            Name = "carousel_armor_legs",
            Shelves = new List<ShopShelf>
            {
                new ShopShelf
                {
                    Name = "carousel_armor_standard",
                    IsHot = false,
                    IsSale = false,
                    Items = new List<string>
                    {
                        "legs_scanner",
                        "legs_chameleon",
                        "legs_dutch",
                        "legs_air_assault",
                        "legs_oracle"
                    }
                },
                new ShopShelf
                {
                    Name = "carousel_armor_premium",
                    IsHot = false,
                    IsSale = false,
                    Items = new List<string>
                    {
                        "legs_juggernaut",
                        "legs_spectrum",
                        "legs_orbital",
                        "legs_gungnir",
                        "legs_hammerhead"
                    }
                },
                new ShopShelf
                {
                    Name = "carousel_armor_platinum",
                    IsHot = false,
                    IsSale = false,
                    Items = new List<string>
                    {
                        "legs_strider"
                    }
                }
            }
                    }
                }
            }
        }
    }
};


            return Ok(result);
        }
    }

    public class GetShopResponse
    {
        public int retCode { get; set; }
        public List<ShopData> data { get; set; }
    }

    public class ShopData
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Race { get; set; }
        public List<ShopSection> Sections { get; set; }
    }

    public class ShopSection
    {
        public string Name { get; set; }
        public List<ShopShelf> Shelves { get; set; }
    }

    public class ShopShelf
    {
        public string Name { get; set; }
        public bool IsHot { get; set; }
        public bool IsSale { get; set; }
        public List<string> Items { get; set; }
    }
}
