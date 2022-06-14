using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HttpClientWhioutSSL
{
    public partial class Form1 : Form
    {
        private RequestHttp _requestHttp = new RequestHttp();
        private int valueIncrement = 0;

        public Form1()
        {
            InitializeComponent();

            this.AddHttpMethod();
        }

        private void AddHttpMethod()
        {
            IList<TypeHttpMethod> typesHttpMethod = Enum.GetValues(typeof(TypeHttpMethod)).Cast<TypeHttpMethod>().ToList<TypeHttpMethod>();
            IList<MethodHttp> methodsList = new List<MethodHttp>();
            foreach(TypeHttpMethod eachMethod in typesHttpMethod)
            {
                methodsList.Add(new MethodHttp(eachMethod));
            }

            this.cbHttpMethod.DataSource = methodsList;
            this.cbHttpMethod.DisplayMember = "LabelMethod";
            this.cbHttpMethod.ValueMember = "ValueMathod";
        }

        private void btnRequest_Click(object sender, EventArgs e)
        {
            RestartRequest();
            this.IncrementProgress();
            string address = this.txtUrl.Text;
            this.DoRequest(address);
        }

        private async void DoRequest(string url)
        {
            try
            {
                this.IncrementProgress();
                TypeHttpMethod typeHttpMethod = this.GetHttpMethodInComboBox();
                this.IncrementProgress();
                string datasToSend = this.GetDatasToSend();
                this.IncrementProgress();
                string responseHttp = await this._requestHttp.DoRequest(url, datasToSend, typeHttpMethod);
                this.FnishIncrementProgress();
                this.txtResponse.Text = responseHttp;
            }
            catch (Exception)
            {
                this.FnishIncrementProgress();
                MessageBox.Show("Selecione um método", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetDatasToSend()
        {
            if (String.IsNullOrWhiteSpace(this.txtDataJson.Text))
                return null;

            return this.txtDataJson.Text;
        }

        private TypeHttpMethod GetHttpMethodInComboBox()
        {
            try
            {
                MethodHttp methodHttp = (MethodHttp)this.cbHttpMethod.SelectedItem;
                return methodHttp.ValueMathod;
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        private void RestartRequest()
        {
            this.progressResponse.Increment(-100);
            this.txtResponse.Text = "";
        }

        public void IncrementProgress()
        {
            if(this.valueIncrement < 80)
            {
                this.valueIncrement += 10;
                this.progressResponse.Increment(10);
            }            
        }

        public void FnishIncrementProgress()
        {
            this.progressResponse.Value = 100;
        }

        private void cbHttpMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            TypeHttpMethod typeSelected = this.GetHttpMethodInComboBox();

            if (typeSelected == TypeHttpMethod.GET)
                this.txtDataJson.Enabled = false;
            else
                this.txtDataJson.Enabled = true;
        }
    }
}
