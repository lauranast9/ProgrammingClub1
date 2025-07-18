﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ProgrammingClub.Models.CreateOrUpdateModels
{
    public class UpdateMemberPartially
    {
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Position { get; set; }
        public string? Resume { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
