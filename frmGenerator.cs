using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Xml;
using System.IO;
using DataServiceGenerator.QueryBuilderClasses;
using DataServiceGenerator.CodeBuilder_Classes;
using DataServiceGenerator.AccessClasses;
using DataServiceGenerator.PersistenceClasses;

namespace DataServiceGenerator
{
    public partial class frmGenerator : Form
    {
        DataSource DS;

        private List<DataBaseServer> Servers=new List<DataBaseServer>();
        private List<PersistenceClasses.Table> Tables = new List<Table>();
        
        private string CurrentSavedFileName="";
        
        public frmGenerator()
        {
            InitializeComponent();
        }

        private void cmdTestAndSave_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            
            DataSourceType DstWorking;
            switch (cmbDatabaseType.Text)
            {
                case "Sql Server":
                    DstWorking=DataSourceType.MsSql;
                    
                    break;
                case "Microsoft Access":
                    DstWorking =DataSourceType.MsAccess;
                    
                    break;
                case "My Sql":
                    DstWorking = DataSourceType.MySql;
                    break;
                default:
                    DstWorking = DataSourceType.none;
                    MessageBox.Show("You have selected an invalid or unsupported database type. Please choose a valid selection and test again");
                    return;
                    break;
            }
            DS = new DataSource(DstWorking);
            if (DS!=null)
            {
                try
                {
                    if (DS.TestConnection(txtConnectionString.Text))
                    {
                        Servers.Add(new DataBaseServer(txtNickname.Text, txtConnectionString.Text, DstWorking));
                        DataTable dt = DS.GetTableList();
                        if (ckEnableAutogeneration.Checked == true)
                        {
                            foreach (DataRow dr in dt.Rows)
                            {
                                Table t = new Table(dr[0].ToString(), txtNickname.Text);
                                t.generateDelete = true;
                                t.generateExists = true;
                                t.generateInsert = true;
                                t.generateConstructor = true;
                                t.generateSave = true;
                                t.generateUpdate = true;
                                Tables.Add(t);
                            }
                        }
                    }
                    else
                    {
                        txtOutputText.Text = txtOutputText.Text + "Connection test to " + txtNickname.Text + " failed\n\r";
                    }
                }
                catch (Exception eex)
                {
                    txtOutputText.Text = txtOutputText.Text + "Connection test to " + txtNickname.Text + " failed:" + eex.Message +"\n\r";
                }
            }
            ListingsRefresh();
            Cursor = Cursors.Default;
        }

        
        public void ListingsRefresh()
        {
            lstServers.Items.Clear();
            foreach( DataBaseServer s in Servers){
                lstServers.Items.Add(s.Nickname);
            }
        }

