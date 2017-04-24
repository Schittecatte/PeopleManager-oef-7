using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeopleManager.Model;

namespace PeopleManager.DataAccess
{
    public class PersonDataAccessor
    {
        public string Email { get; private set; }
        public string FirstName { get; private set; }
        public int Id { get; private set; }
        public string Name { get; private set; }

        public IList<Person> All()
        {
            //Connect to the database
            var connectionString = ConfigurationManager.ConnectionStrings["PeopleManager"].ConnectionString;
            SqlConnection connection= new SqlConnection(connectionString);
            //Creatte the command
            SqlCommand command = connection.CreateCommand();
            command.CommandType = CommandType.Text;
            command.CommandText = "select * from Person";
            //Execute the command
            var people = new List<Person>();
            connection.Open();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var person = new Person
                {
                    Id =(int)reader["Id"],
                    FirstName = reader["FirstName"].ToString(),
                    Name = reader["Name"].ToString(),
                    Email = reader["Email"].ToString()
                }
                ;
                people.Add(person);
            }
            connection.Close();
            connection.Dispose();
            return people;
        }
    }
}
