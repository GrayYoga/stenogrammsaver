/*
 * Created by SharpDevelop.
 * User: 704
 * Date: 06.10.2014
 * Time: 15:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace StenogrammSaver
{
	partial class Authentification
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Authentification));
			this.textBoxName = new System.Windows.Forms.TextBox();
			this.textBoxPass = new System.Windows.Forms.TextBox();
			this.buttonRefresh = new System.Windows.Forms.Button();
			this.comboBoxServers = new System.Windows.Forms.ComboBox();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// textBoxName
			// 
			this.textBoxName.Location = new System.Drawing.Point(88, 12);
			this.textBoxName.Name = "textBoxName";
			this.textBoxName.Size = new System.Drawing.Size(178, 20);
			this.textBoxName.TabIndex = 0;
			// 
			// textBoxPass
			// 
			this.textBoxPass.Location = new System.Drawing.Point(88, 38);
			this.textBoxPass.Name = "textBoxPass";
			this.textBoxPass.PasswordChar = '*';
			this.textBoxPass.Size = new System.Drawing.Size(178, 20);
			this.textBoxPass.TabIndex = 1;
			this.textBoxPass.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxPassKeyDown);
			// 
			// buttonRefresh
			// 
			this.buttonRefresh.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonRefresh.BackgroundImage")));
			this.buttonRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.buttonRefresh.Location = new System.Drawing.Point(244, 64);
			this.buttonRefresh.Name = "buttonRefresh";
			this.buttonRefresh.Size = new System.Drawing.Size(22, 23);
			this.buttonRefresh.TabIndex = 3;
			this.buttonRefresh.UseVisualStyleBackColor = true;
			this.buttonRefresh.Click += new System.EventHandler(this.ButtonRefreshClick);
			// 
			// comboBoxServers
			// 
			this.comboBoxServers.FormattingEnabled = true;
			this.comboBoxServers.Location = new System.Drawing.Point(88, 66);
			this.comboBoxServers.Name = "comboBoxServers";
			this.comboBoxServers.Size = new System.Drawing.Size(150, 21);
			this.comboBoxServers.TabIndex = 2;
			this.comboBoxServers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ComboBoxServersKeyDown);
			// 
			// buttonOK
			// 
			this.buttonOK.Location = new System.Drawing.Point(110, 93);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 23);
			this.buttonOK.TabIndex = 4;
			this.buttonOK.Text = "OK";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.ButtonOKClick);
			// 
			// buttonCancel
			// 
			this.buttonCancel.Location = new System.Drawing.Point(191, 93);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 5;
			this.buttonCancel.Text = "Отмена";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 20);
			this.label1.TabIndex = 6;
			this.label1.Text = "Имя:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 37);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 20);
			this.label2.TabIndex = 7;
			this.label2.Text = "Пароль:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 67);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(70, 20);
			this.label3.TabIndex = 8;
			this.label3.Text = "Сервер:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// Authentification
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.ClientSize = new System.Drawing.Size(276, 123);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.buttonOK);
			this.Controls.Add(this.comboBoxServers);
			this.Controls.Add(this.buttonRefresh);
			this.Controls.Add(this.textBoxPass);
			this.Controls.Add(this.textBoxName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Authentification";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Вход в систему";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AuthentificationFormClosed);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AuthentificationKeyDown);
			this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AuthentificationKeyPress);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonCancel;
		private System.Windows.Forms.Button buttonOK;
		private System.Windows.Forms.ComboBox comboBoxServers;
		private System.Windows.Forms.Button buttonRefresh;
		private System.Windows.Forms.TextBox textBoxPass;
		private System.Windows.Forms.TextBox textBoxName;
	}
}
