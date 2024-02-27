using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Apes.SugarKingdom.Data;

public abstract class BaseEntity
{
    [Key]
    [Column("Id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Column("ModifiedDate")]
    public DateTime ModifiedDate { get; set; }

    [Column("CreatedDate")]
    public DateTime CreatedDate { get; set; }
}
