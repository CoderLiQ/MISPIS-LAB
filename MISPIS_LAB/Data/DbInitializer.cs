using MISPIS_LAB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISPIS_LAB.Data
{
    public class DbInitializer
    {
        public static void Initialize(ProjectContext context)
        {
            context.Database.EnsureCreated();

            if (context.Mains.Any())
            {
                return;   // DB has been seeded
            }

            var auditors = new Auditor[]
            {
            new Auditor{Name="Alex",Position="SysAdmin"},
            new Auditor{Name="Lena",Position="TechDirector"}
            };

            foreach (var a in auditors)
            {
                context.Auditors.Add(a);
            }
            context.SaveChanges();

            var authors = new Author[]
            {
            new Author{Name="Ivan",Position="NeSysAdmin"},
            new Author{Name="Dima",Position="Manager"}
            };

            foreach (var a in authors)
            {
                context.Authors.Add(a);
            }
            context.SaveChanges();


            var types = new Models.Type[]
            {
            new Models.Type{Name="Hardware",Description="Its bad"},
            new Models.Type{Name="Software",Description="Not so bad"}
            };

            foreach (var t in types)
            {
                context.Types.Add(t);
            }
            context.SaveChanges();

            var incidents = new Incident[]
           {
            new Incident{TypeID=1, Name="Servers exploded",Description="oops"},
            new Incident{TypeID=2, Name="App Crashed",Description="who cares..."}
           };

            foreach (var i in incidents)
            {
                context.Incidents.Add(i);
            }
            context.SaveChanges();

            var mains = new Main[]
           {
            new Main{IncidentID=1, AuthorID=1, AuditorID=1},
            new Main{IncidentID=2, AuthorID=2, AuditorID=2}
           };

            foreach (var m in mains)
            {
                context.Mains.Add(m);
            }
            context.SaveChanges();


        }
    }
}
