using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace hassh
{

    public partial class Form1 : Form
    {

        string C1;
        string C2;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {


        }

        public void ENCRIP(string txt_plano, int campo)
        {
            System.Security.Cryptography.HashAlgorithm obj_hash = new System.Security.Cryptography.SHA1CryptoServiceProvider();
            // Convertir el string original a un array de Bytes
            byte[] cadena_plana = System.Text.Encoding.UTF8.GetBytes(txt_plano);
            byte[] cadena_encrp = obj_hash.ComputeHash(cadena_plana);
            obj_hash.Clear();

            if (campo == 1)
            {
                textBox3.Text = (Convert.ToBase64String(cadena_encrp));
            }
            else
            {
                textBox4.Text = (Convert.ToBase64String(cadena_encrp));
            }

        }




        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                if (textBox4.Text != "")
                {
                    if (textBox3.Text == textBox4.Text)
                    {
                        MessageBox.Show("SON IGUALES");
                    }
                    else
                    {
                        MessageBox.Show("NO SON IGUALES");
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                { 
                    filePath = openFileDialog.FileName;
                    var fileStream = openFileDialog.OpenFile();
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }

            C1 = fileContent;
            textBox1.Text = filePath;
            ENCRIP(C1, 1);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    var fileStream = openFileDialog.OpenFile();
                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }

            C2 = fileContent;
            textBox2.Text = filePath;
            ENCRIP(C2, 2);
        }
    }
}
