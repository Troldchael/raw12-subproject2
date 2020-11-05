using System.Collections.Generic;
using DataServiceLib.Framework;

namespace DataServiceLib
{
    public interface IDataService
    {

        IList<Users> GetUsers();

        Users GetUsers(int id);
        void CreateUsers(Users users);
        bool UpdateUsers(Users users);
        bool DeleteUsers(int id);

        IList<Users> GetUsers(int page, int pageSize);
        Users GetUser(int id);
        int NumberOfUsers();
    }
}