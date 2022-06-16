using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AlgorithmDataStructures
{
    public partial class StackandQueus : Form
    {
        Stack<String> stack = new Stack<String>();
        Queue<String> queue = new Queue<String>();
        List<String> list = new List<String>();

        public StackandQueus()
        {
            InitializeComponent();
        }

        private void btnPush_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtElemento.Text))
            {
                MessageBox.Show("Enter Value");
                txtElemento.Clear();
                txtElemento.Focus();
            }
            else
            {
                String add;
                add = txtElemento.Text;
                stack.Push(add);

                txtElemento.Clear();
                txtElemento.Focus();
                lbPilha.Items.Clear();
                foreach (String s in stack)
                {
                    lbPilha.Items.Add((Environment.NewLine + s.ToString()));
                    
                }
            }    
        }

        private void btnPop_Click(object sender, EventArgs e)
        {
            if (stack.Count > 0)
            {
                stack.Pop();
                lbPilha.Items.Clear();
                foreach (String s in stack)
                {
                    lbPilha.Items.Add((Environment.NewLine + s.ToString()));
                }
            }
            else
                MessageBox.Show("Empty Stack");
        }

        private void btnPeek_Click(object sender, EventArgs e)
        {
            if (stack.Count > 0)
            {
                var element = stack.Peek();
                MessageBox.Show("Elemento no topo da pilha  é : " + element.ToString());
            }
            else
                MessageBox.Show("PILHA vazia");
        }

        private void btnSize_Click(object sender, EventArgs e)
        {
            var element = stack.Count();
            MessageBox.Show("Número de elementos é : " + element.ToString());
        }

        private void btnEnqueue_Click(object sender, EventArgs e)
        {
            String add;
            if (String.IsNullOrWhiteSpace(textElemento1.Text))
            {
                MessageBox.Show("Informe valores");
                textElemento1.Clear();
                textElemento1.Focus();
            }
            else
            {
                add = textElemento1.Text;
                queue.Enqueue(add);
                textElemento1.Clear();
                textElemento1.Focus();
            }
            lbFila.Items.Clear();
            foreach (String q in queue)
            {
                lbFila.Items.Add((Environment.NewLine + q.ToString()));
            }
        }

        private void btnDequeue_Click(object sender, EventArgs e)
        {
            if (queue.Count == 0)
            {
                MessageBox.Show("FILA vazia");
            }
            else
            {
                queue.Dequeue();
                lbFila.Items.Clear    ();
                foreach (String q in queue)
                {
                    lbFila.Items.Add((Environment.NewLine + q.ToString()));
                }
            }
        }

        private void btnQsize_Click(object sender, EventArgs e)
        {

            var size = queue.Count();
            MessageBox.Show("Número de elementos na fila  é : " + size.ToString());
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
    
