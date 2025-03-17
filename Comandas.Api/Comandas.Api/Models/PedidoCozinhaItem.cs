using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comandas.Api.Models
{
    public class PedidoCozinhaItem
    {
        public PedidoCozinhaItem()
        {
            
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PedidoCozinhaId { get; set; }
        public virtual PedidoCozinha PedidoCozinha { get; set; } = null!;
        public int ComandaItemId { get; set; }
        public virtual ComandaItem ComandaItem { get; set; } = null!;
    }
}