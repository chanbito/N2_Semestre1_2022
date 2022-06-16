using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AlgorithmDataStructures
{
    public partial class SortingAlgorithms : Form
    {
        int[] elementos = new int[5];
        List<Label> labels = new List<Label>();
        int len = 5;
        public SortingAlgorithms()
        {
            InitializeComponent();
        }

        private void insertionSort()
        {
            int temp, j;
            for (int i = 1; i < elementos.Length; i++)
            {
                temp = elementos[i];
                j = i - 1;

                while (j >= 0 && elementos[j] > temp)
                {
                    elementos[j + 1] = elementos[j];
                    j--;
                }

                elementos[j + 1] = temp;
            }
        }
        public static void Quicksort(int[] elementos, int left, int right)
        {
            int i = left, j = right;
            IComparable pivot = elementos[(left + right) / 2];

            while (i <= j)
            {
                while (elementos[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (elementos[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // troca
                    int tmp = elementos[i];
                    elementos[i] = elementos[j];
                    elementos[j] = tmp;

                    i++;
                    j--;
                }
            }

            // chamada recursiva
            if (left < j)
            {
                Quicksort(elementos, left, j);
            }

            if (i < right)
            {
                Quicksort(elementos, i, right);
            }


        }

        public void DoMerge(int[] numeros, int left, int mid, int right)
        {
            int[] temp = new int[25];
            int i, left_end, num_elementos, tmp_pos;

            left_end = (mid - 1);
            tmp_pos = left;
            num_elementos = (right - left + 1);

            while ((left <= left_end) && (mid <= right))
            {
                if (elementos[left] <= elementos[mid])
                    temp[tmp_pos++] = elementos[left++];
                else
                    temp[tmp_pos++] = elementos[mid++];
            }

            while (left <= left_end)
                temp[tmp_pos++] = elementos[left++];

            while (mid <= right)
                temp[tmp_pos++] = elementos[mid++];

            for (i = 0; i < num_elementos; i++)
            {
                elementos[right] = temp[right];
                right--;
            }
        }

         public void MergeSort_Recursive(int[] numeros, int left, int right)
        {
            int mid;

            if (right > left)
            {
                mid = (right + left) / 2;
                MergeSort_Recursive(elementos, left, mid);
                MergeSort_Recursive(elementos, (mid + 1), right);

                DoMerge(numeros, left, (mid + 1), right);
            }
        }

        private void bubbleSort()
        {

            int temp;
            for (int pass = 1; pass <= elementos.Length - 2; pass++)
            {
                for (int i = 0; i <= elementos.Length - 2; i++)
                {
                    if (elementos[i] > elementos[i + 1])
                    {
                        temp = elementos[i + 1];
                        elementos[i + 1] = elementos[i];
                        elementos[i] = temp;
                    }

                }

            }
        }

        private void ShellSort(int[] elementos)
        {

            int n = elementos.Length;
            int gap = n / 2;
            int temp;

            while (gap > 0)
            {
                for (int i = 0; i + gap < n; i++)
                {
                    int j = i + gap;
                    temp = elementos[j];

                    while (j - gap >= 0 && temp < elementos[j - gap])
                    {
                        elementos[j] = elementos[j - gap];
                        j = j - gap;
                    }

                    elementos[j] = temp;
                }

                gap = gap / 2;
            }
        }
           

        private void groupBox1_Enter(object sender, EventArgs e)
        {
           cboOrdenacao.Items.Add("Selecione um algorítmo de Ordenação");
           cboOrdenacao.Items.Add("Shell sort ");
           cboOrdenacao.Items.Add("Bubble sort ");
           cboOrdenacao.Items.Add("Merge sort ");
           cboOrdenacao.Items.Add("Quick sort ");
           cboOrdenacao.Items.Add("Insertion sort ");
           cboOrdenacao.SelectedIndex = 0;
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

        private void btnSort_Click(object sender, EventArgs e)
        {
            if (cboOrdenacao.SelectedIndex == 0)
            {
                MessageBox.Show("Select a sorting Algorithm");
            }
            if (cboOrdenacao.SelectedIndex == 1)
            {
                ShellSort(elementos);
                for (int i = 0; i < elementos.Length; i++)
                {
                    
                    lbOrdenada.Items.Add(elementos[i]);
                }
                sortingLabel.Text = "Elementos ordenados com shell Sorting";
            }

            if (cboOrdenacao.SelectedIndex == 2)
            {
                bubbleSort();
                for (int i = 0; i < elementos.Length; i++)
                {
                   
                    lbOrdenada.Items.Add(elementos[i]);
                }
                sortingLabel.Text = "Elementos ordenados com Bubble Sorting"; 
            }

            if (cboOrdenacao.SelectedIndex == 3)
            {
                MergeSort_Recursive(elementos, 0, len - 1);
                for (int i = 0; i < 5; i++)
                {
                    lbOrdenada.Items.Add(elementos[i]);
                }
                sortingLabel.Text = "Elementos ordenados com Merge Sorting";
            }

            if (cboOrdenacao.SelectedIndex == 4)
            {
                Quicksort(elementos, 0, elementos.Length - 1);
                // imprime o array ordenado
                for (int i = 0; i < elementos.Length; i++)
                {
                    lbOrdenada.Items.Add(elementos[i]);

                }

                sortingLabel.Text = "Elementos ordenados com Quick Sorting";
            }
            if (cboOrdenacao.SelectedIndex == 5)
            {
                insertionSort();
                for (int i = 0; i < elementos.Length; i++)
                {

                   lbOrdenada.Items.Add(elementos[i]);
                }
                sortingLabel.Text = "Elementos ordenados com Insertion Sorting";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lbOrdenada.Items.Clear();
        }

        private void SortingAlgorithms_Load(object sender, EventArgs e)
        {

        }

        private void btnAddValue_MouseHover(object sender, EventArgs e)
        {
            btnAdicionar.UseVisualStyleBackColor = false;
            btnAdicionar.BackColor = Color.Red;
            btnAdicionar.ForeColor = Color.White;
        }

        private void btnAddValue_MouseLeave(object sender, EventArgs e)
        {
            btnAdicionar.UseVisualStyleBackColor = false;
            btnAdicionar.BackColor = Color.FromArgb(192, 192, 255);
            btnAdicionar.ForeColor = Color.Black;
        }

        private void btnSort_MouseHover(object sender, EventArgs e)
        {
            btnOrdena.UseVisualStyleBackColor = false;
            btnOrdena.BackColor = Color.Red;
            btnOrdena.ForeColor = Color.White;
        }

        private void btnSort_MouseLeave(object sender, EventArgs e)
        {
            btnOrdena.UseVisualStyleBackColor = false;
            btnOrdena.BackColor = Color.FromArgb(192, 192, 255);
            btnOrdena.ForeColor = Color.Black;
        }

        private void btnClear_MouseHover(object sender, EventArgs e)
        {
            btnLimpa.UseVisualStyleBackColor = false;
            btnLimpa.BackColor = Color.Red;
            btnLimpa.ForeColor = Color.White;
        }

        private void btnClear_MouseLeave(object sender, EventArgs e)
        {
            btnLimpa.UseVisualStyleBackColor = false;
            btnLimpa.BackColor = Color.FromArgb(192, 192, 255);
            btnLimpa.ForeColor = Color.Black;
   
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
