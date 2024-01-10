using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace haberPortali1.Models
{
    public class Haber
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string HaberAdi { get; set; }

        public string Tanim { get; set; }

        [Required]
        public string Yazar { get; set; }

        [Required]
        [Range(1, 10)]
        public double Deger { get; set; }

        [ValidateNever]
        public int HaberTuruId {  get; set; }
        [ForeignKey("HaberTuruId")]
        [ValidateNever]
        public HaberTuru HaberTuru { get; set;}

        [ValidateNever]
        public string ResimUrl {  get; set; }

    }
}
