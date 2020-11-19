using DAL;
using DAL.ContextModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IGDB_Tests
{
    public class TestContext
    {
        public async Task<IGDBContext> GetDatabaseContext<T>(List<T> data, string dbName) where T : class
        {
            var options = new DbContextOptionsBuilder<IGDBContext>().UseInMemoryDatabase(databaseName: dbName).EnableSensitiveDataLogging().Options;
            var databaseContext = new IGDBContext(options);
            databaseContext.Database.EnsureCreated();

            if (await databaseContext.Set<T>().CountAsync() <= 0)
            {
                for (int i = 0; i < data.Count; i++)
                {
                    databaseContext.Set<T>().Add(data[i]);
                }
                await databaseContext.SaveChangesAsync();
            }
            return databaseContext;
        }
    }
}
