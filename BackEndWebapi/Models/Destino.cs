using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AtividadeModulo6.Models
{
    [Table("tb_destino")]
    public class Destino
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "nome")]
        [Required(ErrorMessage = "Informe o nome do destino")]
        [StringLength(50)]
        public string Nome { get; set; }

        [Display(Name = "cidade")]
        [Required(ErrorMessage = "Informe o nome da cidade")]
        [StringLength(50)]
        public string Cidade { get; set; }


        [Display(Name = "estado")]
        [Required(ErrorMessage = "Informe o nome do Estado")]
        [StringLength(50)]
        public string Estado { get; set; }


        [Display(Name = "preco_pacote")]
        [Required(ErrorMessage = "Informe o preço da viagem ao destino")]
        public double Preco { get; set; }


        [Display(Name = "promocao")]
        [Required(ErrorMessage = "O Destino está em promoção")]
        public bool Promocao { get; set; }


        [Display(Name = "desconto")]
        [Required(ErrorMessage = "Se está em promoção, qual a porcentagem do desconto?")]
        public double Desconto { get; set; }


        [Display(Name = "url_foto")]
        [Required(ErrorMessage = "Informe o url do destino")]
        [StringLength(1000)]
        public string UrlFoto { get; set; }
    }
 
}
