using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Product.Queries;

public class GetSingleProductQuery: IRequest<Domain.Entities.Product>
{
    public int Id { get; set; }
    internal class GetQueryHandler : IRequestHandler<GetSingleProductQuery, Domain.Entities.Product>
    {
        private readonly IApplicationDbContext _context;

        public GetQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Domain.Entities.Product> Handle(GetSingleProductQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Products.Where(x => x.Id == request.Id).SingleOrDefaultAsync(cancellationToken);
            if(result == null)
            {
                return default;
            }
            return result;
        }
    }
}
