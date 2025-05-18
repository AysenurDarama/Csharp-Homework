namespace Business.Dtos.Requests.Employee;

public class UpdateEmployeeRequest
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Position { get; set; }
}