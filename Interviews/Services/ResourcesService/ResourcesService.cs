using Interviews.Models;
using Interviews.Repositories.ResourcesRepository;
using Microsoft.AspNetCore.Mvc;

namespace Interviews.Services.ResourcesService
{
    public class ResourcesService : IResourcesService
    {
        private readonly IResourcesRepository _repository;

        public ResourcesService(IResourcesRepository repository)
        {
            _repository = repository;
        }

        public async Task<ActionResult<List<ResourceDTO>>> GetAllResourcesService()
        {
            return await _repository.GetAllResourcesRepo();
        }

        public async Task<ActionResult<ResourceDTO>> GetByNameService(string value)
        {
            return await _repository.GetByNameRepo(value);
        }

        public async Task<ActionResult<string>> InsertResourceService(ResourceDTO resource)
        {
            return await _repository.InsertResourceRepo(resource);
        }

        public async Task<ActionResult<string>> UpdateResourceService(string rname, ResourceDTO resource)
        {
            return await _repository.UpdateResourceRepo(rname, resource);
        }

        public async Task<ActionResult<string>> DeleteResourcesService()
        {
            return await _repository.DeleteResourcesRepo();
        }
    }
}
