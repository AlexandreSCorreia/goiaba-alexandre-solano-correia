using goiaba_api.Models;


namespace goiaba_api.Teste
{
    public class UserModelTest
    {
        [Fact]
        public void CriarObjetoUserValido()
        {
            //Arrange
            string id = Guid.NewGuid().ToString();
            string firstName = "Cliente 01";
            string surname = "Sobrenome";
            int age = 22;
            DateTime data = DateTime.Now;

            //Act
            var user = new UserModel()
            {
                Id = id,
                FirstName = firstName,
                Surname = surname,
                Age = age,
                CreationDate = data

            };


            //Assert
            Assert.Equal(id, user.Id);
            Assert.Equal(firstName, user.FirstName);
            Assert.Equal(surname, user.Surname);
            Assert.Equal(age, user.Age);
            Assert.Equal(data, user.CreationDate);
 

        }
    }
}
