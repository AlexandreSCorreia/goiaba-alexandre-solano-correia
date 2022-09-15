using goiaba_mobile.Models;
using goiaba_mobile.Services;
using goiaba_mobile.Teste.Repositories;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace goiaba_mobile.Teste
{

    public class UserRepositoryTest
    {

        private UserService userService;

        public UserRepositoryTest()
        { 
            this.userService = new UserService(new UserRepositoryMock());

        }

        [Fact]
        public void TestFindAllUsersMock()
        {
            //Arange
            var userRepositoryMock = new Mock<IUserRepositoryMock>();
            var mock = userRepositoryMock.Object;

            //Act
            var lista = mock.FindAll();

            //Assert
            userRepositoryMock.Verify(b => b.FindAll());

        }

        [Fact]
        public async void TestFindUserMock()
        {
            //Arange
            var userRepositoryMock = new Mock<IUserRepositoryMock>();
            var mock = userRepositoryMock.Object;

            List<UserModel> list = await userService.FindAll();
            UserModel userTeste = list[0];

            //Act
            var user = mock.Find(userTeste.Id);

            //Assert
            userRepositoryMock.Verify(b => b.Find(userTeste.Id));

        }

        [Theory]
        [InlineData("Cliente Teste 1", "Sobrenome Teste 1", 32)]
        [InlineData("Cliente Teste 2", "Sobrenome Teste 2", 18)]
        public void TestCreateUserMock(string firstName, string surname, int age)
        {
            //Arange
            var userRepositoryMock = new Mock<IUserRepositoryMock>();
            var mock = userRepositoryMock.Object;

            var user = new UserModel()
            {
                FirstName = firstName,
                Surname = surname,
                Age = age
            };

            //Act
            var user_result = mock.Create(user);

            //Assert
            userRepositoryMock.Verify(b => b.Create(user));

        }

        [Theory]
        [InlineData("Cliente Update Mock", "Sobrenome Update Mock", 92)]
        public async void TestUpdateUserMock(string firstName, string surname, int age)
        {
            //Arange
            var userRepositoryMock = new Mock<IUserRepositoryMock>();
            var mock = userRepositoryMock.Object;

            List<UserModel> list = await userService.FindAll();
            UserModel userTeste = list[0];

            var user = new UserModel()
            {
                Id = userTeste.Id,
                FirstName = firstName,
                Surname = surname,
                Age = age
            };

            //Act
            var result = mock.Update(user);

            //Assert
            userRepositoryMock.Verify(b => b.Update(user));

        }

        [Fact]
        public async void TestDestroyUserMock()
        {
            //Arange
            var userRepositoryMock = new Mock<IUserRepositoryMock>();
            var mock = userRepositoryMock.Object;

            List<UserModel> list = await userService.FindAll();
            UserModel userTeste = list[1];

            //Act
            var user = mock.Destroy(userTeste.Id);

            //Assert
            userRepositoryMock.Verify(b => b.Destroy(userTeste.Id));

        }


        [Fact]
        public async void TestFindAllUsers()
        {
            //Arange


            //Act
            List<UserModel> list = await userService.FindAll();

            //Assert
            Assert.NotNull(list);
        }


        [Fact]
        public async void TestFindUser()
        {
            //Arange
            List<UserModel> list = await userService.FindAll();
            UserModel userTeste = list[0];

            //Act
            UserModel userResponse = await userService.Find(userTeste.Id);

            //Assert
            Assert.Equal(userTeste.Id, userResponse.Id);
            Assert.Equal(userTeste.FirstName, userResponse.FirstName);
            Assert.Equal(userTeste.Surname, userResponse.Surname);
            Assert.Equal(userTeste.Age, userResponse.Age);
            Assert.Equal(userTeste.CreationDate, userResponse.CreationDate);

        }


        [Theory]
        [InlineData("Cliente Teste 1", "Sobrenome Teste 1", 32)]
        [InlineData("Cliente Teste 2", "Sobrenome Teste 2", 18)]
        public async void TestCreateUser(string firstName, string surname, int age)
        {
            //Arrange
            var user = new UserModel()
            {
                FirstName = firstName,
                Surname = surname,
                Age = age
            };

            //Act
            UserModel userReturn = await userService.Create(user);


            //Assert
            Assert.Equal(firstName, userReturn.FirstName);
            Assert.Equal(surname, userReturn.Surname);
            Assert.Equal(age, userReturn.Age);  

        }

        [Theory]
        [InlineData("Cliente Update", "Sobrenome Update", 92)]
        public async void TestUpdateUser(string firstName, string surname, int age)
        {
            //Arrange
            List<UserModel> list = await userService.FindAll();
            UserModel userTeste = list[0];

            var user = new UserModel()
            {
                Id = userTeste.Id,
                FirstName = firstName,
                Surname = surname,
                Age = age
            };

            //Act
            bool result = await userService.Update(user);


            //Assert
            Assert.True(result);
           
        }


        [Fact]
        public async void TestDestroyUser()
        {
            //Arrange
            List<UserModel> list = await userService.FindAll();
            UserModel userTeste = list[1];

            //Act
            bool result = await userService.Destroy(userTeste.Id);


            //Assert
            Assert.True(result);

        }
    }
}
