/*
 * Created by SharpDevelop.
 * User: 704
 * Date: 06.10.2014
 * Time: 15:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace StenogrammSaver
{
	partial class MainForm
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
			this.components = new System.ComponentModel.Container();
			this.textBoxPath = new System.Windows.Forms.TextBox();
			this.buttonPath = new System.Windows.Forms.Button();
			this.textBoxOutput = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.listBoxShipher = new System.Windows.Forms.CheckedListBox();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.выделитьВсеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.очиститьВсеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBoxPath
			// 
			this.textBoxPath.Location = new System.Drawing.Point(12, 18);
			this.textBoxPath.Name = "textBoxPath";
			this.textBoxPath.Size = new System.Drawing.Size(221, 20);
			this.textBoxPath.TabIndex = 1;
			// 
			// buttonPath
			// 
			this.buttonPath.Location = new System.Drawing.Point(239, 18);
			this.buttonPath.Name = "buttonPath";
			this.buttonPath.Size = new System.Drawing.Size(24, 20);
			this.buttonPath.TabIndex = 2;
			this.buttonPath.Text = "...";
			this.buttonPath.UseVisualStyleBackColor = true;
			this.buttonPath.Click += new System.EventHandler(this.ButtonPathClick);
			// 
			// textBoxOutput
			// 
			this.textBoxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxOutput.Location = new System.Drawing.Point(291, 18);
			this.textBoxOutput.Multiline = true;
			this.textBoxOutput.Name = "textBoxOutput";
			this.textBoxOutput.Size = new System.Drawing.Size(269, 368);
			this.textBoxOutput.TabIndex = 3;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(271, 139);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(14, 109);
			this.button1.TabIndex = 4;
			this.button1.Text = ">";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// listBoxShipher
			// 
			this.listBoxShipher.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left)));
			this.listBoxShipher.CheckOnClick = true;
			this.listBoxShipher.ContextMenuStrip = this.contextMenuStrip1;
			this.listBoxShipher.FormattingEnabled = true;
			this.listBoxShipher.Location = new System.Drawing.Point(12, 52);
			this.listBoxShipher.Name = "listBoxShipher";
			this.listBoxShipher.Size = new System.Drawing.Size(253, 334);
			this.listBoxShipher.TabIndex = 5;
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.выделитьВсеToolStripMenuItem,
									this.очиститьВсеToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(165, 70);
			// 
			// выделитьВсеToolStripMenuItem
			// 
			this.выделитьВсеToolStripMenuItem.Name = "выделитьВсеToolStripMenuItem";
			this.выделитьВсеToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.выделитьВсеToolStripMenuItem.Text = "Включить все";
			this.выделитьВсеToolStripMenuItem.Click += new System.EventHandler(this.ВыделитьВсеToolStripMenuItemClick);
			// 
			// очиститьВсеToolStripMenuItem
			// 
			this.очиститьВсеToolStripMenuItem.Name = "очиститьВсеToolStripMenuItem";
			this.очиститьВсеToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
			this.очиститьВсеToolStripMenuItem.Text = "Выключить все";
			this.очиститьВсеToolStripMenuItem.Click += new System.EventHandler(this.ОчиститьВсеToolStripMenuItemClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(572, 398);
			this.Controls.Add(this.listBoxShipher);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBoxOutput);
			this.Controls.Add(this.buttonPath);
			this.Controls.Add(this.textBoxPath);
			this.Name = "MainForm";
			this.Text = "StenogrammSaver";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.Shown += new System.EventHandler(this.MainFormShown);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripMenuItem очиститьВсеToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem выделитьВсеToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBoxOutput;
		private System.Windows.Forms.Button buttonPath;
		private System.Windows.Forms.TextBox textBoxPath;
		private System.Windows.Forms.CheckedListBox listBoxShipher;
	}
}
