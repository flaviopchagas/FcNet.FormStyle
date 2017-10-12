using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FcNet.TabMenu
{
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class TabItemAppearance
    {
        public override string ToString() { return ""; }

        //Default State
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), NotifyParentProperty(true)]
        public Size TabSize { get; set; } = new Size(75, 33);

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), NotifyParentProperty(true)]
        public Color BackColor { get; set; } = ColorTranslator.FromHtml("#3C8DBC");

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), NotifyParentProperty(true)]
        public Color ForeColor { get; set; } = ColorTranslator.FromHtml("#E8ECF1");

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), NotifyParentProperty(true)]
        public Padding Margin { get; set; } = new Padding(2, 10, 0, 0);

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), NotifyParentProperty(true)]
        public int BorderSize { get; set; } = 0;

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), NotifyParentProperty(true)]
        public Color BorderColor { get; set; } = Color.Transparent;

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), NotifyParentProperty(true)]
        public Color MouseDownBackColor { get; set; } = ColorTranslator.FromHtml("#3C8DBC");

        [Browsable(true), DefaultValue(typeof(Color), "Color.DodgerBlue"), EditorBrowsable(EditorBrowsableState.Always), NotifyParentProperty(true)]
        public Color MouseOverBackColor { get; set; } = ColorTranslator.FromHtml("#124078");

        //Selected
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), NotifyParentProperty(true)]
        public Color CheckedBackColor { get; set; } = ColorTranslator.FromHtml("#F1F1F1");

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), NotifyParentProperty(true)]
        public Color CheckedForeColor { get; set; } = ColorTranslator.FromHtml("#2B579A");

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), NotifyParentProperty(true)]
        public Color CheckedMouseDownBackColor { get; set; } = ColorTranslator.FromHtml("#F1F1F1");

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), NotifyParentProperty(true)]
        public Color CheckedMouseOverBackColor { get; set; } = ColorTranslator.FromHtml("#F1F1F1");

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), NotifyParentProperty(true)]
        public Color CheckedMouseOverForeColor { get; set; } = ColorTranslator.FromHtml("#2B579A");

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), NotifyParentProperty(true)]
        public int CheckedBorderSize { get; set; } = 0;
    }
}
