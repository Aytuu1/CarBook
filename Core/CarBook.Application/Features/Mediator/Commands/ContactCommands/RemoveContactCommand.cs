

using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.ContactCommands
{
    public class RemoveContactCommand : IRequest
  {
        public RemoveContactCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
