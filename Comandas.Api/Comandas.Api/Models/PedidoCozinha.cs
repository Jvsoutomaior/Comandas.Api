using Comandas.Api.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comandas.Api.Models
{
    public class PedidoCozinha
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ComandaId { get; set; }
        public virtual Comanda Comanda { get; set; } = null!;
        public int SituacaoId { get; set; } = 1;
        public virtual ICollection<PedidoCozinhaItem> PedidoCozinhaItems { get; set; } = null!;

        public PedidoCozinha()
        {
            
        }
    }
}