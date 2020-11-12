using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataServiceLib.Framework
{
    public class DataService : IDataService
    {
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

            var dbCat = GetUser(users.UserId);
            if (dbCat == null)
            {
                return false;
            }

            dbCat.Username = users.Username;
            dbCat.Email = users.Email;
            dbCat.Password = users.Password;

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
    }
}
