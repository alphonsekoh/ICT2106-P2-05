//using PainAssessment.Areas.Admin.Models;
//using PainAssessment.Data;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace PainAssessment.Areas.Admin.Data
//{
//    public static class PractitionerDepartmentDbInitializer
//    {
//        public static void Initialize(HospitalContext context)
//        {
//            //context.Database.EnsureCreated();
//            // Look for any practitioner
//            if (context.Practitioners.Any())
//            {
//                return;   // DB has been seeded
//            }
//            var departments = new Department[]
//            {          
//            new Department{Name="Neurology"},
//            new Department{Name="Orthopaedic"},
//            new Department{Name="Cardiology"},
//            new Department{Name="Urology"},
//            new Department{Name="General Surgery"},
//            new Department{Name="Haematology"},
//            new Department{Name="Dermatology"}
//            }; 

//            context.Departments.AddRange(departments);
            
//            context.SaveChanges();

//            var practitioners = new Practitioner[]
//            {
//            new Practitioner{DepartmentID=1,Name="Alexander"},
//            new Practitioner{DepartmentID=2,Name="Meredith"},
//            new Practitioner{DepartmentID=2,Name="Carson"},
//            new Practitioner{DepartmentID=2,Name="Arturo"},
//            new Practitioner{DepartmentID=3,Name="Gytis"},
//            new Practitioner{DepartmentID=3,Name="Yan"},
//            new Practitioner{DepartmentID=3,Name="Li"},
//            new Practitioner{DepartmentID=4,Name="Alonso"},
//            new Practitioner{DepartmentID=4,Name="Anand"},
//            new Practitioner{DepartmentID=4,Name="Barzdukas"},
//            new Practitioner{DepartmentID=4,Name="Olivetto"},
//            new Practitioner{DepartmentID=5,Name="Nino"},
//            new Practitioner{DepartmentID=5,Name="Peggy"},
//            new Practitioner{DepartmentID=5,Name="Laura"},
//            new Practitioner{DepartmentID=5,Name="Norman"},
//            new Practitioner{DepartmentID=5,Name="Justice"},
//            new Practitioner{DepartmentID=6,Name="Liam"},
//            new Practitioner{DepartmentID=6,Name="Oliver"},
//            new Practitioner{DepartmentID=6,Name="Elijah"},
//            new Practitioner{DepartmentID=6,Name="William"},
//            new Practitioner{DepartmentID=6,Name="James"},
//            new Practitioner{DepartmentID=6,Name="Benjamin"},
//            new Practitioner{DepartmentID=7,Name="Lucas"},

//            };
//            context.Practitioners.AddRange(practitioners);

//            context.SaveChanges();
//        }
//    }
//}
