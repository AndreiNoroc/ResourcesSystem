using Interviews.Models;
using Interviews.Repositories.UserRepository;
using Microsoft.EntityFrameworkCore;

namespace Interviews.Database
{
    public class AppDatabase
    {
        public IConfiguration Configuration { get; }

        public AppDatabase(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            /*
            services.AddDbContext<MobylabAppContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));
            */
        }
    }
}
