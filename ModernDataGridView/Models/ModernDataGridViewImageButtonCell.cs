using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernDataGridView.Models
{
    public class ModernDataGridViewImageButtonCell : ModernDataGridViewCell
    {
        public Action OnClick { get; set; }
    }
}
