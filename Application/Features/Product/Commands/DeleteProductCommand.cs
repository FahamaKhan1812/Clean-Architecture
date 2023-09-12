using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Product.Commands;
public class DeleteProductCommand: IRequest<int>
{
    public int Id { get; set; }


    internal class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _context.Products.Where(x => x.Id == request.Id).SingleOrDefaultAsync(cancellationToken);
            if (product == null)
            {
                return default;
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();    
            return product.Id;
        }
    }
}
