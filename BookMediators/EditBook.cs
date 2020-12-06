using System;
using System.Threading;
using System.Threading.Tasks;
using dotnet_book.Data;
using MediatR;

namespace dotnet_book.BookMediators
{
    public class EditBook
    {
        public class EditCommand : IRequest
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string Author { get; set; }
        }

        public class Handler : IRequestHandler<EditCommand>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(EditCommand request, CancellationToken cancellationToken)
            {
                var book = await _context.Books.FindAsync(request.Id);
                if (book == null)
                {
                    throw new Exception("Book Not found");
                }
                book.Name = request.Name ;
                book.Author = request.Author ;
                var result = await _context.SaveChangesAsync();
                if (result>0)
                {
                    return Unit.Value;
                }
                throw new Exception(" A problem happened while editing the Book");
            }

        }
    }
}