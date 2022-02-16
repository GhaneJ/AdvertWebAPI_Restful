using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;

namespace AdvertWebAPI_Restful.Model
{
    public class Advert
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string AdvertTitle { get; set; }
        public string AdvertText { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
