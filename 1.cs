using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        Button runButton;
        Button[] cells = new Button[9];
        string currentPlayer = "X";
        TextBox textBox;
        Button openFileBtn;
        Button saveFileBtn;

        public Form1()
        {
            InitializeComponent();
            this.Width = 600;
            this.Height = 500;

            CreateRunawayButton();
            CreateTicTacToe();
            CreateTextEditor();
        }
        void CreateRunawayButton()
        {
            runButton = new Button();
            runButton.Text = "Злови мене 😄";
            runButton.Location = new Point(50, 20);

            runButton.MouseEnter += (s, e) =>
            {
                Random rnd = new Random();
                int x = rnd.Next(this.ClientSize.Width - runButton.Width);
                int y = rnd.Next(this.ClientSize.Height - runButton.Height);

                runButton.Location = new Point(x, y);
            };

            this.Controls.Add(runButton);
        }
        void CreateTicTacToe()
        {
            int startX = 50;
            int startY = 80;

            for (int i = 0; i < 9; i++)
            {
                Button btn = new Button();
                btn.Size = new Size(60, 60);
                btn.Location = new Point(startX + (i % 3) * 65, startY + (i / 3) * 65);
                btn.Font = new Font("Arial", 16);

                btn.Click += (s, e) =>
                {
                    if (btn.Text == "")
                    {
                        btn.Text = currentPlayer;
                        currentPlayer = currentPlayer == "X" ? "O" : "X";
                    }
                };

                cells[i] = btn;
                this.Controls.Add(btn);
            }
        }
        void CreateTextEditor()
        {
            openFileBtn = new Button();
            openFileBtn.Text = "Відкрити файл";
            openFileBtn.Location = new Point(300, 80);
            openFileBtn.Click += OpenFile;

            saveFileBtn = new Button();
            saveFileBtn.Text = "Зберегти файл";
            saveFileBtn.Location = new Point(300, 120);
            saveFileBtn.Click += SaveFile;

            textBox = new TextBox();
            textBox.Multiline = true;
            textBox.Size = new Size(200, 150);
            textBox.Location = new Point(300, 160);

            this.Controls.Add(openFileBtn);
            this.Controls.Add(saveFileBtn);
            this.Controls.Add(textBox);
        }

        void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox.Text = File.ReadAllText(dialog.FileName);
            }
        }

        void SaveFile(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(dialog.FileName, textBox.Text);
            }
        }
    }
}
