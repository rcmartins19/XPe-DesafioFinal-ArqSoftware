using System.ComponentModel.DataAnnotations;

namespace DesafioFinalRodrigoMartins.Models.Domains
{
    public class Hero
    {
        [Required]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal PowerLevel { get; set; }

    }
}
