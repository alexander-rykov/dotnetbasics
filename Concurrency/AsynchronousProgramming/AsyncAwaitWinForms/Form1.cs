using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncAwaitWinForms
{
    public partial class Form1 : Form
    {
        public class Service
        {
            public async Task<ServiceData> DoSomething()
            {
                #region GetServiceData implementation

                await Task.Delay(100);

                return new ServiceData
                {
                    MyName = "Windows Forms"
                };

                #endregion
            }
        }

        public class ServiceData
        {
            public string MyName { get; set; }
        }

        private readonly Service _service = new Service();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var task = _service.DoSomething();
            textBox1.Text = task.Result.MyName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var task = _service.DoSomething();
            task.Wait();
            textBox1.Text = task.Result.MyName;
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            var data = await _service.DoSomething();
            textBox1.Text = data.MyName;
        }
    }
}
