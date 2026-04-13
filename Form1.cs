using System;
using System.IO;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private TextBox textBox1;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string[] lines = File.ReadAllLines("prices.txt");

                double sum = 0;
                double min = double.MaxValue;
                double max = double.MinValue;
                int count = 0;
                int countOver100 = 0;

                foreach (string line in lines)
                {
                    double price = double.Parse(line);

                    sum += price;
                    count++;

                    if (price < min)
                        min = price;

                    if (price > max)
                        max = price;

                    if (price > 100)
                        countOver100++;
                }

                double avg = sum / count;

                string result = "Сума: " + sum + Environment.NewLine +
                                "Середнє: " + avg + Environment.NewLine +
                                "Мін: " + min + Environment.NewLine +
                                "Макс: " + max + Environment.NewLine +
                                "Дорожче 100: " + countOver100;

                textBox1.Text = result;

                File.WriteAllText("result.txt", result);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }
    }
}
