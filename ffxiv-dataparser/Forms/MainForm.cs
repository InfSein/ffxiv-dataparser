using ffxiv_dataparser.Models;
using ffxiv_dataparser.Tools;

namespace ffxiv_dataparser.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var test = CsvParser.ReadCsv<CsvModels.Item>(@"D:\Final Fantasy\Experiments\Unpack\CHS\ffxiv-datamining-cn\Item.csv");
            Console.WriteLine("");
        }
    }
}

