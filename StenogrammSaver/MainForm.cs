/*
 * Created by SharpDevelop.
 * User: 704
 * Date: 06.10.2014
 * Time: 15:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Text;

namespace StenogrammSaver
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		
		public bool AutSuccess;
		private string [] args;
		private StenogrammExtractor stExtr;
		public MainForm(string [] args)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			this.args = args;
			InitializeComponent();
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
			stExtr = new StenogrammExtractor();
			
			ComandLineParams clp = new ComandLineParams(args);
			if ( clp.bParseSuccess ) {
				stExtr.Authentification(clp.strServer,clp.strUser,clp.strPassword,clp.bIntAuth);
				//GetTasksList();
				//SaveStenogramms();
			}else{
				Authentification auForm = new Authentification(this,stExtr);
				base.Hide();
	            this.AutSuccess = false;
	            auForm.ShowDialog();
			}
        }
		
		void MainFormLoad(object sender, EventArgs e)
		{
			if ( Settings1.Default.OutputDir.Length == 0 ) {
				textBoxPath.Text = Application.StartupPath;
			}else {
				textBoxPath.Text = Settings1.Default.OutputDir;
			}
			if ( AutSuccess == false ) this.Close();
			
			/*foreach (DataRow row in stExtr.fullinfo.Tables[0].Rows)
            {
                this.listBoxShipher.Items.Add(row["task_cipher"]);
            }/**/
		}
		public void mfWriteLog(string s)
        {
            string contents = string.Format("[{0:dd.MM.yyyy HH:mm:ss.fff}] {1}\r\n", DateTime.Now/* Settings.Default.LastLogin*/, s);
            File.AppendAllText("events.log", contents, Encoding.GetEncoding("Windows-1251"));
        }

		
		void ButtonPathClick(object sender, EventArgs e)
		{
			using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Папка размещения выходных файлов";
                dialog.ShowNewFolderButton = true;
                dialog.SelectedPath = Settings1.Default.OutputDir;
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    Settings1.Default.OutputDir = dialog.SelectedPath;
                    textBoxPath.Text = dialog.SelectedPath;
                }
            }			
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			foreach ( string strsh in listBoxShipher.CheckedItems){
				//DataColumn[] dc = new DataColumn[1];
				//dc[0] = stExtr.fullinfo.Tables[0].Columns["obj_shifr"];
                //stExtr.fullinfo.Tables[0].PrimaryKey = dc;
                //stExtr.fullinfo.Tables[0].PrimaryKey = new DataColumn[1];
                stExtr.fullinfo.Tables[0].PrimaryKey = new DataColumn[] { stExtr.fullinfo.Tables[0].Columns["obj_shifr"] };
                //stExtr.fullinfo.Tables[0].Columns["obj_shifr"]; 
				DataRow row = stExtr.fullinfo.Tables[0].Rows.Find(strsh);
				DataSet dataSet = new DataSet();
                
                textBoxOutput.AppendText(string.Concat(row["task_id"]," ",strsh,"\r\n"));
				
                SqlCommand command = new SqlCommand(string.Concat("SELECT t.[talk_id], t.[task_auto_id], t.[tbegin],t.[direction],tx.Phone, tx.Stenogram",
		                                                          " FROM [MagTalksBase].[dbo].[dt_Talks] t",
																	" INNER JOIN [MagTalksBase].[dbo].[sm_dt_Texts] tx ON t.talk_id = tx.talk_id",
																	" where tx.task_id = ",row["task_id"]," order by tx.tbegin"), stExtr.sqlConn);
                new SqlDataAdapter(command.CommandText, stExtr.sqlConn).Fill(dataSet);
                
                string str2 = "";
                
                foreach ( DataRow row3 in dataSet.Tables[0].Rows)
                {
                	string strPhone = row3["Phone"].ToString();
                
                	strPhone = strPhone.Replace("(","");strPhone = strPhone.Replace(")","");
                	strPhone = strPhone.Replace("-","");strPhone = strPhone.Replace(" ","");
                
                	str2 = string.Concat(str2,
                	                     row3["tbegin"]," ",strPhone," ",
                	                     (row3["direction"].ToString().Contains("1")?"Входящий":"Исходящий"),
                	                     "\r\n", row3["Stenogram"],
                	                     "\r\n");
                	
                }
                int lenHeader = ("ПТП-75-").Length;
                string shipher = strsh/*listBoxShipher.Items[index].ToString()/**/;
                string filename = shipher.Substring(lenHeader);
                
                if (!System.IO.Directory.Exists(textBoxPath.Text)){Directory.CreateDirectory(textBoxPath.Text);}
                	
                StreamWriter writer = new StreamWriter(Path.Combine(textBoxPath.Text, 
                                                       string.Concat( filename , ".txt")),
                                                       false, Encoding.Unicode);
                writer.Write(str2);
                writer.Close();
                string s = string.Concat( "Файл " ,Path.Combine(textBoxPath.Text,
                                                                string.Concat( filename, ".txt")) ,
                                                                " сохранен.");
                
                this.mfWriteLog(s);
                textBoxOutput.AppendText(string.Concat(s,"\r\n"));
			}
			foreach (int i in listBoxShipher.CheckedIndices){
				listBoxShipher.SetItemCheckState(i,CheckState.Unchecked);
				
			}/**/
			
			ResetAndFillLsitBox();
		}
		void ResetAndFillLsitBox(){
			this.listBoxShipher.Items.Clear();
			int lenHeader = ("ПТП-75-").Length;
			int countSkipped = 0;
			foreach (DataRow row in stExtr.fullinfo.Tables[0].Rows)
            {
                string shipher = row["obj_shifr"].ToString();
                string filename = shipher.Substring(lenHeader);
                if ( File.Exists( Path.Combine(textBoxPath.Text, string.Concat( filename , ".txt")) )){ 
                	countSkipped += 1;
                	continue;
                }
                this.listBoxShipher.Items.Add(row["obj_shifr"]);
            }
            this.textBoxOutput.AppendText(string.Concat("Пропущено заданий: ", countSkipped, "\r\n"));
            Settings1.Default.OutputDir = textBoxPath.Text;
		}
		// заполнение списка доступных к обработке заданий
		void MainFormShown(object sender, EventArgs e)
		{
			ResetAndFillLsitBox();
		}
		
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			Settings1.Default.OutputDir = textBoxPath.Text;
			Settings1.Default.Save();
		}
		
		void ВыделитьВсеToolStripMenuItemClick(object sender, EventArgs e)
		{
			for (int i = 0; i< listBoxShipher.Items.Count; i++){
				listBoxShipher.SetItemCheckState(i,CheckState.Checked);
			}
		}
		
		void ОчиститьВсеToolStripMenuItemClick(object sender, EventArgs e)
		{
			for (int i = 0; i< listBoxShipher.Items.Count; i++){
				listBoxShipher.SetItemCheckState(i,CheckState.Unchecked);
			}
		}
	}
}