        private void TablesRefresh(DataBaseServer dbs)
        {
            DataSource d = new DataSource(dbs.Type);
            d.TestConnection(dbs.ConnectString);
            lstTableSelected.Items.Clear();
            DataTable dt;
            dt = d.GetTableList();
            lstTableSelected.Items.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                lstTableSelected.Items.Add(dr[0].ToString());
            }
        }

        private void lstServers_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (DataBaseServer dbs in Servers)
                if (dbs.Nickname == lstServers.Text) 
                    TablesRefresh(dbs);
        }

        private void lstTableSelected_SelectedIndexChanged(object sender, EventArgs e)
        {

            
            tbConfig.SelectedIndex = 1;
            UpdateEditPanel(lstTableSelected.Text);
                
        }

        private Table GetSelectedTable(string TableName)
        {
             foreach (Table t in Tables)
            
                if (t.Name == TableName) return t;

             return null;
            
        }

        private void UpdateEditPanel(string TableName)
        {
            cmdAddTable.Text = "Add Table";
            txtTableName.Text = lstTableSelected.Text;
            Table a=null;
            foreach (Table t in Tables)
            {
                if (t.Name == TableName)
                {
                    a = t;
                    ckConstructor.Checked = (t.generateConstructor) ? true : false;
                    ckDelete.Checked = (t.generateDelete) ? true : false;
                    ckExists.Checked = (t.generateExists) ? true : false;
                    ckInsert.Checked = (t.generateInsert) ? true : false;
                    ckUpdate.Checked = (t.generateUpdate) ? true : false;
                    ckSave.Checked = (t.generateSave) ? true : false;
                    cmdEditPostConstructor.Visible = true;
                    cmdEditPostDelete.Visible = true;
                    cmdEditPostExists.Visible = true;
                    cmdEditPostInsert.Visible = true;
                    cmdEditPostSave.Visible = true;
                    cmdEditPostUpdate.Visible = true;
                    cmdEditPreConstructor.Visible = true;
                    cmdEditPreDelete.Visible = true;
                    cmdEditPreExists.Visible = true;
                    cmdEditPreInsert.Visible = true;
                    cmdEditPreSave.Visible = true;
                    cmdEditPreUpdate.Visible = true;
                    cmdSaveButton.Enabled = true;
                    cmdAddTable.Text = "Delete Table";
                    lstFields.Items.Clear();
                    txtTableKey.Text =  DS.GetPrimaryKey(lstTableSelected.SelectedItem.ToString());
                    foreach (DataRow dr in DS.GetTable(lstTableSelected.SelectedItem.ToString()).Rows)
                        lstFields.Items.Add(dr[0].ToString());
                    
                }
            }
            if (a==null)
            {
                ckConstructor.Checked = false;
                ckDelete.Checked =  false;
                ckExists.Checked = false;
                ckInsert.Checked = false;
                ckUpdate.Checked = false;
                ckSave.Checked = false;
                cmdEditPostConstructor.Visible = false;
                cmdEditPostDelete.Visible = false;
                cmdEditPostExists.Visible = false;
                cmdEditPostInsert.Visible = false;
                cmdEditPostSave.Visible = false;
                cmdEditPostUpdate.Visible = false;
                cmdEditPreConstructor.Visible = false;
                cmdEditPreDelete.Visible = false;
                cmdEditPreExists.Visible = false;
                cmdEditPreInsert.Visible = false;
                cmdEditPreSave.Visible = false;
                cmdEditPreUpdate.Visible = false;
                cmdSaveButton.Enabled = false;
                cmdAddTable.Text = "Add Table";
                lstFields.Items.Clear();
                txtTableKey.Text = "";
               
            }
        }
        private void cmdSaveTable_Click(object sender, EventArgs e)
        {
            
        }
        private void SaveDocument(string filename, XmlDocument xmlDoc)
        {
            XmlTextWriter w = new XmlTextWriter(filename, Encoding.ASCII);
            xmlDoc.Save(w);            
        }
        private XmlDocument SerializeDocument()
        {
            // Persists existing configuration into an XML document.
            XmlDocument xmlDoc = new XmlDocument();
            
            XmlElement xmlRoot = xmlDoc.CreateElement("DataServiceGeneratorConfiguration");
            xmlDoc.AppendChild(xmlRoot);

            XmlNode xmlDB = xmlDoc.CreateNode(XmlNodeType.Element, "Databases", "");
            xmlRoot.AppendChild(xmlDB);

            XmlNode xmlT = xmlDoc.CreateNode(XmlNodeType.Element,"Tables", "");
            xmlRoot.AppendChild(xmlT);

            foreach (DataBaseServer s in Servers) xmlDB.AppendChild(s.writeToXml(xmlDoc));
            foreach (Table t in Tables) xmlT.AppendChild(t.writeToXml(xmlDoc));

            return xmlDoc;

        }
        private void unSerializeXmlDocument(XmlDocument d)
        {
            foreach (XmlNode x in d.ChildNodes)
            {
                if (x.Name=="Databases")
                {
                    foreach (XmlNode y in x.ChildNodes){
                        DataBaseServer db = new DataBaseServer();
                        if (db.parseFromXml(y))
                        {
                            Servers.Add(db);
                        }
                        else
                        {
                            throw new Exception("Could not parse Database server element ");
                        }
                    }
                }
                if (x.Name=="Tables")
                {
                    foreach (XmlNode y in x.ChildNodes)
                    {
                        Table t = new Table();
                        if (t.parseFromXml(y))
                        {
                            Tables.Add(t);
                        }
                        else
                        {
                            throw new Exception("Could not parse Table element ");
                        }
                    }
                    
                }
            }
        }
        private bool GetSaveAsFileName(ref string filename)
        {
            SaveFileDialog o = new SaveFileDialog();
            o.DefaultExt = "xml";
            o.Filter = "XML document|*.xml|all Documents|*.*";
            o.AddExtension = true;
            o.CheckFileExists = true;
            o.Title = "Select filename to save";
            
            if(o.ShowDialog()==DialogResult.OK)
            {
                    filename=o.FileName;
                    return true;
            }
            else
            {
                    return false;
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.CurrentSavedFileName.Length > 0)
            {
                SaveDocument(CurrentSavedFileName, SerializeDocument());
            }
            else
            {
                if (GetSaveAsFileName(ref CurrentSavedFileName))
                {
                    SaveDocument(CurrentSavedFileName, SerializeDocument());
                }
                else
                {
                    MessageBox.Show("Save Cancelled");
                }
            }
        }

        private void saveasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GetSaveAsFileName(ref CurrentSavedFileName))
            {
                SaveDocument(CurrentSavedFileName, SerializeDocument());
            }
            else
            {
                MessageBox.Show("Save Cancelled");
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (GetLoadFileName(ref CurrentSavedFileName))
            {
                if(System.IO.File.Exists(CurrentSavedFileName)){
                    LoadDocument(CurrentSavedFileName);

                }

            }

        }
        private void LoadDocument(string filename)
        {
            string s = GetFileText(filename);

            //Stream s = new StreamReader(filename);
            
            //XmlReader r = System.Xml.XmlTextReader.Create(s);

            //XmlDocument d = new XmlDocument();
            
            
                
        }
        private bool GetLoadFileName(ref string filename)
        {
            OpenFileDialog o = new OpenFileDialog();
            o.DefaultExt = "xml";
            o.Filter = "XML document|*.xml|all Documents|*.*";
            o.AddExtension = true;
            o.CheckFileExists = true;
            o.Title = "Select filename to open";
            
            if(o.ShowDialog()==DialogResult.OK)
            {
                    filename=o.FileName;
                    return true;
            }
            else
            {
                    return false;
            }
        }

        private void cmdSqlTest_Click(object sender, EventArgs e)
        {
            txtOutputText.Text = "";
            
            DataTable t = DS.GetTable(lstTableSelected.Text);
            IQueryBuilder s = new SqlQueryBuilder();
            s.TableName = lstTableSelected.Text;
          
            s.Columns= t;
            try
            {
                s.PrimaryKey = DS.GetPrimaryKey(lstTableSelected.Text);
            }
            catch (Exception ex)
            {
                txtOutputText.Text = txtOutputText.Text + "\r\nWARNING: " + ex.Message;
            }
            
            try { txtOutputText.Text += "\r\nDelete :" + s.Delete(); }
            catch (Exception exa) { txtOutputText.Text = txtOutputText.Text + "\r\nError Generating Delete: " + exa.Message; }

            try { txtOutputText.Text += "\r\nInsert :" + s.Insert();}
            catch (Exception exb) { txtOutputText.Text = txtOutputText.Text + "\r\nError Generating Insert: " + exb.Message; }

            try { txtOutputText.Text += "\r\nExist  :" + s.Exist();}
            catch (Exception exc) { txtOutputText.Text = txtOutputText.Text + "\r\nError Generating Exist: " + exc.Message; }

            try { txtOutputText.Text += "\r\nUpdate :" + s.Update();}
            catch (Exception exd) { txtOutputText.Text = txtOutputText.Text + "\r\nError Generating Update: " + exd.Message; }           
        }

        private void cmdTestBuild_Click(object sender, EventArgs e)
        {
            string s = GenerateCode(lstTableSelected.Text);
            Form w = new frmOutput();
            w.Show();
            TextBox t = (TextBox)w.Controls[0];
            t.Text = s.Replace("\n","\r\n");
        }
        private string GetFileText(string FileName)
        {
            string retval;

            StreamReader R = new StreamReader(FileName);
            retval = R.ReadToEnd();
            return retval;
        }
        private string GenerateCore()
        {
            string OutputCodeText = "";
            string DBType = cmbDatabaseType.SelectedItem.ToString();
            string LangType = cmbOutputLanguage.SelectedItem.ToString();

            if (LangType == "C#")
            {
                switch (DBType)
                {
                    case "Sql Server":
                        OutputCodeText = GetFileText("C:\\Documents and Settings\\smuns631\\Desktop\\Courses\\CUS1159\\Workspace\\DataServiceGenerator\\DataServiceGenerator\\Templates\\CsharpSQLRoot.txt");
                        break;
                    case "Microsoft Access":
                        OutputCodeText = GetFileText("C:\\Documents and Settings\\smuns631\\Desktop\\Courses\\CUS1159\\Workspace\\DataServiceGenerator\\DataServiceGenerator\\Templates\\CsharpAccessRoot.txt");
                        break;
                    case "My Sql":
                        OutputCodeText = GetFileText("C:\\Documents and Settings\\smuns631\\Desktop\\Courses\\CUS1159\\Workspace\\DataServiceGenerator\\DataServiceGenerator\\Templates\\CsharpMySQLRoot.txt");
                        break;
                    default:
                        break;

                }
            }
            return OutputCodeText;
        }
        
        private string GenerateCode(string TableName)
        {
            string SelectedTableName = TableName;
            CodeBuilder_Classes.CodeBuilder Cbldr;

            DataTable Exemplar = DS.GetTable(SelectedTableName);
            PersistenceClasses.Table BuildConfig=null;
            foreach (Table t in Tables)
                if (t.Name == TableName)
                    BuildConfig = t;
            if (BuildConfig == null)
            {
                throw new Exception("Selected Table Not configured");
            }
            IQueryBuilder DbFacilitator = null;
            switch (cmbDatabaseType.Text)
            {
                case "Sql Server":
                    DbFacilitator = new SqlQueryBuilder();

                    break;
                case "Microsoft Access":
                    DbFacilitator = new AccessQueryBuilder();

                    break;
                case "My Sql":
                    DbFacilitator = new MySqlQueryBuilder();
                    break;
                default:
                    DbFacilitator = null;
                    MessageBox.Show("You have selected an invalid or unsupported database type. Please choose a valid selection and test again");
                    return "";
                    break;
            }
            foreach (Table t in Tables)
            {
                t.Fields.Clear();
                using (string s = t.Name)
                {
                    DataTable fdt = DS.GetTable(s);
                    foreach (DataRow dr in fdt)
                    {
                        using( ColumnDefintion cd = new ColumnDefintion()){
                            cd.ColumnName=dr[0].ToString();
                            cd.ColumnSize= DbFacilitator.SqlEncodingType(dr[1].ToString());
                            cd.ColumnSize=DbFacilitator.SqlEncodingSize(dr[2].ToString());
                            t.Fields.Add(cd);
                        }
                    }
                }
                
            }

            
            DbFacilitator.PrimaryKey = DS.GetPrimaryKey(SelectedTableName);
            DbFacilitator.TableName = SelectedTableName;
            DbFacilitator.Columns = Exemplar;

            switch (cmbOutputLanguage.SelectedItem.ToString())
            {
                case "C#":
                    Cbldr = new CSharpBuilder(Exemplar, BuildConfig, DbFacilitator);
                    break;
                case "Java":
                    Cbldr = new JavaBuilder(Exemplar, BuildConfig, DbFacilitator);
                    break;
                default:
                    throw new Exception("Please select a valid Output Language");
                    return "";
                    break;
            }
            try
            {
                Cbldr.Build();
            }
            catch (Exception ex)
            {
                txtOutputText.Text = txtOutputText.Text + "\r\n" + " An Error Occurred Building " + TableName + ": " + ex.Message;
            }
            return Cbldr.CodeText;
        }
        private void cmdBuildAll_Click(object sender, EventArgs e)
        {
            string s="";
            try
            {
                s = GenerateCore();
                foreach (Table tb in Tables)
                {
                    s = s + GenerateCode(tb.Name);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Form w = new frmOutput();
            w.Show();
            TextBox t = (TextBox)w.Controls[0];
            t.Text = s.Replace("\n", "\r\n");
        }

        private void ckConstructor_CheckedChanged(object sender, EventArgs e)
        {
            Table t = GetSelectedTable(lstTableSelected.Text);
            if (t != null)
            {
                t.generateConstructor = ckConstructor.Checked ? true : false;
            }
           
        }

        private void ckDelete_CheckedChanged(object sender, EventArgs e)
        {
            Table t = GetSelectedTable(lstTableSelected.Text);
            if (t != null)
            {
                t.generateDelete = ckDelete.Checked ? true : false;
            }
            
            
        }

        private void ckExists_CheckedChanged(object sender, EventArgs e)
        {
            Table t = GetSelectedTable(lstTableSelected.Text);
            if (t != null)
            {
                t.generateExists = ckExists.Checked ? true : false;
            }
           
        }

        private void ckInsert_CheckedChanged(object sender, EventArgs e)
        {
            Table t = GetSelectedTable(lstTableSelected.Text);
            if (t != null)
            {
                t.generateInsert = ckExists.Checked ? true : false;
            }
            
        }

        private void ckUpdate_CheckedChanged(object sender, EventArgs e)
        {
            Table t = GetSelectedTable(lstTableSelected.Text);
            if (t != null)
            {
                t.generateUpdate = ckExists.Checked ? true : false;
            }
         
        }

        private void ckSave_CheckedChanged(object sender, EventArgs e)
        {
            Table t = GetSelectedTable(lstTableSelected.Text);
            if (t != null)
            {
                t.generateSave = ckExists.Checked ? true : false;
            }

        }



        private void cmdAddTable_Click(object sender, EventArgs e)
        {
            if (cmdAddTable.Text == "Add Table")
            {
                Table t = new Table(txtTableName.Text, lstServers.Text);

                Tables.Add(t);

            }
            else
            {
                int t = -1;
                for (int i = 0; i < Tables.Count; i++)
                    if (Tables[i].Name == txtTableName.Text)
                        t = i;
                if (t != -1) Tables.Remove(Tables[t]);

            }
            UpdateEditPanel(txtTableName.Text);
        }    
        
    }
}
