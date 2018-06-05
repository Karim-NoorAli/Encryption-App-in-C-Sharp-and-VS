using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encyption_App
{
    public partial class form1 : Form
    {
        Random rnd = new Random();
        List<int> skey = new List<int>();
        List<char> ckey = new List<char>();
        public form1()
        {
            InitializeComponent();
        }

        private void form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //String file = (String)sender;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if(button.Text == "ENCRYPT")
            {
                //char[] chars = textBox1.Text.ToCharArray();
               // var asciiBytes = new List<byte>;
                Byte[] asciiBytes = Encoding.ASCII.GetBytes(textBox.Text);
                for (int k = 0; k < asciiBytes.Length; k++) {
                    int code = rnd.Next(1, 15);
                    skey.Add(code);
                    asciiBytes[k] = (byte)(asciiBytes[k] + code);
                    char c = (char)asciiBytes[k];
                    ckey.Add(c);
                }
                keyBox.Text = string.Join(",", skey);
                textBox.Text = string.Join("",ckey);
                error_box.Text = "Save your TEXT and KEY";
            }
            else
            {
                if (string.IsNullOrWhiteSpace(keyBox.Text))
                {
                    error_box.Text = "Enter your Secret Key";
                }
                else if(string.IsNullOrWhiteSpace(textBox.Text))
                {
                    error_box.Text = "Enter your text too";
                }
                else
                {
                    Byte[] asciiBytes = Encoding.ASCII.GetBytes(textBox.Text);
                    foreach (var s in keyBox.Text.Split(','))
                    {
                        int num;
                        if (int.TryParse(s, out num))
                            //yield return num;
                            skey.Add(num);
                    }
                    for (int k = 0; k < asciiBytes.Length; k++)
                    {

                        asciiBytes[k] = (byte)(asciiBytes[k] - skey[k]);
                        char c = (char)asciiBytes[k];
                        ckey.Add(c);
                    }
                    textBox.Text = string.Join("", ckey);
                    error_box.Text = "Here is your Password";

                }
                //else if(!(int.TryParse(textBox2.Text, out skey)))
               
            }
        }
    }
}
