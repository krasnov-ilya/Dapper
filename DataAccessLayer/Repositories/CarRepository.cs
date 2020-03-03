using Dapper;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccessLayer.Repositories
{
    public class CarRepository : ICarRepository
    {
        public bool Create(Car car)
        {
            string connectionString = @"Data Source=.;Initial Catalog=MyDB;Integrated Security=True";
            var query = $"INSERT INTO Cars (name) VALUES ('{car.Name}')";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var affectedRows = connection.Execute(query, new { Name = car.Name });

                connection.Close();
            }
            return true;
        }

        public bool Delete(int id)
        {
            string connectionString = @"Data Source=.;Initial Catalog=MyDb;Integrated Security=True";
            var query = $"DELETE FROM Cars WHERE id = {id}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var affectedRows = connection.Execute(query, id);
                connection.Close();
            }
            return true;
        }

        public IEnumerable<Car> GetAll()
        {
            string connectionString = @"Data Source=.;Initial Catalog=MyDB;Integrated Security=True";
            var query = "SELECT * FROM Cars";
            var result = new List<Car>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                result = connection.Query<Car>(query).ToList();

                connection.Close();
            }
            return result;
        }

        public Car GetById(int id)
        {
            string connectionString = @"Data Source=.;Initial Catalog=MyDb;Integrated Security=True";
            var query = $"SELECT * FROM Cars car WHERE id = {id}";
            var result = new Car();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                result = connection.Query<Car, IEnumerable<Detail>, Car>(query, (car, details) =>
                {
                    details = GetDetails(id);
                    car.Details = details;
                    return car;
                }).FirstOrDefault();

                connection.Close();
            }
            return result;
        }

        public IEnumerable<Detail> GetDetails(int Id)
        {
            string connectionString = @"Data Source=.;Initial Catalog=MyDB;Integrated Security=True";
            var query = $"SELECT Details.id, Details.name FROM Details INNER JOIN Cars on detail_id = Details.id WHERE Cars.id = ('{Id}')";
            var result = new List<Detail>();

            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                result = connection.Query<Detail>(query, new { id = Id }).ToList();

                connection.Close();
            }

            return result;
        }

        public bool Update(Car car)
        {
            string connectionString = @"Data Source=.;Initial Catalog=MyDB;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var query = $"UPDATE Cars SET name = '{car.Name}' where id = {car.Id}";

                var affectedRows = connection.Execute(query, new { Id = car.Id, Name = car.Name });

                connection.Close();
            }
            return true;
        }
    }
}
