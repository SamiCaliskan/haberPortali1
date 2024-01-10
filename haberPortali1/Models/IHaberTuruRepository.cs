using haberPortali1.Models;

namespace haberPortali1.Models
{
    public interface IHaberTuruRepository : IRepository<HaberTuru>
    {
        void Guncelle(HaberTuru haberTuru);
        void Kaydet();

    }
}
