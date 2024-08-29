using Syncfusion.Maui.ListView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopupListView.Popup;

/// <summary>
/// Provides a custom <see cref="ItemsGenerator"/> for handling 
/// selection and hover.
/// </summary>
internal class PopupListViewItemGenerator : ItemsGenerator
{
    private readonly PopupListView _listView;

    /// <summary>
    /// Initializes a new instance of this class.
    /// </summary>
    /// <param name="listView">The containing <see cref="PopupListView"/>.</param>
    public PopupListViewItemGenerator(PopupListView listView)
        : base(listView)
    {
        _listView = listView;
    }

    /// <summary>
    /// Creates a <see cref="ListViewItem"/> for the specified item index.
    /// </summary>
    /// <param name="itemIndex">The zero-based index of the item to create.</param>
    /// <param name="type">The <see cref="ItemType"/> to create.</param>
    /// <param name="data">The optional data associated with the returned item.</param>
    /// <returns>A new instance of a <see cref="ListViewItem"/>.</returns>
    protected override ListViewItem OnCreateListViewItem(int itemIndex, ItemType type, object data = null)
    {
        if (type == ItemType.Record)
        {
            return new PopupListViewItem(_listView, type, data);
        }
        return base.OnCreateListViewItem(itemIndex, type, data);
    }
}
