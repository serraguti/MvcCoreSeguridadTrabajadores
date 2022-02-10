using MvcCoreSeguridadTrabajadores.Data;
using MvcCoreSeguridadTrabajadores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreSeguridadTrabajadores.Repositories
{
    public class RepositoryDoctores
    {
        private DoctoresContext context;
        public RepositoryDoctores(DoctoresContext context)
        {
            this.context = context;
        }

        public List<Enfermo> GetEnfermos()
        {
            return this.context.Enfermos.ToList();
        }

        public Enfermo FindEnfermo(string inscripcion)
        {
            return this.context.Enfermos.SingleOrDefault
                (z => z.Inscripcion == inscripcion);
        }

        public void DeleteEnfermo(string inscripcion)
        {
            Enfermo enfermo = this.FindEnfermo(inscripcion);
            this.context.Enfermos.Remove(enfermo);
            this.context.SaveChanges();
        }

        public Doctor Finddoctor(int iddoctor)
        {
            return this.context.Doctores.SingleOrDefault
                (z => z.IdDoctor == iddoctor);
        }

        public Doctor ExisteDoctor(string apellido, int iddoctor)
        {
            var consulta = from datos in this.context.Doctores
                           where datos.Apellido == apellido
                           && datos.IdDoctor == iddoctor
                           select datos;
            return consulta.FirstOrDefault();
        }
    }
}
