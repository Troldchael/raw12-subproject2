using DataServiceLib;
using Moq;
using System;
using AutoMapper;
using DataServiceLib.Framework;
using FluentAssertions;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using WebService.Controllers;
using WebService.Models;

namespace WebServiceTests
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
        public void GetUserWithValidIdShouldReturnOk()
        {
            //_dataServiceMock.Setup(x => x.GetUser(1).Returns(new Users());

            var ctrl = new UsersController(_dataServiceMock.Object, _mapperMock.Object);

            var response = ctrl.GetUser(1);

            response.Should().BeOfType<OkObjectResult>();
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
