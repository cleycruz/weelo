using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Owners.Commands.CreateOwner;
using CleanArchitecture.Application.Owners.Commands.DeleteOwner;
using CleanArchitecture.Application.Owners.Commands.UpdateOwner;
using CleanArchitecture.Application.Owners.Commands.UpdateOwnerDetail;
using CleanArchitecture.Application.Owners.Queries.GetOwnersWithPagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;

[Authorize]
public class OwnersController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<OwnerBriefDto>>> GetOwnerWithPagination([FromQuery] GetOwnersWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateOwnerCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateOwnerCommand command)
    {
        if (id != command.IdOwner)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpPut("[action]")]
    public async Task<ActionResult> UpdateItemDetails(int id, UpdateOwnerDetailCommand command)
    {
        if (id != command.IdOwner)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteOwnerCommand { Id = id });

        return NoContent();
    }
}
