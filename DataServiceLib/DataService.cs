using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DataServiceLib.Moviedata;

namespace DataServiceLib.Framework
{
    public class DataService : IDataService
    {
        // Framework Dataservice ////////

        // Users data service
        public IList<Users> UserToList()
        {
            var ctx = new Raw12Context();
            var users = ctx.Users.ToList();
            return users;
        }

        public IList<Users> GetUsers()
        {
            return UserToList();
        }

        public Users GetUser(int id)
        {
            var ctx = new Raw12Context();
            var users = ctx.Users;

            return users.FirstOrDefault(x => x.UserId == id);
        }

        public IList<Users> GetUserInfo(int page, int pageSize)
        {
            return UserToList()
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public int NumberOfUsers()
        {
            return UserToList().Count;
        }

        public bool CreateUser(Users users)
        {
            var maxId = UserToList().Max(x => x.UserId);
            users.UserId = maxId + 1;

            var cont = new Raw12Context();

            var dbCat = GetUser(users.UserId);
            if (dbCat == null)
            {
                return false;
            }

            dbCat.Username = users.Username;
            dbCat.Email = users.Email;
            dbCat.Password = users.Password;

            cont.Users.Add(dbCat);
            cont.SaveChanges();

            return true;
        }

        public bool UpdateUser(Users users)
        {
            var cont = new Raw12Context();

            var dbCat = GetUser(users.UserId);
            if (dbCat == null)
            {
                return false;
            }

            dbCat.Username = users.Username;
            dbCat.Email = users.Email;
            dbCat.Password = users.Password;

            cont.Users.Update(dbCat);
            cont.SaveChanges();

            return true;
        }

        public bool DeleteUser(int id)
        {
            var cont = new Raw12Context();
            var dbCat = GetUser(id);
            if (dbCat == null)
            {
                return false;
            }

            cont.Users.Remove(dbCat);
            cont.SaveChanges();
            return true;
        }

        // searchhistory data service
        public IList<SearchHistory> SearchToList()
        {
            var ctx = new Raw12Context();
            var searches = ctx.SearchHistory.ToList();
            return searches;
        }

        public IList<SearchHistory> GetSearches()
        {
            return SearchToList();
        }

        public SearchHistory GetSearch(int id)
        {
            var ctx = new Raw12Context();
            var searches = ctx.SearchHistory;

            return searches.FirstOrDefault(x => x.UserId == id);
        }

        public bool CreateSearch(SearchHistory searches)
        {
            var maxId = SearchToList().Max(x => x.UserId);
            searches.UserId = maxId + 1;

            var dbCat = GetSearch(searches.UserId);
            if (dbCat == null)
            {
                return false;
            }

            dbCat.UserId = searches.UserId;
            dbCat.Timestamp = searches.Timestamp;
            dbCat.Keyword = searches.Keyword;

            return true;
        }

        public bool UpdateSearch(SearchHistory searches)
        {
            var cont = new Raw12Context();

            var dbCat = GetSearch(searches.UserId);
            if (dbCat == null)
            {
                return false;
            }

            dbCat.UserId = searches.UserId;
            dbCat.Timestamp = searches.Timestamp;
            dbCat.Keyword = searches.Keyword;

            cont.SearchHistory.Update(dbCat);
            cont.SaveChanges();

            return true;
        }

        public bool DeleteSearch(int id)
        {
            var cont = new Raw12Context();
            var dbCat = GetSearch(id);
            if (dbCat == null)
            {
                return false;
            }

            cont.SearchHistory.Remove(dbCat);
            cont.SaveChanges();
            return true;
        }

        public IList<SearchHistory> GetSearchInfo(int page, int pageSize)
        {
            return SearchToList()
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public int NumberOfSearches()
        {
            return SearchToList().Count;
        }


        // ratings dataservice
        public IList<RatingHistory> RatingsToList()
        {
            var ctx = new Raw12Context();
            var ratings = ctx.RatingHistory.ToList();
            return ratings;
        }

        public IList<RatingHistory> GetRatings()
        {
            return RatingsToList();
        }

        public RatingHistory GetRating(int id)
        {
            var ctx = new Raw12Context();
            var ratings = ctx.RatingHistory;

            return ratings.FirstOrDefault(x => x.UserId == id);
        }

        public bool CreateRating(RatingHistory ratings)
        {
            var maxId = RatingsToList().Max(x => x.UserId);
            ratings.UserId = maxId + 1;

            var dbCat = GetRating(ratings.UserId);
            if (dbCat == null)
            {
                return false;
            }

            dbCat.UserId = ratings.UserId;
            dbCat.Rating = ratings.Rating;
            dbCat.TitleId = ratings.TitleId;

            return true;
        }

        public bool UpdateRating(RatingHistory ratings)
        {
            var cont = new Raw12Context();

            var dbCat = GetRating(ratings.UserId);
            if (dbCat == null)
            {
                return false;
            }

            dbCat.UserId = ratings.UserId;
            dbCat.Rating = ratings.Rating;
            dbCat.TitleId = ratings.TitleId;

            cont.RatingHistory.Update(dbCat);
            cont.SaveChanges();

            return true;
        }

        public bool DeleteRating(int id)
        {
            var cont = new Raw12Context();
            var dbCat = GetRating(id);
            if (dbCat == null)
            {
                return false;
            }

            cont.RatingHistory.Remove(dbCat);
            cont.SaveChanges();
            return true;
        }

        public IList<RatingHistory> GetRatingInfo(int page, int pageSize)
        {
            return RatingsToList()
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public int NumberOfRatings()
        {
            return SearchToList().Count;
        }


        // title bookings dataservice
        public IList<TitleBookmarking> TBookToList()
        {
            var ctx = new Raw12Context();
            var tbookings = ctx.TitleBook.ToList();
            return tbookings;
        }

        public IList<TitleBookmarking> GetTBookings()
        {
            return TBookToList();
        }

        public TitleBookmarking GetTBooking(int id)
        {
            var ctx = new Raw12Context();
            var tbookings = ctx.TitleBook;

            return tbookings.FirstOrDefault(x => x.UserId == id);
        }

        public IList<TitleBookmarking> GetTBookInfo(int page, int pageSize)
        {
            return TBookToList()
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public int NumberOfTBookings()
        {
            return TBookToList().Count;
        }


        // actor bookings dataservice
        public IList<ActorBookmarking> ABookToList()
        {
            var ctx = new Raw12Context();
            var abookings = ctx.ActorBook.ToList();
            return abookings;
        }

        public IList<ActorBookmarking> GetABookings()
        {
            return ABookToList();
        }

        public ActorBookmarking GetABooking(int id)
        {
            var ctx = new Raw12Context();
            var abookings = ctx.ActorBook;

            return abookings.FirstOrDefault(x => x.UserId == id);
        }

        public IList<ActorBookmarking> GetABookInfo(int page, int pageSize)
        {
            return ABookToList()
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public int NumberOfABookings()
        {
            return ABookToList().Count;
        }



        //Movie Data dataservices ///////////////

        // actors dataservice
        public IList<Actors> ActorsToList()
        {
            var ctx = new Raw12Context();
            var actors = ctx.Actors.ToList();
            return actors;
        }

        public IList<Actors> GetActors()
        {
            return ActorsToList();
        }

        public Actors GetActor(string id)
        {
            var ctx = new Raw12Context();
            var actors = ctx.Actors;

            return actors.FirstOrDefault(x => x.Nconst == id); 
        }

        public IList<Actors> GetActorInfo(int page, int pageSize)
        {
            return ActorsToList()
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public int NumberOfActors()
        {
            return ActorsToList().Count;
        }

        // movies dataservice
        public IList<Movies> MoviesToList()
        {
            var ctx = new Raw12Context();
            var movies = ctx.Movies.ToList();
            return movies;
        }

        public IList<Movies> GetMovies()
        {
            return MoviesToList();
        }

        public Movies GetMovie(string id)
        {
            var ctx = new Raw12Context();
            var movies = ctx.Movies;

            return movies.FirstOrDefault(x => x.TitleId.Trim() == id.Trim()); //trim to fix id whitespace
        }

        public IList<Movies> GetMovieInfo(int page, int pageSize)
        {
            return MoviesToList()
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public int NumberOfMovies()
        {
            return ActorsToList().Count;
        }

        // genres dataservice
        public IList<Genres> GenresToList()
        {
            var ctx = new Raw12Context();
            var genres = ctx.Genres.ToList();
            return genres;
        }

        public IList<Genres> GetGenres()
        {
            return GenresToList();
        }

        public Genres GetGenre(string id)
        {
            var ctx = new Raw12Context();
            var genres = ctx.Genres;

            return genres.FirstOrDefault(x => x.TitleId == id);
        }

        public IList<Genres> GetGenreInfo(int page, int pageSize)
        {
            return GenresToList()
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public int NumberOfGenres()
        {
            return GenresToList().Count;
        }


        // details dataservice
        public IList<Details> DetailsToList()
        {
            var ctx = new Raw12Context();
            var details = ctx.Details.ToList();
            return details;
        }

        public IList<Details> GetDetails()
        {
            return DetailsToList();
        }

        public Details GetDetail(string id)
        {
            var ctx = new Raw12Context();
            var details = ctx.Details;

            return details.FirstOrDefault(x => x.TitleId == id);
        }

        public IList<Details> GetDetailInfo(int page, int pageSize)
        {
            return DetailsToList()
                .Skip(page * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public int NumberOfDetails()
        {
            return DetailsToList().Count;
        }
    }
}
