using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private TextBox nameBox, loginBox, passwordBox, ageBox, outputBox;
        private Button saveButton, loadButton;

        public Form1()
        {
            // InitializeComponent();
            CreateUI();
        }

        private void CreateUI()
        {
            Label l1 = new Label() { Text = "Ім'я", Top = 20, Left = 20 };
            nameBox = new TextBox() { Top = 40, Left = 20, Width = 200 };

            Label l2 = new Label() { Text = "Логін", Top = 70, Left = 20 };
            loginBox = new TextBox() { Top = 90, Left = 20, Width = 200 };

            Label l3 = new Label() { Text = "Пароль", Top = 120, Left = 20 };
            passwordBox = new TextBox() { Top = 140, Left = 20, Width = 200 };

            Label l4 = new Label() { Text = "Вік", Top = 170, Left = 20 };
            ageBox = new TextBox() { Top = 190, Left = 20, Width = 200 };

            saveButton = new Button()
            {
                Text = "Зберегти",
                Top = 230,
                Left = 20
            };
            saveButton.Click += saveButton_Click;

            loadButton = new Button()
            {
                Text = "Завантажити",
                Top = 230,
                Left = 120
            };
            loadButton.Click += loadButton_Click;

            outputBox = new TextBox()
            {
                Top = 270,
                Left = 20,
                Width = 400,
                Height = 200,
                Multiline = true
            };

            this.Controls.AddRange(new Control[]
            {
                l1, nameBox,
                l2, loginBox,
                l3, passwordBox,
                l4, ageBox,
                saveButton, loadButton,
                outputBox
            });
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            try
            {
                string name = nameBox.Text.Trim();
                string login = loginBox.Text.Trim();
                string password = passwordBox.Text.Trim();
                string ageText = ageBox.Text.Trim();

                if (name == "")
                {
                    MessageBox.Show("Ім'я не може бути порожнім");
                    return;
                }

                if (login.Length < 5)
                {
                    MessageBox.Show("Логін має містити мінімум 5 символів");
                    return;
                }

                if (!Regex.IsMatch(password, @"[A-Z]") || !Regex.IsMatch(password, @"[0-9]"))
                {
                    MessageBox.Show("Пароль має містити велику літеру і цифру");
                    return;
                }

                int age;

                try
                {
                    age = int.Parse(ageText);
                }
                catch
                {
                    MessageBox.Show("Вік має бути числом");
                    return;
                }

                if (age < 10)
                {
                    MessageBox.Show("Вік має бути не менше 10");
                    return;
                }

                string user =
                    "Ім'я: " + name + Environment.NewLine +
                    "Логін: " + login + Environment.NewLine +
                    "Пароль: " + password + Environment.NewLine +
                    "Вік: " + age + Environment.NewLine +
                    "------------------------";

                File.AppendAllText("users.txt", user + Environment.NewLine);

                MessageBox.Show("Користувача збережено!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!File.Exists("users.txt"))
                {
                    MessageBox.Show("Файл ще порожній");
                    return;
                }

                outputBox.Text = File.ReadAllText("users.txt");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }
    }
}