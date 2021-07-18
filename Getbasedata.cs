using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthWind.WpfUi.Models;
using NorthWind.WpfUi.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Microsoft.Data.SqlClient;

namespace NorthWind.WpfUi
{
   public static class Getbasedata
    {

        //para construir la conexion con entity y cargar los metodos
        public static IConfiguration configuracion;
        public static void Getconnectiondb()
        {
            string ConnectionString = configuracion.GetConnectionString("Nortwind");
            var optionsBuilder = new DbContextOptionsBuilder<NorthwindContext>();
            optionsBuilder.UseSqlServer(ConnectionString);
            NorthwindContext db = new NorthwindContext(optionsBuilder.Options);

        }

        public static void LoadSetting()
        {
            var SettingBuilder = new ConfigurationBuilder();
            SettingBuilder.AddJsonFile("Appsettings.json");
            configuracion = SettingBuilder.Build();
        }





        
    }
}
