﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PainAssessment.Areas.ModuleTwo.Models;

namespace PainAssessment.Areas.ModuleTwo.Data
{
    public interface IConsultationChecklistRepo
    {
        Checklist GetBySessionId(int attribute);

        void InsertConsultationChecklist(Checklist attribute);
    }
}
