namespace AdvertWebAPI_Restful.Model;

using System.ComponentModel.DataAnnotations;

public class Advert
{
    public int Id { get; set; }

    [MaxLength(50)]
    public string AdvertTitle { get; set; }
    public string AdvertText { get; set; }
    public DateTime DateAdded { get; set; }
}
