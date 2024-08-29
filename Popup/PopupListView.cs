using Syncfusion.Maui.ListView;
using System.Diagnostics;

namespace PopupListView.Popup;

/// <summary>
/// Provides a simple 
/// </summary>
internal class PopupListView : SfListView
{
    readonly Dictionary<PopupItem, PopupListViewItem> _items = new(ReferenceEqualityComparer.Instance);

    public PopupListView()
    {
        ItemGenerator = new PopupListViewItemGenerator(this);
    }

    protected override Size MeasureContent(double widthConstraint, double heightConstraint)
    {
        int count = 0;

        if (BindingContext is PopupMenuContext context)
        { 
            count = context.Items.Count;
        }
        Trace.WriteLine($"PopupListView.MeasureContent.Count: {count}");
        Size size = base.MeasureContent(widthConstraint, heightConstraint);
        Trace.WriteLine($"PopupListView.MeasureContent.Size: {size.Width}x{size.Height}");
        if (count > 0)
        {
            Trace.WriteLine($"PopupListView.MeasureContent: WidthRequest:{WidthRequest} HeightRequest:{HeightRequest}");
            Size measured = MeasureItems();
            if (measured.Height > 0)
            {
                HeightRequest = measured.Height;
                WidthRequest = measured.Width;
                Trace.WriteLine($"PopupListView.MeasureContent.Set: WidthRequest:{measured.Width} HeightRequest:{measured.Height}");
            }
            else
            {
                Trace.WriteLine($"PopupListView.MeasureContent: PopupListViewItem.MeasureContent has not been called yet.");
            }
        }
        return size;
    }

    #region Item Tracking

    // NOTE: Item tracking is an attempt to adjust the 
    // WidthRequest and HeightRequest of the SfListView.
    // SfListView doesn't appear accurate when measuring
    // items of variable heights.

    Size MeasureItems()
    {
        double width = 0;
        double height = 0;
        int count = 0;

        foreach (PopupListViewItem item in _items.Values)
        {
            // Get size cached by PopupListViewItem.MeasureContent
            Size size = item.MeasuredSize;
            width = Math.Max(width, size.Width);
            height += size.Height;
            count++;
        }
        height += (count - 1) * base.ItemSpacing.VerticalThickness;

        return new Size(width, height);
    }

    internal void OnItemAdded(PopupItem item, PopupListViewItem listItem)
    {
        if (item != null)
        {
            if (_items.ContainsKey(item))
            {
                _items[item] = listItem;
            }
            else
            {
                _items.Add(item, listItem);
            }
        }
    }

    internal void OnItemRemoved(PopupItem item)
    {
        if (item != null)
        {
            _items.Remove(item);
        }
    }

    #endregion Item Tracking
}
