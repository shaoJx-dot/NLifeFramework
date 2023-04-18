using System.ComponentModel;
using System.Drawing.Design;
using DevComponents.DotNetBar.SuperGrid.Primitives;

namespace DevComponents.DotNetBar.SuperGrid
{
    /// <summary>
    /// Represents the collection of grid items.
    /// </summary>
    [Editor("DevComponents.SuperGrid.Design.GridRowCollectionEditor, DevComponents.SuperGrid.Design, Version=11.4.0.0, Culture=neutral,  PublicKeyToken=26d81176cfa2b486", typeof(UITypeEditor))]
    public class GridItemsCollection : CustomCollection<GridElement>
    {
        #region ClearItems

        protected override void ClearItems()
        {
            int n = Items.Count;

            if (FloatLastItem == true)
                n--;

            for (int i = 0; i < n; i++)
                DetachItem(Items[i] as GridContainer, true);

            base.ClearItems();
        }

        #endregion

        #region RemoveItem

        protected override void RemoveItem(int index)
        {
            DetachItem(Items[index] as GridContainer, false);

            base.RemoveItem(index);
        }

        #endregion

        #region DetachItem

        private void DetachItem(GridContainer item, bool clear)
        {
            if (item != null)
            {
                item.DetachNestedRows(false);

                if (clear == false)
                    item.Parent = null;
            }
        }

        #endregion
    }
}
