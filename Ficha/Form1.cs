using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace Ficha
{
    public partial class Form1 : Form
    {
        public DateTime ValorDataIngresso { get; private set; }

        public void sqlConn()
        {
            string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\alvaro.pimentel\Documents\geapeteste.mdf;Integrated Security=True;Connect Timeout=30";
            SqlConnection cnn = new SqlConnection(connString);
            cnn.Open();

            if (textBox1.Text == "")
            {
                MessageBox.Show("Preencha o campo MATRICULA para pesquisar uma ficha.");
            }
            else
            {
                String sql = "SELECT ServidorCompetencia, ServidorNome, ServidorLotacao, ServidorCargo, ServidorAtividade, ServidorConhecimento, ServidorHabilidade, ServidorAtitude, ServidorAreaAtuacao, ServidorTipoIngresso " +
                    $"FROM fichacompetencia where ServidorMatricula = {textBox1.Text}";
                String outputCompetencia = "";
                String outputNome = "";
                String outputLot = "";
                String outputCargo = "";
                String outputAtividade = "";
                String outputConhecimento = "";
                String outputHabilidade = "";
                String outputAtitude = "";
                String outputArea = "";
                String outputIngresso = "";

                SqlCommand cmd = new SqlCommand(sql, cnn);
                SqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    outputCompetencia = outputCompetencia + dataReader.GetValue(0);
                    outputNome = outputNome + dataReader.GetValue(1);
                    outputLot = outputLot + dataReader.GetValue(2);
                    outputCargo = outputCargo + dataReader.GetValue(3);
                    outputAtividade = outputAtividade + dataReader.GetValue(4);
                    outputConhecimento = outputConhecimento + dataReader.GetValue(5);
                    outputHabilidade = outputHabilidade + dataReader.GetValue(6);
                    outputAtitude = outputAtitude + dataReader.GetValue(7);
                    outputArea = outputArea + dataReader.GetValue(8);
                    outputIngresso = outputIngresso + dataReader.GetValue(9);
                }

                richTextBox1.Enabled = false; richTextBox1.Text = outputCompetencia;
                textBox1Servidor.Enabled = false; textBox1Servidor.Text = outputNome;
                textBox3.Enabled = false; textBox3.Text = outputLot;
                textBox2.Enabled = false; textBox2.Text = outputCargo;
                richTextBox2.Enabled = false; richTextBox2.Text = outputAtividade;
                richTextBox3.Enabled = false; richTextBox3.Text = outputConhecimento;
                richTextBox4.Enabled = false; richTextBox4.Text = outputHabilidade;
                richTextBox5.Enabled = false; richTextBox5.Text = outputAtitude;
                comboBox1.Enabled = false; comboBox1.Text= outputArea;
                comboBox2.Enabled = false; comboBox2.Text = outputIngresso;


                dataReader.Close();
                cmd.Dispose();
                cnn.Close();
            }
            
        }

        public void sqlInsert()
        {
            String connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\alvaro.pimentel\Documents\geapeteste.mdf;Integrated Security=True;";
            using (SqlConnection cnn = new SqlConnection(connString))
            {
                cnn.Open();

                String inserirDados =
                    "INSERT INTO fichacompetencia(ServidorMatricula, ServidorNome, ServidorLotacao, ServidorCargo," +
                    " ServidorCompetencia, ServidorAreaAtuacao, ServidorTipoIngresso)" +
                    "VALUES(@matricula, @nome, @lotacao, @cargo, @competencias, @area, @ingresso)"
                    ;

                SqlCommand cmd = new SqlCommand(inserirDados, cnn);
                cmd.Parameters.AddWithValue("@matricula", textBox1.Text);
                cmd.Parameters.AddWithValue("@nome", textBox1Servidor.Text.ToUpper());
                cmd.Parameters.AddWithValue("@lotacao", textBox3.Text.ToUpper());
                cmd.Parameters.AddWithValue("@cargo", textBox2.Text);
                cmd.Parameters.AddWithValue("@competencias", richTextBox1.Text);
                cmd.Parameters.AddWithValue("@area", comboBox1.Text);
                cmd.Parameters.AddWithValue("@ingresso", comboBox2.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Dados inseridos com sucesso.");
                cnn.Close();
            }
            
        }

        public void sqlDelete()
        {
            String connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\alvaro.pimentel\Documents\geapeteste.mdf;Integrated Security=True;";
            using (SqlConnection cnn = new SqlConnection(connString))
            {
                cnn.Open();

                String deletarDados =
                    $"DELETE FROM fichacompetencia WHERE ServidorMatricula ={textBox1.Text}";

                SqlCommand cmd = new SqlCommand(deletarDados, cnn);
                cmd.ExecuteNonQuery();
                MessageBox.Show($"Dados da matricula {textBox1.Text} deletados.");
                cnn.Close();
            }
        }

        public void print()
        {
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, this.Width, this.Height));
            PrintDocument window = new PrintDocument();
            window.PrintPage += new PrintPageEventHandler(this.printDocument4_PrintPage);
            window.Print();
        }

        public Form1()
        {
            InitializeComponent();
            int IDCONT = 1;
            string IDString = IDCONT.ToString();
            BD_ID.Text = IDString;

            //server=10.95.2.78;port=33066;password=;User ID=root;database=fichacompetencia 
            //data source=10.95.2.78; database=fichacompetencia;password=; user id=root;
            //data source=10.95.2.78; password=; user id=root; Initial Catalog=fichacompetencia;
            //root@10.95.2.78:33066 Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\alvaro.pimentel\Documents\geapeteste.mdf;Integrated Security=True;Connect Timeout=30
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

         private void button7_Click(object sender, EventArgs e)
        {
            sqlConn();
        }

        public void LimpaTudo()
        {
            textBox1.Enabled = true; textBox1.Text = "";
            textBox1Servidor.Enabled = true; ; textBox1Servidor.Text = "";            
            dateTimePicker1.Enabled = true; dateTimePicker1.Value = DateTime.Now;        
            textBox2.Enabled = true;   textBox2.Text = "";
            textBox3.Enabled = true;   textBox3.Text = "";
            textBox4.Enabled = true;   textBox4.Text = "";
            textBox5.Enabled = true;   textBox5.Text = "";
            comboBox1.Enabled = true;  comboBox1.SelectedIndex = 0;
            comboBox2.Enabled = true;  comboBox2.SelectedIndex = 0;
            richTextBox1.Enabled = false; richTextBox1.Text = "";
            richTextBox2.Enabled = false; richTextBox2.Text = "";
            richTextBox3.Enabled = false; richTextBox3.Text = "";
            richTextBox4.Enabled = false; richTextBox4.Text = "";
            richTextBox5.Enabled = false; richTextBox5.Text = "";
        }

        public void LimpaNew()
        {
            textBox1.Text = "";
            //textBox1Servidor.Enabled = false;
            textBox1Servidor.Text = "";
            dateTimePicker1.Enabled = true; dateTimePicker1.Value = DateTime.Now;
            textBox2.Enabled = true; textBox2.Text = "";          
            textBox4.Enabled = true; textBox4.Text = "";
            textBox5.Enabled = true; textBox5.Text = "";
            comboBox1.Enabled = true; comboBox1.SelectedIndex = 0;
            comboBox2.Enabled = true; comboBox2.SelectedIndex = 0;
            richTextBox1.Enabled =false; richTextBox1.Text = "";
            richTextBox2.Enabled = false; richTextBox2.Text = "";
            richTextBox3.Enabled = false; richTextBox3.Text = "";
            richTextBox4.Enabled = false; richTextBox4.Text = "";
            richTextBox5.Enabled = false; richTextBox5.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LimpaTudo();
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cancelando (Limpando) Dados da Ficha!");
            LimpaTudo();
        }

        private void textBox1Servidor_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void BD_ID_Click(object sender, EventArgs e)
        {
            //int IDCONT = 2;
            //string IDString = IDCONT.ToString();
            //BD_ID.Text = IDString;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Deseja deletar essa ficha?", "Deletar ficha", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm.ToString().ToUpper() == "YES")
            {
                sqlDelete();
                LimpaTudo();
            }
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("NOVA Ficha? Lembre de salvar a atual!");

            int IDCONT2 = 1;
            IDCONT2 = IDCONT2 + 1;
            string IDString2 = IDCONT2.ToString();
            BD_ID.Text = IDString2;

            LimpaNew();
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ABRIR... Selecione Ficha!");
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SALVAR... Selecione Destino!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Deseja Continuar?", "Adicionar nova ficha", MessageBoxButtons.YesNo);

            if (confirm.ToString().ToUpper() == "YES")
            {
                try
                {
                    sqlInsert();
                }
                catch (Exception)
                {
                    MessageBox.Show("Já existe um servidor com número de matrícula: " + textBox1.Text);
                }
            }
            
            /*try
            {
                sqlInsert();
            }
            catch(Exception)
            {
                MessageBox.Show("Já existe um servidor com número de matrícula: " + textBox1.Text);
            }*/
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("ABRIR... Selecione Ficha!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            print();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_ID_Click(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void printDocument4_PrintPage(object sender, PrintPageEventArgs e)
        {
            System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(this.Width, this.Height);
            this.DrawToBitmap(bmp, new System.Drawing.Rectangle(0, 0, this.Width, this.Height));
            e.Graphics.DrawImage(bmp, 0, 0);
        }
    }
}
