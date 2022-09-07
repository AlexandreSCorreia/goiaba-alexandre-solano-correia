using goiaba_mobile.Models;
using Xunit;

namespace goiaba_mobile.Teste
{
    public class UserModelTeste
    {
        [Theory]
        [InlineData("Cliente", "Sobrenome",22)]
        [InlineData("Cliente 2", "", 28)]
        [InlineData("Cliente 3", "Sobrenome 3", 52)]
        public void CriarObjetoUserValido(string firstName,string surname, int age)
        {
            //Arrange
          

            //Act
            var user = new UserModel()
            {
                FirstName = firstName,
                Surname = surname,
                Age = age
            };


            //Assert
            Assert.Equal(firstName, user.FirstName);
            Assert.Equal(surname, user.Surname);
            Assert.Equal(age, user.Age);

        }

    }
}