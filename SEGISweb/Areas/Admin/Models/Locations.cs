using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SEGISweb.Models
{
    public class Locations
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Please enter city name")]
        [Display(Name = "City Name")]
        public string CityName { get; set; }
        [Required(ErrorMessage = "Please enter city latitude")]
        public string Latitude { get; set; }
        [Required(ErrorMessage = "Please enter city longitude ")]
        public string Longitude { get; set; }
        public string Description { get; set; }

        public string PIPE_Latitude_1 { get; set; }
        public string PIPE_Longitude_1 { get; set; }
        public string PIPE_Latitude_2 { get; set; }
        public string PIPE_Longitude_2 { get; set; }
    }
}