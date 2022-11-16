namespace HelloMyCSharp03
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_input = new System.Windows.Forms.TextBox();
            this.s = new System.Windows.Forms.Label();
            this.button_mbox = new System.Windows.Forms.Button();
            this.button_customized = new System.Windows.Forms.Button();
            this.button_show = new System.Windows.Forms.Button();
            this.circularButton1 = new HelloMyCSharp03.CircularButton();
            this.SuspendLayout();
            // 
            // textBox_input
            // 
            this.textBox_input.Location = new System.Drawing.Point(79, 44);
            this.textBox_input.Name = "textBox_input";
            this.textBox_input.Size = new System.Drawing.Size(218, 21);
            this.textBox_input.TabIndex = 0;
            this.textBox_input.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // s
            // 
            this.s.AutoSize = true;
            this.s.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.s.Location = new System.Drawing.Point(-3, 49);
            this.s.Name = "s";
            this.s.Size = new System.Drawing.Size(76, 16);
            this.s.TabIndex = 1;
            this.s.Text = "글자 입력";
            this.s.Click += new System.EventHandler(this.label1_Click);
            // 
            // button_mbox
            // 
            this.button_mbox.Location = new System.Drawing.Point(79, 79);
            this.button_mbox.Name = "button_mbox";
            this.button_mbox.Size = new System.Drawing.Size(105, 23);
            this.button_mbox.TabIndex = 2;
            this.button_mbox.Text = "메세지 박스";
            this.button_mbox.UseVisualStyleBackColor = true;
            this.button_mbox.Click += new System.EventHandler(this.button1_Click);
            // 
            // button_customized
            // 
            this.button_customized.Location = new System.Drawing.Point(200, 79);
            this.button_customized.Name = "button_customized";
            this.button_customized.Size = new System.Drawing.Size(97, 23);
            this.button_customized.TabIndex = 3;
            this.button_customized.Text = "맞춤박스";
            this.button_customized.UseVisualStyleBackColor = true;
            this.button_customized.Click += new System.EventHandler(this.button_customized_Click);
            // 
            // button_show
            // 
            this.button_show.Location = new System.Drawing.Point(312, 79);
            this.button_show.Name = "button_show";
            this.button_show.Size = new System.Drawing.Size(121, 23);
            this.button_show.TabIndex = 4;
            this.button_show.Text = "그냥 창 띄우기";
            this.button_show.UseVisualStyleBackColor = true;
            this.button_show.Click += new System.EventHandler(this.button_show_Click);
            // 
            // circularButton1
            // 
            this.circularButton1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.circularButton1.FlatAppearance.BorderSize = 0;
            this.circularButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.circularButton1.Font = new System.Drawing.Font("D2Coding", 71.99999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.circularButton1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.circularButton1.Location = new System.Drawing.Point(79, 150);
            this.circularButton1.Name = "circularButton1";
            this.circularButton1.Size = new System.Drawing.Size(252, 207);
            this.circularButton1.TabIndex = 5;
            this.circularButton1.Text = "원";
            this.circularButton1.UseVisualStyleBackColor = false;
            this.circularButton1.Click += new System.EventHandler(this.circularButton1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 504);
            this.Controls.Add(this.circularButton1);
            this.Controls.Add(this.button_show);
            this.Controls.Add(this.button_customized);
            this.Controls.Add(this.button_mbox);
            this.Controls.Add(this.s);
            this.Controls.Add(this.textBox_input);
            this.Name = "MainForm";
            this.Text = " MainForm";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_input;
        private System.Windows.Forms.Label s;
        private System.Windows.Forms.Button button_mbox;
        private System.Windows.Forms.Button button_customized;
        private System.Windows.Forms.Button button_show;
        private CircularButton circularButton1;
    }
}

