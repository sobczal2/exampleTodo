using Microsoft.AspNetCore.Mvc;
using TodoExampleAPI.Models;

namespace TodoExampleAPI.Controllers;

// oznaczenia, że ta klasa to kontroller i że ma być dostępna pod adresem api/notebook
// api/[controller] jest tłumaczenie na adres api/{nazwa_klasy_bez_słowa_controller}
[ApiController, Route("api/[controller]")]
public class NotebookController : ControllerBase
{
    private readonly TodoDbContext _dbContext;

    public NotebookController(TodoDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    // metoda zwracająca notatkę o konkretnym Id [FromRoute] oznacza, że Id jest pobierane z adresu
    [HttpGet("{id}")]
    public async Task<Notebook> Get([FromRoute]Guid id)
    {
        // sięgamy do bazy po notatkę o konkretnym Id
        // warto zauważyć, że FirstOrDefault może zwrócić nulla
        // nie obsługujemy na razie takiej sytuacji i zakładamy, że notatka istnieje
        return _dbContext.Notebooks.FirstOrDefault(n => n.Id == id);
    }
    
    // metoda zwracająca wszystkie notatki
    [HttpGet]
    public async Task<IEnumerable<Notebook>> GetAll()
    {
        // zwracamy wszystkie notatki
        return _dbContext.Notebooks;
    }
    
    // metoda dodająca nową notatkę [FromBody] oznacza, że notatka jest pobierana z ciała żądania
    [HttpPost]
    public async Task<Notebook> Add([FromBody]Notebook notebook)
    {
        // dodajemy notatkę do bazy
        _dbContext.Notebooks.Add(notebook);
        // zapisujemy zmiany
        await _dbContext.SaveChangesAsync();
        // zwracamy notatkę
        return notebook;
    }
    
    // metoda aktualizująca notatkę from body dla klas jest opcjonalne - asp net zmapuje to i tak z ciała
    [HttpPut]
    public async Task<Notebook> Update(Notebook notebook)
    {
        // aktualizujemy notatkę w bazie
        // Update tak na prawdę pod spodem robi idiotyczne rzeczy,
        // więcej o tym jak się zobaczymy, ale to dlatego
        // w tatuazach nie używamy Update
        _dbContext.Notebooks.Update(notebook);
        // zapisujemy zmiany
        await _dbContext.SaveChangesAsync();
        // zwracamy notatkę
        return notebook;
    }
    
    // metoda usuwająca notatkę
    [HttpDelete("{id}")]
    public async Task Delete([FromRoute]Guid id)
    {
        // szukamy notatki o konkretnym Id
        var notebook = _dbContext.Notebooks.FirstOrDefault(n => n.Id == id);
        // usuwamy notatkę
        _dbContext.Notebooks.Remove(notebook);
        // zapisujemy zmiany
        await _dbContext.SaveChangesAsync();
        
        // nie zwracamy tutaj informacji o tym czy się powiodło - notatka o tym id może nie istnieć
    }
}
// metody są asynchroniczne, jest to celowe. Operacje na bazie danych trwają i jeżeli wykonywane synchronicznie
// mogą blokować wątek, co jest niepożądane. Jeżeli nie używałyście async await to nie ma co się przejmować
// bo nie jest to bardziej skomplikowane niż pisanie kodu synchronicznego w 90% przypadków
