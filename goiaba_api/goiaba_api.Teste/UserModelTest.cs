using goiaba_api.Models;


namespace goiaba_api.Teste
{
    public class UserModelTest
    {
        [Fact]
        public void CriarObjetoUserValido()
        {
            //Arrange
            string firstName = "Cliente 01";
            string surname = "Sobrenome";
            int age = 22;

            //Act
            var user = new UserModel()
            {
                FirstName = firstName,
                Surname = surname,
                Age = age
            };


            //Assert
            Assert.NotEmpty(user.Id);
            Assert.Equal(firstName, user.FirstName);
            Assert.Equal(surname, user.Surname);
            Assert.Equal(age, user.Age);
            Assert.NotEmpty(user.CreationDate.ToString());
 

        }
    }
}
