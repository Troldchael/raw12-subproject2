﻿using System.Collections.Generic;
using DataServiceLib.Framework;

namespace DataServiceLib
{
    public interface IDataService
    {
        // users interface
        IList<Users> GetUsers();
        bool CreateUser(Users users);
        bool UpdateUser(Users users);
        bool DeleteUser(int id);
        Users GetUser(int id);
        IList<Users> GetUserInfo(int page, int pageSize);
        int NumberOfUsers();


        // search interface
        IList<SearchHistory> GetSearches();
        SearchHistory GetSearch(string id);
        IList<SearchHistory> GetSearchInfo(int page, int pageSize);
        int NumberOfSearches();

        // din mors interface 

        
    }
}