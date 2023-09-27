using healthclinic_webapi.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace healthclinic_webapi.Contexts
{
    public class ClinicContext : DbContext
    {
        public DbSet<Clinica> Clinica { get; set; }
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Especialidade> Especialidade { get; set; }
        public DbSet<Feedback> Feedback { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Perfil> Perfil { get; set; }
        public DbSet<Prontuario> Prontuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //SENAI Conection
            optionsBuilder.UseSqlServer("Server=NOTE22-S15;Database=HealthClinic_Manha;User Id=sa; Pwd = Senai@134; TrustServerCertificate=True;", x => x.UseDateOnlyTimeOnly());

            //HOME Conection
            //optionsBuilder.UseSqlServer("Server=DESKTOP-C6SOG6K\\SQLEXPRESS;Database=HealthClinic_Manha;User Id=sa; Pwd = pPtA3002; TrustServerCertificate=True;", x => x.UseDateOnlyTimeOnly());
            base.OnConfiguring(optionsBuilder);
        }
    }
}
