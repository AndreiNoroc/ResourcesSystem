using Interviews.Models;
using Interviews.Services.ResourcesService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Interviews.Controllers.ResourcesController
{
    [Route("resources/[controller]/[action]")]
    [ApiController]
    public class ResourcesController : ControllerBase
    {
        private readonly IResourcesService _resourcesService;

        public ResourcesController(IResourcesService _resourcesService)
        {
            this._resourcesService = _resourcesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ResourceDTO>>> GetAllResources()
        {
            return await _resourcesService.GetAllResourcesService();
        }

        [HttpGet("{rname}"), Authorize]
        public async Task<ActionResult<ResourceDTO>> GetByName([FromRoute] string rname)
        {
            return await _resourcesService.GetByNameService(rname);
        }

        [HttpPost, Authorize]
        public async Task<ActionResult<string>> InsertResource([FromBody] ResourceDTO resource)
        {
            return await _resourcesService.InsertResourceService(resource);
        }

        [HttpPut("{rname}"), Authorize]
        public async Task<ActionResult<string>> UpdateResource([FromRoute] string rname, [FromBody] ResourceDTO resource)
        {
            return await _resourcesService.UpdateResourceService(rname, resource);
        }

        [HttpDelete, Authorize]
        public async Task<ActionResult<string>> DeleteResources()
        {
            return await _resourcesService.DeleteResourcesService();
        }
    }
}
