using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Webmvcapi.Models
{
    public class users
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string name { get; set; }

        [BsonElement("age")]
        public int age { get; set; }

        [BsonElement("email")]
        public string email { get; set; }

        [BsonElement("status")]
        public string status { get; set; }

    }
}
