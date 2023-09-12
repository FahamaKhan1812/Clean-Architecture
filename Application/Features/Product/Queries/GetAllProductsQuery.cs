using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Product.Queries;

public class GetAllProductsQuery: IRequest<IEnumerable<Domain.Entities.Product>>
{
    internal class GetQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<Domain.Entities.Product>>
    {
        private readonly IApplicationDbContext _context;

        public GetQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Domain.Entities.Product>?> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Products.ToListAsync(cancellationToken);
            if(result == null)
            {
                return null;
            }
            return result;
        }
    }
}
