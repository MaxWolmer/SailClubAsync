using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.Data.SqlClient;
using SailClubLibrary.Interfaces;
using SailClubLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SailClubLibrary.Services
{
    public class BoatRepoAsync : Connection, IBoatRepoAsync
    {
        private string _getAllBoats = "SELECT * FROM Boat";
        private string _addBoat = "INSERT INTO Boat Values (@Id, @The_Boat_Type, @Model, @Sail_Number, @Engine_Info, @Draft, @Width, @Length, @Year_Of_Construction)";
        private string _searchBoat = "SELECT * FROM Boat WHERE SailNumber = @Sail_Number";
        private string _removeBoat = "DELETE FROM Boat WHERE SailNumber = @Sail_Number";
        private string _updateBoat = "UPDATE Boat SET @Id, @The_Boat_Type, @Model, Sail_Number, @Engine_Info, @Draft, @Width, @Length, @Year_Of_Construction WHERE Sail_Number = @Sail_Number";

        public Task<int> Count => throw new NotImplementedException();

        public async Task AddBoat(Boat boat)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(_addBoat, connection);

                    await command.Connection.OpenAsync();
                    command.Parameters.AddWithValue("@Id", boat.Id);
                    command.Parameters.AddWithValue("@The_Boat_Type", boat.TheBoatType);
                    command.Parameters.AddWithValue("@Model", boat.Model);
                    command.Parameters.AddWithValue("@Sail_Number", boat.SailNumber);
                    command.Parameters.AddWithValue("@Engine_Info", boat.EngineInfo);
                    command.Parameters.AddWithValue("@Draft", boat.Draft);
                    command.Parameters.AddWithValue("@Width", boat.Width);
                    command.Parameters.AddWithValue("@Length", boat.Length);
                    command.Parameters.AddWithValue("@Year_Of_Construction", boat.YearOfConstruction);

                    int noOfRows = await command.ExecuteNonQueryAsync();
                    await command.Connection.CloseAsync();
                }
                catch (SqlException sqlExp)
                {
                    Console.WriteLine("Database error: " + sqlExp.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Generel fejl: " + ex.Message);
                }
                finally
                {

                }
            }
        }

        public List<Boat> FilterBoats(string filterCriteria)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Boat>> GetAllBoats()
        {
            List<Boat> boats = new List<Boat>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(_getAllBoats, connection);
                    await command.Connection.OpenAsync();

                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32("Id");
                        string model = reader.GetString("Model");
                        string sailNumber = reader.GetString("SailNumber");
                        string engineInfo = reader.GetString("EngineInfo");
                        int draft = reader.GetInt32("Draft");
                        int width = reader.GetInt32("Width");
                        int length = reader.GetInt32("Length");
                        string yearOfConstruction = reader.GetString("Year_Of_Construction");
                        BoatType bt = Enum.Parse<BoatType>(reader.GetString("TheBoatType"));
                        Boat boat = new Boat(id, bt, model, sailNumber, engineInfo, draft, width, length, yearOfConstruction);
                        boats.Add(boat);
                    }
                    reader.Close();
                }
                catch (SqlException sqlExp)
                {
                    Console.WriteLine("Database error" + sqlExp.Message);
                }
                catch (Exception exp)
                {
                    Console.WriteLine("Generic database error" + exp.Message);
                }
            }
            return boats;
        }

        public async Task RemoveBoat(string sailNumber)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(_removeBoat, connection);
                    await command.Connection.OpenAsync();
                    command.Parameters.AddWithValue("@Sail_Number", sailNumber);
                    int noOfRows = await command.ExecuteNonQueryAsync();
                    await command.Connection.CloseAsync();
                }
                catch (SqlException sqlExp)
                {
                    Console.WriteLine("Database error" + sqlExp.Message);
                }
                catch (Exception exp)
                {
                    Console.WriteLine("Generic database error" + exp.Message);
                }
            }
        }

        public async Task<Boat?> SearchBoat(string sailNumber)
        {
            Boat boat = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(_searchBoat, connection);
                    await command.Connection.OpenAsync();
                    command.Parameters.AddWithValue("@Sail_Number", sailNumber);
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    if (reader.Read())
                    {
                        int id = reader.GetInt32("Id");
                        string model = reader.GetString("Boat_Model");
                        string engineInfo = reader.GetString("Engine_Info");
                        int draft = reader.GetInt32("Draft");
                        int width = reader.GetInt32("Width");
                        int length = reader.GetInt32("Length");
                        string yearOfConstruction = reader.GetString("Year_Of_Construction");
                        BoatType bt = Enum.Parse<BoatType>(reader.GetString("TheBoatType"));
                        boat = new Boat(id, bt, model, sailNumber, engineInfo, draft, width, length, yearOfConstruction);
                    }
                    reader.Close();
                }
                catch (SqlException sqlExp)
                {
                    Console.WriteLine("Database error" + sqlExp.Message);
                }
                catch (Exception exp)
                {
                    Console.WriteLine("Generic database error" + exp.Message);
                }
            }
            return boat;
        }

        public async Task UpdateBoat(Boat boat)
        {
            //    Task<Boat> boat1 = SearchBoat(boat.SailNumber);
            //    using (SqlConnection connection = new SqlConnection(connectionString))
            //    {
            //        try
            //        {
            //            SqlCommand command = new SqlCommand(_updateBoat, connection);
            //            await command.Connection.OpenAsync();
            //            command.Parameters.AddWithValue("@Sail_Number", sailNumber);
            //            SqlDataReader reader = await command.ExecuteReaderAsync();
            //            if (reader.Read())
            //            {
            //                int id = newId.
            //            }
            //        }
            //    }
            //}
            throw new NotImplementedException();
        }
    }
}
