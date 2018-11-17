using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisEventos.Models
{
    public class Banco : DbContext
    {
        public Banco(DbContextOptions<Banco> options) : base(options) { }

        public virtual DbSet<Hotel> Hoteis { get; set; }
        public virtual DbSet<Cidade> Cidades { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Suite> Suites { get; set; }
        public virtual DbSet<Reserva> Reservas { get; set; }
        public virtual DbSet<Gastronomia> Gastronomias { get; set; }
        public virtual DbSet<Contato> Contatos { get; set; }
    }

}
