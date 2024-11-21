using BLL.Interfaces;
using BLL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.NationalityDAL
{
    public class NationalityDataAccessLayer : INationalityRepository
    {
        private readonly IConfiguration configuration;

        public NationalityDataAccessLayer(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public List<Nationality> GetAllNationalities()
        {
            List<Nationality> nationalityList = new List<Nationality>();

            using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                string sqlQuery = "SELECT * FROM [Nationality]";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Nationality nationality = new Nationality(Convert.ToInt32(rdr["Id"]), rdr["Name"].ToString());
                    nationalityList.Add(nationality);
                }
                return nationalityList;
            }
        }
    }
}
