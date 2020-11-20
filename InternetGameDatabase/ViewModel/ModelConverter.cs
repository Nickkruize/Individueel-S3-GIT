using DAL.ContextModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternetGameDatabase.ViewModel
{
    public static class ModelConverter
    {
        public static ReviewReadViewModel ReviewEntityToReadViewModel(Review review)
        {
            return new ReviewReadViewModel()
            {
                Id = review.Id,
                Content = review.Content,
                PostDate = review.PostDate,
                Rating = review.Rating,
                Title = review.Title,
                Username = review.User.Username,
                GameId = review.Game.Id,
                UserId = review.User.Id,
                GameTitle = review.Game.Title,
            };
        }

        public static GameListViewModel GameEntityToGameListViewModel(Game game)
        {
            return new GameListViewModel()
            {
                Id = game.Id,
                Description = game.Description,
                Image = game.Image,
                ReleaseYear = game.ReleaseYear,
                Title = game.Title,
                Publisher = new Publisher()
                {
                    Id = game.Publisher.Id,
                    FoundingYear = game.Publisher.FoundingYear,
                    Name = game.Publisher.Name,
                    Logo = game.Publisher.Logo
                }
            };
        }
    }
}
