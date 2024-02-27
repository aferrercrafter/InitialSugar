using System.ComponentModel.DataAnnotations.Schema;

namespace Apes.SugarKingdom.Data;

[Table("VersusPoints")]
public class VersusPoints : BaseEntity
{
    [Column("Wallet", TypeName = "varchar(100)")]
    public string Wallet { get; set; } = default!;
    
    [Column("Points")]
    public int Points { get; set; }
}
