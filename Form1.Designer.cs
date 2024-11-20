using System.Drawing;
using System.Windows.Forms;

namespace ComputerGraphics_Filters
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.file_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.open_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAs_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edit_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undo_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repeat_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

            this.filters_lr5_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invert_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayScale_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.binarization_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.increaseBrightness_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.decreaseBrightness_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contrast_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

            this.filters_lr6_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noiseDots_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noiseGauss_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noiseLines_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noiseCircles_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.box_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gaussian_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sharpness_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.waves_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

            this.filters_lr7_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neighbor_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bilinear_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.cancel_button = new System.Windows.Forms.Button();
            this.amountTextBox = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.file_ToolStripMenuItem,
            this.edit_ToolStripMenuItem,
            this.filters_lr5_ToolStripMenuItem,
            this.filters_lr6_ToolStripMenuItem,
            this.filters_lr7_ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(582, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // file_ToolStripMenuItem
            // 
            this.file_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.open_ToolStripMenuItem,
            this.saveAs_ToolStripMenuItem});
            this.file_ToolStripMenuItem.Name = "file_ToolStripMenuItem";
            this.file_ToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.file_ToolStripMenuItem.Text = "Файл";
            // 
            // open_ToolStripMenuItem
            // 
            this.open_ToolStripMenuItem.Name = "open_ToolStripMenuItem";
            this.open_ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.open_ToolStripMenuItem.Size = new System.Drawing.Size(251, 26);
            this.open_ToolStripMenuItem.Text = "Открыть";
            this.open_ToolStripMenuItem.Click += new System.EventHandler(this.Open_ToolStripMenuItem_Click);
            // 
            // saveAs_ToolStripMenuItem
            // 
            this.saveAs_ToolStripMenuItem.Name = "saveAs_ToolStripMenuItem";
            this.saveAs_ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveAs_ToolStripMenuItem.Size = new System.Drawing.Size(251, 26);
            this.saveAs_ToolStripMenuItem.Text = "Сохранить как...";
            this.saveAs_ToolStripMenuItem.Click += new System.EventHandler(this.Save_as_ToolStripMenuItem_Click);
            // 
            // edit_ToolStripMenuItem
            // 
            this.edit_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undo_ToolStripMenuItem,
            this.repeat_ToolStripMenuItem});
            this.edit_ToolStripMenuItem.Name = "edit_ToolStripMenuItem";
            this.edit_ToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.edit_ToolStripMenuItem.Text = "Правка";
            // 
            // undo_ToolStripMenuItem
            // 
            this.undo_ToolStripMenuItem.Name = "undo_ToolStripMenuItem";
            this.undo_ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undo_ToolStripMenuItem.Size = new System.Drawing.Size(352, 26);
            this.undo_ToolStripMenuItem.Text = "Отменить";
            this.undo_ToolStripMenuItem.Click += new System.EventHandler(this.Undo_ToolStripMenuItem_Click);
            // 
            // repeat_ToolStripMenuItem
            // 
            this.repeat_ToolStripMenuItem.Name = "repeat_ToolStripMenuItem";
            this.repeat_ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.repeat_ToolStripMenuItem.Size = new System.Drawing.Size(352, 26);
            this.repeat_ToolStripMenuItem.Text = "Повторить последний фильтр";
            this.repeat_ToolStripMenuItem.Click += new System.EventHandler(this.Repeat_ToolStripMenuItem_Click);
            // 
            // filters_lr5_ToolStripMenuItem
            // 
            this.filters_lr5_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.invert_ToolStripMenuItem,
            this.grayScale_ToolStripMenuItem,
            this.binarization_ToolStripMenuItem,
            this.increaseBrightness_ToolStripMenuItem,
            this.decreaseBrightness_ToolStripMenuItem,
            this.contrast_ToolStripMenuItem});
            this.filters_lr5_ToolStripMenuItem.Name = "filters_lr5_ToolStripMenuItem";
            this.filters_lr5_ToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.filters_lr5_ToolStripMenuItem.Text = "Фильтры ЛР5";
            // 
            // invert_ToolStripMenuItem
            // 
            this.invert_ToolStripMenuItem.Name = "invert_ToolStripMenuItem";
            this.invert_ToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.invert_ToolStripMenuItem.Text = "Негатив";
            this.invert_ToolStripMenuItem.Click += new System.EventHandler(this.Inverse_ToolStripMenuItem_Click);
            // 
            // grayScale_ToolStripMenuItem
            // 
            this.grayScale_ToolStripMenuItem.Name = "grayScale_ToolStripMenuItem";
            this.grayScale_ToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.grayScale_ToolStripMenuItem.Text = "Оттенки серого";
            this.grayScale_ToolStripMenuItem.Click += new System.EventHandler(this.GrayScale_ToolStripMenuItem_Click);
            // 
            // binarization_ToolStripMenuItem
            // 
            this.binarization_ToolStripMenuItem.Name = "binarization_ToolStripMenuItem";
            this.binarization_ToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.binarization_ToolStripMenuItem.Text = "Бинаризация";
            this.binarization_ToolStripMenuItem.Click += new System.EventHandler(this.Binarization_ToolStripMenuItem_Click);
            // 
            // increaseBrightness_ToolStripMenuItem
            // 
            this.increaseBrightness_ToolStripMenuItem.Name = "increaseBrightness_ЯркостьToolStripMenuItem";
            this.increaseBrightness_ToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.increaseBrightness_ToolStripMenuItem.Text = "Увеличить яркость";
            this.increaseBrightness_ToolStripMenuItem.Click += new System.EventHandler(this.IncreaseBrightness_ToolStripMenuItem_Click);
            // 
            // decreaseBrightness_ToolStripMenuItem
            // 
            this.decreaseBrightness_ToolStripMenuItem.Name = "decreaseBrightness_ЯркостьToolStripMenuItem";
            this.decreaseBrightness_ToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.decreaseBrightness_ToolStripMenuItem.Text = "Уменьшить яркость";
            this.decreaseBrightness_ToolStripMenuItem.Click += new System.EventHandler(this.DecreaseBrightness_ToolStripMenuItem_Click);
            // 
            // contrast_ToolStripMenuItem
            // 
            this.contrast_ToolStripMenuItem.Name = "contrast_ToolStripMenuItem";
            this.contrast_ToolStripMenuItem.Size = new System.Drawing.Size(347, 26);
            this.contrast_ToolStripMenuItem.Text = "Изменить контрастность";
            this.contrast_ToolStripMenuItem.Click += new System.EventHandler(this.Contrast_ToolStripMenuItem_Click);
            // 
            // filters_lr6_ToolStripMenuItem
            // 
            this.filters_lr6_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noiseDots_ToolStripMenuItem,
            this.noiseGauss_ToolStripMenuItem,
            this.noiseLines_ToolStripMenuItem,
            this.noiseCircles_ToolStripMenuItem,
            this.box_ToolStripMenuItem,
            this.gaussian_ToolStripMenuItem,
            this.waves_ToolStripMenuItem,
            this.sharpness_ToolStripMenuItem});
            this.filters_lr6_ToolStripMenuItem.Name = "filters_lr6_ToolStripMenuItem";
            this.filters_lr6_ToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.filters_lr6_ToolStripMenuItem.Text = "Фильтры ЛР6";
            // 
            // noiseDots_ToolStripMenuItem
            // 
            this.noiseDots_ToolStripMenuItem.Name = "noiseDots_ToolStripMenuItem";
            this.noiseDots_ToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.noiseDots_ToolStripMenuItem.Text = "Шум \"точки\"";
            this.noiseDots_ToolStripMenuItem.Click += new System.EventHandler(this.NoiseDots_ToolStripMenuItem_Click);
            // 
            // noiseGauss_ToolStripMenuItem
            // 
            this.noiseGauss_ToolStripMenuItem.Name = "noiseGauss_ToolStripMenuItem";
            this.noiseGauss_ToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.noiseGauss_ToolStripMenuItem.Text = "Гауссов шум";
            this.noiseGauss_ToolStripMenuItem.Click += new System.EventHandler(this.NoiseGauss_ToolStripMenuItem_Click);
            // 
            // noiseLines_ToolStripMenuItem
            // 
            this.noiseLines_ToolStripMenuItem.Name = "noiseLines_ToolStripMenuItem";
            this.noiseLines_ToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.noiseLines_ToolStripMenuItem.Text = "Шум \"линии\"";
            this.noiseLines_ToolStripMenuItem.Click += new System.EventHandler(this.NoiseLines_ToolStripMenuItem_Click);
            // 
            // noiseCircles_ToolStripMenuItem
            // 
            this.noiseCircles_ToolStripMenuItem.Name = "noiseCircles_ToolStripMenuItem";
            this.noiseCircles_ToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.noiseCircles_ToolStripMenuItem.Text = "Шум \"окружности\"";
            this.noiseCircles_ToolStripMenuItem.Click += new System.EventHandler(this.NoiseCircles_ToolStripMenuItem_Click);
            // 
            // box_ToolStripMenuItem
            // 
            this.box_ToolStripMenuItem.Name = "box_ToolStripMenuItem";
            this.box_ToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.box_ToolStripMenuItem.Text = "Равномерное шумоподавление";
            this.box_ToolStripMenuItem.Click += new System.EventHandler(this.Box_ToolStripMenuItem_Click);
            // 
            // gaussian_ToolStripMenuItem
            // 
            this.gaussian_ToolStripMenuItem.Name = "gaussian_ToolStripMenuItem";
            this.gaussian_ToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.gaussian_ToolStripMenuItem.Text = "Шумоподавление Гаусса";
            this.gaussian_ToolStripMenuItem.Click += new System.EventHandler(this.Gaussian_ToolStripMenuItem_Click);
            // 
            // sharpness_ToolStripMenuItem
            // 
            this.sharpness_ToolStripMenuItem.Name = "sharpness_ToolStripMenuItem";
            this.sharpness_ToolStripMenuItem.Size = new System.Drawing.Size(160, 26);
            this.sharpness_ToolStripMenuItem.Text = "Резкость";
            this.sharpness_ToolStripMenuItem.Click += new System.EventHandler(this.Sharpness_ToolStripMenuItem_Click);
            // 
            // waves_ToolStripMenuItem
            // 
            this.waves_ToolStripMenuItem.Name = "waves_ToolStripMenuItem";
            this.waves_ToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.waves_ToolStripMenuItem.Text = "Эффект \"волны\"";
            this.waves_ToolStripMenuItem.Click += new System.EventHandler(this.Waves_ToolStripMenuItem_Click);
            // 
            // filters_lr7_ToolStripMenuItem
            // 
            this.filters_lr7_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neighbor_ToolStripMenuItem,
            this.bilinear_ToolStripMenuItem});
            this.filters_lr7_ToolStripMenuItem.Name = "filters_lr7_ToolStripMenuItem";
            this.filters_lr7_ToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.filters_lr7_ToolStripMenuItem.Text = "Фильтры ЛР7";
            // 
            // neighbour_ToolStripMenuItem
            // 
            this.neighbor_ToolStripMenuItem.Name = "neighbour_ToolStripMenuItem";
            this.neighbor_ToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.neighbor_ToolStripMenuItem.Text = "Сглаживание методом \"Ближайших соседей\"";
            this.neighbor_ToolStripMenuItem.Click += new System.EventHandler(this.Neighbor_ToolStripMenuItem_Click);
            // 
            // bilinear_ToolStripMenuItem
            // 
            this.bilinear_ToolStripMenuItem.Name = "bilinear_ToolStripMenuItem";
            this.bilinear_ToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.bilinear_ToolStripMenuItem.Text = "Билинейное сглаживание";
            this.bilinear_ToolStripMenuItem.Click += new System.EventHandler(this.Bilinear_ToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Image files | *.png; *.jpg; *.bmp; | All files(*.*) | *.*";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.tableLayoutPanel1.SetColumnSpan(this.pictureBox1, 2);
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0, 0, 10, 0); // Отступ справа 20 пикселей
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(582, 375);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.tableLayoutPanel1.SetColumnSpan(this.pictureBox1, 2);
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(1, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(10, 0, 20, 0); // Отступ слева 20 пикселей
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(582, 375);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(10, 385);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(10);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(412, 30);
            this.progressBar1.TabIndex = 2;
            // 
            // cancel_button
            // 
            this.cancel_button.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cancel_button.Location = new System.Drawing.Point(442, 385);
            this.cancel_button.Margin = new System.Windows.Forms.Padding(10);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(130, 30);
            this.cancel_button.TabIndex = 3;
            this.cancel_button.Text = "Отмена";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.Cancel_button_Click);
            // 
            // Label1
            // 
            this.Label1.Location = new Point(this.ClientSize.Width - this.Label1.Width - 10, 115); // Отступ 10 пикселей от правого края
            this.Label1.Anchor = AnchorStyles.Right; // Фиксируем положение относительно правого края
            this.Label1.AutoSize = true;
            this.Label1.Name = "label1";
            this.Label1.Size = new System.Drawing.Size(99, 16);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Параметры преобразований: ";
            // 
            // amountTextBox
            // 
            this.amountTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
           | System.Windows.Forms.AnchorStyles.Left)
           | System.Windows.Forms.AnchorStyles.Right)));
            this.amountTextBox.Location = new System.Drawing.Point(542, 385);
            this.amountTextBox.Margin = new System.Windows.Forms.Padding(10);
            this.amountTextBox.Name = "amountTextBox";
            this.amountTextBox.Size = new System.Drawing.Size(130, 30);
            this.amountTextBox.TabIndex = 4;
            this.amountTextBox.Text = "50";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorker1_RunWorkerCompleted);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));

            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));

            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.pictureBox2, 1, 0);

            this.tableLayoutPanel1.Controls.Add(this.progressBar1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cancel_button, 1, 1);

            this.tableLayoutPanel1.Controls.Add(this.Label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.amountTextBox, 1, 2);

            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";

            this.tableLayoutPanel1.Size = new System.Drawing.Size(582, 425);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileName = "filename.png";
            this.saveFileDialog1.Filter = "Image files | *.png; *.jpg; *.bmp; | All files(*.*) | *.*";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2800, 1200);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(600, 500);
            this.Name = "Form1";
            this.Text = "Обработка изображений";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem file_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filters_lr5_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invert_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grayScale_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem binarization_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem increaseBrightness_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem decreaseBrightness_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contrast_ToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem filters_lr6_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem box_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gaussian_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem waves_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sharpness_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noiseDots_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noiseGauss_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noiseLines_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noiseCircles_ToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem filters_lr7_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem neighbor_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bilinear_ToolStripMenuItem;

        private System.Windows.Forms.ToolStripMenuItem open_ToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.TextBox amountTextBox;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripMenuItem saveAs_ToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem edit_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undo_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem repeat_ToolStripMenuItem;
    }
}

