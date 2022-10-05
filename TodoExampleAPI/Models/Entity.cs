namespace TodoExampleAPI.Models;

/// <summary>
/// Klasa bazowa dla wszystkich encji bazodanowych
/// </summary>
public class Entity
{
    /// <summary>
    /// Ef core wie, że to jest klucz główny dzięki nazewnictwu
    /// </summary>
    public Guid Id { get; set; }
}