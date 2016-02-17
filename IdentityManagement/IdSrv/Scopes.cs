using System.Collections.Generic;
using IdentityServer3.Core.Models;

namespace IdentityManagement.IdSrv
{
    public static class Scopes
    {
        public static IEnumerable<Scope> Get()
        {
            var scopes = new List<Scope>
        {
            new Scope
            {
                Enabled = true,
                Name = "roles",
                Type = ScopeType.Identity,
                Claims = new List<ScopeClaim>
                {
                    new ScopeClaim("role")
                }
            },
             new Scope
                    {
                        Name = "gallerymanagement",
                        DisplayName = "Gallery Management",
                        Description = "Allow the application to manage galleries on your behalf.",
                        Type = ScopeType.Resource,
                        Claims = new List<ScopeClaim>
                            {
                                new ScopeClaim("role", false)
                            }

                    },
              new Scope
                    {
                        Name = "roles",
                        DisplayName = "Role(s)",
                        Description = "Allow the application to see your role(s).",
                        Type = ScopeType.Identity,
                        Claims = new List<ScopeClaim>()
                        {
                            new ScopeClaim("role", true)
                        }
              },
             StandardScopes.OpenId,
             StandardScopes.ProfileAlwaysInclude,
             StandardScopes.Address
        };


            return scopes;
        }
    }

}