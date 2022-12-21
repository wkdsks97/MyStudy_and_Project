namespace MewtocolTest
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_readSingleIo = new System.Windows.Forms.Button();
            this.button_setContactData = new System.Windows.Forms.Button();
            this.textBox_writeContactCode = new System.Windows.Forms.TextBox();
            this.textBox_writeContactAddress = new System.Windows.Forms.TextBox();
            this.textBox_writeContactValue = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.myThread = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_readSingleIo
            // 
            this.button_readSingleIo.Location = new System.Drawing.Point(292, 130);
            this.button_readSingleIo.Name = "button_readSingleIo";
            this.button_readSingleIo.Size = new System.Drawing.Size(121, 38);
            this.button_readSingleIo.TabIndex = 21;
            this.button_readSingleIo.Text = "단점 읽기";
            this.button_readSingleIo.UseVisualStyleBackColor = true;
            this.button_readSingleIo.Click += new System.EventHandler(this.button_readSingleIo_Click);
            // 
            // button_setContactData
            // 
            this.button_setContactData.Location = new System.Drawing.Point(292, 64);
            this.button_setContactData.Name = "button_setContactData";
            this.button_setContactData.Size = new System.Drawing.Size(122, 42);
            this.button_setContactData.TabIndex = 7;
            this.button_setContactData.Text = "접점 설정";
            this.button_setContactData.UseVisualStyleBackColor = true;
            this.button_setContactData.Click += new System.EventHandler(this.button_setContactData_Click);
            // 
            // textBox_writeContactCode
            // 
            this.textBox_writeContactCode.Location = new System.Drawing.Point(61, 76);
            this.textBox_writeContactCode.Name = "textBox_writeContactCode";
            this.textBox_writeContactCode.Size = new System.Drawing.Size(50, 21);
            this.textBox_writeContactCode.TabIndex = 9;
            // 
            // textBox_writeContactAddress
            // 
            this.textBox_writeContactAddress.Location = new System.Drawing.Point(129, 76);
            this.textBox_writeContactAddress.Name = "textBox_writeContactAddress";
            this.textBox_writeContactAddress.Size = new System.Drawing.Size(50, 21);
            this.textBox_writeContactAddress.TabIndex = 8;
            // 
            // textBox_writeContactValue
            // 
            this.textBox_writeContactValue.Location = new System.Drawing.Point(197, 76);
            this.textBox_writeContactValue.Name = "textBox_writeContactValue";
            this.textBox_writeContactValue.Size = new System.Drawing.Size(50, 21);
            this.textBox_writeContactValue.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(59, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 12);
            this.label6.TabIndex = 20;
            this.label6.Text = "접점 코드";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(141, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 19;
            this.label5.Text = "주소";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(207, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 18;
            this.label4.Text = "값";
            // 
            // myThread
            // 
            this.myThread.Location = new System.Drawing.Point(85, 248);
            this.myThread.Name = "myThread";
            this.myThread.Size = new System.Drawing.Size(121, 38);
            this.myThread.TabIndex = 22;
            this.myThread.Text = "쓰레드 읽기";
            this.myThread.UseVisualStyleBackColor = true;
            this.myThread.Click += new System.EventHandler(this.myThread_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 538);
            this.Controls.Add(this.myThread);
            this.Controls.Add(this.button_readSingleIo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_writeContactValue);
            this.Controls.Add(this.textBox_writeContactAddress);
            this.Controls.Add(this.textBox_writeContactCode);
            this.Controls.Add(this.button_setContactData);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button_readSingleIo;
        private System.Windows.Forms.Button button_setContactData;
        private System.Windows.Forms.TextBox textBox_writeContactCode;
        private System.Windows.Forms.TextBox textBox_writeContactAddress;
        private System.Windows.Forms.TextBox textBox_writeContactValue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button myThread;
    }
}

