using goiaba_api.Models;
using goiaba_api.Teste.Services;
using Moq;


namespace goiaba_api.Teste
{
    public class UserRepositoryTest
    {

        [Fact]
        public void TestFindAllUsersMock()
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
        public void TestFindUserMock(string id)
        {
            // Arrange
            var repositoryMock = new GoiabaAPIRepository();

            //Act
            var user = repositoryMock.Find(id);

            //Assert
            Assert.NotNull(user);
        }

        [Fact]
        public void TestCreateUserMock()
        {
            // Arrange
            var user = new UserModel()
            {
                FirstName = "new name",
                Surname = "new surname",
                Age = 13
            };

            var repositoryMock = new GoiabaAPIRepository();

            //Act
            var added = repositoryMock.Create(user);

            //Assert
            Assert.True(added);
        }


        [Fact]
        public void TestUpdateUserMock()
        {
            // Arrange
            var user = new UserModel()
            {
                FirstName = "Freddy",
                Surname = "Crugger",
                Age = 55,
            };

            var repositoryMock = new GoiabaAPIRepository();

            //Act
            var result = repositoryMock.Update("b4f5a-b4f5a-b4f5a-b4f5a-b4f5a", user);

            //Assert
            Assert.True(result);

        }

        [Theory]
        [InlineData("b4f5b-b4f5b-b4f5b-b4f5b-b4f5b")]
        [InlineData("b4f5a-b4f5a-b4f5a-b4f5a-b4f5a")]
        public void TestDestroyUserMock(string id)
        {
            // Arrange
            var repositoryMock = new GoiabaAPIRepository();

            //Act
            var result = repositoryMock.Destroy(id);

            //Assert
            Assert.True(result);
        }


        //Exceções
        [Fact]
        public void TestExcecaoFindUser()
        {
            //Arrange
            var repositoryMock = new GoiabaAPIRepository();

            //Act     
            //Assert
            Assert.Throws<Exception>(() => repositoryMock.Find("b4f5a-b4f5a-b4f5a-b4f5a-b4f5k"));

        }

    }
}
