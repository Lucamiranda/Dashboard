using Microsoft.EntityFrameworkCore;
using Dashboard.Model;

namespace Dashboard.Dados
{
    public class Context : DbContext
    {
        private string stringConexao;
        public Context()
        {
            Ini();
        }

        private void Ini()
        {
            string nomeServidor;
            string pathPar;
            string path = Application.StartupPath + @"\Alterdb.ini";
            InicializadorINI ini = new InicializadorINI(path);

            nomeServidor = ini.IniReadValue("SERVIDOR", "NOMESERVIDOR");
            pathPar = ini.IniReadValue("PATH", "PATHPAR");

            stringConexao = @"User = SYSDBA; Password = masterkey; Database =" + nomeServidor + ":" + pathPar + "\\alterdb.ib";
        }

        //Configurando o acesso ao banco de dados
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseFirebird(stringConexao);
            //optionsBuilder.UseFirebird("User = SYSDBA; Password = masterkey;Database=D:\\Fcerta\\db\\alterdb.ib;Datasource=PC");
        }

        //Construtor de modelo para configurar as configurações do banco de dados (Metodo para evita usar Annotations na classe modelo)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //Configuração dentro do metodo onModelCreating 
            /*modelBuilder.Entity<Consulta>()
                .ToTable("FC01000");

            modelBuilder.Entity<Consulta>()
                .Property(a => a.Id)
                .HasColumnName("CDFIL");

            modelBuilder.Entity<Consulta>()
                .Property(a => a.Name)
                .HasColumnName("DESCRFIL");*/

            //Separando a configuração das tabelas da classe de contexto e utilizando a classe de configuração
            //Instanciando a classe.
            modelBuilder.ApplyConfiguration(new ParametroConfiguration());
            modelBuilder.ApplyConfiguration(new FormulasConfiguration());
            modelBuilder.ApplyConfiguration(new ReceitasConfiguration());
        }
        public DbSet<Parametro> Parametros { get; set; }
        public DbSet<Formulas> Formulas { get; set; }
        public DbSet<Receitas> Receitas { get; set; }
    }
}
