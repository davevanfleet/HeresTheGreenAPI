using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace HeresTheGreenAPI.Models
{
    public class Course
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string CourseName { get; set; }

        public int Par { get; set; }
        public IEnumerable<Hole> Holes { get; set; }
        public Location Location { get; set; }
    }

    public class Location 
    {
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }
        public Address Address { get; set; }
    }

    public class Address 
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}