﻿using System;
using System.Collections.Generic;

namespace ReactCustomerService.Models
{
    public partial class Admin
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
    }
}
