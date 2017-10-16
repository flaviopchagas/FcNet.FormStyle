using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;

namespace FcNet.FormStyle
{
    [DefaultProperty("TabItems")]
    public class TabbedMenu : FlowLayoutPanel
    {
        [Category("TabbedMenu"), Description("TabItems")]
        [Editor(typeof(ItemsCollectionEditor), typeof(UITypeEditor))]
        public ObservableCollection<TabItem> TabItems { get; } = new ObservableCollection<TabItem>();

        [Category("TabbedMenu"), Description("TabAppearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public TabItemAppearance TabAppearance { get; } = new TabItemAppearance();

        public TabbedMenu()
        {
            Controls.Clear();

            Size = new Size(320, 50);
            Margin = new Padding(0);
            Padding = new Padding(0);
            BackColor = ColorTranslator.FromHtml("#3C8DBC");
            ForeColor = ColorTranslator.FromHtml("#000000");

            TabItems.CollectionChanged += TabItems_CollectionChanged;

            for (int i = 0; i < 2; i++)
            {
                CreateButton();
            }

            TabItem_Click(TabItems[0], null);
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            TabItems.CollectionChanged -= TabItems_CollectionChanged;

            try
            {
                base.OnControlAdded(e);
                TabItem btn = (TabItem)e.Control;
                btn.Click += TabItem_Click;

                SetDefaultTheme(btn);

                if (!TabItems.Contains(btn))
                    TabItems.Add(btn);
            }
            catch (Exception)
            {
                Controls.Remove(e.Control);
                MessageBox.Show("Invalid control. Only Button is acceptable.");
            }
            finally { TabItems.CollectionChanged += TabItems_CollectionChanged; }
        }

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

        private void TabItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    TabItem btn = (TabItem)e.NewItems[0];
                    btn.Click += TabItem_Click;

                    if (!Controls.Contains(btn))
                        Controls.Add(btn);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    Controls.Remove((Control)e.NewItems[0]);
                    break;
                default:
                    break;
            }
        }

        private void TabItem_Click(object sender, EventArgs e)
        {
            foreach (TabItem b in Controls)
            {
                SetDefaultTheme(b);
            }

            TabItem btn = (sender as TabItem);
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = TabAppearance.CheckedBackColor;
            btn.FlatAppearance.MouseOverBackColor = TabAppearance.CheckedBackColor;
            btn.ForeColor = TabAppearance.CheckedForeColor;
            btn.FlatAppearance.BorderColor = TabAppearance.CheckedBorderColor;
            btn.FlatAppearance.BorderSize = TabAppearance.CheckedBorderSize;
        }

        private void CreateButton()
        {
            int total = TabItems.Count + 1;

            TabItem tb = new TabItem();
            tb.Name = $"tabItem{total}";
            tb.Text = $"tabItem{total}";

            SetDefaultTheme(tb);
            TabItems.Add(tb);
        }

        private void SetDefaultTheme(TabItem tb)
        {
            tb.FlatStyle = FlatStyle.Flat;
            tb.BackColor = TabAppearance.BackColor;
            tb.ForeColor = TabAppearance.ForeColor;
            tb.FlatAppearance.MouseOverBackColor = TabAppearance.MouseOverBackColor;
            tb.FlatAppearance.MouseDownBackColor = TabAppearance.MouseDownBackColor;
            tb.FlatAppearance.BorderSize = TabAppearance.CheckedBorderSize;
            tb.Size = TabAppearance.TabSize;
            tb.Margin = TabAppearance.Margin;
        }
    }
}

