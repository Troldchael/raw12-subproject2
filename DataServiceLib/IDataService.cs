﻿using System;
using System.Collections.Generic;

using DataServiceLib.Framework;

using DataServiceLib.Moviedata;

namespace DataServiceLib
{
    public interface IDataService
    {

        IList<Users> GetUsers();

        void CreateUser(string username, string password, string salt);
        bool UpdateUser(Users users);
        bool DeleteUser(int id);
        IList<Details> GetDetails();

        IList<Actors> GetActors();

        IList<Genres> GetGenres();

        IList<Ratings> GetRatings();



        /*Category GetCategory(int id);
        void CreateCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(int id);*/

        Users GetUserId(int id);

        Users GetUserName(String userName);

        IList<Users> GetUserInfo(int page, int pageSize);
       
        int NumberOfUsers();
    }
}