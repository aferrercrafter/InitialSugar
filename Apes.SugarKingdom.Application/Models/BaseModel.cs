using System.ComponentModel.DataAnnotations;

namespace Apes.SugarKingdom.Application.Models;

public class BaseModel
{
    public Guid Id { get; set; }

    public virtual List<ValidationResult> Validate()
    {
        var context = new ValidationContext(this, serviceProvider: null, items: null);
        var results = new List<ValidationResult>();

        _ = Validator.TryValidateObject(this, context, results, true);

        return results;
    }

    public string ValidationErrors => string.Join("; ", Validate().Select(x => x.ErrorMessage));
}
