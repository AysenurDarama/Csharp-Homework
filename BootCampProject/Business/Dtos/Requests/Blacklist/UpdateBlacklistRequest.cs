﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Requests.Blacklist;

public class UpdateBlacklistRequest
{
    public int Id { get; set; }
    public string Reason { get; set; }
}
