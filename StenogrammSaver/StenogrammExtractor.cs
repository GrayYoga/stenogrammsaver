/*
 * Created by SharpDevelop.
 * User: 704
 * Date: 22.10.2014
 * Time: 15:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace StenogrammSaver
{
	/// <summary>
	/// Description of StenogrammExtractor.
	/// </summary>
	public class StenogrammExtractor
	{
		public StenogrammExtractor()
		{
			
		}
		public SqlConnection sqlConn;
		public DataSet fullinfo;
		//public delegate void WriteLog(string str);
        
        public void WriteLog(string s)
        {
            string contents = string.Format("[{0:dd.MM.yyyy HH:mm:ss.fff}] {1}\r\n", DateTime.Now/* Settings.Default.LastLogin*/, s);
            File.AppendAllText("events.log", contents, Encoding.GetEncoding("Windows-1251"));
        }
		
        //private WriteLog listWriteLogs;
		//public void 
		/// <summary>
		/// Попытка авторизации на сервере.
		/// </summary>
		/// <param name="server"></param>
		/// <param name="user"></param>
		/// <param name="pass"></param>
		/// <param name="IntAuth"></param>
		/// <returns>true в случае удачной авторизации</returns>
		public void Authentification(string server, string user, string pass, bool IntAuth){
			SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder {
					ConnectionString = "server=" + server + 
					";Initial Catalog=MagTalksBase;user id=" + 
					user + 
					";password=" + pass + ";"
			};
			// Integrated Security=true;
			sqlConn = new SqlConnection(builder.ConnectionString);
			try
			{
				sqlConn.Open(); 
				// выборка только заданий не на контроле ( в таких уже точно обработаны все заявки и составлены все сводки)
				SqlCommand command = new SqlCommand("SELECT obj_shifr,task_id  FROM [MagTalksBase].[dbo].[dt_Tasks]" +
													"WHERE ctrl_allowed = 0 ORDER BY task_begin ", sqlConn);
				SqlDataAdapter adapter = new SqlDataAdapter(command.CommandText, sqlConn);
				fullinfo = new DataSet();
				adapter.Fill(fullinfo);
				
			}
			catch (SqlException exception)
			{
				string text = "Ошибка соединения с базой данных.\n";
				for (int i = 0; i < exception.Errors.Count; i++)
				{
				    text = text + exception.Errors[i].Message + "\n";
				}
				System.Windows.Forms.MessageBox.Show(text);
				/*this.fMain.mfWriteLog*/WriteLog("Сбой аутентификации.");
				/*this.fMain.mfWriteLog*/WriteLog(text);
			}
		}
	}
}
