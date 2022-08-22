using goiaba_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            DateTime data = DateTime.Now;

            //Act
            var user = new UserModel()
            {
                FirstName = firstName,
                Surname = surname,
                Age = age,
                CreationDate = data

            };


            //Assert
            Assert.Equal(firstName, user.FirstName);
            Assert.Equal(surname, user.Surname);
            Assert.Equal(age, user.Age);
            Assert.Equal(data, user.CreationDate);
 

        }//End CriarObjetoUserValido
    }
}
