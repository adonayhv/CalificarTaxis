﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CalificarTaxis.Web.Entiries.Data
{
    public class TaxiEntity
    {
        public int Id { get; set; }
        [StringLength(6, ErrorMessage ="The {0} field must have {1} characters.")]
        [RegularExpression(@"^([A-Za-z]{3}\d{3})$", ErrorMessage = "The field {0} must have three characters and three numbers.")]
        [Required(ErrorMessage ="The field{0} is mandatory.")]
        public string Plaque { get; set; }
        public ICollection <TripEntity> trips { get; set; }
        public UserEntity User { get; set; }


    }
}
