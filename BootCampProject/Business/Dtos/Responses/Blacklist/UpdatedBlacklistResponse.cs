﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Responses.Blacklist;

public class UpdatedBlacklistResponse
{
    public int Id { get; set; }
    public string Reason { get; set; }
}
