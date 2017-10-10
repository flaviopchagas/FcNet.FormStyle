using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Forms;

namespace FcNet.TabMenu
{
    public partial class TabMenu : FlowLayoutPanel
    {
        public TabMenu()
        {
            TabItems.CollectionChanged += TabItems_CollectionChanged;
        }

        [Browsable(true), CategoryAttribute("Behavior"), DescriptionAttribute("TabItems")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ObservableCollection<TabItem> TabItems { get; } = new ObservableCollection<TabItem>();

        [Browsable(true), CategoryAttribute("Appearance"), DescriptionAttribute("TabItemAppearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TabItemAppearance TabItemAppearance { get; } = new TabItemAppearance();

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
                b.FlatStyle = TabItemAppearance.FlatStyle;
                b.BackColor = TabItemAppearance.BackColor;
                b.ForeColor = TabItemAppearance.ForeColor;
                b.FlatAppearance.MouseOverBackColor = TabItemAppearance.MouseOverBackColor;
                b.FlatAppearance.MouseDownBackColor = TabItemAppearance.MouseDownBackColor;
            }

            TabItem btn = (sender as TabItem);
            btn.FlatStyle = TabItemAppearance.FlatStyle;
            btn.BackColor = TabItemAppearance.CheckedBackColor;
            btn.FlatAppearance.MouseOverBackColor = TabItemAppearance.CheckedMouseOverBackColor;
            btn.ForeColor = TabItemAppearance.CheckedMouseOverForeColor;
            btn.FlatAppearance.BorderSize = TabItemAppearance.CheckedBorderSize;
        }
    }
}

