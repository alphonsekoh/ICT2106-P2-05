﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PainAssessment.Areas.ModuleTwo.Models
{
    public interface ILocalDomain : IDomain
    {
        public Boolean getIsLocalDeleted();
    }
}
