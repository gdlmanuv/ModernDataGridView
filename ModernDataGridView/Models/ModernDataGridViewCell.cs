using ModernDataGridView.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernDataGridView.Models
{
    public class ModernDataGridViewCell
    {
        public int ColumnIndex { get; set; }

        public ModernDataGridViewCellType CellType { get; set; }

        public object Value { get; set; }

        public ModernDataGridViewCell()
        {
            CellType = ModernDataGridViewCellType.Text;
        }
    }
}
