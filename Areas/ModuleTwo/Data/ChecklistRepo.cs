using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PainAssessment.Areas.ModuleTwo.Models;

namespace PainAssessment.Areas.ModuleTwo.Data
{
    public class ChecklistRepo : IChecklistRepo
    {
        private MvcChecklistContext _context;

        public ChecklistRepo(MvcChecklistContext context)
        {
            _context = context;
        }

        public List<Checklist> GetAll(int user)
        {
            List<Checklist> checklists;
            switch(user)
            {
                case 0:
                    checklists = _context.Checklist.ToList();
                    break;
                case 1:
                    checklists = GetAllChecklistsFrom(user);
                    break;
                default:
                    checklists = GetActiveChecklists();
                    List<Checklist> pract = GetAllChecklistsFrom(user);
                    checklists.AddRange(pract);
                    break;
            }
            return checklists;
        }


        public List<Checklist> GetAllChecklistsFrom(int id)
        {
            List<Checklist> checklists;
            checklists = _context.Checklist
                .Where(a => a.PractitionerId == id)
                .ToList();
            return checklists;
        }

        public List<Checklist> GetActiveChecklists()
        {
            List<Checklist> checklists;
            checklists = GetAllChecklistsFrom(1)
                .Where(a => a.Active == true)
                .ToList();
            return checklists;
        }

        public Checklist GetById(int id)
        {
            Checklist checklist = _context.Checklist
                .Include(c => c.Central)
                .Include(r => r.Regional)
                .Include(l => l.Local)

                .Where(a => a.ChecklistId == id).FirstOrDefault();
            return checklist;
        }


        public void Delete(Checklist checklist)
        {
            _context.Attach(checklist);
            _context.Entry(checklist).State = EntityState.Deleted;
        }

        public Checklist InsertGet()
        {
            Checklist checklist = new Checklist();
            checklist.Central.Add(new CentralDomain() { RowId = 1 });
            checklist.Regional.Add(new RegionalDomain() { RowId = 1 });
            checklist.Local.Add(new LocalDomain() { RowId = 1 });

            return checklist;
        }

        public Checklist InsertGetTest()
        {
            Checklist checklist = new Checklist();
            //checklist.Central.Add(1);
            //checklist.Regional.Add(2);
            //checklist.Local.Add(3);
            checklist.Central.Add(new CentralDomain());
            checklist.Regional.Add(new RegionalDomain());
            checklist.Local.Add(new LocalDomain());

            return checklist;
        }

        public void InsertPost(Checklist checklist)
        {
            checklist.Central.RemoveAll(n => n.getIsCentralDeleted() == true);
            checklist.Regional.RemoveAll(n => n.IsRegionalDeleted == true);
            checklist.Local.RemoveAll(n => n.IsLocalDeleted == true);
            _context.Add(checklist);
        }

        public void PreUpdate(Checklist checklist)
        {
            List<CentralDomain> centralDetails = _context.CentralDomain.Where(d => d.ChecklistId == checklist.RetrieveIntAttribute("ChecklistId")).ToList();
            List<RegionalDomain> regionalDetails = _context.RegionalDomain.Where(d => d.ChecklistId == checklist.RetrieveIntAttribute("ChecklistId")).ToList();
            List<LocalDomain> localDetails = _context.LocalDomain.Where(d => d.ChecklistId == checklist.RetrieveIntAttribute("ChecklistId")).ToList();
            _context.CentralDomain.RemoveRange(centralDetails);
            _context.RegionalDomain.RemoveRange(regionalDetails);
            _context.LocalDomain.RemoveRange(localDetails);
        }

        public void Update(Checklist checklist)
        {

            checklist.Central.RemoveAll(n => n.IsCentralDeleted == true);
            checklist.Regional.RemoveAll(n => n.IsRegionalDeleted == true);
            checklist.Local.RemoveAll(n => n.IsLocalDeleted == true);
            _context.Attach(checklist);
            _context.Entry(checklist).State = EntityState.Modified;
            _context.CentralDomain.AddRange(checklist.Central);
            _context.RegionalDomain.AddRange(checklist.Regional);
            _context.LocalDomain.AddRange(checklist.Local);
        }

        public Boolean CheckExists(int id)
        {
            return _context.Checklist.Any(e => e.RetrieveIntAttribute("ChecklistId") == id);
        }

        public void SetActive(int id)
        {
            var checklist = GetById(id);
            if (checklist.Active == false)
            {
                checklist.Active = true;
            }
        }

        public void SetInActive(int id)
        {
            var checklist = GetById(id);
            if (checklist.Active == true)
            {
                checklist.Active = false;
            }
        }

    }
}
