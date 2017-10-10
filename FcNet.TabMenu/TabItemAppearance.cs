using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FcNet.TabMenu
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class TabItemAppearance
    {
        public override string ToString()
        {
            return "";
        }

        [Browsable(true), DefaultValue(typeof(FlatStyle), ""), EditorBrowsable(EditorBrowsableState.Always), NotifyParentProperty(true)]
        public FlatStyle FlatStyle { get; set; }

        [Browsable(true), DefaultValue(1), EditorBrowsable(EditorBrowsableState.Always), NotifyParentProperty(true)]
        public int BorderSize { get; set; }

        [Browsable(true), DefaultValue(typeof(Color), ""), EditorBrowsable(EditorBrowsableState.Always), NotifyParentProperty(true)]
        public Color BorderColor { get; set; }

        [Browsable(true), DefaultValue(typeof(Color), ""), EditorBrowsable(EditorBrowsableState.Always), NotifyParentProperty(true)]
        public Color MouseDownBackColor { get; set; }

        [Browsable(true), DefaultValue(typeof(Color), ""), EditorBrowsable(EditorBrowsableState.Always), NotifyParentProperty(true)]
        public Color MouseOverBackColor { get; set; }


        [Browsable(true), DefaultValue(typeof(Color), ""), EditorBrowsable(EditorBrowsableState.Always), NotifyParentProperty(true)]
        public Color CheckedBackColor { get; set; }

        [Browsable(true), DefaultValue(typeof(Color), ""), EditorBrowsable(EditorBrowsableState.Always), NotifyParentProperty(true)]
        public Color CheckedForeColor { get; set; }

        [Browsable(true), DefaultValue(typeof(Color), ""), EditorBrowsable(EditorBrowsableState.Always), NotifyParentProperty(true)]
        public Color CheckedMouseDownBackColor { get; set; }

        [Browsable(true), DefaultValue(typeof(Color), ""), EditorBrowsable(EditorBrowsableState.Always), NotifyParentProperty(true)]
        public Color CheckedMouseOverBackColor { get; set; }

        [Browsable(true), DefaultValue(typeof(Color), ""), EditorBrowsable(EditorBrowsableState.Always), NotifyParentProperty(true)]
        public Color CheckedMouseOverForeColor { get; set; }

        [Browsable(true), DefaultValue(1), EditorBrowsable(EditorBrowsableState.Always), NotifyParentProperty(true)]
        public int CheckedBorderSize { get; set; }


        [Browsable(true), DefaultValue(typeof(Color), ""), EditorBrowsable(EditorBrowsableState.Always), NotifyParentProperty(true)]
        public Color BackColor { get; set; }

        [Browsable(true), DefaultValue(typeof(Color), ""), EditorBrowsable(EditorBrowsableState.Always), NotifyParentProperty(true)]
        public Color ForeColor { get; set; }
    }
}
