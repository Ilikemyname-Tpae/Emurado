﻿using System;
using System.Data.SQLite;
using System.Security.Claims;
using System.Web.Http;
using HaloOnline.Server.Core.Http.Model.Presence;
using HaloOnline.Server.Model.Presence;

namespace HaloOnline.Server.Core.Http.Controllers
{
    [RoutePrefix("PresenceService.svc")]
    public class PartyGetStatusController : ApiController
    {
        private const string ConnectionString = "Data Source=halodb.sqlite;Version=3;";

        [HttpPost]
        [Route("PartyGetStatus")]
        [Authorize]
        public IHttpActionResult PartyGetStatus()
        {
            var userIdClaim = (User?.Identity as ClaimsIdentity)?.FindFirst("Id");
            int userId = userIdClaim != null ? int.Parse(userIdClaim.Value) : -1;

            var partyStatus = GetPartyStatusFromDatabase(userId);

            var result = new
            {
                PartyGetStatusResult = new
                {
                    retCode = 0,
                    data = new
                    {
                        Party = new
                        {
                            Id = partyStatus.Party?.Id ?? "",
                        },
                        SessionMembers = new[]
                        {
                            new
                            {
                                User = new
                                {
                                    Id = userId
                                },
                                IsOwner = true
                            }
                        },
                        MatchmakeState = partyStatus.MatchmakeState,
                        GameData = partyStatus.GameData
                    }
                }
            };

            return Ok(result);
        }

        private PartyStatus GetPartyStatusFromDatabase(int userId)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand("SELECT Id, MatchmakeState, GameData FROM Party", connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new PartyStatus
                            {
                                Party = new PartyId
                                {
                                    Id = reader["Id"].ToString()
                                },
                                MatchmakeState = Convert.ToInt32(reader["MatchmakeState"]),
                                GameData = reader["GameData"] as byte[] ?? new byte[100]
                            };
                        }
                        else
                        {
                            return new PartyStatus();
                        }
                    }
                }
            }
        }
    }
}
