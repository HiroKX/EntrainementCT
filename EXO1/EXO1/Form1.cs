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

namespace EXO1
{
    public partial class Form1 : Form
    {

        public Dictionary<char,char> clef { get; } = new Dictionary<char, char>();


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
            if( values.Length < 27)
            {
                MessageBox.Show("L clef doit contenir assez de char ");
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
                MessageBox.Show("LA clef n'a pas pu être comprise ! "+ clef.Count);
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
                char c = (char) r.Next('a','z'+1);
                if (!clef.ContainsValue(c))
                {
                    clef.Add(Alphabet.Elements[index],c);
                    index++;
                }

                if(index == 26)
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
    }
}
