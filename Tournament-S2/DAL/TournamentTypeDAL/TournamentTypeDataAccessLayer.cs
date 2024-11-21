using BLL.Interfaces;
using BLL.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.TournamentTypeDAL
{
    public class TournamentTypeDataAccessLayer : ITournamentTypeRepository
    {
        private readonly IConfiguration configuration;

        public TournamentTypeDataAccessLayer(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public List<TournamentType> GetAllTournamentType()
        {
            List<TournamentType> tournamentTypeList = new List<TournamentType>();

            using (SqlConnection con = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                string sqlQuery = "SELECT * FROM [TournamentType]";
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    TournamentType tournamentType = new TournamentType(Convert.ToInt32(rdr["Id"]), rdr["Name"].ToString());
                    tournamentTypeList.Add(tournamentType);
                }
                return tournamentTypeList;
            }
        }
    }
}
