﻿using DAL;
using DAL.ContextModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IGDB_Tests
{
    public class TestContext
    {
        public async Task<IGDBContext> GetDatabaseContext<T>(List<T> data) where T : class
        {
            var options = new DbContextOptionsBuilder<IGDBContext>().UseInMemoryDatabase(databaseName: "testdb").EnableSensitiveDataLogging().Options;
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
