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
                                                "assault_rifle_v5",
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
                                                "smg_v1",
                                                "smg_v2",
                                                "smg_v4",
                                                "smg_v5",
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
                            Name = "internal_shop",
                            Type = "internal",
                            Race = 3,
                            Sections = new List<ShopSection>
                            {
                                new ShopSection
                                {
                                    Name = "section_career",
                                    Shelves = new List<ShopShelf>
                                    {
                                        new ShopShelf
                                        {
                                            Name = "shelf_bundles_start_kits",
                                            IsHot = false,
                                            IsSale = false,
                                            Items = new List<string>
                                            {
                                                "ranger_kit_offer",
                                                "sniper_kit_offer",
                                                "tactician_kit_offer"
                                            }
                                        }
                                    }
                                },
                                new ShopSection
                                {
                                    Name = "section_account_modifiers",
                                    Shelves = new List<ShopShelf>
                                    {
                                        new ShopShelf
                                        {
                                            Name = "shelf_account_modifiers",
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
                                            Name = "shelf_career_ranger",
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
                                            Name = "shelf_career_sniper",
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
                                            Name = "shelf_career_tactician",
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
                        "helmet_hammerhead",
                        "helmet_mercenary",
                        "helmet_hoplite",
                        "helmet_ballista",
                        "helmet_spectrum",
                        "helmet_omni",
                        "helmet_silverback",
                        "helmet_widowmaker"
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
                        "helmet_stealth",
                        "helmet_renegade",
                        "helmet_nihard",
                        "helmet_gladiator",
                        "helmet_mac",
                        "helmet_shark",
                        "helmet_halberd",
                        "helmet_cyclops",
                        "helmet_demo"
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
                        "chest_hammerhead",
                        "chest_mercenary",
                        "chest_hoplite",
                        "chest_ballista",
                        "chest_spectrum",
                        "chest_omni",
                        "chest_silverback",
                        "chest_widowmaker"
                    }
                },
                new ShopShelf
                {
                    Name = "carousel_armor_platinum",
                    IsHot = false,
                    IsSale = false,
                    Items = new List<string>
                    {
                        "chest_strider",
                        "chest_stealth",
                        "chest_renegade",
                        "chest_nihard",
                        "chest_gladiator",
                        "chest_mac",
                        "chest_shark",
                        "chest_halberd",
                        "chest_cyclops",
                        "chest_demo"
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
                        "shoulders_hammerhead",
                        "shoulders_mercenary",
                        "shoulders_hoplite",
                        "shoulders_ballista",
                        "shoulders_spectrum",
                        "shoulders_omni",
                        "shoulders_silverback",
                        "shoulders_widowmaker"
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
                        "shoulders_stealth",
                        "shoulders_renegade",
                        "shoulders_nihard",
                        "shoulders_gladiator",
                        "shoulders_mac",
                        "shoulders_shark",
                        "shoulders_halberd",
                        "shoulders_cyclops",
                        "shoulders_demo"
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
                        "arms_hammerhead",
                        "arms_mercenary",
                        "arms_hoplite",
                        "arms_ballista",
                        "arms_spectrum",
                        "arms_omni",
                        "arms_silverback",
                        "arms_widowmaker"
                    }
                },
                new ShopShelf
                {
                    Name = "carousel_armor_platinum",
                    IsHot = false,
                    IsSale = false,
                    Items = new List<string>
                    {
                        "arms_strider",
                        "arms_stealth",
                        "arms_renegade",
                        "arms_nihard",
                        "arms_gladiator",
                        "arms_mac",
                        "arms_shark",
                        "arms_halberd",
                        "arms_cyclops",
                        "arms_demo"
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
                        "legs_hammerhead",
                        "legs_mercenary",
                        "legs_hoplite",
                        "legs_ballista",
                        "legs_spectrum",
                        "legs_omni",
                        "legs_silverback",
                        "legs_widowmaker"
                    }
                },
                new ShopShelf
                {
                    Name = "carousel_armor_platinum",
                    IsHot = false,
                    IsSale = false,
                    Items = new List<string>
                    {
                        "legs_strider",
                        "legs_stealth",
                        "legs_renegade",
                        "legs_nihard",
                        "legs_gladiator",
                        "legs_mac",
                        "legs_shark",
                        "legs_halberd",
                        "legs_cyclops",
                        "legs_demo"
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
