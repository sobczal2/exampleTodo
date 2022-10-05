namespace TodoExampleAPI.Models;

public class Notebook : Entity
{
    /// <summary>
    /// default! jest po to tylko, żeby IDE nie krzyczało, że niezainicjowane
    /// </summary>
    public string Title { get; set; } = default!;

    public string Owner { get; set; } = default!;
    
    /// <summary>
    /// To pole nie istnieje faktycznie w bazie danych a jednynie w kodzie
    /// Reprezentuje relację one to many między notebook a note - jeden notebook może mieć wiele notes
    /// Notes jest opcjonalne tylko dla tego przykładu, nie należy się aż tak sugerować
    /// </summary>
    public virtual IEnumerable<Note>? Notes { get; set; }
}