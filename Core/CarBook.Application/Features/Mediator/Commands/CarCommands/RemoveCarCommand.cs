using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.CarCommands
{
    public class RemoveCarCommand:IRequest
    {
        public RemoveCarCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
