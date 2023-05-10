

namespace Dashboard.Model
{
    public class FormulaReceita
    {
        public int CodigoFilial { get; set; }
        public int Requisicao { get; set; }
        public char Serie { get; set; }
        public double ValorLiquido { get; set; }
        public int Cliente { get; set; }
        public DateTime DataAprovacao { get; set; }
        public string CanalCaptacao { get; set; }
    }
}
