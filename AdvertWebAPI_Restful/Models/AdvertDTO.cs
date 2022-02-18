using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace AdvertWebAPI_Restful.Model
{
    public class AdvertDTO
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string AdvertTitle { get; set; }
        public string AdvertText { get; set; }
        public DateTime DateAdded { get; set; }
    }

    public class AdvertNewDTO
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string AdvertTitle { get; set; }
        public string AdvertText { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
