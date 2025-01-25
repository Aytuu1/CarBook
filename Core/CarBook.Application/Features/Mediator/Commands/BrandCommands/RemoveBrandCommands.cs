

using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.BrandCommands
{
    public class RemoveBrandCommands:IRequest
    {
        public RemoveBrandCommands(int id)
        {
            Id = id;
        }

        public int Id { get; set; }




    }
}
