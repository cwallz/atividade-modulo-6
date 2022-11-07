using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AtividadeModulo6.Models
{
    public class DestinoDBContext : DbContext
    {
        public DestinoDBContext(DbContextOptions<DestinoDBContext> options)
        : base(options)
        { }


        public DbSet<Destino> Destino { get; set; }
        //Mais tabelas colocar aqui

    }
}
