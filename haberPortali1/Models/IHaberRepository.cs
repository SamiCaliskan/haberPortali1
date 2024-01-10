using haberPortali1.Models;

namespace haberPortali1.Models
{
    public interface IHaberRepository : IRepository<Haber>
    {
        void Guncelle(Haber haber);
        void Kaydet();

    }
}
