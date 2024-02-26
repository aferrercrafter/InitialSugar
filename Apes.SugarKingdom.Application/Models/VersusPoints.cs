namespace Apes.SugarKingdom.Application.Models;

public class VersusPoints : BaseModel
{
    public string Wallet { get; set; } = default!;
    public int Points { get; set; }
}
