namespace ApartmentManagement.Entities.Dtos.Occupant
{
    public class AddOccupantResultDto
    {
        public AddOccupantResultDto(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public string Email { get; }
        public string Password { get; }
    }
}