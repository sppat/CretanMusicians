﻿using System.ComponentModel.DataAnnotations;

namespace CretanMusicians.API.Data
{
    public class Instrument
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public IList<Musician> Musicians { get; set; }
    }
}