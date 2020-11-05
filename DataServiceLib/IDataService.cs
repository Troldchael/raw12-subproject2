using System.Collections.Generic;
using DataServiceLib.Framework;

namespace DataServiceLib
{
    public interface IDataService
    {

        IList<Users> GetUsers();

        void CreateUser(Users users);
        bool UpdateUser(Users users);
        bool DeleteUser(string id);

        Users GetUser(string id);

        IList<Users> GetUserInfo(int page, int pageSize);
       
        int NumberOfUsers();
    }
}