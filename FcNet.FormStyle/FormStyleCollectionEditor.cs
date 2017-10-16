using System;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace FcNet.FormStyle
{

    public class NotifyingCollectionEditor : CollectionEditor
    {
        // Define a static event to expose the inner PropertyGrid's PropertyValueChanged event args...
        public static event EventHandler<PropertyValueChangedEventArgs> ElementChanged;

        // Inherit the default constructor from the standard Collection Editor...
        public NotifyingCollectionEditor(Type type) : base(type) { }

        // Override this method in order to access the containing user controls from the default Collection Editor form or to add new ones...
        protected override CollectionForm CreateCollectionForm()
        {
            // Getting the default layout of the Collection Editor...
            CollectionForm collectionForm = base.CreateCollectionForm();
            Form frmCollectionEditorForm = collectionForm as Form;
            TableLayoutPanel tlpLayout = frmCollectionEditorForm.Controls[0] as TableLayoutPanel;

            if (tlpLayout != null)
            {
                // Get a reference to the inner PropertyGrid and hook an event handler to it.
                if (tlpLayout.Controls[5] is PropertyGrid)
                {
                    PropertyGrid propertyGrid = tlpLayout.Controls[5] as PropertyGrid;
                    propertyGrid.PropertyValueChanged += new PropertyValueChangedEventHandler(propertyGrid_PropertyValueChanged);
                }
            }

            return collectionForm;
        }

        protected override object SetItems(object editValue, object[] value)
        {
            object ret_val = base.SetItems(editValue, value);

            // Fire our customized collection event...
            var evt = NotifyingCollectionEditor.ElementChanged;

            if (evt != null)
                evt(this, null);

            return ret_val;
        }

        void propertyGrid_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
        {
            // Fire our customized collection event...
            var evt = ElementChanged;

            if (evt != null)
                evt(this, e);
        }
    }


    //public class FormStyleCollectionEditor : CollectionEditor
    //{
    //    public delegate void PropertyValueChangedEventHandler(object sender, PropertyValueChangedEventArgs e);

    //    public static event PropertyValueChangedEventHandler PropertyValueChanged;

    //    public FormStyleCollectionEditor(Type type) : base(type) { }

    //    protected override CollectionForm CreateCollectionForm()
    //    {
    //        CollectionForm cf = base.CreateCollectionForm();

    //        Form cef = cf as Form;
    //        TableLayoutPanel tlp = cef.Controls[0] as TableLayoutPanel;

    //        if (tlp != null)
    //        {
    //            if (tlp.Controls[5] is PropertyGrid)
    //            {
    //                PropertyGrid pg = tlp.Controls[5] as PropertyGrid;
    //                pg.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(PropertyGrid_PropertyValueChanged);
    //            }
    //        }

    //        return cf;
    //    }

    //    void PropertyGrid_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
    //    {
    //        PropertyValueChanged(this, e);
    //    }
    //}
}
