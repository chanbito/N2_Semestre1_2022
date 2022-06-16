using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;

namespace BinaryTree
{
    public partial class Trees : Form
    {
        public Trees()
        {
            InitializeComponent();
        }

        private BinaryTree _tree;

        //private bool _acting = false;
        //private bool _paintAgain = false;
        void DesenhaArvore()
        {
            if (_tree == null) return;
            pictureBox1.Image = _tree.Draw();
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            _tree = new BinaryTree();
            lblEvents.Text = @"new binary tree";
            DesenhaArvore();
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                var val = int.Parse(txtValor.Text);
                if (_tree == null)
                    btnCriar_Click(btnCriar, new EventArgs());
                lblEvents.Text = _tree.Add(new Node(val))
                                  ? string.Format("{0} adicionado com sucesso", val)
                                  : string.Format("{0} não adicionado: número repetido!", val);
                lblCount.Text = _tree.Count.ToString();
                DesenhaArvore();
                txtValor.SelectAll();
                this.Update();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            try
            {
                var val = int.Parse(txtValor.Text);
                lblEvents.Text = _tree.Remove(val)
                                  ? string.Format("{0} removido com sucesso", val)
                                  : string.Format("não removido: {0} não existe", val);
                DesenhaArvore();
                txtValor.Text = _tree.RootNode.Right.Value.ToString();
                this.Update();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnAdicionar_Click(btnAdicionar, new EventArgs());
            }
        }

        Random rnd = new Random();
        private void btnRnd_Click(object sender, EventArgs e)
        {
            var val = rnd.Next(1, 999);
            var contador = 0;
            if (_tree != null)
            {
                _tree.Exists(val);
                while (_tree.Exists(val) && contador++ < 999)
                    val = rnd.Next(1, 999);
            }
            txtValor.Text = val.ToString();
            btnAdicionar_Click(btnAdicionar, new EventArgs());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnCriar_Click(btnCriar, new EventArgs());
            new Action(() =>
            {
                for (var i = 0; i < 45; i++)
                {
                    var val = rnd.Next(1, 999);
                    var contador = 0;
                    if (_tree != null)
                    {
                        _tree.Exists(val);
                        while (_tree.Exists(val) && contador++ < 998)
                            val = rnd.Next(1, 999);
                    }

                    var res = _tree.Add(new Node(val));

                    Invoke(new Action(() =>
                    {
                        lblEvents.Text = res
                                            ? string.Format("{0} adicionado com sucesso", val)
                                            : string.Format("{0} não adicionado: número repetido!",
                                                            val);

                        lblCount.Text = _tree.Count.ToString();
                    }));

                    if (i % 1 == 0)
                        DesenhaArvore();
                    //System.Threading.Thread.Sleep(1);
                }
                DesenhaArvore();

            }).BeginInvoke(null, null);


        }

        public static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            // Pega imaens codecs para todos os formatos de imagem
            var codecs = ImageCodecInfo.GetImageEncoders();
            // encontra o code de imagem correto
            return codecs.FirstOrDefault(t => t.MimeType == mimeType);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            const double quality = 1;
            var d = new SaveFileDialog { Filter = @"jpeg files|*.jpg" };
            try
            {
                if (d.ShowDialog() != DialogResult.OK)
                    return;
                var bmp = pictureBox1.Image;
                var qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality,
                                                                     (long)(quality * 75));
                // Jpeg image codec
                var jpegCodec = GetEncoderInfo("image/jpeg");

                if (jpegCodec == null)
                    return;

                var encoderParams = new EncoderParameters(1);
                encoderParams.Param[0] = qualityParam;
                bmp.Save(d.FileName, jpegCodec, encoderParams);
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

        }

        private void btnAdicionar_MouseHover(object sender, EventArgs e)
        {
            btnAdicionar.UseVisualStyleBackColor = false;
            btnAdicionar.BackColor = Color.Red;
            btnAdicionar.ForeColor = Color.White;
        }

        private void btnAdicionar_MouseLeave(object sender, EventArgs e)
        {

            btnAdicionar.UseVisualStyleBackColor = false;
            btnAdicionar.BackColor = Color.FromArgb(192, 192, 255);
            btnAdicionar.ForeColor = Color.Black;
        }

        private void btnRemover_MouseHover(object sender, EventArgs e)
        {
            btnRemover.UseVisualStyleBackColor = false;
            btnRemover.BackColor = Color.Red;
            btnRemover.ForeColor = Color.White;
        }

        private void btnRemover_MouseLeave(object sender, EventArgs e)
        {
            btnRemover.UseVisualStyleBackColor = false;
            btnRemover.BackColor = Color.FromArgb(192, 192, 255);
            btnRemover.ForeColor = Color.Black;
        }

        private void btnSalvar_MouseHover(object sender, EventArgs e)
        {
            btnSalvar.UseVisualStyleBackColor = false;
            btnSalvar.BackColor = Color.Red;
            btnSalvar.ForeColor = Color.White;
        }

        private void btnSalvar_MouseLeave(object sender, EventArgs e)
        {
            btnSalvar.UseVisualStyleBackColor = false;
            btnSalvar.BackColor = Color.FromArgb(192, 192, 255);
            btnSalvar.ForeColor = Color.Black;
        }

        private void btnCriar_MouseHover(object sender, EventArgs e)
        {
            btnCriar.UseVisualStyleBackColor = false;
            btnCriar.BackColor = Color.Red;
            btnCriar.ForeColor = Color.White;

        }

        private void btnCriar_MouseLeave(object sender, EventArgs e)
        {
            btnCriar.UseVisualStyleBackColor = false;
            btnCriar.BackColor = Color.FromArgb(192, 192, 255);
            btnCriar.ForeColor = Color.Black;
        }

        private void btnRnd_MouseHover(object sender, EventArgs e)
        {
            btnRnd.UseVisualStyleBackColor = false;
            btnRnd.BackColor = Color.Red;
            btnRnd.ForeColor = Color.White;
        }

        private void btnRnd_MouseLeave(object sender, EventArgs e)
        {
            btnRnd.UseVisualStyleBackColor = false;
            btnRnd.BackColor = Color.FromArgb(192, 192, 255);
            btnRnd.ForeColor = Color.Black;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
