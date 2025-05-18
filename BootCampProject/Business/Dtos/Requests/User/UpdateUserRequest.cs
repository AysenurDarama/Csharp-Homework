namespace Business.Dtos.Requests.User;

public class UpdateUserRequest
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string NationalIdentity { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }
}
