using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Respository
{
    public class ContactRepository
    {
        private string connectionString = "Data Source=(localdb)\\MSSQLLOCALDB;Initial Catalog=ASP_DEMO;Integrated Security=True;";

        //getAllContact
        public List<Contact> getAllContact()
        {
            SqlConnection c = new SqlConnection();
            c.ConnectionString = connectionString;

            SqlCommand cmd = c.CreateCommand();
            cmd.CommandText = "SELECT * FROM Contact";

            List<Contact> contacts = new List<Contact>();

            c.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    contacts.Add(new Contact
                    {
                        Id = (int)reader["Id"],
                        Birthdate = (DateTime)reader["Birthdate"],
                        FirstName = (string)reader["FirstName"],
                        LastName = (string)reader["LastName"],
                        SurName = (string)reader["SurName"] is DBNull ? null : (string)reader["SurName"],
                        Email = (string)reader["Email"],
                        Phone = (string)reader["Phone"]
                    });
                }
            }


            c.Close();

            return contacts;
        }

        //getById
        public Contact GetContactById(int id)
        {
            SqlConnection c = new SqlConnection();
            c.ConnectionString = connectionString;

            SqlCommand cmd = c.CreateCommand();
            cmd.CommandText = "SELECT * FROM Contact WHERE id = @id";
            cmd.Parameters.AddWithValue("id", id);

            Contact contact = new Contact();

            c.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    contact.Id = (int)reader["Id"];
                    contact.FirstName = (string)reader["FirstName"];
                    contact.LastName = (string)reader["LastName"];
                    contact.SurName = (string)reader["SurName"] is DBNull ? null : (string)reader["SurName"];
                    contact.Email = (string)reader["Email"];
                    contact.Phone = (string)reader["Phone"];
                    contact.Birthdate = (DateTime)reader["Birthdate"];
                }

                c.Close();

                return contact;
            }
        }
        //add
        public int AddContact (Contact contact)
        {
            SqlConnection c = new SqlConnection();
            c.ConnectionString = connectionString;

            SqlCommand cmd = c.CreateCommand();
            cmd.CommandText = " INSERT INTO Contact(FirstName, LastName, SurName, Email, Phone, Birthdate) " +
                              " OUTPUT inserted.id " +
                              " VALUES (@FirstName, @LastName, @SurName, @Email, @Phone, @Birthdate)";
            cmd.Parameters.AddWithValue("FirstName", contact.FirstName);
            cmd.Parameters.AddWithValue("LastName", contact.LastName);
            cmd.Parameters.AddWithValue("SurName", contact.SurName);
            cmd.Parameters.AddWithValue("Email", contact.Email);
            cmd.Parameters.AddWithValue("Phone", contact.Phone);
            cmd.Parameters.AddWithValue("Birthdate", contact.Birthdate);

            c.Open();
            int id = (int)cmd.ExecuteScalar();
            c.Close();

            return id;
        }


        //update
        public bool UpdateContact(int id, Contact contact)
        {
            SqlConnection c = new SqlConnection();
            c.ConnectionString = connectionString;

            SqlCommand cmd = c.CreateCommand();
            cmd.CommandText = " UPDATE Contact " +
                              " SET FirstName = @FirstName, LastName = @LastName, SurName = @SurName, Email = @Email, Phone = @Phone, Birthdate = @Birthdate " +
                              " WHERE Id=@Id ";
            cmd.Parameters.AddWithValue("Id", id);
            cmd.Parameters.AddWithValue("FirstName", contact.FirstName);
            cmd.Parameters.AddWithValue("LastName", contact.LastName);
            cmd.Parameters.AddWithValue("SurName", contact.SurName);
            cmd.Parameters.AddWithValue("Email", contact.Email);
            cmd.Parameters.AddWithValue("Phone", contact.Phone);
            cmd.Parameters.AddWithValue("Birthdate", contact.Birthdate);

            c.Open();
            int nbRow = cmd.ExecuteNonQuery();
            c.Close();

            return nbRow ==1;
        }

        //delete

        public bool DeleteContact(int id)
        {
            SqlConnection c = new SqlConnection();
            c.ConnectionString = connectionString;

            SqlCommand cmd = c.CreateCommand();
            cmd.CommandText = " DELETE Contact WHERE Id=@Id ";
            cmd.Parameters.AddWithValue("Id", id);

            c.Open();
            int nbRow = cmd.ExecuteNonQuery();
            c.Close();
                             
            return nbRow == 1;
        }


        
    }
}
