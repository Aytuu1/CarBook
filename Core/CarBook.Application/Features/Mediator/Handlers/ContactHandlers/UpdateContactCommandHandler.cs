using CarBook.Application.Features.Mediator.Commands.ContactCommands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.Mediator.Handlers.ContactHandlers
{
    public class UpdateContactCommandHandler:IRequestHandler<UpdateContactCommand>
  {

        private readonly IRepository<Contact> _repository;

        public UpdateContactCommandHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

    public async Task Handle(UpdateContactCommand command, CancellationToken cancellationToken)
    {
      var values = await _repository.GetByIdAsync(command.ContactID);
      values.Name = command.Name;
      values.Email = command.Email;
      values.Message = command.Message;
      values.Subject = command.Subject;
      values.SendDate = command.SendDate;
      await _repository.UpdateAsync(values);
    }
  }
}
