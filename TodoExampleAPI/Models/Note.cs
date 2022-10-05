namespace TodoExampleAPI.Models;

public class Note : Entity
{
    /// <summary>
    /// default! jest po to tylko, żeby IDE nie krzyczało, że niezainicjowane
    /// </summary>
    public string Name { get; set; } = default!;
    public string Content { get; set; } = default!;
    
    /// <summary>
    /// Definicja relacji one to many.
    /// NotebookId jest faktycznie kolumną w bazie danych i jest to Foreign Key do tabeli Notebooks
    /// Propertasy oznaczone jako virtual tak na prawdę nie istnieją,
    /// służą do łatwiejszego operowania na bazie danych z kodu
    /// </summary>
    public Guid NotebookId { get; set; }
    public virtual Notebook Notebook { get; set; } = default!;
}