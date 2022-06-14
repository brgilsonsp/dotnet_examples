using System;

using System.Data.Odbc;
using System.Windows.Forms;
using System.Data;


namespace ODBCViewer
{
    public partial class AppMainForm : Form
    {
        public OdbcConnection connection;
        public OdbcCommand command;
        public OdbcDataAdapter dataAdapter;

        public string GetHost { get { return txtHost.Text; } }
        public string GetDatabase { get { return txtDatabase.Text; } }
        public string GetUsername { get { return txtUsername.Text; } }
        public string GetPassword { get { return txtPassword.Text; } }
        public string GetCommand { get { return txtSql.Text; } }
        public string GetSql { get { return txtSql.Text; } }       

        public bool AllRight
        {
            get
            {
                if (string.IsNullOrEmpty(GetHost) || string.IsNullOrEmpty(GetDatabase) || string.IsNullOrEmpty(GetUsername) || string.IsNullOrEmpty(GetPassword) || string.IsNullOrEmpty(GetCommand))
                    return false;

                return true;
            }

        }

        public AppMainForm()
        {
            InitializeComponent();
        }

        private void AppMainForm_Load(object sender, EventArgs e)
        {

        }

        private void btRun_Click(object sender, EventArgs e)
        {
            if (!AllRight)
            {
                MessageBox.Show("É necessario preencher todos os campos!");
                return;
            }

            try
            {
                connection = new OdbcConnection();
                command = new OdbcCommand(GetSql);

                connection.ConnectionString
                = "Dsn=upstreamCMS;"
                + "Host=" + GetHost + ";"
                + "Database=" + GetDatabase + ";"
                + "Uid=" + GetUsername + ";"
                + "Pwd=" + GetPassword + ";"
                ;

                command.Connection = connection;

                connection.Open();

                dataAdapter = new OdbcDataAdapter(command);

                DataTable table = new DataTable();

                dataAdapter.Fill(table);

                dataGridViewer.DataSource = table;

                //for (int ordinal = 0; ordinal < result.FieldCount; ordinal++)
                //    Console.WriteLine("Field {0}: {1} >> {2}", ordinal, result.GetName(ordinal), result[result.GetName(ordinal)].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
