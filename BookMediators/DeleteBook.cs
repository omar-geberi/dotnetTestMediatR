using System;
using System.Threading;
using System.Threading.Tasks;
using dotnet_book.Data;
using MediatR;

namespace dotnet_book.BookMediators
{
    public class DeleteBook
    {
        public class DeleteCommand : IRequest
        {
            public int Id { get; set; }   
        }

        public class Handler : IRequestHandler<DeleteCommand>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteCommand request, CancellationToken cancellationToken)
            {
                var book = await _context.Books.FindAsync(request.Id);
                if (book == null)
                {
                    throw new Exception("Could not find book");
                }
                _context.Remove(book);
                var result = await _context.SaveChangesAsync();
                if (result>0)
                {
                    return Unit.Value;
                }
                throw new Exception("A problem happened while Deleting the book");
            }

            
        }
    }
}