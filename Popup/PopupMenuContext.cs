namespace PopupListView.Popup;

internal class PopupMenuContext
{
    PopupMenu _popup;

    public PopupMenuContext(PopupMenu popup, IEnumerable<PopupItem> items, PopupItemTemplateSelector itemTemplate)
    {
        _popup = popup;
        Items = new List<PopupItem>(items);
        ItemTemplate = itemTemplate;
    }

    public IReadOnlyList<PopupItem> Items
    {
        get;
    }

    public PopupItemTemplateSelector ItemTemplate
    {
        get;
    }

    /// <summary>
    /// Bound to the SfListView.SelectedItem as OneWayToSource
    /// </summary>
    public object SelectedItem
    {
        get => null;
        set
        {
            if (value is PopupItem item)
            {
                Result = item;
                _popup.Dismiss();
                item.Execute(item);
            }
        }
    }

    public PopupItem Result
    {
        get;
        private set;
    }
}
