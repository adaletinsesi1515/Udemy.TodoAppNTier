﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.TodoAppNtier.Dtos.WorkDto
{
    public class WorkCreateDto
    {
        public string Definition { get; set; }
        public bool IsCompleted { get; set; }
    }
}