using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FcNet.FormStyle
{
    public class ItemsCollectionEditor : CollectionEditor
    {
        private Type[] typItems;

        public ItemsCollectionEditor(Type typItem) : base(typItem)
        {
            typItems = new Type[] { typeof(TabItem) };
        }

        protected override Type[] CreateNewItemTypes()
        {
            return typItems;
        }

        protected override CollectionForm CreateCollectionForm()
        {
            CollectionForm collectionForm = base.CreateCollectionForm();
            collectionForm.Text = "Tabs Collection Editor";
            return collectionForm;
            //return base.CreateCollectionForm();
        }

        protected override object SetItems(object editValue, object[] value)
        {
            return base.SetItems(editValue, value);
        }
    }
}
