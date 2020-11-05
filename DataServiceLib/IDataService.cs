using System.Collections.Generic;
using DataServiceLib.Framework;

namespace DataServiceLib
{
    public interface IDataService
    {

        IList<Users> GetUsers();

        void CreateUsers(Users users);
        bool UpdateUsers(Users users);
        bool DeleteUsers(string id);

        Users GetUser(string id);

        IList<Users> GetUserInfo(int page, int pageSize);
       
        int NumberOfUsers();
    }
}