using System.Threading;
using System.Threading.Tasks;
using dotnet_book.Data;
using dotnet_book.Models;
using MediatR;

namespace dotnet_book.BookMediators
{
    public class GetBookById
    {
        public class QueryBook : IRequest<Book>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<QueryBook, Book>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;

            }
            public async Task<Book> Handle(QueryBook request, CancellationToken cancellationToken)
            {
               var book =  await _context.Books.FindAsync(request.Id);
               return book;
            }
        }
    }
}