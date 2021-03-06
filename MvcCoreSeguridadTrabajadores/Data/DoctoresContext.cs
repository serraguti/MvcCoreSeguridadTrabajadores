using Microsoft.EntityFrameworkCore;
using MvcCoreSeguridadTrabajadores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCoreSeguridadTrabajadores.Data
{
    public class DoctoresContext: DbContext
    {
        public DoctoresContext
            (DbContextOptions<DoctoresContext> options) : base(options) { }
        public DbSet<Doctor> Doctores { get; set; }
        public DbSet<Enfermo> Enfermos { get; set; }
    }
}
