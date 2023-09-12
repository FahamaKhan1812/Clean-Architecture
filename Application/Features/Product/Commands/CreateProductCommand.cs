using Application.Interfaces;
using MediatR;

namespace Application.Features.Product.Commands;
public class CreateProductCommand: IRequest<int>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Rate { get; set; }

    internal class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateProductCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Domain.Entities.Product product = new();

            product.Name = request.Name;
            product.Description = request.Description;
            product.Rate = request.Rate;

            await _context.Products.AddAsync(product, cancellationToken);
            await _context.SaveChangesAsync();
            return product.Id;
        }
    }
}
