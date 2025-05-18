namespace Business.Dtos.Requests.User;

public class CreateUserRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalIdentity { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
}
