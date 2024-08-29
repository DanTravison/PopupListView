using Syncfusion.Maui.ListView;
using System.Diagnostics;

namespace PopupListView.Popup;

/// <summary>
/// Provides a <see cref="ListViewItem"/> to handle hover when an item is not selectable.
/// </summary>
internal class PopupListViewItem : ListViewItem
{
    #region Fields

    readonly PopupListView _listView;
    PopupItem _item;

    #endregion Fields

    /// <summary>
    /// Initializes a new instance of this class.
    /// </summary>
    /// <param name="listView">The containing <see cref="PopupListView"/>.</param>
    /// <param name="itemType">The <see cref="ItemType"/> to create.</param>
    /// <param name="data">The optional data associated with the returned item.</param>
    /// <returns>A new instance of a <see cref="ListViewItem"/>.</returns>
    public PopupListViewItem(PopupListView listView, ItemType itemType, object data)
        : base(itemType)
    {
        _listView = listView;
        Trace.WriteLine($"PopupListViewItem.ctor");
        OnItemChanged(data as PopupItem);
    }

    #region Properties

    public Size MeasuredSize
    {
        get;
        private set;
    } = Size.Zero;

    public PopupItem Value
    {
        get => _item;
    }

    #endregion Properties

    #region Overrides

    /// <summary>
    /// Handles BindingContext changes to update the contained <see cref="PopupItem"/>.
    /// </summary>
    protected override void OnBindingContextChanged()
    {
        OnItemChanged(BindingContext as PopupItem);
        base.OnBindingContextChanged();
    }

    public override SizeRequest Measure(double widthConstraint, double heightConstraint, MeasureFlags flags = MeasureFlags.None)
    {
        SizeRequest size = base.Measure(widthConstraint, heightConstraint, flags);
        MeasuredSize = size.Request;
        Trace.WriteLine($"PopupListViewItem.Measure: {size.Request.Width}x{size.Request.Height} {_item.Text}");
        return size;
    }

    protected override Size MeasureContent(double widthConstraint, double heightConstraint)
    {
        Size size = base.MeasureContent(widthConstraint, heightConstraint);
        MeasuredSize = size;
        Trace.WriteLine($"PopupListViewItem.MeasureContent: {size.Width}x{size.Height} {_item.Text}");
        return size;
    }

    #endregion Overrides

    void OnItemChanged(PopupItem item)
    {
        Trace.WriteLine($"PopupListViewItem.OnItemChanged: {item?.Text}");
        if (!ReferenceEquals(item, _item))
        {
            PopupItem previous = _item;
            if (previous != null)
            {
                _listView.OnItemRemoved(previous);
            }
            _item = item;
            if (_item != null)
            {
                _listView.OnItemAdded(item, this);
            }
        }
    }
}