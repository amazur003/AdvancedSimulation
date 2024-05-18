using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AdvancedSimulation
{
    public partial class Form1 : Form
    {
        private Cell[,] cells;  // Deklaracja tablicy komórek
        private int rows = 80;
        private int cols = 80;
        private Timer timer;
        private int cellSize = 10;
        private Stopwatch stopwatch = new Stopwatch();  // Tylko jedna deklaracja

        public Form1()
        {
            InitializeComponent(); // Inicjalizacja kontrolek formularza, w tym timer
            trackBarTimerInterval.Minimum = 10;
            trackBarTimerInterval.Maximum = 1000;
            timer = new Timer();
            int initialInterval = 100;
            timer.Interval = initialInterval;  // Milisekundy
            timer.Tick += Timer_Tick;

            // Ustawienia dla TrackBar
            trackBarTimerInterval.Value = initialInterval;
            labelTimerInterval.Text = $"Interwał timera: {timer.Interval} ms";

            // Przypisanie obsługi zdarzeń do przycisków
            btnStart.Click += btnStart_Click;
            btnStop.Click += btnStop_Click;
            btnReset.Click += btnReset_Click;
            btnSave.Click += btnSave_Click;
            btnLoad.Click += btnLoad_Click;

            cells = new Cell[rows, cols];  // Inicjalizacja tablicy komórek
            pictureBox1.Paint += PictureBox1_Paint;
            comboBoxColorScheme.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxColorScheme.DrawMode = DrawMode.OwnerDrawFixed;
            comboBoxColorScheme.DrawItem += comboBoxColorScheme_DrawItem;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            InitializeGame();
            timer.Start();
            stopwatch.Restart();  // Rozpoczyna lub resetuje i rozpoczyna pomiar czasu
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
            stopwatch.Stop();  // Zatrzymuje pomiar czasu
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            timer.Stop(); // Zatrzymuje timer symulacji
            stopwatch.Reset(); // Resetuje i zatrzymuje Stopwatch
            ClearCells(); // Czyści stan gry
            pictureBox1.Invalidate(); // Odświeża PictureBox, aby pokazać czysty stan
            UpdateTimerLabel(); // Resetuje tekst etykiety z czasem, jeśli istnieje
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                {
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            // Zapisuje '1' dla żywych komórek i '0' dla martwych
                            sw.Write(cells[i, j].IsAlive ? '1' : '0');
                        }
                        sw.WriteLine(); // Nowa linia dla każdego wiersza
                    }
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                {
                    int y = 0;
                    while (!sr.EndOfStream && y < rows)
                    {
                        string line = sr.ReadLine();
                        for (int x = 0; x < Math.Min(line.Length, cols); x++)
                        {
                            cells[y, x] = new Cell(line[x] == '1');
                        }
                        y++;
                    }
                }
                pictureBox1.Invalidate(); // Odświeża PictureBox po wczytaniu nowego stanu
            }
        }

        private void InitializeGame()
        {
            Random rand = new Random();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    // Zmniejsz prawdopodobieństwo, że komórka będzie żywa
                    cells[i, j] = new Cell(rand.Next(10) == 0); // 10% szansa, że komórka będzie żywa
                }
            }
            pictureBox1.Invalidate();  // Wymuszenie odświeżenia na początku
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Cell[,] newCells = new Cell[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    int aliveNeighbors = CountAliveNeighbors(i, j);
                    bool isAlive = cells[i, j].IsAlive;

                    // Klasyczne reguły gry w życie Conwaya
                    bool survives = isAlive && (aliveNeighbors == 2 || aliveNeighbors == 3);
                    bool born = !isAlive && (aliveNeighbors == 3);

                    newCells[i, j] = new Cell(survives || born);

                    if (survives || born)
                    {
                        newCells[i, j].Age = cells[i, j].Age + 1;  // Zwiększ wiek, jeśli komórka przeżywa
                    }
                    else
                    {
                        newCells[i, j].Age = 0;  // Resetuj wiek
                    }
                }
            }

            cells = newCells;
            pictureBox1.Invalidate();
            UpdateTimerLabel();
        }

        private int CountAliveNeighbors(int x, int y)
        {
            int count = 0;
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if (i == 0 && j == 0) continue;

                    int nx = x + i;
                    int ny = y + j;

                    if (nx >= 0 && ny >= 0 && nx < rows && ny < cols && cells[nx, ny].IsAlive)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Cell cell = cells[i, j];
                    Color color = GetColorForCell(cell);
                    Brush brush = new SolidBrush(color);

                    g.FillRectangle(brush, j * cellSize, i * cellSize, cellSize, cellSize);
                    g.DrawRectangle(Pens.Black, j * cellSize, i * cellSize, cellSize, cellSize);
                }
            }
        }

        private void ClearCells()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    cells[i, j] = new Cell(false, 0);  // Resetuje komórki
                }
            }
        }

        public class Cell
        {
            public bool IsAlive { get; set; }
            public int Age { get; set; }

            public Cell(bool isAlive, int age = 0)
            {
                IsAlive = isAlive;
                Age = age;
            }
        }


        private Color GetColorForCell(Cell cell)
        {
            if (cell == null || !cell.IsAlive)
                return Color.White;

            int ageFactor = Math.Min(255, cell.Age * 10);

            string colorScheme = comboBoxColorScheme?.SelectedItem?.ToString() ?? "Standardowy"; // Ustawienie wartości domyślnej

            switch (colorScheme)
            {
                case "Standardowy":
                    return Color.FromArgb(255, 0, ageFactor, 0);
                case "Pastelowy":
                    return Color.FromArgb(255, Math.Min(255, ageFactor + 80), Math.Min(255, ageFactor + 160), 200);
                case "Nocny":
                    return Color.FromArgb(255, 0, 0, ageFactor);
                default:
                    return Color.FromArgb(255, 0, ageFactor, 0);
            }
        }
        private void UpdateTimerLabel()
        {
            if (lblTimer != null)
                lblTimer.Text = $"Czas trwania: {stopwatch.ElapsedMilliseconds} ms";
        }
        private void trackBarTimerInterval_ValueChanged(object sender, EventArgs e)
        {
            timer.Interval = trackBarTimerInterval.Value;
            labelTimerInterval.Text = $"Interwał timera: {timer.Interval} ms";
        }
        private void comboBoxColorScheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxColorScheme.SelectedItem.ToString())
            {
                case "Standardowy":
                    // Ustaw standardowe kolory
                    break;
                case "Pastelowy":
                    // Ustaw pastelowe kolory
                    break;
                case "Nocny":
                    // Ustaw nocne kolory
                    break;
            }
            pictureBox1.Invalidate(); // Przemaluj planszę z nowymi kolorami
        }

        private void comboBoxColorScheme_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            // Pobierz element do narysowania
            string text = comboBoxColorScheme.Items[e.Index].ToString();

            // Rysowanie tła
            e.DrawBackground();

            // Ustawienie kolorów tekstu
            Brush brush = ((e.State & DrawItemState.Selected) == DrawItemState.Selected) ?
                          new SolidBrush(SystemColors.HighlightText) : new SolidBrush(e.ForeColor);

            // Rysowanie tekstu
            e.Graphics.DrawString(text, e.Font, brush, e.Bounds, StringFormat.GenericDefault);

            // Rysowanie ramki dla aktywnego elementu
            e.DrawFocusRectangle();
        }

        private void trackBarTimerInterval_Scroll(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
    }
}
