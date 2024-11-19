using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComputerGraphics_Filters;
using static System.Windows.Forms.AxHost;

namespace ComputerGraphics_Filters
{
    public partial class Form1 : Form
    {
        Bitmap previous_image = null;
        Bitmap image = null;
        Filter lastFilter = null;

        public Form1()
        {
            InitializeComponent();
        }

        private int[] CalculateBrightnessHistogram(Bitmap image)
        {
            int[] histogram = new int[256]; // Массив для хранения частот яркости (от 0 до 255)

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color pixelColor = image.GetPixel(x, y);

                    // Рассчитываем интенсивность (яркость) пикселя
                    int brightness = (int)(0.299 * pixelColor.R + 0.5876 * pixelColor.G + 0.114 * pixelColor.B);

                    histogram[brightness]++; // Увеличиваем частоту соответствующей яркости
                }
            }

            return histogram;
        }

        private void DrawHistogram(int[] histogram, PictureBox pictureBox)
        {
            int width = 256 + 55; // Ширина гистограммы с учётом разметки
            int height = 540; // Полная высота для отображения гистограммы
            int paddingTop = 10; // Отступ сверху
            int paddingBottom = 10; // Отступ снизу

            Bitmap histogramBitmap = new Bitmap(width, height);
            int totalPixels = histogram.Sum(); // Общее количество пикселей

            // Преобразуем значения в проценты
            double[] percentages = histogram.Select(value => (double)value / totalPixels * 100).ToArray();

            using (Graphics g = Graphics.FromImage(histogramBitmap))
            {
                g.Clear(Color.White); // Заливаем фон белым цветом

                // Рисуем шкалу оси Y
                int numberOfTicks = 20; // Количество отметок на оси Y
                Font font = new Font("Arial", 10); // Шрифт для текста
                Brush brush = Brushes.Black;
                Pen pen = new Pen(Color.Gray, 1);
                for (int i = 0; i <= numberOfTicks; i++)
                {
                    int y = height - paddingBottom - (i * (height - paddingTop - paddingBottom) / numberOfTicks);
                    int labelValue = i * 5; // Шаг в процентах (0, 20, 40, ..., 100)

                    // Линия шкалы
                    g.DrawLine(pen, 45, y, width - 10, y);

                    // Текстовая разметка
                    g.DrawString(labelValue.ToString() + "%", font, brush, 5, y - 7);
                }

                // Рисуем столбцы гистограммы
                for (int i = 0; i < percentages.Length; i++)
                {
                    int barHeight = (int)(percentages[i] / 100 * (height - paddingTop - paddingBottom)); // Нормализуем высоту столбцов
                    int barTop = height - paddingBottom - barHeight; // Верхняя точка столбца
                    g.DrawLine(Pens.Black, i + 45, height - paddingBottom, i + 45, barTop); // Столбец от нижней границы вверх
                }
            }

            pictureBox.Image = histogramBitmap; // Отображаем гистограмму
            pictureBox.Refresh();
        }


        private void UpdateHistogram()
        {
            if (image != null)
            {
                int[] histogram = CalculateBrightnessHistogram(image); // Вычисляем гистограмму
                DrawHistogram(histogram, pictureBox2); // Отображаем её в PictureBox
            }
            else
            {
                MessageBox.Show("Сначала загрузите изображение!");
            }
        }


        // Файл открытие

        private void Open_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Выбор исходного изображения:";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                previous_image = image;
                image = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = image;
                pictureBox1.Refresh();
                UpdateHistogram(); // Обновляем гистограмму
            }
        }

        private void Save_as_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (image != null)
            {
                saveFileDialog1.Title = "Сохранение результата:";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    image.Save(saveFileDialog1.FileName);
                }
            }
            else
            {
                MessageBox.Show("Сначала загрузите изображение!");
            }
        }

        // Отмена

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        // Правка

        private void Undo_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            image = previous_image;
            pictureBox1.Image = image;
            pictureBox1.Refresh();
            UpdateHistogram(); // Обновляем гистограмму
        }

        private void Repeat_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartFilter(lastFilter);
        }

        // BackgroundWorker1

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (image != null)
            {
                Bitmap resultImage = ((Filter)e.Argument).processImage(image, backgroundWorker1);

                if (!backgroundWorker1.CancellationPending)
                {
                    previous_image = image;
                    lastFilter = (Filter)e.Argument;
                    image = resultImage;
                }
            }
            else
            {
                MessageBox.Show("Сначала загрузите изображение!");
            }
        }

        private void BackgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                pictureBox1.Image = image;
                pictureBox1.Refresh();
                UpdateHistogram(); // Обновляем гистограмму
            }
            progressBar1.Value = 0;
        }

        private void StartFilter(Filter filter)
        {
            if (backgroundWorker1.IsBusy == false)
                backgroundWorker1.RunWorkerAsync(filter);
        }

        private void Inverse_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartFilter(new InvertFilter());
        }

        private void GrayScale_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartFilter(new GrayScaleFilter());
        }
        
        private void Binarization_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int threshold = Convert.ToInt32(amountTextBox.Text); // Пороговое значение для бинаризации
            StartFilter(new BinarizationFilter(threshold));
        }

        private void IncreaseBrightness_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int amount = Convert.ToInt32(amountTextBox.Text);
            StartFilter(new BrightnessFilter(amount));
        }

        private void DecreaseBrightness_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int amount = Convert.ToInt32(amountTextBox.Text);
            StartFilter(new BrightnessFilter(-amount));
        }
        
        private void IncreaseContrast_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double amount = Convert.ToDouble(amountTextBox.Text);
            StartFilter(new ContrastFilter(amount));
        }

        private void DecreaseContrast_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           double amount = Convert.ToDouble(amountTextBox.Text);
            StartFilter(new ContrastFilter(1/amount));
        }
        private void NoiseDots_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double amount = Convert.ToDouble(amountTextBox.Text);
            StartFilter(new NoiseDotsFilter());
        }
        private void NoiseCircles_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double amount = Convert.ToDouble(amountTextBox.Text);
            StartFilter(new NoiseCirclesFilter());
        }

        private void NoiseLines_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartFilter(new NoiseLinesFilter());
        }

        private void Box_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String setting = amountTextBox.Text;
            String[] parts = setting.Split('_');
            StartFilter(new BoxFilter(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3])));
        }

        private void Gaussian_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String setting = amountTextBox.Text;
            String[] parts = setting.Split('_');
            StartFilter(new GaussianFilter(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]), int.Parse(parts[3])));
        }

        private void Waves_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartFilter(new WavesFilter());
        }

        private void Neighbor_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double scale = Convert.ToDouble(amountTextBox.Text);
            StartFilter(new NeighborFilter(scale));
        }

        private void Bilinear_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double scale = Convert.ToDouble(amountTextBox.Text);
            StartFilter(new BilinearFilter(scale));
        }
    }
}
