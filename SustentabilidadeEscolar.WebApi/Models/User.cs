using MongoDB.Bson;
using System;

namespace SustentabilidadeEscolar.WebApi.Models
{
    public class User
    {
        public User()
        {
            InsertDate = DateTime.Now;
        }

        public ObjectId Id { get; set; }
        public string Provider { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhotoUrl { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public DateTime InsertDate { get; set; }
        public string  Password { get; set; }

    }
}