using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Forms;

namespace FcNet.TabMenu
{
    public partial class TabMenu : FlowLayoutPanel
    {
        public TabMenu() { TabItems.CollectionChanged += TabItems_CollectionChanged; }

        [Browsable(true), Category("TabMenu"), Description("TabItems")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public ObservableCollection<TabItem> TabItems { get; } = new ObservableCollection<TabItem>();

        [Browsable(true), Category("TabMenu"), Description("TabAppearance"), DefaultValue(typeof(string), "")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TabItemAppearance TabAppearance { get; } = new TabItemAppearance();

        protected override void OnControlRemoved(ControlEventArgs e)
        {
            TabItems.CollectionChanged -= TabItems_CollectionChanged;
            try
            {
                base.OnControlRemoved(e);
                TabItems.Remove((TabItem)e.Control);
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
                TabItem btn = (TabItem)e.Control;
                btn.Click += Tab_Click;

                TabItems.Add(btn);
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
                    TabItem btn = (TabItem)e.NewItems[0];
                    btn.Click += Tab_Click;
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
            foreach (TabItem b in Controls)
            {
                b.FlatStyle = TabAppearance.FlatStyle;
                b.BackColor = TabAppearance.BackColor;
                b.ForeColor = TabAppearance.ForeColor;
                b.FlatAppearance.MouseOverBackColor = TabAppearance.MouseOverBackColor;
                b.FlatAppearance.MouseDownBackColor = TabAppearance.MouseDownBackColor;
            }

            TabItem btn = (sender as TabItem);
            btn.FlatStyle = TabAppearance.FlatStyle;
            btn.BackColor = TabAppearance.CheckedBackColor;
            btn.FlatAppearance.MouseOverBackColor = TabAppearance.CheckedMouseOverBackColor;
            btn.ForeColor = TabAppearance.CheckedMouseOverForeColor;
            btn.FlatAppearance.BorderSize = TabAppearance.CheckedBorderSize;
        }
    }
}

