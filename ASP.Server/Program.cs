using ASP.Server.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var B1 = new Book
            {
                Id = 1,
                Nom = "Le Nom du vent",
                Autheur = "Patrick Rothfuss",
                Prix = 15,
                Contenu = "Le silence avait un poids et il m'écrasait la poitrine...",
                Genres = new List<Genre> { GenresPossible.Fantastique, GenresPossible.Aventure }
            };

            // CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
