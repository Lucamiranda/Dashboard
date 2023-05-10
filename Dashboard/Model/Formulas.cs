using System.ComponentModel.DataAnnotations;


namespace Dashboard.Model
{
    // Tabela Formulas Receitas - FC12100
    public class Formulas
    {
        [Key]
        public int Filial { get; set; }
        public int Requisicao { get; set; }
        public char Serie { get; set; }
        public double ValorCobrado { get; set; }
        public double Desconto { get; set; }
        public DateTime DataEntrada { get; set; }


        public override string ToString()
        {
            return Filial.ToString();
        }

    }
}
