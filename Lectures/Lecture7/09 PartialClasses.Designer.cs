using System.Collections.Generic;

namespace Lecture7.PartialClasses
{
    // kod generowany
    partial class UserData
    {
        private List<string> ValidationErrors = new List<string>();

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Address { get; set; }

        public int Age { get; set; }

        public void FillFrom(UserData user)
        {
            Name = user.Name;
            Surname = user.Surname;
            Address = user.Address;
            Age = user.Age;

            Validate();
        }

        partial void Validate();
    }
}
