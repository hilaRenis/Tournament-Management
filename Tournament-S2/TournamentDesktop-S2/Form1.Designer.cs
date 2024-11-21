namespace TournamentDesktop_S2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            logIn_btn = new Button();
            passwordLogIn_tb = new TextBox();
            usernameLogIn_tb = new TextBox();
            passwordLogIn_lbl = new Label();
            usernameLogIn_lbl = new Label();
            SuspendLayout();
            // 
            // logIn_btn
            // 
            logIn_btn.Location = new Point(71, 177);
            logIn_btn.Name = "logIn_btn";
            logIn_btn.Size = new Size(137, 45);
            logIn_btn.TabIndex = 9;
            logIn_btn.Text = "Log In";
            logIn_btn.UseVisualStyleBackColor = true;
            logIn_btn.Click += logIn_btn_Click;
            // 
            // passwordLogIn_tb
            // 
            passwordLogIn_tb.Cursor = Cursors.IBeam;
            passwordLogIn_tb.Location = new Point(175, 124);
            passwordLogIn_tb.Name = "passwordLogIn_tb";
            passwordLogIn_tb.PasswordChar = '*';
            passwordLogIn_tb.Size = new Size(206, 27);
            passwordLogIn_tb.TabIndex = 8;
            // 
            // usernameLogIn_tb
            // 
            usernameLogIn_tb.Location = new Point(175, 57);
            usernameLogIn_tb.Name = "usernameLogIn_tb";
            usernameLogIn_tb.Size = new Size(206, 27);
            usernameLogIn_tb.TabIndex = 7;
            // 
            // passwordLogIn_lbl
            // 
            passwordLogIn_lbl.AutoSize = true;
            passwordLogIn_lbl.Location = new Point(24, 127);
            passwordLogIn_lbl.Name = "passwordLogIn_lbl";
            passwordLogIn_lbl.Size = new Size(73, 20);
            passwordLogIn_lbl.TabIndex = 6;
            passwordLogIn_lbl.Text = "Password:";
            // 
            // usernameLogIn_lbl
            // 
            usernameLogIn_lbl.AutoSize = true;
            usernameLogIn_lbl.Location = new Point(24, 60);
            usernameLogIn_lbl.Name = "usernameLogIn_lbl";
            usernameLogIn_lbl.Size = new Size(82, 20);
            usernameLogIn_lbl.TabIndex = 5;
            usernameLogIn_lbl.Text = "Username: ";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(402, 247);
            Controls.Add(logIn_btn);
            Controls.Add(passwordLogIn_tb);
            Controls.Add(usernameLogIn_tb);
            Controls.Add(passwordLogIn_lbl);
            Controls.Add(usernameLogIn_lbl);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button logIn_btn;
        private TextBox passwordLogIn_tb;
        private TextBox usernameLogIn_tb;
        private Label passwordLogIn_lbl;
        private Label usernameLogIn_lbl;
    }
}