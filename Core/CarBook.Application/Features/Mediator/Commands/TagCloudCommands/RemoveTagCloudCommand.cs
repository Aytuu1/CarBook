﻿

using MediatR;

namespace CarBook.Application.Features.Mediator.Commands.TagCloudCommands
{
  public class RemoveTagCloudCommand:IRequest
  {
    public RemoveTagCloudCommand(int id)
    {
      Id = id;
    }

    public int Id { get; set; }
    }
}
