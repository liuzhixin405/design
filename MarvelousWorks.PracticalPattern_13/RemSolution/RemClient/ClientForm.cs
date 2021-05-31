#region using
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;
using System.Runtime.Remoting;

using Test.Rem.Common;
#endregion
namespace Test.Rem.Client
{
	public class ClientForm : System.Windows.Forms.Form
	{
		#region windows code
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtConfigFile;
		private System.Windows.Forms.Button btnLoad;
		private System.Windows.Forms.Button btnGet;
		private System.Windows.Forms.Button btnSet;
		private System.Windows.Forms.TextBox txtMessage;
        private TextBox txtQuery;
        private Button btnQuery;
		private System.ComponentModel.Container components = null;

		public ClientForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.label1 = new System.Windows.Forms.Label();
            this.txtConfigFile = new System.Windows.Forms.TextBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnGet = new System.Windows.Forms.Button();
            this.btnSet = new System.Windows.Forms.Button();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Configuration File";
            // 
            // txtConfigFile
            // 
            this.txtConfigFile.Location = new System.Drawing.Point(120, 16);
            this.txtConfigFile.Name = "txtConfigFile";
            this.txtConfigFile.ReadOnly = true;
            this.txtConfigFile.Size = new System.Drawing.Size(132, 20);
            this.txtConfigFile.TabIndex = 1;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(268, 16);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(19, 144);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(324, 108);
            this.txtMessage.TabIndex = 3;
            this.txtMessage.Text = "Syntax based on .NET Framework version 1.1.";
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(16, 56);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(75, 23);
            this.btnGet.TabIndex = 4;
            this.btnGet.Text = "&Get";
            // 
            // btnSet
            // 
            this.btnSet.Location = new System.Drawing.Point(96, 56);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(75, 23);
            this.btnSet.TabIndex = 5;
            this.btnSet.Text = "&Set";
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(16, 90);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(327, 48);
            this.txtQuery.TabIndex = 6;
            this.txtQuery.Text = "SELECT * FROM Sales.Currency";
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(177, 56);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(75, 23);
            this.btnQuery.TabIndex = 7;
            this.btnQuery.Text = "Query";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(349, 264);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.btnSet);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtConfigFile);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClientForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client Console (Ver 1.0.57)";
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new ClientForm());

		}
		#endregion

        private IDataFacade remObj;

        private object CreateWellKnownType(string typeName)
        {
            WellKnownClientTypeEntry[] entries = RemotingConfiguration.GetRegisteredWellKnownClientTypes();
            foreach (WellKnownClientTypeEntry entry in entries)
                if (string.Equals(entry.TypeName, typeName))
                    return Activator.GetObject(Type.GetType(typeName), entry.ObjectUrl);
            return null;
        }

        private void ClientForm_Load(object sender, System.EventArgs e)
		{
			string configFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
			txtConfigFile.Text = configFile;
            RemotingConfiguration.Configure(configFile, false);
            string typeName = "Test.Rem.Common.IDataFacade";
            remObj = (IDataFacade)RemHelper.CreateWellKnownType(typeName);
			txtMessage.Text = "Hello world";
		}

        private void btnQuery_Click(object sender, EventArgs e)
        {
            DataSet result = remObj.ExecuteQuery(txtQuery.Text);
            if((result == null) || (result.Tables[0].Rows.Count == 0)) return;
            txtMessage.Text = "";
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 10; i++)
                sb.Append(Convert.ToString(result.Tables[0].Rows[i][1]) + Environment.NewLine);
            txtMessage.Text = sb.ToString();
        }
    }
}
