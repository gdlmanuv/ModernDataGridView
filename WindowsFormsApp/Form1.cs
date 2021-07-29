using ModernDataGridView.Enumerations;
using ModernDataGridView.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp.Properties;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        private Random _random;
        private ModernDataGridViewDataSource _dataSource;

        public Form1()
        {
            InitializeComponent();
            _random = new Random();
            GetInitialDataSource();
            ucModernDataGridView.Initialize(_dataSource);
        }

        private void GetInitialDataSource()
        {
            _dataSource = new ModernDataGridViewDataSource
            {
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                Columns = new List<ModernDataGridViewColumn>
                {
                    new ModernDataGridViewColumn
                    {
                        ColumnIndex = 0,
                        Header = "App Name"
                    },
                    new ModernDataGridViewColumn
                    {
                        ColumnIndex = 1,
                        Header = "Web Site"
                    },
                    new ModernDataGridViewColumn
                    {
                        ColumnIndex = 2,
                        Header = "App Pool"
                    },
                    new ModernDataGridViewColumn
                    {
                        ColumnIndex = 3,
                        Header = "Instance Type"
                    },
                    new ModernDataGridViewColumn
                    {
                        ColumnIndex = 4,
                        Header = "Port"
                    },
                    new ModernDataGridViewColumn
                    {
                        ColumnIndex = 5,
                        Header = "Protocol"
                    },
                    new ModernDataGridViewColumn
                    {
                        ColumnIndex = 6,
                        Header = "URL"
                    },
                    new ModernDataGridViewColumn
                    {
                        ColumnIndex = 7,
                        Header = "Web Site Status"
                    },
                    new ModernDataGridViewColumn
                    {
                        ColumnIndex = 8,
                        Header = "App Pool Status"
                    },
                    new ModernDataGridViewColumn
                    {
                        ColumnIndex = 9,
                        Header = "Updates Status"
                    },
                    new ModernDataGridViewColumn
                    {
                        ColumnIndex = 10,
                        Header = "Uninstall"
                    }
                },
                Rows = new List<ModernDataGridViewRow>
                {
                    CreateModernDataGridViewRow(),
                    CreateModernDataGridViewRow(),
                    CreateModernDataGridViewRow(),
                    CreateModernDataGridViewRow(),
                    CreateModernDataGridViewRow()
                }
            };
            //_dataSource.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //_dataSource.HeadersBackgroundColor = Color.Silver;
            //_dataSource.HeadersFontColor = Color.Navy;
            //_dataSource.HeadersFontSize = 10f;
            //_dataSource.FontSize = 10f;
            //_dataSource.FontFamily = "Arial";
            //_dataSource.AlternateRowBackgroundColor = Color.Gainsboro;
            //_dataSource.AlternateRowFontColor = Color.Black;
            //_dataSource.ShowFirstColumn = false;
            //_dataSource.ReadOnly = true;
        }

        private ModernDataGridViewRow CreateModernDataGridViewRow()
        {
            var appName = $"FFWCTST001{_random.Next(1000)}";
            var row = new ModernDataGridViewRow
            {
                Cells = new List<ModernDataGridViewCell>
                {
                    new ModernDataGridViewCell
                    {
                        ColumnIndex = 0,
                        Value = appName
                    },
                    new ModernDataGridViewCell
                    {
                        ColumnIndex = 1,
                        Value = $"FFWCTST001{_random.Next(1000)}"
                    },
                    new ModernDataGridViewCell
                    {
                        ColumnIndex = 2,
                        Value = $"FFWCTST001{_random.Next(1000)}"
                    },
                    new ModernDataGridViewCell
                    {
                        ColumnIndex = 3,
                        Value = "Development"
                    },
                    new ModernDataGridViewCell
                    {
                        ColumnIndex = 4,
                        Value = 80
                    },
                    new ModernDataGridViewCell
                    {
                        ColumnIndex = 5,
                        Value = "http"
                    },
                    new ModernDataGridViewCell
                    {
                        ColumnIndex = 6,
                        CellType = ModernDataGridViewCellType.Link,
                        Value = "https://www.google.com"
                    },
                    new ModernDataGridViewCell
                    {
                        ColumnIndex = 7,
                        CellType = ModernDataGridViewCellType.Image,
                        Value = Resources.ResourceManager.GetObject("GreenBullet")
                    },
                    new ModernDataGridViewCell
                    {
                        ColumnIndex = 8,
                        CellType = ModernDataGridViewCellType.Image,
                        Value = Resources.ResourceManager.GetObject("YellowBullet")
                    },
                    new ModernDataGridViewCell
                    {
                        ColumnIndex = 9,
                        CellType = ModernDataGridViewCellType.Image,
                        Value = Resources.ResourceManager.GetObject("RedBullet")
                    },
                    new ModernDataGridViewImageButtonCell
                    {
                        ColumnIndex = 10,
                        CellType = ModernDataGridViewCellType.ImageButton,
                        Value = Resources.ResourceManager.GetObject("TrashIcon"),
                    },
                }
            };

            (row.Cells[10] as ModernDataGridViewImageButtonCell).OnClick = () =>
            {
                if (MessageBox.Show($"Do you really want to delete {appName}", "Delete web application?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _dataSource.Rows.Remove(row);
                    ucModernDataGridView.Refresh();
                }
            };

            return row;
        }

        private void btnAddRecord_Click(object sender, EventArgs e)
        {
            _dataSource.Rows.Add(CreateModernDataGridViewRow());
            ucModernDataGridView.Refresh();
        }
    }
}
