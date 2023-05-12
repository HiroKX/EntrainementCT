using EXO3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Markup;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EXO3
{
    public partial class Form1 : Form
    {

        public Dictionary<char, char> clef { get; } = new Dictionary<char, char>();
        public Dictionary<char, char> clef2 { get; } = new Dictionary<char, char>();



        public Form1()
        {
            InitializeComponent();
            dataGridView1.Rows.Add();
            dataGridView2.Rows.Add();

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
                int c = r.Next(0, 27);
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
                dataGridView1.Rows[0].Cells[index].Value = value;
                index++;
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            clef2.Clear();
            if (clef.Count != 27)
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
            foreach (char key in clef.Keys)
            {
                clef.TryGetValue(key, out bis);
                if (bis == value)
                {
                    return key;
                }
            }
            return 'T';
        }

        private void button5_Click(object sender, EventArgs e) {
            clef2.Clear();
            char[] text = richTextBox2.Text.ToCharArray();
            Dictionary<char, int> occur = new Dictionary<char, int>();
            List<char> dejaUsed = new List<char>();

            foreach(char t in text)
            {
                if(!occur.ContainsKey(t))
                    occur.Add(t, getOccurInString(richTextBox2.Text, t));
            }
            int index = 0;
            while(dejaUsed.Count() < 27)
            {
                int temp = 0;
                char charTemp = 'T';
                foreach(char t in occur.Keys){
                    int temp2= 0;
                    occur.TryGetValue(t, out temp2);
                    if (temp2 > temp && !dejaUsed.Contains(t))
                    {
                        temp = temp2;
                        charTemp = t;
                    }
                }
                dejaUsed.Add(charTemp);
                clef2.Add(Alphabet.Freq[index], charTemp);
                index++;
            }
            addLetters2();
        }


        private void addLetters2()
        {
            int index = 0;
            foreach(char t in Alphabet.Elements)
            {
                char tempor = '/';
                clef2.TryGetValue(t, out tempor);
                dataGridView2.Rows[0].Cells[index].Value = tempor;
                index++;
            }
        }

        private int getOccurInString(string c, char e)
        {
            int wordCount = 0;
            foreach (Match m in Regex.Matches(c, ""+e))
            {
                wordCount++;
            }
            return wordCount;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (clef2.Count != 27)
            {
                MessageBox.Show("Clef invalide !" + clef2.Count);
                return;
            }
            string val = richTextBox2.Text;
            char[] arr = val.ToCharArray();
            richTextBox3.Text = "";
            foreach (char c in arr)
            {
                char outchar = getKeyFromValue2(c);
                richTextBox3.Text = richTextBox3.Text + outchar;
            }
        }

        private char getKeyFromValue2(char value)
        {
            char bis;
            foreach (char key in clef2.Keys)
            {
                clef2.TryGetValue(key, out bis);
                if (bis == value)
                {
                    return key;
                }
            }
            return 'T';
        }
    }
}
