using DotNetCoreReactAdmin.Controllers;
using DotNetCoreReactAdmin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static NUnit.Framework.Assert;

namespace DotNetCoreReactAdmin.Test.Controllers
{
    /// <summary>
    /// <see cref="UserController"/> のテストクラスです。
    /// </summary>
    public class UserControllerTest
    {
        private DotNetCoreReactAdminContext _context = null!;
        private UserController _userController = null!;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<DotNetCoreReactAdminContext>()
                .UseInMemoryDatabase(databaseName: "DotNetCoreReactAdminContext")
                .Options;
            _context = new DotNetCoreReactAdminContext(options);

            DbInitializer.Initialize(_context);

            _userController = new UserController(_context) { ControllerContext = { HttpContext = new DefaultHttpContext() } };
        }

        [TearDown]
        public void TearDown()
        {
            _context.Dispose();
        }

        [Test]
        public async Task GetList_Ok()
        {
            // Arrange・Act
            var result = await _userController.Get("{\"Name\":\"Taro\"}", "[0,9]", "[\"id\",\"ASC\"]");

            // Assert
            var users= result.Value?.ToList();
            That(users, Is.Not.Null);
            That(users?.Count, Is.EqualTo(4));
            That(users?.Select(x => x.Id).ToList(), Is.EqualTo(new List<int>{ 1, 6, 11, 16}));
            
            var headers = _userController.Response.Headers;
            That(headers["Access-Control-Expose-Headers"].ToString(), Is.EqualTo("Content-Range"));
            That(headers["Content-Range"].ToString(), Is.EqualTo("user 0-9/4"));
        }

        [Test]
        public async Task GetList_Ok_ArgsEmpty()
        {
            // Arrange・Act
            var result = await _userController.Get();

            // Assert
            var users = result.Value?.ToList();
            That(users, Is.Not.Null);
            That(users?.Count, Is.EqualTo(20));
            That(users?.Select(x => x.Id).ToList(), Is.EqualTo(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 }));

            var headers = _userController.Response.Headers;
            That(headers["Access-Control-Expose-Headers"].ToString(), Is.EqualTo("Content-Range"));
            That(headers["Content-Range"].ToString(), Is.EqualTo("user 0-0/20"));
        }

        [Test]
        public async Task Get_Ok()
        {
            // Arrange・Act
            var result = await _userController.Get(1);

            // Assert
            var user = result.Value;
            That(user, Is.Not.Null);
            That(user?.Id, Is.EqualTo(1));
            That(user?.Name, Is.EqualTo("Taro Yamada"));
        }

        [Test]
        public async Task Get_Ng_TargetNotFound()
        {
            // Arrange・Act
            var result = await _userController.Get(999);

            // Assert
            That(result.Result, Is.AssignableTo(typeof(NotFoundResult)));
        }

        [Test]
        public async Task Post_Ok()
        {
            // Arrange
            var input = new User
            {
                Age = 20,
                Name = "Sample Test",
                Email = "sample@test.com",
                Phone = "111-1111-111",
                Website = "test.co.jp"
            };

            // Act
            var result = (await _userController.Post(input)).Result as OkObjectResult;

            // Assert
            var user = result?.Value as User;
            That(user, Is.Not.Null);
            That(user?.Name, Is.EqualTo("Sample Test"));
        }

        [Test]
        public async Task Put_Ok()
        {
            // Arrange
            var input = _context.User.First(x => x.Id == 1);
            input.Name = "Sample Test";

            // Act
            var result = (await _userController.Put(1, input)).Result as OkObjectResult;

            // Assert
            var user = result?.Value as User;
            That(user, Is.Not.Null);
            That(user?.Name, Is.EqualTo("Sample Test"));
        }

        [Test]
        public async Task Put_Ng_MismatchId()
        {
            // Arrange
            var input = _context.User.First(x => x.Id == 1);
            input.Name = "Sample Test";

            // Act
            var result = await _userController.Put(999, input);

            // Assert
            That(result.Result, Is.AssignableTo(typeof(BadRequestResult)));
        }
    }
}
