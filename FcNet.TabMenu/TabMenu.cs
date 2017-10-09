using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace FcNet.TabMenu
{
    public partial class TabMenu : FlowLayoutPanel
    {
        public TabMenu()
        {
            TabItems.CollectionChanged += TabItems_CollectionChanged;
        }

        private ObservableCollection<Button> _tabItems = new ObservableCollection<Button>();

        #region General Config

        [Category("TabMenu"), Description("TabItems"), MergableProperty(false), Bindable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ObservableCollection<Button> TabItems { get { return _tabItems; } }

        [Category("TabMenu"), Description("TabSize"), MergableProperty(false), Bindable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Size TabSize { get; set; } = new Size(75, 50);

        [Category("TabMenu"), Description("TabMargin"), MergableProperty(false), Bindable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Padding TabMargin { get; set; } = new Padding(3);

        [Category("TabMenu"), Description("TabBorderColor"), MergableProperty(false), Bindable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Color TabBorderColor { get; set; } = Color.White;

        [Category("TabMenu"), Description("TabMargin"), MergableProperty(false), Bindable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public int TabBorderSize { get; set; } = 0;

        [Category("TabMenu"), Description("TabMargin"), MergableProperty(false), Bindable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public FlatStyle TabFlatStyle { get; set; } = FlatStyle.Flat;

        #endregion

        #region TabBackColor

        [Category("TabApperance"), Description("TabBackColor"), MergableProperty(false), Bindable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Color TabBackColor { get; set; } = Color.Gainsboro;

        [Category("TabApperance"), Description("TabMouseOverBackColor"), MergableProperty(false), Bindable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Color TabMouseOverBackColor { get; set; }

        [Category("TabApperance"), Description("TabMouseDownBackColor"), MergableProperty(false), Bindable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Color TabMouseDownBackColor { get; set; }

        [Category("TabApperance"), Description("TabActiveBackColor"), MergableProperty(false), Bindable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Color TabActiveBackColor { get; set; } = Color.Silver;

        [Category("TabApperance"), Description("TabActiveMouseOverBackColor"), MergableProperty(false), Bindable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Color TabActiveMouseOverBackColor { get; set; }

        [Category("TabApperance"), Description("TabAciveMouseDownBackColor"), MergableProperty(false), Bindable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Color TabAciveMouseDownBackColor { get; set; }

        #endregion

        #region TabForeColor

        [Category("TabApperance"), Description("TabBackColor"), MergableProperty(false), Bindable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Color TabForeColor { get; set; }

        [Category("TabApperance"), Description("TabMouseOverForeColor"), MergableProperty(false), Bindable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Color TabMouseOverForeColor { get; set; }

        [Category("TabApperance"), Description("TabMouseDownForeColor"), MergableProperty(false), Bindable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Color TabMouseDownForeColor { get; set; }

        [Category("TabApperance"), Description("TabActiveForeColor"), MergableProperty(false), Bindable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Color TabActiveForeColor { get; set; }

        [Category("TabApperance"), Description("TabActiveMouseOverForeColor"), MergableProperty(false), Bindable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Color TabActiveMouseOverForeColor { get; set; }

        [Category("TabApperance"), Description("TabAciveMouseDownForeColor"), MergableProperty(false), Bindable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Color TabAciveMouseDownForeColor { get; set; }

        #endregion

        protected override void OnControlRemoved(ControlEventArgs e)
        {
            TabItems.CollectionChanged -= TabItems_CollectionChanged;
            try
            {
                base.OnControlRemoved(e);
                TabItems.Remove((Button)e.Control);
            }
            catch (Exception) { }
            finally { TabItems.CollectionChanged += TabItems_CollectionChanged; }
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            TabItems.CollectionChanged -= TabItems_CollectionChanged;
            try
            {
                base.OnControlAdded(e);

                Button btn = (Button)e.Control;
                btn.Click += Tab_Click;

                btn.BackColor = TabBackColor;
                btn.ForeColor = TabForeColor;

                btn.FlatAppearance.BorderColor = TabBorderColor;
                btn.FlatAppearance.BorderSize = TabBorderSize;

                TabItems.Add((Button)e.Control);
            }
            catch (Exception)
            {
                Controls.Remove(e.Control);
                MessageBox.Show("Invalid control. Only Button is acceptable.");
            }
            finally { TabItems.CollectionChanged += TabItems_CollectionChanged; }
        }

        private void TabItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    Button btn = (Button)e.NewItems[0];
                    btn.Click += Tab_Click;

                    btn.FlatStyle = TabFlatStyle;

                    btn.BackColor = TabBackColor;
                    btn.ForeColor = TabForeColor;

                    btn.FlatAppearance.BorderColor = TabBorderColor;
                    btn.FlatAppearance.BorderSize = TabBorderSize;

                    btn.Size = TabSize;

                    Controls.Add(btn);

                    break;
                case NotifyCollectionChangedAction.Remove:
                    Controls.Remove((Control)e.NewItems[0]);
                    break;
                default:
                    break;
            }
        }

        private void Tab_Click(object sender, EventArgs e)
        {
            foreach (Button b in Controls)
            {
                b.FlatAppearance.MouseOverBackColor = TabMouseOverBackColor;
                b.ForeColor = TabMouseOverForeColor;
                b.FlatAppearance.MouseDownBackColor = TabMouseDownBackColor;
                b.BackColor = TabBackColor;
            }

            Button btn = (sender as Button);

            btn.FlatStyle = FlatStyle.Flat;

            btn.BackColor = TabActiveBackColor;
            btn.FlatAppearance.MouseOverBackColor = TabActiveMouseOverBackColor;
            btn.ForeColor = TabActiveForeColor;
            btn.FlatAppearance.BorderSize = TabBorderSize;
        }
    }
}

