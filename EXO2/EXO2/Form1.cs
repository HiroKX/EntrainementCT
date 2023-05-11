using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EXO2
{
    public partial class Form1 : Form
    {

        public Dictionary<char, char> clef { get; } = new Dictionary<char, char>();


        public Form1()
        {
            InitializeComponent();
            dataGridView1.Rows.Add();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            char[] values = textBox1.Text.ToCharArray();
            int index = 0;
            if (values.Length < 26)
            {
                MessageBox.Show("La clef doit contenir assez de char ");
                return;
            }
            foreach (char letter in Alphabet.Elements)
            {
                while (index < values.Length && clef.ContainsValue(values[index]))
                {
                    index++;
                }
                if (index < values.Length && !clef.ContainsKey(letter))
                {
                    clef.Add(letter, values[index]);
                }
            }

            if (clef.Count != 27)
            {
                MessageBox.Show("La clef n'a pas pu être comprise ! " + clef.Count);
                return;
            }
            addLetters();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clef.Clear();
            bool notEnd = true;
            int index = 0;
            while (notEnd)
            {
                Random r = new Random();
                int c = r.Next(0,27);
                if (!clef.ContainsValue(Alphabet.Elements[c]))
                {
                    clef.Add(Alphabet.Elements[index], Alphabet.Elements[c]);
                    index++;
                }

                if (index == 27)
                {
                    notEnd = false;
                }
            }
            addLetters();

        }

        private void addLetters()
        {
            int index = 0;
            foreach (char value in clef.Values)
            {
                int data = dataGridView1.Rows[0].Cells.Count;
                dataGridView1.Rows[0].Cells[index].Value = value;
                index++;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if(clef.Count != 27)
            {
                MessageBox.Show("Clef invalide !" + clef.Count);
                return;
            }
            string val = richTextBox1.Text;
            char[] arr = val.ToCharArray();
            richTextBox2.Text = "";
            foreach (char c in arr)
            {
                char outchar;
                clef.TryGetValue(c, out outchar);
                richTextBox2.Text = richTextBox2.Text + outchar;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (clef.Count != 27)
            {
                MessageBox.Show("Clef invalide !" + clef.Count);
                return;
            }
            string val = richTextBox2.Text;
            char[] arr = val.ToCharArray();
            richTextBox1.Text = "";
            foreach (char c in arr)
            {
                char outchar = getKeyFromValue(c);
                richTextBox1.Text = richTextBox1.Text + outchar;
            }
        }

        private char getKeyFromValue(char value)
        {
            char bis;
            foreach(char key in clef.Keys)
            {
                clef.TryGetValue(key, out bis);
                if (bis == value)
                {
                    return key;
                }
            }
            return ' ';
        }
    }
}
