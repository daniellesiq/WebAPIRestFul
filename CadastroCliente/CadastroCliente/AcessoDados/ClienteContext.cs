using CadastroCliente.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroCliente
{
    public class ClienteContext: DbContext
    {
        /*Configurando o DBContext para mapear as Entidades para o banco de dados - MySql*/

        public DbSet<ClienteModel> Clientes { get; set; }

        public ClienteContext(DbContextOptions<ClienteContext> options):base(options)
        {

        }

        /*sobreponto o método OnModelCreating - Modelo de Dados*/
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*Definindo a propriedade Id como chave da classe*/
            modelBuilder.Entity<ClienteModel>().HasKey(p => p.Id);
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }

    }
}
