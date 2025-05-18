namespace Business.Dtos.Requests.Applicant;

public class UpdateApplicantRequest 
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string About { get; set; }
}
