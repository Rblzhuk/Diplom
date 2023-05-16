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
            this.drawSymbolsClass1 = new DrawDigits.DrawSymbolsClass();
            this.label3 = new System.Windows.Forms.Label();
            this.label_Accuracy = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(601, 137);
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
            this.Laber_NetworkAnswer.Location = new System.Drawing.Point(671, 193);
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
            this.Button_DownloadNextDigit.Location = new System.Drawing.Point(605, 81);
            this.Button_DownloadNextDigit.Name = "Button_DownloadNextDigit";
            this.Button_DownloadNextDigit.Size = new System.Drawing.Size(326, 42);
            this.Button_DownloadNextDigit.TabIndex = 8;
            this.Button_DownloadNextDigit.Text = "Загрузить случайный символ";
            this.Button_DownloadNextDigit.UseVisualStyleBackColor = true;
            this.Button_DownloadNextDigit.Click += new System.EventHandler(this.Button_DownloadNextDigit_Click);
            // 
            // Button_StartLearningSet
            // 
            this.Button_StartLearningSet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.Label_RightAnswer.Location = new System.Drawing.Point(332, 193);
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
            this.label4.Location = new System.Drawing.Point(236, 137);
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
            this.label1.Location = new System.Drawing.Point(51, 137);
            this.label1.MinimumSize = new System.Drawing.Size(100, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 42);
            this.label1.TabIndex = 12;
            this.label1.Text = "Символ";
            // 
            // Button_DeleteWeights
            // 
            this.Button_DeleteWeights.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.Button_DownloadPucture.Location = new System.Drawing.Point(690, 12);
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
            this.Button_MatrixClear.Location = new System.Drawing.Point(394, 12);
            this.Button_MatrixClear.Name = "Button_MatrixClear";
            this.Button_MatrixClear.Size = new System.Drawing.Size(181, 42);
            this.Button_MatrixClear.TabIndex = 15;
            this.Button_MatrixClear.Text = "Стереть символ";
            this.Button_MatrixClear.UseVisualStyleBackColor = true;
            this.Button_MatrixClear.Click += new System.EventHandler(this.Button_MatrixClear_Click);
            // 
            // drawSymbolsClass1
            // 
            this.drawSymbolsClass1.BackColor = System.Drawing.SystemColors.Control;
            this.drawSymbolsClass1.ForeColor = System.Drawing.SystemColors.Control;
            this.drawSymbolsClass1.IsDrawMode = false;
            this.drawSymbolsClass1.Location = new System.Drawing.Point(24, 193);
            this.drawSymbolsClass1.MaximumSize = new System.Drawing.Size(896, 896);
            this.drawSymbolsClass1.MinimumSize = new System.Drawing.Size(224, 224);
            this.drawSymbolsClass1.Name = "drawSymbolsClass1";
            this.drawSymbolsClass1.Size = new System.Drawing.Size(224, 224);
            this.drawSymbolsClass1.TabIndex = 0;
            this.drawSymbolsClass1.Text = "drawDigitsClass1";
            this.drawSymbolsClass1.DoubleClick += new System.EventHandler(this.drawDigitsClass1_DoubleClick);
            this.drawSymbolsClass1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.drawDigitsClass1_MouseMove);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(582, 436);
            this.label3.MinimumSize = new System.Drawing.Size(100, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(198, 42);
            this.label3.TabIndex = 16;
            this.label3.Text = "Точность:";
            // 
            // label_Accuracy
            // 
            this.label_Accuracy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Accuracy.AutoSize = true;
            this.label_Accuracy.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Accuracy.ForeColor = System.Drawing.Color.Black;
            this.label_Accuracy.Location = new System.Drawing.Point(786, 436);
            this.label_Accuracy.MinimumSize = new System.Drawing.Size(100, 10);
            this.label_Accuracy.Name = "label_Accuracy";
            this.label_Accuracy.Size = new System.Drawing.Size(100, 42);
            this.label_Accuracy.TabIndex = 17;
            this.label_Accuracy.Text = "0";
            this.label_Accuracy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(938, 537);
            this.Controls.Add(this.label_Accuracy);
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
            this.Controls.Add(this.drawSymbolsClass1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public DrawDigits.DrawSymbolsClass drawSymbolsClass1;
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
        private System.Windows.Forms.Label label_Accuracy;
    }
}

