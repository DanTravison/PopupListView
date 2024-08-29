using PopupListView.Popup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopupListView;

internal class MainViewModel
{
    #region Static Fields

    static readonly List<PopupItem> _items =
    [
        new PopupItem("Item 1"),
        new PopupItem("Item 2", "Item 2 Description"),
        new PopupItem("Item 3"),
        PopupItem.Separator,
        new PopupItem("Item 4", "Item 4 Description"),
        new PopupItem("Item 5"),
        new PopupItem("Item 6", "Item 6 Description"),
        PopupItem.Separator,
        new PopupItem("Item 7", "Item 7 Description"),
        new PopupItem("Item 8", "Item 8 Description"),
        new PopupItem("Item 9", "Item 9 Description")

    ];

    #endregion Static Fields

    #region Properties

    public IEnumerable<PopupItem> Items
    {
        get;
    } = _items;

    public PopupItem SelectedItem
    {
        get => null;
        set
        {
            if (value != null)
            {
                value.Execute(value);
            }
        }
    }

    #endregion Properties
}

