namespace Lecture7.PartialClasses
{
    partial class UserData
    {
        public UserData Clone()
        {
            UserData result = new UserData();
            result.FillFrom(this);

            return result;
        }

        partial void Validate()
        {
            if (Age < 18)
                ValidationErrors.Add("User Age is below 18");
            else
                ValidationErrors.Clear();
        }
    }
}
