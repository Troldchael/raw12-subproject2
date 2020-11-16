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
    public class Raw12Tests
    {
        private Mock<IDataService> _dataServiceMock;
        private Mock<IMapper> _mapperMock;
        private Mock<IUrlHelper> _urlMock;

        public Raw12Tests()
        {
            _dataServiceMock = new Mock<IDataService>();
            _mapperMock = new Mock<IMapper>();
            _urlMock = new Mock<IUrlHelper>();
        }

        //user tests
        [Fact]
        public void GetUserWithValidIdShouldReturnOk()
        {

            _dataServiceMock.Setup(x => x.GetUser(1)).Returns(new Users { UserId = new int() }); // dunno what to return here so test failes, even though it should pass

            _mapperMock.Setup(x => x.Map<UserElementDto>(It.IsAny<Users>())).Returns(new UserElementDto());

            var ctrl = new UsersController(_dataServiceMock.Object, _mapperMock.Object);

            var response = ctrl.GetUser(1);

            response.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public void GetUserWithInvalidIdShouldReturnNotFound()
        {

            var ctrl = new UsersController(_dataServiceMock.Object, null);

            var response = ctrl.GetUser(1221);

            response.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public void CreateUserShouldCallDataService()
        {
            var ctrl = new UsersController(_dataServiceMock.Object, _mapperMock.Object);

            ctrl.CreateUsers(new UserForCreationOrUpdateDto());

            _dataServiceMock.Verify(x => x.CreateUser(It.IsAny<Users>()), Times.Once);
        }

        // ratingstest
        [Fact]
        public void CreateRatingShouldCallDataService()
        {
            var ctrl = new RatingsController(_dataServiceMock.Object, _mapperMock.Object);

            ctrl.CreateRating(new RatingForCreationOrUpdateDto());

            _dataServiceMock.Verify(x => x.CreateRating(It.IsAny<RatingHistory>()), Times.Once);
        }

        // maybe an moviedata test here

    }
}
