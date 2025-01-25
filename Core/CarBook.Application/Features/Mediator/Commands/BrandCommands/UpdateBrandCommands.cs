

using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.BrandCommands
{
    public class UpdateBrandCommands:IRequest
    {
        public int BrandID { get; set; }
        public string Name { get; set; }














    }
}
