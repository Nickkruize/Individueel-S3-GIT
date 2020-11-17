using DAL.ContextModel;
using IGDB_Users.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DeepEqual.Syntax;
using System.Linq;
using InternetGameDatabase.Repositories;

namespace IGDB_Tests.RepositoryTests
{
    [TestClass]
    public class PublisherRepositoryTests : TestContext
    {
        private readonly PublisherRepository _repo;

        public PublisherRepositoryTests()
        {
            _repo = new PublisherRepository(GetDatabaseContext<Publisher>(Publisherdata()).Result);
        }

        private List<Publisher> Publisherdata()
        {
            List<Publisher> publishers = new List<Publisher>();

            for (int i = 1; i <= 10; i++)
            {
                Publisher publisher = new Publisher()
                {
                    Id = i + 100,
                    Name = $"testgame{i}",
                    FoundingYear = 1900 + 1,
                    Logo = $"MooiLogo{i}"
                };
                publishers.Add(publisher);
            }

            return publishers;
        }
    }
}