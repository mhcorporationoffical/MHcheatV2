using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zorara;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using FastColoredTextBoxNS;
using System.IO;

namespace MHCHEAT_V2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Checker.Interval = 1000;
            Checker.Tick += timerInject_Tick;
            //Checker.Enabled = true;
        }

        private void siticoneCheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            timerInject.Interval = 5000;
            timerInject.Tick += timerInject_Tick;
            if (siticoneCheckBox1.Checked == true)
            {
                // Запускаем циклическую проверку
                timerInject.Enabled = true;
            }
            else
            {
                // Останавливаем циклическую проверку
                timerInject.Enabled = false;
            }
        }

        private void timerInject_Tick(object sender, EventArgs e)
        {
            if (CoreFunctions.IsInjected() == false)
            {
                if (CoreFunctions.IsRobloxOpen())
                {
                    CoreFunctions.Inject();
                }
            }
        }

        private void siticoneButton4_Click(object sender, EventArgs e)
        {
            if (CoreFunctions.IsRobloxOpen() == false) {
                MessageBox.Show("Dont forget to open roblox!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            else
            {
                CoreFunctions.Inject();
                if (CoreFunctions.IsInjected())
                {
                    MessageBox.Show("Cheat has aerly injected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }

        private void siticoneButton2_Click(object sender, EventArgs e)
        {
            CoreFunctions.ExecuteScript(CodeBox.Text);
        }

        private void siticoneButton3_Click(object sender, EventArgs e)
        {
            CoreFunctions.KillRoblox();
        }

        private void siticoneButton1_Click(object sender, EventArgs e)
        {
            CodeBox.Text = string.Empty;
        }

        private void siticoneButton5_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                openFileDialog1.Title = "Open";
                CodeBox.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void siticoneButton6_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(CodeBox.Text);
                }
            }

        }

        private void Checker_Tick(object sender, EventArgs e)
        {
            //if (CoreFunctions.IsRobloxOpen() == false) {
            //    robloxStatus.Text = "FALSE";
            //}
            //else {
            //    robloxStatus.Text = "TRUE";
            //}
            //if (CoreFunctions.IsInjected() == false)
            //{
            //    injectStatus.Text = "FALSE";
            //}
            //else
            //{
            //    injectStatus.Text = "TRUE";
            //}
        }

        private void siticoneButton7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void siticoneButton8_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void ListboxChecker_Tick(object sender, EventArgs e)
        {
            string path = "./scripts";
            if (Directory.Exists(path))
            {
                listBox1.Items.Clear();
                foreach (FileInfo fileInfo in new DirectoryInfo("./scripts").GetFiles("*.txt"))
                {
                    this.listBox1.Items.Add(fileInfo.Name);
                }
                foreach (FileInfo fileInfo2 in new DirectoryInfo("./scripts").GetFiles("*.lua"))
                {
                    this.listBox1.Items.Add(fileInfo2.Name);
                }
            }
            else
            {
                Directory.CreateDirectory(path);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fileName = listBox1.SelectedItem?.ToString() ?? string.Empty;
            if (!string.IsNullOrEmpty(fileName))
            {
                string filePath = Path.Combine("./scripts", fileName);
                if (File.Exists(filePath))
                {
                    CodeBox.Text = File.ReadAllText(filePath);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
