using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using projAulaADO.Models;

namespace projAulaADO.Services
{
    public class AirplaneService
    {

        readonly string strConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Users\adm\Documents\Aulas C#\projAulaADO\Database\fly.mdf;";
        readonly SqlConnection conn;

        public AirplaneService()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }

        public bool Insert(Airplane airplane)
        {
            bool status = false;

            try
            {
                string strInsert = "insert into Airplane (Name, NumberOfPassagers, Description, IdEngine) " +
                    "values (@Name, @NumberOfPassagers, @Description, @IdEngine)";

                SqlCommand commandInsert = new SqlCommand(strInsert, conn);

                commandInsert.Parameters.Add(new SqlParameter("@Name", airplane.Name));
                commandInsert.Parameters.Add(new SqlParameter("@NumberOfPassagers", airplane.NumberOfPassagers));
                commandInsert.Parameters.Add(new SqlParameter("@Description", airplane.Description));
                commandInsert.Parameters.Add(new SqlParameter("@IdEngine", InsertEngine(airplane)));

                commandInsert.ExecuteNonQuery();
                status = true;
            }
            catch (Exception e) 
            {
                Console.WriteLine("\n" + e.Message + "\n");
                status = false;
                throw;
            }
            finally
            {
                conn.Close();
            }
            return status;
        }

        private int InsertEngine(Airplane airplane)
        {
            string strInsert = "insert into Engine (Description) values (@Description); " +
                "select cast(scope_identity() as int)";

            SqlCommand commandInsert = new SqlCommand(strInsert, conn);
            commandInsert.Parameters.Add(new SqlParameter("@Description", airplane.Engine.Description));

            return (int) commandInsert.ExecuteScalar();
        }

        public List<Airplane> FindAll()
        {

            List<Airplane> airplanes = new();

            StringBuilder sb = new StringBuilder();
            sb.Append("select a.Id, a.Name, a.Description,a.NumberOfPassagers, e.Description Engine ");
            sb.Append("from Airplane a, Engine e ");
            sb.Append("WHERE a.IdEngine = e.Id");

            SqlCommand commandSelect = new(sb.ToString(), conn);
            SqlDataReader dr = commandSelect.ExecuteReader();

            while (dr.Read())
            {
                Airplane airplane = new();

                airplane.Id = (int) dr["Id"];
                airplane.Name = (string) dr["Name"];
                airplane.NumberOfPassagers = (int) dr["NumberOfPassagers"];
                airplane.Description = (string) dr["Description"];
                airplane.Engine = new Engine() { Description = (string)dr["Engine"] };

                airplanes.Add(airplane);
            }
            return airplanes;
        }
    }
}
