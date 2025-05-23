﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities;

public class Blacklist
{
    public int Id { get; set; }
    public string Reason { get; set; }
    public DateTime Date { get; set; }

    public int ApplicantId { get; set; }

    // Navigation property
    public Applicant Applicant { get; set; }
}
