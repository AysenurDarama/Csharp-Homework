using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities;

public class Bootcamp
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int InstructorId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public BootcampState BootcampState { get; set; }

    // Navigation properties
    public Instructor Instructor { get; set; }
    public ICollection<Application> Applications { get; set; }
}
 public enum BootcampState
    {
        PREPARING = 0,
        OPEN_FOR_APPLICATION = 1,
        IN_PROGRESS = 2,
        FINISHED = 3,
        CANCELLED = 4
    }
