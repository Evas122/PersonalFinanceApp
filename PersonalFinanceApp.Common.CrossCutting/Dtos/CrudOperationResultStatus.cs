﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalFinanceApp.Common.CrossCutting.Dtos
{
    public enum CrudOperationResultStatus
    {
        Success,
        Failure,
        RecordNotFound
    }
}
