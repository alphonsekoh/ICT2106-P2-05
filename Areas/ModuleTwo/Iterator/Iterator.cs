using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PainAssessment.Areas.ModuleTwo.Models;

namespace PainAssessment.Areas.ModuleTwo.Iterator
{
    /// <summary>
    /// The 'Aggregate' abstract class
    /// </summary>
    class iterator
    {
        private Checklist checklist;

        // Constructor
        public iterator(Checklist myList)
        {
            this.checklist = myList;
        }

        public void resetChecklistID()
        {
            checklist.ChecklistId = 0;

            foreach (var item in checklist.Central)
            {
                item.RowId = 0;
            }
            foreach (var item in checklist.Local)
            {
                item.RowId = 0;
            }
            foreach (var item in checklist.Regional)
            {
                item.RowId = 0;
            }
        }

        public Checklist getChecklist()
        {
            return checklist;
        }
    }
}

