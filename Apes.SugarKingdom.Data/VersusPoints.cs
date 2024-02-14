using System.ComponentModel.DataAnnotations.Schema;

namespace Apes.SugarKingdom.Data;

[Table("VersusPoints")]
public class VersusPoints : BaseEntity
{
    [Column("Wallet", TypeName = "varchar(100)")]
    public string Wallet { get; set; } = default!;
    
    [Column("Points", TypeName = "decimal(12,2)")]
    public decimal Points { get; set; }
}
