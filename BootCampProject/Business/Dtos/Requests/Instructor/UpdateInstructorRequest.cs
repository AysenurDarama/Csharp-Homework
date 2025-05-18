namespace Business.Dtos.Requests.Instructor;

public class UpdateInstructorRequest
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string CompanyName { get; set; }
}