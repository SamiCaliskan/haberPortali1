using haberPortali1.Utility;

namespace haberPortali1.Models
{
    public class HaberRepository : Repository<Haber>, IHaberRepository
    {
        private UygulamaDbContext _uygulamaDbContext;
        public HaberRepository(UygulamaDbContext uygulamaDbContext) : base(uygulamaDbContext)
        {
            _uygulamaDbContext = uygulamaDbContext;
        }

        public void Guncelle(Haber haber)
        {
            _uygulamaDbContext.Update(haber);
        }

        public void Kaydet()
        {
            _uygulamaDbContext.SaveChanges();
        }
        public void Sil(object haber)
        {
            _uygulamaDbContext.Remove(haber);
        }
    }
}
