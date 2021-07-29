using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernDataGridView.Models
{
    public class ModernDataGridViewDataSource
    {
        public List<ModernDataGridViewColumn> Columns { get; set; }

        public DataGridViewAutoSizeColumnsMode AutoSizeColumnsMode { get; set; }

        public List<ModernDataGridViewRow> Rows { get; set; }

        public Color BackgroundColor { get; set; }

        public Color HeadersBackgroundColor { get; set; }

        public float HeadersFontSize { get; set; }

        public Color HeadersFontColor { get; set; }

        public string FontFamily { get; set; }

        public float FontSize { get; set; }

        public Color AlternateRowBackgroundColor { get; set; }
        
        public Color AlternateRowFontColor { get; set; }

        public bool ShowFirstColumn { get; set; }

        public bool ReadOnly { get; set; }

        public ModernDataGridViewDataSource()
        {
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            BackgroundColor = Color.White;
            HeadersBackgroundColor = Color.Navy;
            HeadersFontColor = Color.White;
            FontFamily = "Calibri";
            FontSize = 8.75f;
            HeadersFontSize = 8.75f;
            AlternateRowBackgroundColor = Color.LightSteelBlue;
            AlternateRowFontColor = Color.Black;
            ShowFirstColumn = false;
            ReadOnly = true;
        }
    }
}
