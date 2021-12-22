﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AareonTechnicalTest.Models
{
    public class Ticket : IEntity
    {
        [Key]
        public int Id { get; }

        public string Content { get; set; }

        public int PersonId { get; set; }

        public List<Note> Notes { get; set; }
    }
}
