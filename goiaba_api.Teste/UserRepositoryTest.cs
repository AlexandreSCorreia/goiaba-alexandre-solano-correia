using goiaba_api.Models;
using goiaba_api.Teste.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace goiaba_api.Teste
{
    public class UserRepositoryTest
    {

        // Testes com Mock
        [Fact]
        public void TestarFindAllUsersMock()
        {
            //Arange
            var goiabaAPIRepositoryMoc = new Mock<IGoiabaAPIRepository>();
            var mock = goiabaAPIRepositoryMoc.Object;

            //Act
            var lista = mock.FindAll();

            //Assert
            goiabaAPIRepositoryMoc.Verify(b => b.FindAll());

        }


        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void TestaFindUserMock(int id)
        {
            // Arrange
            var repositorioMock = new GoiabaAPIRepository();

            //Act
            var user = repositorioMock.Find(id);

            //Assert
            Assert.NotNull(user);
        }

        [Fact]
        public void TestaCreateUserMock()
        {
            // Arrange
            var user = new UserModel()
            {
                Id = 4,
                FirstName = "Noa",
                Surname = "Oliveira",
                Age = 13,
                CreationDate = DateTime.Now
            };

            var repositorioMock = new GoiabaAPIRepository();

            //Act
            var adicionado = repositorioMock.Create(user);

            //Assert
            Assert.True(adicionado);
        }


        [Fact]
        public void TestaUpdateUserMock()
        {
            // Arrange
            var user = new UserModel()
            {
                FirstName = "Freddy",
                Surname = "Crugger",
                Age = 55,
            };

            var repositorioMock = new GoiabaAPIRepository();

            //Act
            var result = repositorioMock.Update(2, user);

            //Assert
            Assert.Equal(user.FirstName, result.FirstName);
            Assert.Equal(user.Surname, result.Surname);
            Assert.Equal(user.Age, result.Age);

        }

        [Theory]
        [InlineData(1)]
        [InlineData(3)]
        public void TestarDestroyUserMock(int id)
        {
            // Arrange
            var repositorioMock = new GoiabaAPIRepository();

            //Act
            var result = repositorioMock.Destroy(id);

            //Assert
            Assert.True(result);
        }


        //Exceções
        [Fact]
        public void TestaExcecaoFindUser()
        {
            //Arrange
            var repositorioMock = new GoiabaAPIRepository();

            //Act     
            //Assert
            Assert.Throws<Exception>(() => repositorioMock.Find(33));

        }

    }
}
