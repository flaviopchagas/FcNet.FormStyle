using System;
using System.Drawing;
using System.Windows.Forms;

namespace FcNet.DataGrid
{
    internal class DataGridConfig
    {
        private DataGridView dgv = null;

        public DataGridConfig(DataGridView dataGrid)
        {
            dgv = dataGrid;

            ApplyGridTheme();
            SetGridRowHeader();
        }

        private DataGridViewCellStyle dateCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight };

        private DataGridViewCellStyle amountCellStyle = new DataGridViewCellStyle
        {
            Alignment = DataGridViewContentAlignment.MiddleRight,
            Format = "N2"
        };

        private DataGridViewCellStyle gridCellStyle = new DataGridViewCellStyle
        {
            Alignment = DataGridViewContentAlignment.MiddleLeft,
            BackColor = Color.FromArgb(Convert.ToInt32(Convert.ToByte(79)), Convert.ToInt32(Convert.ToByte(129)), Convert.ToInt32(Convert.ToByte(189))),
            Font = new Font("Segoe UI", 10f, FontStyle.Regular, GraphicsUnit.Point, Convert.ToByte(0)),
            ForeColor = SystemColors.ControlLightLight,
            SelectionBackColor = SystemColors.Highlight,
            SelectionForeColor = SystemColors.HighlightText,
            WrapMode = DataGridViewTriState.True
        };

        private DataGridViewCellStyle gridCellStyle2 = new DataGridViewCellStyle
        {
            Alignment = DataGridViewContentAlignment.MiddleLeft,
            BackColor = SystemColors.ControlLightLight,
            Font = new Font("Segoe UI", 10f, FontStyle.Regular, GraphicsUnit.Point, Convert.ToByte(0)),
            ForeColor = SystemColors.ControlText,
            SelectionBackColor = Color.FromArgb(Convert.ToInt32(Convert.ToByte(155)), Convert.ToInt32(Convert.ToByte(187)), Convert.ToInt32(Convert.ToByte(89))),
            SelectionForeColor = SystemColors.HighlightText,
            WrapMode = DataGridViewTriState.False
        };

        private DataGridViewCellStyle gridCellStyle3 = new DataGridViewCellStyle
        {
            Alignment = DataGridViewContentAlignment.MiddleLeft,
            BackColor = Color.Lavender,
            Font = new Font("Segoe UI", 10f, FontStyle.Regular, GraphicsUnit.Point, Convert.ToByte(0)),
            ForeColor = SystemColors.WindowText,
            SelectionBackColor = Color.FromArgb(Convert.ToInt32(Convert.ToByte(155)), Convert.ToInt32(Convert.ToByte(187)), Convert.ToInt32(Convert.ToByte(89))),
            SelectionForeColor = SystemColors.HighlightText,
            WrapMode = DataGridViewTriState.True
        };

        private void ApplyGridTheme()
        {
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.BackgroundColor = SystemColors.Window;
            dgv.BorderStyle = BorderStyle.None;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.ColumnHeadersDefaultCellStyle = gridCellStyle;
            dgv.ColumnHeadersHeight = 32;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.DefaultCellStyle = gridCellStyle2;
            dgv.EnableHeadersVisualStyles = false;
            dgv.GridColor = SystemColors.GradientInactiveCaption;
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = true;
            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.RowHeadersDefaultCellStyle = gridCellStyle3;
            dgv.Font = gridCellStyle.Font;
        }

        public void SetGridRowHeader(bool hSize = false)
        {
            dgv.TopLeftHeaderCell.Value = "NO ";
            dgv.TopLeftHeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders);

            foreach (DataGridViewColumn cCol in dgv.Columns)
            {
                if (cCol.ValueType == typeof(DateTime))
                {
                    cCol.DefaultCellStyle = dateCellStyle;
                }
                else if (cCol.ValueType == typeof(decimal) | cCol.ValueType == typeof(double))
                {
                    cCol.DefaultCellStyle = amountCellStyle;
                }
            }
            if (hSize)
            {
                dgv.RowHeadersWidth = dgv.RowHeadersWidth + 16;
            }

            dgv.AutoResizeColumns();
        }

        public void rowPostPaint_HeaderCount(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            //set rowheader count
            DataGridView grid = (DataGridView)sender;
            string rowIdx = (e.RowIndex + 1).ToString();
            dynamic centerFormat = new StringFormat();

            centerFormat.Alignment = StringAlignment.Center;
            centerFormat.LineAlignment = StringAlignment.Center;

            Rectangle headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height - grid.Rows[e.RowIndex].DividerHeight);
            e.Graphics.DrawString(rowIdx, grid.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }
    }
}
