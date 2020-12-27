using System;
using Microsoft.Identity.Client;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GraphClient
{
    public class Program
    {
        private const string _clientID="6bac34a2-ab76-48be-831f-f5893571272d";
        private const string _tenantId="2acaa146-956f-4dde-871f-ed300b4e8030";
        public static async Task  Main(string[] args)
        {
            IPublicClientApplication app;
            app=PublicClientApplicationBuilder
            .Create(_clientID)
            .WithAuthority(AzureCloudInstance.AzurePublic,_tenantId)
            .WithRedirectUri("http://localhost")
            .Build();

            Console.WriteLine("Registered Client App!!");
            List<string> scopes = new List<string>
            {
                "user.read"
            };

            AuthenticationResult result;
            result = await app
            .AcquireTokenInteractive(scopes)
            .ExecuteAsync();

            Console.WriteLine($"Token:\t{result.AccessToken}");




        }
    }
}
