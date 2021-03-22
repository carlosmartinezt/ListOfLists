// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System;
using System.Linq;
using System.Security.Claims;
using IdentityModel;
using list_of_lists_webapp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace list_of_lists_webapp {
    public class SeedData {
        public static void EnsureSeedData() {
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddDbContext<ListsDbContext>();

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<ListsDbContext>()
                .AddDefaultTokenProviders();

            using (var serviceProvider = services.BuildServiceProvider()) {
                using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope()) {
                    var context = scope.ServiceProvider.GetService<ListsDbContext>();
                    context.Database.Migrate();

                    var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();
                    var alice = userMgr.FindByNameAsync("alice").Result;
                    if (alice == null) {
                        alice = new IdentityUser {
                            UserName = "carlosmartinezt@outlook.com",
                            Email = "carlosmartinezt@outlook.com",
                            EmailConfirmed = true,
                        };
                        var result = userMgr.CreateAsync(alice, "voltio").Result;
                        if (!result.Succeeded) {
                            throw new Exception(result.Errors.First().Description);
                        }

                        result = userMgr.AddClaimsAsync(alice, new Claim[]{
                            new Claim(JwtClaimTypes.Name, "Carlos Martinez"),
                            new Claim(JwtClaimTypes.GivenName, "Carlos"),
                            new Claim(JwtClaimTypes.FamilyName, "Martinez"),
                            new Claim(JwtClaimTypes.WebSite, "http://martinez-villar.com"),
                        }).Result;
                        if (!result.Succeeded) {
                            throw new Exception(result.Errors.First().Description);
                        }
                        Log.Debug("carlos created");
                    } else {
                        Log.Debug("carlos already exists");
                    }
                }
            }
        }
    }
}
