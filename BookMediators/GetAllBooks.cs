using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using dotnet_book.Data;
using dotnet_book.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace dotnet_book.BookMediators
{
    public class GetAllBooks
    {
        public class QueryBooks : IRequest<List<Book>>
        {

        }
        public class Handler : IRequestHandler<QueryBooks, List<Book>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;

            }
            public async Task<List<Book>> Handle(QueryBooks request, CancellationToken cancellationToken)
            {
                var books = await  _context.Books.ToListAsync();
                return books;
            }
        }
    }
}