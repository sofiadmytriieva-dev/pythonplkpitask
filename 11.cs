using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Button button1;
        private TextBox textBox1;

        public Form1()
        {
            InitializeComponent();
            CreateUI();
        }

        private void CreateUI()
        {
            // BUTTON
            button1 = new Button();
            button1.Text = "Обробити файл";
            button1.Width = 150;
            button1.Height = 40;
            button1.Top = 20;
            button1.Left = 20;
            button1.Click += button1_Click;
            this.Controls.Add(button1);

            // TEXTBOX
            textBox1 = new TextBox();
            textBox1.Multiline = true;
            textBox1.Width = 300;
            textBox1.Height = 200;
            textBox1.Top = 80;
            textBox1.Left = 20;
            this.Controls.Add(textBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string path = "prices.txt";

                if (!File.Exists(path))
                {
                    MessageBox.Show("Файл prices.txt не знайдено!");
                    return;
                }

                string[] lines = File.ReadAllLines(path);

                double sum = 0;
                double min = double.MaxValue;
                double max = double.MinValue;
                int count = 0;
                int countOver100 = 0;

                foreach (string line in lines)
                {
                    if (double.TryParse(line, out double price))
                    {
                        sum += price;
                        count++;

                        if (price < min) min = price;
                        if (price > max) max = price;
                        if (price > 100) countOver100++;
                    }
                }

                if (count == 0)
                {
                    textBox1.Text = "Немає коректних чисел у файлі";
                    return;
                }

                double avg = sum / count;

                string result =
                    "Сума: " + sum + Environment.NewLine +
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

        private void InitializeComponent()
        {
            // If you are not using the designer, this can be left empty.
            // If you use the designer, this method is auto-generated in Form1.Designer.cs.
        }
    }
}