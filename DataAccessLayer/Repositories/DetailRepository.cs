using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    public class DetailRepository : IDetailRepository
    {
        public bool Create(Detail detail)
        {
            string connectionString = @"Data Source=.;Initial Catalog=MyDB;Integrated Security=True";
            var query = $"INSERT INTO Details (name) VALUES ('{detail.Name}')";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var affectedRows = connection.Execute(query, new {Name = detail.Name});

                connection.Close();
            }
            return true;
        }

        public bool Delete(int id)
        {
            string connectionString = @"Data Source=.;Initial Catalog=MyDb;Integrated Security=True";
            var query = $"DELETE FROM Details WHERE id = {id}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var affectedRows= connection.Execute(query, id);
                connection.Close(); 
            }
            return true;
        }

        public IEnumerable<Detail> GetAll()
        {
            string connectionString = @"Data Source=.;Initial Catalog=MyDB;Integrated Security=True";
            var query = "SELECT * FROM Details";
            var result = new List<Detail>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                result = connection.Query<Detail>(query).ToList();

                connection.Close();
            }
            return result;
        }

        public Detail GetById(int id)
        {
            string connectionString = @"Data Source=.;Initial Catalog=MyDb;Integrated Security=True";
            var query = $"SELECT * FROM Details WHERE id = {id}";
            var result = new Detail();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                 result = connection.Query<Detail>(query, new { Id = id }).FirstOrDefault();
                connection.Close();
            }
            return result;
        }

        public bool Update(Detail detail)
        {
            string connectionString = @"Data Source=.;Initial Catalog=MyDB;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var query = $"UPDATE Details SET name = '{detail.Name}' where id = {detail.Id}";

                var affectedRows = connection.Execute(query, new { Id = detail.Id, Name = detail.Name});

                connection.Close();
            }
            return true;
        }
    }
}
