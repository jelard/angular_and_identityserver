using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentityServer3.Core.Models;

namespace IdentityManagement.IdSrv
{
    public static class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new[]
            {
            new Client
            {
                Enabled = true,
                ClientName = "MVC Client",
                ClientId = "mvc",
                Flow = Flows.Implicit,

                RedirectUris = new List<string>
                {
                    "https://localhost:44300/"
                },

                AllowAccessToAllScopes = true
            },
            new Client
            {
                Enabled = true,
                ClientName = "Pure Html Client",
                ClientId = "html",
                Flow = Flows.Implicit,

                RedirectUris = new List<string>
                {
                    "https://localhost:44301/" + "callback.html",
                    "https://localhost:44301/" + "silentrefreshframe.html",
                },

                AllowAccessToAllScopes = true
            },

        };
        }
    }

}