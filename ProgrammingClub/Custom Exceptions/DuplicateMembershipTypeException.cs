namespace ProgrammingClub.Custom_Exceptions
{
    public class DuplicateMembershipTypeException : Exception
    {
        public DuplicateMembershipTypeException(string name) : base($"A membership type with the name '{name}' already exists.")
        {

        }
    }
}
