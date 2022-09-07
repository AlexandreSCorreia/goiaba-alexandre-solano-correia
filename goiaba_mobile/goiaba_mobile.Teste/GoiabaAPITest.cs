using goiaba_mobile.Models;
using goiaba_mobile.Services;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace goiaba_mobile.Teste
{

    public class GoiabaAPITest
    {

        private GoiabaApi api;

        public GoiabaAPITest()
        { 
            api = new GoiabaApi();
            
        }


        [Fact]
        public async void TestFindAllUsers()
        {
            //Arange


            //Act
            List<UserModel> list = await api.FindAll();

            //Assert
            Assert.NotNull(list);
        }


        [Fact]
        public async void TestFindUser()
        {
            //Arange
            List<UserModel> list = await api.FindAll();
            UserModel userTeste = list[0];

            //Act
            UserModel userResponse = await api.Find(userTeste.Id);

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
            UserModel userReturn = await api.Create(user);


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
            List<UserModel> list = await api.FindAll();
            UserModel userTeste = list[0];

            var user = new UserModel()
            {
                Id = userTeste.Id,
                FirstName = firstName,
                Surname = surname,
                Age = age
            };

            //Act
            bool result = await api.Update(user);


            //Assert
            Assert.True(result);
           
        }


        [Fact]
        public async void TestDeleteUser()
        {
            //Arrange
            List<UserModel> list = await api.FindAll();
            UserModel userTeste = list[1];

            //Act
            bool result = await api.Destroy(userTeste.Id);


            //Assert
            Assert.True(result);

        }
    }
}
