using AdvertWebAPI_Restful.Model;

namespace AdvertWebAPI_Restful.Services.AdvertService
{
    public interface IAdvertService
    {
        public Advert Create(AdvertNewDTO advert);
        public Advert Get(int id);
        public List<AdvertDTO> List();
        public Advert Update(int id, AdvertDTO advert);
        public IResult Delete(int id);
    }
}
