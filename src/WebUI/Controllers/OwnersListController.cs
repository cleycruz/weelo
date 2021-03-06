using CleanArchitecture.Application.OwnersLists.Commands.CreateOwnersList;
using CleanArchitecture.Application.OwnersLists.Commands.DeleteOwnersList;
using CleanArchitecture.Application.OwnersLists.Commands.UpdateOwnersList;
using CleanArchitecture.Application.OwnersLists.Queries.ExportOwners;
using CleanArchitecture.Application.OwnersLists.Queries.GetOwners;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.WebUI.Controllers;

[Authorize]
public class OwnersListController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<OwnersVm>> Get()
    {
        return await Mediator.Send(new GetOwnersQuery());
    }

    [HttpGet("{id}")]
    public async Task<FileResult> Get(int id)
    {
        var vm = await Mediator.Send(new ExportOwnersQuery { ListId = id });

        return File(vm.Content, vm.ContentType, vm.FileName);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateOwnersListCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateOwnersListCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteOwnersListCommand { Id = id });

        return NoContent();
    }
}
