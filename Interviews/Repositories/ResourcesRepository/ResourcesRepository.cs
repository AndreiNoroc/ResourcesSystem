using Interviews.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Interviews.Repositories.ResourcesRepository
{
    public class ResourcesRepository : IResourcesRepository
    {
        private readonly MobylabAppContext _dbContext;

        public ResourcesRepository()
        {
            _dbContext = new MobylabAppContext();
        }

        public async Task<ActionResult<List<ResourceDTO>>> GetAllResourcesRepo()
        {
            List<Resource> rawResources = _dbContext.Resources.ToList();
            List<ResourceDTO> resources = new List<ResourceDTO>();

            foreach (Resource resource in rawResources)
            {
                Company company = _dbContext.Companies.SingleOrDefault(company => company.CompId == resource.RCompanyId);
                
                ResourceDTO newDTOResource = new ResourceDTO
                {

                    RName = resource.RName,
                    RUrl = resource.RUrl,
                    CName = _dbContext.Categories.SingleOrDefault(category => category.CId == resource.RCategoryId).CName,
                    CompName = company.CompName,
                    PName = _dbContext.Positions.SingleOrDefault(position => position.PId == company.CompPositionId).PName,
                    LDescription = _dbContext.Levels.SingleOrDefault(level => level.LId == resource.RLevelId).LDescription
                };

                resources.Add(newDTOResource);
            }

            return resources;
        }

        public async Task<ActionResult<ResourceDTO>> GetByNameRepo(string value)
        {
            Resource resource = _dbContext.Resources.SingleOrDefault(resource => resource.RName == value);

            Company company = _dbContext.Companies.SingleOrDefault(company => company.CompId == resource.RCompanyId);

            ResourceDTO newDTOResource = new ResourceDTO
            {

                RName = resource.RName,
                RUrl = resource.RUrl,
                CName = _dbContext.Categories.SingleOrDefault(category => category.CId == resource.RCategoryId).CName,
                CompName = company.CompName,
                PName = _dbContext.Positions.SingleOrDefault(position => position.PId == company.CompPositionId).PName,
                LDescription = _dbContext.Levels.SingleOrDefault(level => level.LId == resource.RLevelId).LDescription
            };

            return newDTOResource;
        }

        public async Task<ActionResult<string>> InsertResourceRepo(ResourceDTO resource)
        {
            Category cat = _dbContext.Categories.SingleOrDefault(category => category.CName == resource.CName);

            Category category = cat;
            int insertCatId = -1;
            if (cat == null)
            {
                category = new Category
                { 
                    CName = resource.CName,
                };

                await _dbContext.Categories.AddAsync(category);
                await _dbContext.SaveChangesAsync();

                insertCatId = category.CId;
            }
            else
            {
                insertCatId = cat.CId;
            }

            Company comp = _dbContext.Companies.SingleOrDefault(company => company.CompName == resource.CompName);
            Position pos = _dbContext.Positions.SingleOrDefault(position => position.PName == resource.PName);

            Position position = pos;
            int insertPosId = -1;
            if (pos == null)
            {
                position = new Position
                {
                    PName = resource.PName,
                };

                await _dbContext.Positions.AddAsync(position);
                await _dbContext.SaveChangesAsync();

                insertPosId = position.PId;
            }
            else
            {
            insertPosId = pos.PId;
            }

            Company company = comp;
            int insertCompId = -1;
            if (comp == null)
            {
                company = new Company
                {
                    CompName = resource.CompName,
                    CompPositionId = insertPosId,
                    CompPosition = position
                };

                await _dbContext.Companies.AddAsync(company);
                await _dbContext.SaveChangesAsync();

                insertCompId = company.CompId;
            }
            else
            {
                insertCompId = comp.CompId;
            }

            Level lev = _dbContext.Levels.SingleOrDefault(level => level.LDescription == resource.LDescription);

            Level level = lev;
            int insertLevelId = -1;
            if (lev == null)
            {
                level = new Level
                {
                    LDescription = resource.LDescription,
                };

                await _dbContext.Levels.AddAsync(level);
                await _dbContext.SaveChangesAsync();

                insertLevelId = level.LId;
            }
            else
            {
                insertLevelId = lev.LId;
            }

            Resource insertResource = new Resource
            {
                RName = resource.RName,
                RUrl = resource.RUrl,
                RCategoryId = insertCatId,
                RCompanyId = insertCompId,
                RLevelId = insertLevelId,
                RCategory = category,
                RCompany = company,
                RLevel = lev
            };

            await _dbContext.Resources.AddAsync(insertResource);
            await _dbContext.SaveChangesAsync();

            return "Successfully added!";
        }

        public async Task<ActionResult<string>> UpdateResourceRepo(string rname, ResourceDTO resource)
        {
            Resource getResource = _dbContext.Resources.SingleOrDefault(resource => resource.RName == rname);

            Company company = _dbContext.Companies.SingleOrDefault(company => company.CompId == getResource.RCompanyId);

            Category category = _dbContext.Categories.SingleOrDefault(category => category.CId == getResource.RCategoryId);

            Position position = _dbContext.Positions.SingleOrDefault(position => position.PId == company.CompPositionId);

            Level level = _dbContext.Levels.SingleOrDefault(level => level.LId == getResource.RLevelId);

            if (getResource.RUrl != resource.RUrl)
            {
                getResource.RUrl = resource.RUrl;
            }

            if (category.CName != resource.CName)
            {
                Category newCategory = _dbContext.Categories.SingleOrDefault(category => category.CName == resource.CName);
                getResource.RCategoryId = newCategory.CId;
                getResource.RCategory = newCategory;
            }

            if (company.CompName != resource.CName)
            {
                Position newPostion = position;
                if (position.PName != resource.PName)
                {
                    newPostion = _dbContext.Positions.SingleOrDefault(position => position.PName == resource.PName);   
                }

                Company newCompany = _dbContext.Companies.SingleOrDefault(company => company.CompName == resource.CName && company.CompPositionId == newPostion.PId);

                getResource.RCompanyId = newCompany.CompId;
                getResource.RCompany = newCompany;
            }

            if (level.LDescription != resource.LDescription)
            {
                Level newLevel = _dbContext.Levels.SingleOrDefault(level => level.LDescription == resource.LDescription);
                getResource.RLevelId = newLevel.LId;
                getResource.RLevel = newLevel;
            }

            _dbContext.Resources.Update(getResource);
            await _dbContext.SaveChangesAsync();

            return "Successfully updated!";
        }

        public async Task<ActionResult<string>> DeleteResourcesRepo()
        {
            await _dbContext.Resources.ExecuteDeleteAsync();

            return "Successfully deleted!";
        }
    }
}
