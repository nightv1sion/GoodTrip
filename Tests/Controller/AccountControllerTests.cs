using FakeItEasy;
using FluentAssertions;
using goodtrip.Controllers;
using goodtrip.Models;
using goodtrip.Storage.Entity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Controller
{
    public class AccountControllerTests
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<UserRole> _roleManager;
        private readonly AccountController _controller;
        public AccountControllerTests()
        {
            _userManager = A.Fake<UserManager<User>>();
            _signInManager = A.Fake<SignInManager<User>>();
            _roleManager = A.Fake<RoleManager<UserRole>>();
            _controller = new AccountController(_userManager, _signInManager, _roleManager);
        }
        [Fact]
        public async Task AccountController_RegisterGET_ReturnsViewResult()
        {
            // Arrange
            // Act
            var result = await _controller.Register();
            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<ViewResult>();
        }
        [Fact]
        public async Task AccountController_RegisterPOST_ReturnsViewResult_IfModelStateIsNotValid()
        {
            // Arrange
            var registerUser = new RegisterUser(); // Not valid model

            // Act
            var result = await _controller.Register(registerUser);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<ViewResult>();
        }
        [Fact]
        public async Task AccountController_LoginGet_ReturnsViewResult()
        {
            // Arrange

            // Act
            var result = await _controller.Login();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<ViewResult>();
        }
        [Fact]
        public async Task AccountController_LoginPost_ReturnsRedirectToActionResult_IfReturnUrlIsNotProvided()
        {
            var loginUser = new LoginUser()
            {
                Login = "SomeLogin",
                Password = "SomePassword",
                RememberMe = true,
                ReturnUrl = null
            };

            A.CallTo(() => _signInManager.PasswordSignInAsync(loginUser.Login, loginUser.Password, loginUser.RememberMe, false))
                .Returns(Task.FromResult(Microsoft.AspNetCore.Identity.SignInResult.Success));

            // Act
            var result = await _controller.Login(loginUser);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<RedirectToActionResult>();
        }

        [Fact]
        public async Task AccountController_LoginPost_ReturnsRedirectResult_IfReturnUrlIsProvided()
        {
            // Arrange
            var loginUser = new LoginUser()
            {
                Login = "SomeLogin",
                Password = "SomePassword",
                RememberMe = true,
                ReturnUrl = "/Views/Home/Index"
            };

            A.CallTo(() => _signInManager.PasswordSignInAsync(loginUser.Login, loginUser.Password, loginUser.RememberMe, false))
                .Returns(Task.FromResult(Microsoft.AspNetCore.Identity.SignInResult.Success));

            // Act
            var result = await _controller.Login(loginUser);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<RedirectResult>();
        }

        [Fact]
        public async Task AccountController_LoginPost_ReturnsViewResult_IfModelStateIsNotValid()
        {
            // Arrange
            var loginUser = new LoginUser();

            // Act
            var result = await _controller.Login(loginUser);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<ViewResult>();
        }
        [Fact]
        public async Task AccountController_Logout_ReturnsRedirectToActionResult()
        {
            // Arrange
            A.CallTo(() => _signInManager.SignOutAsync())
                .Returns(Task.CompletedTask);

            // Act
            var result = await _controller.Logout();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<RedirectToActionResult>();
        }
    }
}
