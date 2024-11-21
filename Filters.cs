using System;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;

namespace ComputerGraphics_Filters
{
    public abstract class Filter
    {
        protected abstract Color calculateNewPixelColor(Bitmap sourceImage, int x, int y);

        public virtual Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker,int MaxPercent = 100, int add = 0)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress((int)((double)i / resultImage.Width * MaxPercent) + add);
                if (worker.CancellationPending)
                    return null;
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
            }

            return resultImage;
        }

        protected int Clamp(int value, int min, int max)
        {
            if (value < min)
                return min;
            if (value > max)
                return max;
            return value;
        }
    }

    public class InvertFilter : Filter
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            return Color.FromArgb(255 - sourceColor.R, 255 - sourceColor.G, 255 - sourceColor.B);
        }
    }

    public class GrayScaleFilter : Filter
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            int Intensity = (int)(0.299 * sourceColor.R + 0.5876 * sourceColor.G + 0.114 * sourceColor.B);
            return Color.FromArgb(Intensity, Intensity, Intensity);
        }
    }

    public class BinarizationFilter : Filter
    {
        private int threshold; // Пороговое значение для бинаризации

        public BinarizationFilter(int threshold)
        {
            this.threshold = threshold; // Убедимся, что порог в пределах [0, 255]
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);

            // Рассчитываем интенсивность (яркость) пикселя
            int intensity = (int)(0.299 * sourceColor.R + 0.5876 * sourceColor.G + 0.114 * sourceColor.B);

            // Определяем, чёрный или белый пиксель
            int binaryColor = 0;
            if (intensity >= threshold)
            {
                binaryColor = 255;
            }

            // Возвращаем результат как чёрно-белый пиксель
            return Color.FromArgb(binaryColor, binaryColor, binaryColor);
        }
    }

    public class BrightnessFilter : Filter
    {
        private int amount;

        public BrightnessFilter(int amount)
        {
            this.amount = amount;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color sourceColor = sourceImage.GetPixel(x, y);
            return Color.FromArgb(Clamp(sourceColor.R + amount, 0, 255),
                Clamp(sourceColor.G + amount, 0, 255),
                Clamp(sourceColor.B + amount, 0, 255));
        }
    }

    public class ContrastFilter : GlobalFilter
    {
        protected int brightness = 0;

        private double amount;

        public ContrastFilter(double amount)
        {
            this.amount = amount;
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker, int MaxPercent = 100, int add = 0)
        {
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height);

            brightness = GetBrightness(sourceImage, worker, 50);

            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress((int)((double)i / resultImage.Width * 50) + 50);
                if (worker.CancellationPending)
                    return null;
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    resultImage.SetPixel(i, j, calculateNewPixelColor(sourceImage, i, j));
                }
            }

            return resultImage;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            double c = amount;
            Color sourceColor = sourceImage.GetPixel(x, y);
            return Color.FromArgb(Clamp((int)(brightness + (sourceColor.R - brightness) * c), 0, 255),
                                  Clamp((int)(brightness + (sourceColor.G - brightness) * c), 0, 255),
                                  Clamp((int)(brightness + (sourceColor.B - brightness) * c), 0, 255));
        }
    }

    public abstract class GlobalFilter : Filter
    {
        /// <summary>
        /// Возвращает среднюю яркость по всем каналам
        /// </summary>
        public int GetBrightness(Bitmap sourceImage, BackgroundWorker worker, int MaxPercent = 100)
        {
            long brightness = 0;
            for (int i = 0; i < sourceImage.Width; i++)
            {
                worker.ReportProgress((int)((double)i / sourceImage.Width * MaxPercent));
                if (worker.CancellationPending)
                    return 0;
                for (int j = 0; j < sourceImage.Height; j++)
                {
                    long pix = 0;
                    Color color = sourceImage.GetPixel(i, j);
                    pix += color.R;
                    pix += color.G;
                    pix += color.B;
                    pix /= 3;
                    brightness += pix;
                }
            }
            brightness /= sourceImage.Width * sourceImage.Height;
            return (int)brightness;
        }
    }

    public class MatrixFilter : Filter
    {
        protected double[,] kernel = null;

        protected MatrixFilter() { }
        public MatrixFilter(double[,] kernel)
        {
            this.kernel = kernel;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int radiusX = kernel.GetLength(0) / 2;
            int radiusY = kernel.GetLength(1) / 2;

            double resultR = 0;
            double resultG = 0;
            double resultB = 0;

            for (int l = -radiusX; l <= radiusX; l++)
            {
                for (int k = -radiusY; k <= radiusY; k++)
                {
                    int idX = Clamp(x + k, 0, sourceImage.Width - 1);
                    int idY = Clamp(y + l, 0, sourceImage.Height - 1);
                    Color neighbourColor = sourceImage.GetPixel(idX, idY);
                    resultR += neighbourColor.R * kernel[k + radiusX, l + radiusY];
                    resultG += neighbourColor.G * kernel[k + radiusX, l + radiusY];
                    resultB += neighbourColor.B * kernel[k + radiusX, l + radiusY];
                }
            }

            return Color.FromArgb(
                Clamp((int)resultR, 0, 255),
                Clamp((int)resultG, 0, 255),
                Clamp((int)resultB, 0, 255)
            );
        }
    }

    public class BoxFilter : MatrixFilter
    {
        public BoxFilter(int aperture)
        {
            // Инициализируем ядро с пользовательскими размерами
            kernel = new double[aperture, aperture];

            // Заполняем ядро равномерными коэффициентами
            double value = 1.0 / (aperture * aperture); // Усреднение
            for (int i = 0; i < aperture; i++)
                for (int j = 0; j < aperture; j++)
                    kernel[i, j] = value;
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker, int MaxPercent = 100, int add = 0)
        {
            Bitmap resultImage = new Bitmap(sourceImage); // Копия исходного изображения

            // Проходим по всему изображению
            for (int x = 0; x < sourceImage.Width; x++)
            {
                // Отчет о прогрессе обработки
                worker.ReportProgress((int)((double)x / sourceImage.Width * MaxPercent) + add);
                if (worker.CancellationPending) // Проверяем, не отменена ли задача
                    return null;

                for (int y = 0; y < sourceImage.Height; y++)
                {
                    // Вычисляем новый цвет пикселя с помощью ядра фильтра
                    resultImage.SetPixel(x, y, calculateNewPixelColor(sourceImage, x, y));
                }
            }

            return resultImage; // Возвращаем обработанное изображение
        }
    }

    public class GaussianFilter : MatrixFilter
    {
        public GaussianFilter(int radius)
        {
            double sigma = radius/3;

            int size = radius * 2 + 1; // Размер ядра
            kernel = new double[size, size];
            double norm = 0;

            // Заполняем ядро значениями гауссовой функции
            for (int i = -radius; i <= radius; i++)
            {
                for (int j = -radius; j <= radius; j++)
                {
                    kernel[i + radius, j + radius] = Math.Exp(-(i * i + j * j) / (2 * sigma * sigma));
                    norm += kernel[i + radius, j + radius];
                }
            }

            // Нормализация ядра
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    kernel[i, j] /= norm;
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker, int MaxPercent = 100, int add = 0)
        {
            Bitmap resultImage = new Bitmap(sourceImage);

            for (int x = 0; x < sourceImage.Width; x++)
            {
                worker.ReportProgress((int)((double)x / sourceImage.Width * MaxPercent) + add);
                if (worker.CancellationPending)
                    return null;

                for (int y = 0; y < sourceImage.Height; y++)
                {
                    resultImage.SetPixel(x, y, calculateNewPixelColor(sourceImage, x, y));
                }
            }

            return resultImage;
        }
    }

    public class SharpnessFilter : MatrixFilter
    {
        public SharpnessFilter(int k)
        {
            kernel = new double[3, 3] {
                { -k/8, -k/8, -k/8 },
                { -k/8, 1+k, -k/8 },
                { -k/8, -k/8, -k/8 } };
        }
    }

    public class WavesFilter : Filter
    {
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            int new_x = x + (int)(20 * Math.Sin(2 * Math.PI * y / 30));
            int new_y = y;
            new_x = Clamp(new_x, 0, sourceImage.Width - 1);
            new_y = Clamp(new_y, 0, sourceImage.Height - 1);
            return sourceImage.GetPixel(new_x, new_y);
        }
    }

    public class NoiseDotsFilter : Filter
    {
        protected readonly Random random = new Random();
        protected double p_white; // Вероятность белых точек
        protected double p_black; // Вероятность черных точек

        public NoiseDotsFilter(double pWhite = 0.005, double pBlack = 0.005)
        {
            p_white = pWhite;
            p_black = pBlack;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            double p = random.NextDouble(); // Случайное число от 0 до 1
            if (p < p_white)
                return Color.White; // Белый шум
            else if (p + p_black > 1)
                return Color.Black; // Черный шум
            else
                return sourceImage.GetPixel(x, y); // Оригинальный пиксель
        }
    }

    public class NoiseGaussianFilter : Filter
    {
        private readonly Random random = new Random();
        private readonly double mean;    // Среднее значение (μ)
        private readonly double stdDev; // Стандартное отклонение (σ)

        public NoiseGaussianFilter(double mean = 0, double stdDev = 10)
        {
            this.mean = mean;
            this.stdDev = stdDev;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            Color color = sourceImage.GetPixel(x, y);

            // Генерация случайного значения с нормальным распределением (Box-Muller Transform)
            double noise = mean + stdDev * Math.Sqrt(-2.0 * Math.Log(random.NextDouble())) * Math.Cos(2.0 * Math.PI * random.NextDouble());

            // Добавляем шум к каждому каналу
            int r = Clamp((int)(color.R + noise), 0, 255);
            int g = Clamp((int)(color.G + noise), 0, 255);
            int b = Clamp((int)(color.B + noise), 0, 255);

            return Color.FromArgb(r, g, b);
        }
    }

    public class NoiseLinesFilter : Filter
    {
        protected readonly Random random = new Random();
        protected int numberOfLines; // Количество линий

        public NoiseLinesFilter(int numberOfLines = 1000, int maxLength = 40)
        {
            this.numberOfLines = numberOfLines;
            this.maxLength = maxLength;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            // Вернем оригинальный цвет, линии обрабатываются в процессе
            return sourceImage.GetPixel(x, y);
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker, int MaxPercent = 100, int add = 0)
        {
            Bitmap resultImage = new Bitmap(sourceImage);

            for (int i = 0; i < numberOfLines; i++)
            {

                    // Случайная начальная точка
                    int startX = random.Next(0, sourceImage.Width);
                    int startY = random.Next(0, sourceImage.Height);

                    // Случайный угол и длина
                    double angle = random.NextDouble() * 2 * Math.PI; // Угол в радианах
                    int length = random.Next(10, maxLength);

                    // Случайный цвет линии
                    bool isBlack = random.Next(2) == 0;
                    Color lineColor = isBlack ? Color.Black : Color.White;

                    // Рисуем линию
                    DrawLine(resultImage, startX, startY, angle, length, lineColor);

            }

            return resultImage;
        }

        private void DrawLine(Bitmap image, int startX, int startY, double angle, int length, Color color)
        {
            for (int i = 0; i < length; i++)
            {
                // Вычисляем координаты следующего пикселя вдоль линии
                int x = startX + (int)(i * Math.Cos(angle));
                int y = startY + (int)(i * Math.Sin(angle));

                // Проверяем, находится ли пиксель в границах изображения
                if (x >= 0 && x < image.Width && y >= 0 && y < image.Height)
                {
                    image.SetPixel(x, y, color);
                }
                else
                {
                    break; // Выходим, если линия выходит за границы изображения
                }
            }
        }

        private int maxLength;
    }

    public class NoiseCirclesFilter : Filter
    {
        protected readonly Random random = new Random();
        private readonly int numberOfCircles; // Количество окружностей
        private readonly int maxRadius;      // Максимальный радиус окружности
        private readonly double p_white;     // Вероятность белой окружности
        private readonly double p_black;     // Вероятность черной окружности

        public NoiseCirclesFilter(int numberOfCircles = 600, int maxRadius = 30, double pWhite = 0.5, double pBlack = 0.5)
        {
            this.numberOfCircles = numberOfCircles;
            this.maxRadius = maxRadius;
            this.p_white = pWhite;
            this.p_black = pBlack;
        }

        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            // Окружности рисуются в процессе обработки изображения
            return sourceImage.GetPixel(x, y);
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker, int MaxPercent = 100, int add = 0)
        {
            Bitmap resultImage = new Bitmap(sourceImage);

            for (int i = 0; i < numberOfCircles; i++)
            {
                // Случайные параметры окружности
                int centerX = random.Next(0, sourceImage.Width);   // Координата центра
                int centerY = random.Next(0, sourceImage.Height);  // Координата центра
                int radius = random.Next(5, maxRadius);           // Радиус окружности

                // Случайный цвет
                Color circleColor = random.NextDouble() < p_white
                    ? Color.White
                    : random.NextDouble() < p_black ? Color.Black : Color.Transparent;

                if (circleColor != Color.Transparent)
                {
                    DrawCircle(resultImage, centerX, centerY, radius, circleColor);
                }
            }

            return resultImage;
        }

        private void DrawCircle(Bitmap image, int centerX, int centerY, int radius, Color color)
        {
            for (int angle = 0; angle < 360; angle++)
            {
                // Вычисляем координаты точки на окружности
                int x = centerX + (int)(radius * Math.Cos(angle * Math.PI / 180.0));
                int y = centerY + (int)(radius * Math.Sin(angle * Math.PI / 180.0));

                // Проверяем границы изображения
                if (x >= 0 && x < image.Width && y >= 0 && y < image.Height)
                {
                    image.SetPixel(x, y, color);
                }
            }
        }
    }

    public class NeighborFilter : Filter
    {
        private readonly double scale; // Коэффициент масштабирования

        public NeighborFilter(double scale)
        {

            this.scale = scale; // Устанавливаем коэффициент масштабирования
        }

        // Метод расчета нового цвета не используется в этом фильтре
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            throw new NotImplementedException();
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker, int MaxPercent = 100, int add = 0)
        {
            // Вычисляем размеры результирующего изображения
            int newWidth = (int)(sourceImage.Width * scale);
            int newHeight = (int)(sourceImage.Height * scale);

            Bitmap resultImage = new Bitmap(newWidth, newHeight); // Создаем новое изображение

            // Проходим по всем пикселям нового изображения
            for (int x = 0; x < newWidth; x++)
            {
                worker.ReportProgress((int)((double)x / newWidth * MaxPercent) + add); // Обновление прогресса
                if (worker.CancellationPending)
                    return null;

                for (int y = 0; y < newHeight; y++)
                {
                    // Находим ближайший пиксель в исходном изображении
                    int srcX = Clamp((int)(x / scale), 0, sourceImage.Width - 1);
                    int srcY = Clamp((int)(y / scale), 0, sourceImage.Height - 1);

                    // Устанавливаем цвет пикселя из исходного изображения
                    resultImage.SetPixel(x, y, sourceImage.GetPixel(srcX, srcY));
                }
            }

            return resultImage; // Возвращаем масштабированное изображение
        }
    }

    public class BilinearFilter : Filter
    {
        private readonly double scale; // Коэффициент масштабирования

        public BilinearFilter(double scale)
        {
            this.scale = scale; // Устанавливаем коэффициент масштабирования
        }

        // Метод расчета нового цвета не используется в этом фильтре
        protected override Color calculateNewPixelColor(Bitmap sourceImage, int x, int y)
        {
            throw new NotImplementedException();
        }

        public override Bitmap processImage(Bitmap sourceImage, BackgroundWorker worker, int MaxPercent = 100, int add = 0)
        {
            // Вычисляем размеры результирующего изображения
            int newWidth = (int)(sourceImage.Width * scale);
            int newHeight = (int)(sourceImage.Height * scale);

            Bitmap resultImage = new Bitmap(newWidth, newHeight); // Создаем новое изображение

            // Проходим по всем пикселям нового изображения
            for (int x = 0; x < newWidth; x++)
            {
                worker.ReportProgress((int)((double)x / newWidth * MaxPercent) + add); // Обновление прогресса
                if (worker.CancellationPending)
                    return null;

                for (int y = 0; y < newHeight; y++)
                {
                    // Преобразуем координаты в исходное изображение
                    double srcX = x / scale;
                    double srcY = y / scale;

                    // Находим координаты соседних пикселей
                    int x1 = Clamp((int)Math.Floor(srcX), 0, sourceImage.Width - 1);
                    int y1 = Clamp((int)Math.Floor(srcY), 0, sourceImage.Height - 1);
                    int x2 = Clamp(x1 + 1, 0, sourceImage.Width - 1);
                    int y2 = Clamp(y1 + 1, 0, sourceImage.Height - 1);

                    // Рассчитываем отступы для интерполяции
                    double dx = srcX - x1;
                    double dy = srcY - y1;

                    // Берем значения цветов соседних пикселей
                    Color c11 = sourceImage.GetPixel(x1, y1);
                    Color c12 = sourceImage.GetPixel(x1, y2);
                    Color c21 = sourceImage.GetPixel(x2, y1);
                    Color c22 = sourceImage.GetPixel(x2, y2);

                    // Интерполяция по оси X
                    Color c1 = InterpolateColor(c11, c21, dx);
                    Color c2 = InterpolateColor(c12, c22, dx);

                    // Интерполяция по оси Y
                    Color c = InterpolateColor(c1, c2, dy);

                    resultImage.SetPixel(x, y, c); // Устанавливаем рассчитанный цвет
                }
            }

            return resultImage; // Возвращаем масштабированное изображение
        }

        // Метод для линейной интерполяции между двумя цветами
        private Color InterpolateColor(Color c1, Color c2, double t)
        {
            int r = (int)(c1.R + t * (c2.R - c1.R));
            int g = (int)(c1.G + t * (c2.G - c1.G));
            int b = (int)(c1.B + t * (c2.B - c1.B));

            return Color.FromArgb(Clamp(r, 0, 255), Clamp(g, 0, 255), Clamp(b, 0, 255));
        }
    }
}
