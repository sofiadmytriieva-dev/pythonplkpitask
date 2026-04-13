using System;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private TextBox textBoxWord;
        private TextBox textBoxResult;
        private Button buttonSearch;

        public Form1()
        {
            CreateUI();
        }

        private void CreateUI()
        {
            Label label = new Label();
            label.Text = "Введіть слово:";
            label.Top = 20;
            label.Left = 20;
            this.Controls.Add(label);

            textBoxWord = new TextBox();
            textBoxWord.Top = 50;
            textBoxWord.Left = 20;
            textBoxWord.Width = 200;
            this.Controls.Add(textBoxWord);

            buttonSearch = new Button();
            buttonSearch.Text = "Пошук";
            buttonSearch.Top = 90;
            buttonSearch.Left = 20;
            buttonSearch.Click += buttonSearch_Click;
            this.Controls.Add(buttonSearch);

            textBoxResult = new TextBox();
            textBoxResult.Multiline = true;
            textBoxResult.Top = 140;
            textBoxResult.Left = 20;
            textBoxResult.Width = 400;
            textBoxResult.Height = 250;
            this.Controls.Add(textBoxResult);
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string word = textBoxWord.Text.Trim();

                if (word == "")
                {
                    MessageBox.Show("Введіть слово для пошуку!");
                    return;
                }

                string path = "text.txt";

                if (!File.Exists(path))
                {
                    MessageBox.Show("Файл text.txt не знайдено!");
                    return;
                }

                string[] lines = File.ReadAllLines(path);

                int count = 0;
                string resultLines = "";

                foreach (string line in lines)
                {
                    if (line.ToLower().Contains(word.ToLower()))
                    {
                        count++;
                        resultLines += line + Environment.NewLine;
                    }
                }

                string result;

                if (count > 0)
                {
                    result =
                        "Слово знайдено!" + Environment.NewLine +
                        "Кількість входжень (рядків): " + count + Environment.NewLine +
                        "Рядки:" + Environment.NewLine +
                        resultLines;
                }
                else
                {
                    result = "Слово не знайдено у файлі.";
                }

                textBoxResult.Text = result;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }
    }
}