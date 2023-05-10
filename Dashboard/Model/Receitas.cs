using System.ComponentModel.DataAnnotations;


namespace Dashboard.Model
{
    // Tabela Receitas - FC12000
    public class Receitas
    {
        public int Filial { get; set; }
        [Key]
        public int Requisicao { get; set; }
        public int Cliente { get; set; }
        public string CanalCaptacao { get; set;}

    }
}
