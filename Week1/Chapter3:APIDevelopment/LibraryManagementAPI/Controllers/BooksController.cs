using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using LibraryManagementAPI.Exceptions;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace LibraryManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IRedisCacheService _redisCacheService;

        public BooksController(IRedisCacheService redisCacheService)
    {
        _redisCacheService = redisCacheService;
    }

        private const string CacheKey = "BooksList";

        private static List<Book> Books = new List<Book>
        {
            new Book { Id = 1, Title = "1984", Author = "George Orwell", Year = 1949 },
            new Book { Id = 2, Title = "Brave New World", Author = "Aldous Huxley", Year = 1932 },
            new Book { Id = 3, Title = "Fahrenheit 451", Author = "Ray Bradbury", Year = 1953 },
            new Book { Id = 4, Title = "To Kill a Mockingbird", Author = "Harper Lee", Year = 1960 },
            new Book { Id = 5, Title = "Moby-Dick", Author = "Herman Melville", Year = 1851 },
            new Book { Id = 6, Title = "Pride and Prejudice", Author = "Jane Austen", Year = 1813 },
            new Book { Id = 7, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Year = 1925 },
            new Book { Id = 8, Title = "Catch-22", Author = "Joseph Heller", Year = 1961 },
            new Book { Id = 9, Title = "Crime and Punishment", Author = "Fyodor Dostoevsky", Year = 1866 },
            new Book { Id = 10, Title = "The Odyssey", Author = "Homer", Year = 1800 }
        };

        [HttpPost("add")]
        public IActionResult AddBook([FromBody] Book book)
        {
            if (string.IsNullOrWhiteSpace(book.Title))
                throw new ValidationException("The book title cannot be empty.");

            book.Id = Books.Count + 1;
            Books.Add(book);

            return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
        }

        [HttpPost("cache/set")]
        public async Task<IActionResult> UpdateCache([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 5)
        {
            var cacheKey = $"Books_Page{pageNumber}_Size{pageSize}";
            var pagedBooks = Books.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            await _redisCacheService.SetValueAsync(cacheKey, JsonSerializer.Serialize(pagedBooks));

            return Ok(pagedBooks);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 5)
        {
            if (pageNumber <= 0 || pageSize <= 0)
            {
                return BadRequest("Page number and page size must be greater than 0.");
            }

             var cacheKey = $"Books_Page{pageNumber}_Size{pageSize}";
             var cachedData = await _redisCacheService.GetValueAsync(cacheKey);

            if (!string.IsNullOrEmpty(cachedData))
        {
             // Eğer veri Redis'te varsa, deserialize et ve "Redis'ten alındı" mesajıyla döndür
            var booksFromCache = JsonSerializer.Deserialize<List<Book>>(cachedData);
            return Ok(new
            {
                Message = "Data retrieved from Redis cache.",
                Data = booksFromCache
            });
        }
         else {
            // Veri Redis'te yoksa, API'den çek ve Redis'e kaydet
            if ((pageNumber - 1) * pageSize >= Books.Count)
            {
                return BadRequest("Page number exceeds total pages.");
            }

            var totalBooks = Books.Count;
            var pagedBooks = Books.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            var paginationMetadata = new
            {
                TotalCount = totalBooks,
                TotalPages = (int)Math.Ceiling((double)totalBooks / pageSize),
                PageSize = pageSize,
                CurrentPage = pageNumber
            };

            Response.Headers["X-Pagination"] = JsonSerializer.Serialize(paginationMetadata);

           await _redisCacheService.SetValueAsync(cacheKey, JsonSerializer.Serialize(pagedBooks));

            return Ok(new
            {
                Message = "Data retrieved from API and saved to Redis cache.",
                Data = pagedBooks
            });
         }
        
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var book = Books.Find(b => b.Id == id);
            if (book == null)
            {
                throw new NotFoundException($"Book with ID {id} not found.");
            }
            return Ok(book);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] Book updatedBook)
        {
            var book = Books.Find(b => b.Id == id);
            if (book == null) return NotFound();

            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Year = updatedBook.Year;
            return NoContent();
        }

        [HttpPatch("{id:int}")]
        public IActionResult Patch(int id, [FromBody] JsonPatchDocument<Book> patchDoc)
        {
            var book = Books.Find(b => b.Id == id);
            if (book == null) return NotFound();

            patchDoc.ApplyTo(book, ModelState); 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return NoContent();  
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var book = Books.Find(b => b.Id == id);
            if (book == null) return NotFound();

            Books.Remove(book);

            return NoContent();
        }

    }

    public class JsonPatchDocument<T>
    {
        internal void ApplyTo(Book book, ModelStateDictionary modelState)
        {
            throw new NotImplementedException();
        }
    }
}
