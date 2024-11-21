using BLL.Interfaces;
using BLL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.LocationDAL
{
    public class LocationDataAccessLayer : ILocationRepository
    {
        private readonly IConfiguration configuration;

        public LocationDataAccessLayer(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public List<Location> GetAllLocation()
        {
            List<Location> locationList = new List<Location>();

            using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                string sqlQuery = "SELECT * FROM [Location]";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Location location = new Location(Convert.ToInt32(rdr["Id"]), rdr["Name"].ToString());
                    locationList.Add(location);
                }
                return locationList;
            }
        }
    }
}
