﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Requests.Application;

public class UpdateApplicationRequest
{
    public int Id { get; set; }
    public int ApplicantId { get; set; }
    public int BootcampId { get; set; }
    public ApplicationState ApplicationState { get; set; }
}
