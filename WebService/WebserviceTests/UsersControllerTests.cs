using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataServiceLib;
using DataServiceLib.Framework;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebService.Controllers;
using WebService.Models;
using Xunit;

namespace WebService.WebserviceTests
{
    public class UsersControllerTests
    {
        private Mock<IDataService> _dataServiceMock;
        private Mock<IMapper> _mapperMock;
        private Mock<IUrlHelper> _urlMock;

        public UsersControllerTests()
        {
            _dataServiceMock = new Mock<IDataService>();
            _mapperMock = new Mock<IMapper>();
            _urlMock = new Mock<IUrlHelper>();
        }

        [Fact]
        public void CreateUserShouldCallDataService()
        {
            var ctrl = new UsersController(_dataServiceMock.Object, _mapperMock.Object);

            ctrl.CreateUsers(new UserForCreationOrUpdateDto());

            _dataServiceMock.Verify(x => x.CreateUser(It.IsAny<Users>()), Times.Once);
        }
    }
}
