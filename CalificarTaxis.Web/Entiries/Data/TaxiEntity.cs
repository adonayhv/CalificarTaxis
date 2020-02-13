using System;
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
        [Required(ErrorMessage ="The field{0} is mandatory.")]
        public string Plaque { get; set; }
        public ICollection <TripEntity> trips { get; set; }


    }
}
