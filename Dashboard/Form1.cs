using Dashboard.Dados;
using Dashboard.Model;
using System.Windows.Forms.DataVisualization.Charting;

namespace Dashboard
{
    public partial class Form1 : Form
    {
        private List<FormulaReceita> resultado;
        public Form1()
        {
            InitializeComponent();
            try
            {
                CarregaDadosIniciais();
            }
            catch (Exception)
            {
                MessageBox.Show("Base de dados não disponível.", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TimeSpan data = dateTimePicker2.Value.Subtract(dateTimePicker1.Value);
            var dias = data.Days;
            try
            {
                if (dateTimePicker1.Value > dateTimePicker2.Value)
                {
                    MessageBox.Show("Periodo invalído", "Erro na consulta!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (dias > 366)
                {
                    MessageBox.Show("Consulta maxima é de 1 ano", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (cbFiliais.Text == "")
                {
                    CarregaDadosIniciais();
                }
                ConsultaBanco();
                TopClientes(GraficoTopClientes);
                PedidosPorFilial(graficoPorFilial);
                QuantidadePorCanal(graficoPorMes);
                ValorPorCanal(graficoValorPorCanal);
                TicketMedio(GraficoTicketMedio);
            }
            catch (Exception)
            {

            }
        }

        private void CarregaDadosIniciais()
        {
            cbFiliais.Items.Clear();
            using (var contexto = new Context())
            {
                var filiais = from filial in contexto.Formulas orderby filial.Filial ascending select filial.Filial;
                foreach (var item in filiais.Distinct().ToList())
                {
                    cbFiliais.Items.Add(item);
                }
            }
        }

        private void ConsultaBanco()
        {
            using (var contexto = new Context())
            {
                resultado = (from REQ in contexto.Formulas
                             join CAP in contexto.Receitas
                                 on new { REQ.Filial, REQ.Requisicao } equals new { CAP.Filial, CAP.Requisicao }
                             join PAR in contexto.Parametros.Where(p => p.Argumentos == "CDCAPTACAO")
                                 on CAP.CanalCaptacao equals PAR.SubArgumentos into joinPAR
                             from subPAR in joinPAR.DefaultIfEmpty()
                             where REQ.DataEntrada >= dateTimePicker1.Value && REQ.DataEntrada <= dateTimePicker2.Value
                             select new FormulaReceita
                             {
                                 CodigoFilial = REQ.Filial,
                                 Requisicao = REQ.Requisicao,
                                 Serie = REQ.Serie,
                                 ValorLiquido = REQ.ValorCobrado - REQ.Desconto,
                                 Cliente = CAP.Cliente,
                                 DataAprovacao = REQ.DataEntrada,
                                 CanalCaptacao = subPAR.Parametros
                             }).ToList();
            }
        }

        private void PedidosPorFilial(Chart grafico)
        {

            string titulo = "PEDIDOS POR FILIAIS";
            string tituloSecundario = "VALOR DE PEDIDOS APROVADOS POR FILIAL";

            LimpaComponentes(grafico);
            ParametrosGraficos(grafico, "FILIAIS");
            TitulosGraficos(grafico, titulo, tituloSecundario);
            grafico.Series[0].LabelFormat = "R$#,##0.00";

            var filiais = resultado.Where(x => x.DataAprovacao >= dateTimePicker1.Value && x.DataAprovacao <= dateTimePicker2.Value)
                .GroupBy(filial => filial.CodigoFilial)
                .Select(filial => new
                {
                    Filiais = filial.Key,
                    ValorPorFiliais = filial.Sum(x => x.ValorLiquido)
                });

            foreach (var item in filiais)
            {
                grafico.Series[0].Points.AddXY(item.Filiais.ToString(), item.ValorPorFiliais);
            }
        }

        private void QuantidadePorCanal(Chart grafico)
        {
            string titulo = "CAPTAÇÃO DE PEDIDOS";
            string tituloSecundario = "QUANTIDADE DE PEDIDOS POR CANAL DE CAPTAÇÃO";

            LimpaComponentes(grafico);
            ParametrosGraficos(grafico, "MES");
            TitulosGraficos(grafico, titulo, tituloSecundario);

            if (cbFiliais.Text.Trim() == "")
            {
                var filiais = resultado.Where(x => x.DataAprovacao >= dateTimePicker1.Value && x.DataAprovacao <= dateTimePicker2.Value)
                    .GroupBy(filial => filial.CanalCaptacao)
                    .Select(filial => new
                    {
                        Filiais = filial.Key,
                        ValorPorFiliais = filial.Select(x => x.Requisicao).Distinct().Count()
                    });
                foreach (var item in filiais)
                {
                    if (item.Filiais == null)
                    {
                        grafico.Series[0].Points.AddXY("SEM CANAL", item.ValorPorFiliais);
                    }
                    else
                    {
                        grafico.Series[0].Points.AddXY(item.Filiais.ToString(), item.ValorPorFiliais);
                    }
                }
            }
            if (cbFiliais.Text.Trim() != "")
            {
                var filiais = resultado.Where(x => x.CodigoFilial.Equals(Convert.ToInt32(cbFiliais.Text)) && x.DataAprovacao >= dateTimePicker1.Value && x.DataAprovacao <= dateTimePicker2.Value)
                .GroupBy(filial => filial.CanalCaptacao)
                .Select(filial => new
                {
                    Filiais = filial.Key,
                    ValorPorFiliais = filial.Select(x => x.Requisicao).Distinct().Count()
                });

                foreach (var item in filiais)
                {
                    if (item.Filiais == null)
                    {
                        grafico.Series[0].Points.AddXY("SEM CANAL", item.ValorPorFiliais);
                    }
                    else
                    {
                        grafico.Series[0].Points.AddXY(item.Filiais.ToString(), item.ValorPorFiliais);
                    }
                }
            }
        }


        private void ValorPorCanal(Chart grafico)
        {
            string titulo = "VALOR POR CANAIS DE ATENDIMENTO";
            string tituloSecundario = "VALOR DE PEDIDOS APROVADOS POR CANAL DE CAPTAÇÃO";

            LimpaComponentes(grafico);
            ParametrosGraficos(grafico, "MES");
            TitulosGraficos(grafico, titulo, tituloSecundario);
            grafico.Series[0].LabelFormat = "R$#,##0.00";


            if (cbFiliais.Text.Trim() == "")
            {
                var filiais = resultado.Where(x => x.DataAprovacao >= dateTimePicker1.Value && x.DataAprovacao <= dateTimePicker2.Value)
                    .GroupBy(filial => filial.CanalCaptacao)
                    .Select(filial => new
                    {
                        Filiais = filial.Key,
                        ValorPorFiliais = filial.Sum(x => x.ValorLiquido)
                    });
                foreach (var item in filiais)
                {
                    if (item.Filiais == null)
                    {
                        grafico.Series[0].Points.AddXY("SEM CANAL", item.ValorPorFiliais);
                    }
                    else
                    {
                        grafico.Series[0].Points.AddXY(item.Filiais.ToString(), item.ValorPorFiliais);
                    }
                }
            }
            if (cbFiliais.Text.Trim() != "")
            {
                var filiais = resultado.Where(x => x.CodigoFilial.Equals(Convert.ToInt32(cbFiliais.Text)) && x.DataAprovacao >= dateTimePicker1.Value && x.DataAprovacao <= dateTimePicker2.Value)
                .GroupBy(filial => filial.CanalCaptacao)
                .Select(filial => new
                {
                    Filiais = filial.Key,
                    ValorPorFiliais = filial.Sum(x => x.ValorLiquido)
                });

                foreach (var item in filiais)
                {
                    if (item.Filiais == null)
                    {
                        grafico.Series[0].Points.AddXY("SEM CANAL", item.ValorPorFiliais);
                    }
                    else
                    {
                        grafico.Series[0].Points.AddXY(item.Filiais.ToString(), item.ValorPorFiliais);
                    }
                }
            }
        }


        public void TopClientes(Chart grafico)
        {
            string titulo = "TOP 10 PEDIDOS APROVADOS POR CLIENTE";
            LimpaComponentes(grafico);
            ParametrosGraficos(grafico, "TOP");
            TitulosGraficos(grafico, titulo);
            grafico.Series[0].LabelFormat = "R$#,##0.00";

            if (cbFiliais.Text.Trim() == "")
            {
                var filiais = resultado.Where(x => x.DataAprovacao >= dateTimePicker1.Value && x.DataAprovacao <= dateTimePicker2.Value)
                    .GroupBy(filial => filial.Cliente)
                    .Select(filial => new
                    {
                        Filiais = filial.Key,
                        ValorPorFiliais = filial.Sum(x => x.ValorLiquido)
                    });

                foreach (var item in filiais.OrderByDescending(x => x.ValorPorFiliais).Take(10))
                {

                    grafico.Series[0].Points.AddXY(item.Filiais.ToString(), item.ValorPorFiliais);

                }
            }
            if (cbFiliais.Text.Trim() != "")
            {
                var filiais = resultado.Where(x => x.CodigoFilial.Equals(Convert.ToInt32(cbFiliais.Text)) && x.DataAprovacao >= dateTimePicker1.Value && x.DataAprovacao <= dateTimePicker2.Value)
                    .GroupBy(filial => filial.Cliente)
                    .Select(filial => new
                    {
                        Filiais = filial.Key,
                        ValorPorFiliais = filial.Sum(x => x.ValorLiquido)
                    });

                foreach (var item in filiais.OrderByDescending(x => x.ValorPorFiliais).Take(10))
                {

                    grafico.Series[0].Points.AddXY(item.Filiais.ToString(), item.ValorPorFiliais);

                }
            }
        }

        public void TicketMedio(Chart grafico)
        {
            string titulo = "TOP 10 TICKET MEDIO POR CLIENTE";
            LimpaComponentes(grafico);
            ParametrosGraficos(grafico, "TOP");
            TitulosGraficos(grafico, titulo);
            grafico.Series[0].LabelFormat = "R$#,##0.00";

            if (cbFiliais.Text.Trim() == "")
            {
                var filiais = resultado.Where(x => x.DataAprovacao >= dateTimePicker1.Value && x.DataAprovacao <= dateTimePicker2.Value)
                    .GroupBy(filial => filial.Cliente)
                    .Select(filial => new
                    {
                        Filiais = filial.Key,
                        ticket = filial.Sum(x => x.ValorLiquido) / filial.Select(x => x.Requisicao).Distinct().Count(),

                    });

                foreach (var item in filiais.OrderByDescending(x => x.ticket).Take(10))
                {

                    grafico.Series[0].Points.AddXY(item.Filiais.ToString(), item.ticket);

                }

            }
            if (cbFiliais.Text.Trim() != "")
            {
                var filiais = resultado.Where(x => x.CodigoFilial.Equals(Convert.ToInt32(cbFiliais.Text)) && x.DataAprovacao >= dateTimePicker1.Value && x.DataAprovacao <= dateTimePicker2.Value)
                    .GroupBy(filial => filial.Cliente)
                    .Select(filial => new
                    {
                        Filiais = filial.Key,
                        ticket = filial.Sum(x => x.ValorLiquido) / filial.Select(x => x.Requisicao).Distinct().Count(),

                    });

                foreach (var item in filiais.OrderByDescending(x => x.ticket).Take(10))
                {

                    grafico.Series[0].Points.AddXY(item.Filiais.ToString(), item.ticket);

                }
            }
        }

        private void LimpaComponentes(Chart Grafico)
        {
            Grafico.Series.Clear();
            Grafico.Titles.Clear();
            Grafico.Legends.Clear();
        }

        private void ParametrosGraficos(Chart LayoutGrafico, string serie)
        {
            LayoutGrafico.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            LayoutGrafico.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            LayoutGrafico.ChartAreas[0].AxisY.Enabled = AxisEnabled.False;
            LayoutGrafico.ChartAreas[0].RecalculateAxesScale();
            LayoutGrafico.ChartAreas[0].AxisX.LabelStyle.Interval = 1;
            LayoutGrafico.Series.Add(serie);
            LayoutGrafico.Series[serie].IsValueShownAsLabel = true;

        }

        private void TitulosGraficos(Chart grafico, string titulo, string tituloSec = null)
        {
            Title tituloPrincipal = new Title();
            tituloPrincipal.Font = new Font("Arial", 12, FontStyle.Bold);
            tituloPrincipal.ForeColor = Color.Brown;
            tituloPrincipal.Text = titulo;
            grafico.Titles.Add(tituloPrincipal);

            Title tituloSecundario = new Title();
            tituloSecundario.Font = new Font("Arial", 8, FontStyle.Bold);
            tituloSecundario.ForeColor = Color.Brown;
            tituloSecundario.Text = tituloSec;
            grafico.Titles.Add(tituloSecundario);
        }
    }
}