using System;
using System.Threading;
using System.Threading.Tasks;
using dotnet_book.Data;
using dotnet_book.Models;
using MediatR;

namespace dotnet_book.BookMediators
{
    public class CreateBook
    {
        public class CreateCommand : IRequest
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Author { get; set; }
        }

        
            public class Handler : IRequestHandler<CreateCommand>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;

            }
            public async Task<Unit> Handle(CreateCommand request, CancellationToken cancellationToken)
            {
                var book = new Book {
                    Id  = request.Id,
                    Name = request.Name,
                    Author = request.Author
                };
                _context.Books.Add(book);
                var result = await _context.SaveChangesAsync() ;
                if(result>0)
                {
                    return Unit.Value;
                }
                else
                {
                    throw new Exception("An error happened during Creation of the Book");
                }
            }
        }
    }
}
