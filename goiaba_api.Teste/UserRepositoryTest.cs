using goiaba_api.Models;
using goiaba_api.Teste.Services;
using Moq;


namespace goiaba_api.Teste
{
    public class UserRepositoryTest
    {

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
        [InlineData("b4f5b-b4f5b-b4f5b-b4f5b-b4f5b")]
        [InlineData("b4f5a-b4f5a-b4f5a-b4f5a-b4f5a")]
        [InlineData("b4f5c-b4f5c-b4f5c-b4f5c-b4f5c")]
        public void TestaFindUserMock(string id)
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
                FirstName = "Noa",
                Surname = "Oliveira",
                Age = 13
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
            var result = repositorioMock.Update("b4f5a-b4f5a-b4f5a-b4f5a-b4f5a", user);

            //Assert
            Assert.True(result);

        }

        [Theory]
        [InlineData("b4f5b-b4f5b-b4f5b-b4f5b-b4f5b")]
        [InlineData("b4f5a-b4f5a-b4f5a-b4f5a-b4f5a")]
        public void TestarDestroyUserMock(string id)
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
            Assert.Throws<Exception>(() => repositorioMock.Find("b4f5a-b4f5a-b4f5a-b4f5a-b4f5k"));

        }

    }
}
