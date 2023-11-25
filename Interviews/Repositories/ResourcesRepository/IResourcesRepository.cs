using Interviews.Models;
using Microsoft.AspNetCore.Mvc;

namespace Interviews.Repositories.ResourcesRepository
{
    public interface IResourcesRepository
    {
        public Task<ActionResult<List<ResourceDTO>>> GetAllResourcesRepo();
        public Task<ActionResult<ResourceDTO>> GetByNameRepo(string value);
        public Task<ActionResult<string>> InsertResourceRepo(ResourceDTO resource);
        public Task<ActionResult<string>> UpdateResourceRepo(string rname, ResourceDTO resource);
        public Task<ActionResult<string>> DeleteResourcesRepo();
    }
}
