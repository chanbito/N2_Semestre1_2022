using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AlgorithmDataStructures
{
    public partial class SearchingAlgorithms : Form
    {
        int[] elementos = new int[5];
        List<Label> labels = new List<Label>();
        
        public SearchingAlgorithms()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            cboBusca.Items.Add("Selecione um Algorítmo");
            cboBusca.Items.Add("Busca Elemento usando a Busca Linear");
            cboBusca.Items.Add("Busca Elemento usando a Busca Binária");
            cboBusca.SelectedIndex = 0;
            labels.Add(index1Label);
            labels.Add(index2Label);
            labels.Add(index3Label);
            labels.Add(index4Label);
            labels.Add(index5Label);
           
        }

        private void btnAddValue_Click(object sender, EventArgs e)
        {
            int numero1,numero2,numero3,numero4,numero5;
            if (int.TryParse(txtElemento1.Text, out numero1))
            {
                if (int.TryParse(txtElemento2.Text, out numero2))
                {
                    if (int.TryParse(txtElemento3.Text, out numero3))
                    {
                        if (int.TryParse(txtElemento4.Text, out numero4))
                        {
                            if (int.TryParse(txtElemento5.Text, out numero5))
                        {
              for(int i=0;i<elementos.Length;i++)
              {
                     
                    numero1 = int.Parse(txtElemento1.Text);
                    numero2 = int.Parse(txtElemento2.Text);
                    numero3 = int.Parse(txtElemento3.Text);
                    numero4 = int.Parse(txtElemento4.Text);
                    numero5 = int.Parse(txtElemento5.Text);

                  elementos[0] = numero1;
                  elementos[1] = numero2;
                  elementos[2] = numero3;
                  elementos[3] = numero4;
                  elementos[4] = numero5;
                


                  labels[0].Text = elementos[0].ToString();
                  labels[1].Text = elementos[1].ToString();
                  labels[2].Text = elementos[2].ToString();
                  labels[3].Text = elementos[3].ToString();
                  labels[4].Text = elementos[4].ToString();
                  
               
                 labels[0].Text = elementos[0].ToString();
                 labels[1].Text = elementos[1].ToString();
                 labels[2].Text = elementos[2].ToString();
                 labels[3].Text = elementos[3].ToString();
                 labels[4].Text = elementos[4].ToString();
              }
             }
            else
            {
                MessageBox.Show("Dados Inválidos");
            }
            }
           else
            {
                MessageBox.Show("Dados Inválidos");
            }
            }
          else
            {
                MessageBox.Show("Dados Inválidos");
            }
                }
                else
                {
                    MessageBox.Show("Dados Inválidos");
                }
                }
            else
            {
                MessageBox.Show("Dados Inválidos");
            }
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            if (cboBusca.SelectedIndex == 0)
            {
                MessageBox.Show("Selecione um algorítmo");
            }
            if (cboBusca.SelectedIndex == 1)
            {
                int numero;
                if (int.TryParse(txtBusca.Text, out numero))
                {
                    numero = int.Parse(txtBusca.Text);

                    for (int i = 0; i<elementos.Length; i++)
                    {
                        if (elementos[i] == numero)
                        {
                            lblResultado.Text = "Busca feita com sucesso " + "O número " + elementos[i] + " foi encontrado no índice " + i;
                            break;
                        }
                        else
                        {
                            lblResultado.Text = "Busca falhou...";
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Dados Inválidos");
                }
            }
            if (cboBusca.SelectedIndex == 2)
            {
                int baixo = 0;
                int alto = elementos.Length - 1;

                int numero;

                if (int.TryParse(txtBusca.Text, out numero))
                {
                    numero = int.Parse(txtBusca.Text);
                    while (baixo <= alto)
                    {
                        int medio = (baixo + alto) / 2;

                        if (numero < elementos[medio])
                        {
                            alto = medio - 1;
                        }
                        else if (numero > elementos[medio])
                        {
                            baixo = medio + 1;
                        }

                        else if (numero == elementos[medio])
                        {
                            lblResultado.Text = "Busca feita com sucesso " + "O número " + numero + " foi encontrado no índice ";
                            break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Dados Inválidos");
                }
            }
        }

        private void btnIncluirValores_Click(object sender, EventArgs e)
        {
            int numero1, numero2, numero3, numero4, numero5;
            if (int.TryParse(txtElemento1.Text, out numero1))
            {
                if (int.TryParse(txtElemento2.Text, out numero2))
                {
                    if (int.TryParse(txtElemento3.Text, out numero3))
                    {
                        if (int.TryParse(txtElemento4.Text, out numero4))
                        {
                            if (int.TryParse(txtElemento5.Text, out numero5))
                            {
                                for (int i = 0; i < elementos.Length; i++)
                                {

                                    numero1 = int.Parse(txtElemento1.Text);
                                    numero2 = int.Parse(txtElemento2.Text);
                                    numero3 = int.Parse(txtElemento3.Text);
                                    numero4 = int.Parse(txtElemento4.Text);
                                    numero5 = int.Parse(txtElemento5.Text);

                                    elementos[0] = numero1;
                                    elementos[1] = numero2;
                                    elementos[2] = numero3;
                                    elementos[3] = numero4;
                                    elementos[4] = numero5;



                                    labels[0].Text = elementos[0].ToString();
                                    labels[1].Text = elementos[1].ToString();
                                    labels[2].Text = elementos[2].ToString();
                                    labels[3].Text = elementos[3].ToString();
                                    labels[4].Text = elementos[4].ToString();


                                    labels[0].Text = elementos[0].ToString();
                                    labels[1].Text = elementos[1].ToString();
                                    labels[2].Text = elementos[2].ToString();
                                    labels[3].Text = elementos[3].ToString();
                                    labels[4].Text = elementos[4].ToString();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Dados Inválidos");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Dados Inválidos");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Dados Inválidos");
                    }
                }
                else
                {
                    MessageBox.Show("Dados Inválidos");
                }
            }
            else
            {
                MessageBox.Show("Dados Inválidos");
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
