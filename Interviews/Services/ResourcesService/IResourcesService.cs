using Interviews.Models;
using Microsoft.AspNetCore.Mvc;

namespace Interviews.Services.ResourcesService
{
    public interface IResourcesService
    {
        public Task<ActionResult<List<ResourceDTO>>> GetAllResourcesService();
        public Task<ActionResult<ResourceDTO>> GetByNameService(string value);
        public Task<ActionResult<string>> InsertResourceService(ResourceDTO resource);
        public Task<ActionResult<string>> UpdateResourceService(string rname, ResourceDTO resource);
        public Task<ActionResult<string>> DeleteResourcesService();

    }
}
