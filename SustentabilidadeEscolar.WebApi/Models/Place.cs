using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace SustentabilidadeEscolar.WebApi.Models
{
    public class Content
    {
        public string Title { get; set; }
        public string Detail { get; set; }
    }

    public class Position
    {
        public double Lat { get; set; }
        public double Lng { get; set; }
    }

    public class Activity
    {
        public Activity()
        {
            Key = Guid.NewGuid().ToString();
        }

        public string Key { get; set; }
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Content> Content { get; set; }
        public string ImageDescripton { get; set; }
        public string Image { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public Position Position { get; set; }
    }
}
