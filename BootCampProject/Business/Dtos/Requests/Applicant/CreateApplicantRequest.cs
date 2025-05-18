namespace Business.Dtos.Requests.Applicant;

public class CreateApplicantRequest
{
    public int UserId { get; set; }
    public string About { get; set; }
    public string NationalIdentity { get; set; }
}