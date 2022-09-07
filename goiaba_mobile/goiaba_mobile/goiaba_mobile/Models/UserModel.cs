using System;

namespace goiaba_mobile.Models
{
    public class UserModel
    {
        private string id;
        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        private string firstName;

        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private string surname;

        public string Surname
        {
            get { return surname; }
            set { surname = value; }
        }

        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        private DateTime creationDate;

        public DateTime CreationDate
        {
            get { return creationDate; }
            set { creationDate = value; }
        }

    }
}
