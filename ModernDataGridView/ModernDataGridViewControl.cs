using ModernDataGridView.Models;
using ModernDataGridView.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModernDataGridView
{
    public partial class ModernDataGridViewControl : UserControl
    {
        private ModernDataGridViewDataSource _dataSource;

        public ModernDataGridViewControl()
        {
            InitializeComponent();

            dgvControl.CellContentClick += (o, e) =>
            {
                if (e.RowIndex > -1)
                {
                    if (dgvControl.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewLinkCell)
                    {
                        Process.Start(dgvControl.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }

                    if(((ModernDataGridViewCell)dgvControl.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag)?.CellType == Enumerations.ModernDataGridViewCellType.ImageButton)
                    {
                        var cell = (ModernDataGridViewImageButtonCell)dgvControl.Rows[e.RowIndex].Cells[e.ColumnIndex].Tag;
                        cell.OnClick();
                    }
                }
            };
        }

        public void Initialize(ModernDataGridViewDataSource dataSource)
        {
            _dataSource = dataSource;
            ThrowExceptionIfDataSourceIsNullOrEmpty();
            FillDataGridViewControlColumns();
            ThrowExceptionWhenAnyRowContainsMoreOrLessCellsThanPreDefinedColumns();
            GenerateRowsAndCells();

            dgvControl.AutoSizeColumnsMode = dataSource.AutoSizeColumnsMode;
            dgvControl.AllowUserToAddRows = false;
            dgvControl.AllowUserToDeleteRows = false;

            dgvControl.DefaultCellStyle.Font = new Font(_dataSource.FontFamily, _dataSource.FontSize);
            dgvControl.BackgroundColor = _dataSource.BackgroundColor;
            dgvControl.AlternatingRowsDefaultCellStyle.BackColor = _dataSource.AlternateRowBackgroundColor;
            dgvControl.AlternatingRowsDefaultCellStyle.ForeColor = _dataSource.AlternateRowFontColor;
            dgvControl.ColumnHeadersDefaultCellStyle.BackColor = _dataSource.HeadersBackgroundColor;
            dgvControl.ColumnHeadersDefaultCellStyle.ForeColor = _dataSource.HeadersFontColor;
            dgvControl.ColumnHeadersDefaultCellStyle.Font = new Font(_dataSource.FontFamily, _dataSource.HeadersFontSize);
            dgvControl.RowHeadersVisible = _dataSource.ShowFirstColumn;
            dgvControl.EnableHeadersVisualStyles = false;
            dgvControl.ReadOnly = _dataSource.ReadOnly;



        }

        public override void Refresh()
        {
            dgvControl.Rows.Clear();
            GenerateRowsAndCells();
        }

        private void GenerateRowsAndCells()
        {
            _dataSource.Rows.ForEach(r =>
            {
                var dataGridViewRow = new DataGridViewRow();

                r.Cells.OrderBy(c => c.ColumnIndex).ToList().ForEach(c =>
                {
                    switch (c.CellType)
                    {
                        case Enumerations.ModernDataGridViewCellType.Link:
                            CreateDataGridViewLinkCell(c, dataGridViewRow);
                            break;

                        case Enumerations.ModernDataGridViewCellType.Image:
                            CreateDataGridViewImageCell(c, dataGridViewRow);
                            break;

                        case Enumerations.ModernDataGridViewCellType.ImageButton:
                            var cell = new DataGridViewImageCell
                            {
                                Tag = c,
                                Value = c.Value
                            };

                            cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                            dataGridViewRow.Cells.Add(cell);

                            break;

                        default:
                            CreateDataGridViewTextBoxCell(c, dataGridViewRow);
                            break;
                    }

                });

                dgvControl.Rows.Add(dataGridViewRow);
            });
        }

        private void CreateDataGridViewTextBoxCell(ModernDataGridViewCell c, DataGridViewRow dataGridViewRow)
        {
            dataGridViewRow.Cells.Add(new DataGridViewTextBoxCell
            {
                Value = c.Value
            });
        }

        private void CreateDataGridViewImageCell(ModernDataGridViewCell c, DataGridViewRow dataGridViewRow)
        {
            var cell = new DataGridViewImageCell
            {
                Value = c.Value
            };

            cell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dataGridViewRow.Cells.Add(cell);
        }

        private void CreateDataGridViewLinkCell(ModernDataGridViewCell c, DataGridViewRow dataGridViewRow)
        {
            dataGridViewRow.Cells.Add(new DataGridViewLinkCell
            {
                Value = c.Value,
            });
        }

        private void ThrowExceptionIfDataSourceIsNullOrEmpty()
        {
            if (_dataSource == default)
                throw new Exception("dataSource cannot be empty.");
        }

        private void FillDataGridViewControlColumns()
        {
            _dataSource.Columns.ForEach(c =>
            {
                dgvControl.Columns.Add(c.Header, c.Header);
            });
        }

        private void ThrowExceptionWhenAnyRowContainsMoreOrLessCellsThanPreDefinedColumns()
        {
            _dataSource.Rows.ForEach(r =>
            {
                if (r.Cells.Count != _dataSource.Columns.Count)
                    throw new Exception($"The amount of cells in a row cannot be different than the amount of columns in data source. Row {_dataSource.Rows.IndexOf(r)}");
            });
        }
    }
}
