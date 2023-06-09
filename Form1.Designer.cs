﻿using NeuralNetworkConstructor;
namespace DiplomPrototype
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend11 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint76 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint77 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint78 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint79 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint80 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint81 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint82 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint83 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint84 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.Title title11 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend12 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint85 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint86 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint87 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint88 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint89 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint90 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 0D);
            System.Windows.Forms.DataVisualization.Charting.Title title12 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.label2 = new System.Windows.Forms.Label();
            this.Laber_NetworkAnswer = new System.Windows.Forms.Label();
            this.Button_DownloadNextDigit = new System.Windows.Forms.Button();
            this.Button_StartLearningSet = new System.Windows.Forms.Button();
            this.Label_RightAnswer = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Button_DeleteWeights = new System.Windows.Forms.Button();
            this.Button_DownloadPucture = new System.Windows.Forms.Button();
            this.Button_MatrixClear = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Chart_AccuracyGraphic = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Button_UpdateStatistic = new System.Windows.Forms.Button();
            this.Label_precitionCountToSession = new System.Windows.Forms.Label();
            this.chart_lossToEpoch = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label_epochCount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.drawSymbolsClass1 = new DrawSymbols.DrawSymbolsClass(NetworkParameters.imageRows,NetworkParameters.imageColumns,NetworkParameters.standartComponentWeight,NetworkParameters.standartComponentHeight,NetworkParameters.drawComponentWeight,NetworkParameters.drawComponentHeight);
            ((System.ComponentModel.ISupportInitialize)(this.Chart_AccuracyGraphic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_lossToEpoch)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(1464, 137);
            this.label2.MinimumSize = new System.Drawing.Size(100, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(330, 42);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ответ нейросети";
            // 
            // Laber_NetworkAnswer
            // 
            this.Laber_NetworkAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Laber_NetworkAnswer.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Laber_NetworkAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 80.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Laber_NetworkAnswer.Location = new System.Drawing.Point(1534, 193);
            this.Laber_NetworkAnswer.Name = "Laber_NetworkAnswer";
            this.Laber_NetworkAnswer.Size = new System.Drawing.Size(229, 224);
            this.Laber_NetworkAnswer.TabIndex = 4;
            this.Laber_NetworkAnswer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Button_DownloadNextDigit
            // 
            this.Button_DownloadNextDigit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_DownloadNextDigit.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Button_DownloadNextDigit.ForeColor = System.Drawing.Color.Black;
            this.Button_DownloadNextDigit.Location = new System.Drawing.Point(1468, 81);
            this.Button_DownloadNextDigit.Name = "Button_DownloadNextDigit";
            this.Button_DownloadNextDigit.Size = new System.Drawing.Size(326, 42);
            this.Button_DownloadNextDigit.TabIndex = 8;
            this.Button_DownloadNextDigit.Text = "Загрузить случайный символ";
            this.Button_DownloadNextDigit.UseVisualStyleBackColor = true;
            this.Button_DownloadNextDigit.Click += new System.EventHandler(this.Button_MakeRandomSymbolPrediction_Click);
            // 
            // Button_StartLearningSet
            // 
            this.Button_StartLearningSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Button_StartLearningSet.ForeColor = System.Drawing.Color.Black;
            this.Button_StartLearningSet.Location = new System.Drawing.Point(12, 81);
            this.Button_StartLearningSet.Name = "Button_StartLearningSet";
            this.Button_StartLearningSet.Size = new System.Drawing.Size(326, 41);
            this.Button_StartLearningSet.TabIndex = 9;
            this.Button_StartLearningSet.Text = "Запустить обучающий набор";
            this.Button_StartLearningSet.UseVisualStyleBackColor = true;
            this.Button_StartLearningSet.Click += new System.EventHandler(this.Button_StartLearningSet_Click);
            // 
            // Label_RightAnswer
            // 
            this.Label_RightAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_RightAnswer.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Label_RightAnswer.Font = new System.Drawing.Font("Microsoft Sans Serif", 80.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label_RightAnswer.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Label_RightAnswer.Location = new System.Drawing.Point(1195, 193);
            this.Label_RightAnswer.Name = "Label_RightAnswer";
            this.Label_RightAnswer.Size = new System.Drawing.Size(214, 224);
            this.Label_RightAnswer.TabIndex = 10;
            this.Label_RightAnswer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(1099, 137);
            this.label4.MinimumSize = new System.Drawing.Size(100, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(359, 42);
            this.label4.TabIndex = 11;
            this.label4.Text = "Правильный ответ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(33, 137);
            this.label1.MinimumSize = new System.Drawing.Size(100, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 42);
            this.label1.TabIndex = 12;
            this.label1.Text = "Символ";
            // 
            // Button_DeleteWeights
            // 
            this.Button_DeleteWeights.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Button_DeleteWeights.ForeColor = System.Drawing.Color.Black;
            this.Button_DeleteWeights.Location = new System.Drawing.Point(12, 12);
            this.Button_DeleteWeights.Name = "Button_DeleteWeights";
            this.Button_DeleteWeights.Size = new System.Drawing.Size(181, 42);
            this.Button_DeleteWeights.TabIndex = 13;
            this.Button_DeleteWeights.Text = "Сбросить веса";
            this.Button_DeleteWeights.UseVisualStyleBackColor = true;
            this.Button_DeleteWeights.Click += new System.EventHandler(this.Button_ResetWeights_Click);
            // 
            // Button_DownloadPucture
            // 
            this.Button_DownloadPucture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_DownloadPucture.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Button_DownloadPucture.ForeColor = System.Drawing.Color.Black;
            this.Button_DownloadPucture.Location = new System.Drawing.Point(1553, 12);
            this.Button_DownloadPucture.Name = "Button_DownloadPucture";
            this.Button_DownloadPucture.Size = new System.Drawing.Size(236, 42);
            this.Button_DownloadPucture.TabIndex = 14;
            this.Button_DownloadPucture.Text = "Загрузить рисунок";
            this.Button_DownloadPucture.UseVisualStyleBackColor = true;
            this.Button_DownloadPucture.Click += new System.EventHandler(this.Button_DownloadPucture_Click);
            // 
            // Button_MatrixClear
            // 
            this.Button_MatrixClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_MatrixClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Button_MatrixClear.ForeColor = System.Drawing.Color.Black;
            this.Button_MatrixClear.Location = new System.Drawing.Point(1257, 12);
            this.Button_MatrixClear.Name = "Button_MatrixClear";
            this.Button_MatrixClear.Size = new System.Drawing.Size(181, 42);
            this.Button_MatrixClear.TabIndex = 15;
            this.Button_MatrixClear.Text = "Стереть символ";
            this.Button_MatrixClear.UseVisualStyleBackColor = true;
            this.Button_MatrixClear.Click += new System.EventHandler(this.Button_MatrixClear_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(1144, 436);
            this.label3.MinimumSize = new System.Drawing.Size(100, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(382, 42);
            this.label3.TabIndex = 16;
            this.label3.Text = "Всего предсказано:";
            // 
            // Chart_AccuracyGraphic
            // 
            this.Chart_AccuracyGraphic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Chart_AccuracyGraphic.BorderlineWidth = 0;
            chartArea11.Area3DStyle.PointDepth = 1;
            chartArea11.Area3DStyle.PointGapDepth = 1;
            chartArea11.Area3DStyle.WallWidth = 2;
            chartArea11.Name = "ChartArea1";
            this.Chart_AccuracyGraphic.ChartAreas.Add(chartArea11);
            legend11.Name = "Legend1";
            this.Chart_AccuracyGraphic.Legends.Add(legend11);
            this.Chart_AccuracyGraphic.Location = new System.Drawing.Point(1122, 481);
            this.Chart_AccuracyGraphic.Name = "Chart_AccuracyGraphic";
            series11.ChartArea = "ChartArea1";
            series11.Legend = "Legend1";
            series11.Name = "Символы, которые распознаёт нейросеть";
            series11.Points.Add(dataPoint76);
            series11.Points.Add(dataPoint77);
            series11.Points.Add(dataPoint78);
            series11.Points.Add(dataPoint79);
            series11.Points.Add(dataPoint80);
            series11.Points.Add(dataPoint81);
            series11.Points.Add(dataPoint82);
            series11.Points.Add(dataPoint83);
            series11.Points.Add(dataPoint84);
            this.Chart_AccuracyGraphic.Series.Add(series11);
            this.Chart_AccuracyGraphic.Size = new System.Drawing.Size(654, 395);
            this.Chart_AccuracyGraphic.TabIndex = 18;
            this.Chart_AccuracyGraphic.Text = "chart1";
            title11.Name = "Title1";
            title11.Text = "Точность распознавания символов";
            this.Chart_AccuracyGraphic.Titles.Add(title11);
            // 
            // Button_UpdateStatistic
            // 
            this.Button_UpdateStatistic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_UpdateStatistic.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Button_UpdateStatistic.ForeColor = System.Drawing.Color.Black;
            this.Button_UpdateStatistic.Location = new System.Drawing.Point(835, 12);
            this.Button_UpdateStatistic.Name = "Button_UpdateStatistic";
            this.Button_UpdateStatistic.Size = new System.Drawing.Size(250, 42);
            this.Button_UpdateStatistic.TabIndex = 19;
            this.Button_UpdateStatistic.Text = "Обновить статистику";
            this.Button_UpdateStatistic.UseVisualStyleBackColor = true;
            this.Button_UpdateStatistic.Click += new System.EventHandler(this.Button_UpdateStatistic_Click);
            // 
            // Label_precitionCountToSession
            // 
            this.Label_precitionCountToSession.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_precitionCountToSession.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label_precitionCountToSession.ForeColor = System.Drawing.Color.Black;
            this.Label_precitionCountToSession.Location = new System.Drawing.Point(1532, 436);
            this.Label_precitionCountToSession.MinimumSize = new System.Drawing.Size(100, 10);
            this.Label_precitionCountToSession.Name = "Label_precitionCountToSession";
            this.Label_precitionCountToSession.Size = new System.Drawing.Size(262, 42);
            this.Label_precitionCountToSession.TabIndex = 20;
            this.Label_precitionCountToSession.Text = "0";
            this.Label_precitionCountToSession.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chart_lossToEpoch
            // 
            this.chart_lossToEpoch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chart_lossToEpoch.BorderlineWidth = 0;
            chartArea12.Area3DStyle.PointDepth = 1;
            chartArea12.Area3DStyle.PointGapDepth = 1;
            chartArea12.Area3DStyle.WallWidth = 2;
            chartArea12.Name = "ChartArea1";
            this.chart_lossToEpoch.ChartAreas.Add(chartArea12);
            this.chart_lossToEpoch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            legend12.Name = "Legend1";
            this.chart_lossToEpoch.Legends.Add(legend12);
            this.chart_lossToEpoch.Location = new System.Drawing.Point(474, 481);
            this.chart_lossToEpoch.Name = "chart_lossToEpoch";
            series12.ChartArea = "ChartArea1";
            series12.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series12.Legend = "Legend1";
            series12.Name = "Усреднённая ошибка";
            dataPoint85.IsEmpty = true;
            series12.Points.Add(dataPoint85);
            series12.Points.Add(dataPoint86);
            series12.Points.Add(dataPoint87);
            series12.Points.Add(dataPoint88);
            series12.Points.Add(dataPoint89);
            series12.Points.Add(dataPoint90);
            this.chart_lossToEpoch.Series.Add(series12);
            this.chart_lossToEpoch.Size = new System.Drawing.Size(654, 395);
            this.chart_lossToEpoch.TabIndex = 21;
            this.chart_lossToEpoch.Text = "chart1";
            title12.Name = "Title1";
            title12.Text = "Усреднённая ошибка нейросети на каждой эпохе";
            this.chart_lossToEpoch.Titles.Add(title12);
            // 
            // label_epochCount
            // 
            this.label_epochCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_epochCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_epochCount.ForeColor = System.Drawing.Color.Black;
            this.label_epochCount.Location = new System.Drawing.Point(804, 436);
            this.label_epochCount.MinimumSize = new System.Drawing.Size(100, 10);
            this.label_epochCount.Name = "label_epochCount";
            this.label_epochCount.Size = new System.Drawing.Size(334, 42);
            this.label_epochCount.TabIndex = 23;
            this.label_epochCount.Text = "0";
            this.label_epochCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(491, 436);
            this.label6.MinimumSize = new System.Drawing.Size(100, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(307, 42);
            this.label6.TabIndex = 22;
            this.label6.Text = "Пройдено эпох:";
            // 
            // drawSymbolsClass1
            // 
            this.drawSymbolsClass1.IsDrawMode = false;
            this.drawSymbolsClass1.Location = new System.Drawing.Point(12, 193);
            this.drawSymbolsClass1.Name = "drawSymbolsClass1";
            this.drawSymbolsClass1.Size = new System.Drawing.Size(224, 224);
            this.drawSymbolsClass1.TabIndex = 24;
            this.drawSymbolsClass1.Text = "drawSymbolsClass1";
            this.drawSymbolsClass1.DoubleClick += new System.EventHandler(this.drawSymbolsClass1_DoubleClick);
            this.drawSymbolsClass1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawSymbolsClass1_MouseMove);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1801, 1061);
            this.Controls.Add(this.drawSymbolsClass1);
            this.Controls.Add(this.label_epochCount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chart_lossToEpoch);
            this.Controls.Add(this.Label_precitionCountToSession);
            this.Controls.Add(this.Button_UpdateStatistic);
            this.Controls.Add(this.Chart_AccuracyGraphic);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Button_MatrixClear);
            this.Controls.Add(this.Button_DownloadPucture);
            this.Controls.Add(this.Button_DeleteWeights);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Label_RightAnswer);
            this.Controls.Add(this.Button_StartLearningSet);
            this.Controls.Add(this.Button_DownloadNextDigit);
            this.Controls.Add(this.Laber_NetworkAnswer);
            this.Controls.Add(this.label2);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Chart_AccuracyGraphic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_lossToEpoch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DrawSymbols.DrawSymbolsClass drawSymbolsClass1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Laber_NetworkAnswer;
        private System.Windows.Forms.Button Button_DownloadNextDigit;
        private System.Windows.Forms.Button Button_StartLearningSet;
        private System.Windows.Forms.Label Label_RightAnswer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Button_DeleteWeights;
        private System.Windows.Forms.Button Button_DownloadPucture;
        private System.Windows.Forms.Button Button_MatrixClear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart_AccuracyGraphic;
        private System.Windows.Forms.Button Button_UpdateStatistic;
        private System.Windows.Forms.Label Label_precitionCountToSession;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_lossToEpoch;
        private System.Windows.Forms.Label label_epochCount;
        private System.Windows.Forms.Label label6;
    }
}

