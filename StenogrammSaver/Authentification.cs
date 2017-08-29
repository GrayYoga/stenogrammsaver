/*
 * Created by SharpDevelop.
 * User: 704
 * Date: 06.10.2014
 * Time: 15:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace StenogrammSaver
{
	/// <summary>
	/// Description of Authentification.
	/// </summary>
	public partial class Authentification : Form
	{
		public SqlConnection sqlConn {get;set;}
		private MainForm fMain;
		private StenogrammExtractor stExtr;
		public Authentification(MainForm fMain, StenogrammExtractor stExtr)
		{
			this.InitializeComponent();
            this.fMain = fMain;
            this.stExtr = stExtr;
            this.fMain.Hide();
            this.textBoxName.Text = Settings1.Default.LastLogin;
            this.comboBoxServers.Text = Settings1.Default.LastServer;
            foreach (string str in Settings1.Default.AllServers.Split(new char[0]))
            {
                if (str.Trim() != "")
                {
                    this.comboBoxServers.Items.Add(str);
                }
            }/**/
            if (this.textBoxName.Text.Length > 0)
            {
                this.textBoxPass.TabIndex = 0;
            }
		}
		
		void ButtonOKClick(object sender, EventArgs e)
		{
			stExtr.Authentification(this.comboBoxServers.Text,this.textBoxName.Text,this.textBoxPass.Text,false);
//			SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder {
//					ConnectionString = "server=" + this.comboBoxServers.Text + 
//					";Initial Catalog=MagTalksBase;user id=" + 
//					this.textBoxName.Text + ";password=" + this.textBoxPass.Text + ";"
//			};
//			// Integrated Security=true;
//			this.fMain.sqlConn = new SqlConnection(builder.ConnectionString);
//			try
//			{
//				this.fMain.sqlConn.Open(); 
//				// выборка только заданий не на контроле ( в таких уже точно обработаны все заявки и составлены все сводки)
//				SqlCommand command = new SqlCommand("SELECT obj_shifr,task_id  FROM [MagTalksBase].[dbo].[dt_Tasks]" +
//													"WHERE ctrl_allowed = 0 ORDER BY task_begin ", this.fMain.sqlConn);
//				SqlDataAdapter adapter = new SqlDataAdapter(command.CommandText, this.fMain.sqlConn);
//				this.fMain.fullinfo = new DataSet();
//				adapter.Fill(this.fMain.fullinfo);
//				
//			}
//			catch (SqlException exception)
//			{
//				string text = "Ошибка соединения с базой данных.\n";
//				for (int i = 0; i < exception.Errors.Count; i++)
//				{
//				    text = text + exception.Errors[i].Message + "\n";
//				}
//				MessageBox.Show(text);
//				this.fMain.mfWriteLog("Сбой аутентификации.");
//				this.fMain.mfWriteLog(text);
//			}
			Settings1.Default.LastLogin = this.textBoxName.Text;
			Settings1.Default.LastServer = this.comboBoxServers.Text;
			Settings1.Default.AllServers = "";
			
			foreach (object obj2 in this.comboBoxServers.Items)
			{
			    Settings1 settings1 = Settings1.Default;
			    settings1.AllServers = settings1.AllServers + obj2 + " ";
			}
			Settings1.Default.Save();/**/
			this.fMain.AutSuccess = true;
			this.DialogResult = DialogResult.OK;
			base.Close();
			this.fMain.mfWriteLog("Аутентификация: успешно.");
		}
		
		void ButtonRefreshClick(object sender, EventArgs e)
		{
			this.comboBoxServers.Items.Clear();
            DataTable dataSources = SqlDataSourceEnumerator.Instance.GetDataSources();
            foreach (DataRow row in dataSources.Rows)
            {
                foreach (DataColumn column in dataSources.Columns)
                {
                    Console.WriteLine("{0} = {1}", column.ColumnName, row[column]);
                    if (column.ColumnName == "ServerName")
                    {
                        this.comboBoxServers.Items.Add(row[column]);
                    }
                }
            }
		}
		
		void ButtonCancelClick(object sender, EventArgs e)
		{		
			this.fMain.AutSuccess = false;
			base.Close();
			this.fMain.mfWriteLog("Выход.");
		}
				
		
		void AuthentificationKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
            {
                this.ButtonOKClick(sender, e);
            }
		}
		
		void AuthentificationKeyPress(object sender, KeyPressEventArgs e)
		{
			
		}
		
		void AuthentificationFormClosed(object sender, FormClosedEventArgs e)
		{
			
		}
		
		void ComboBoxServersKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
            {
                this.ButtonOKClick(sender, e);
            }
		}
		
		void TextBoxPassKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
            {
                this.ButtonOKClick(sender, e);
            }
		}
	}
}
