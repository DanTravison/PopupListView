using Syncfusion.Maui.Popup;

namespace PopupListView.Popup;

internal class PopupMenu : SfPopup
{
    PopupMenuContext _context;
    public PopupMenu(IEnumerable<PopupItem> items, PopupItemTemplateSelector itemTemplate = null)
    {
        BindingContext = _context = new PopupMenuContext
        (
            this,
            items,
            itemTemplate ?? DefaultSelector
        );
        ContentTemplate = PopupContentTemplate;
        ShowFooter = false;
        ShowHeader = false;
        ShowOverlayAlways = false;
        StaysOpen = false;
        PopupStyle.CornerRadius = 3;
        AutoSizeMode = PopupAutoSizeMode.Height;
    }

    /// <summary>
    /// Replaces <see cref="SfPopup.ShowAsync"/> to support return an <see cref="PopupItem"/>.
    /// </summary>
    /// <returns>A <see cref="Task{IPopupItem}"/> to use to await the results.</returns>
    public new async Task<PopupItem> ShowAsync()
    {
        await base.ShowAsync();
        return _context.Result;
    }

    public PopupItem Show()
    {
        base.Show();
        return _context.Result;
    }

    #region Resources

    DataTemplate _contentTemplate;
    public DataTemplate PopupContentTemplate
    {
        get
        {
            if (_contentTemplate == null)
            {
                _contentTemplate = GetResource<DataTemplate>(nameof(PopupContentTemplate));
            }
            return _contentTemplate;
        }
    }

    PopupItemTemplateSelector _templateSelector;
    public PopupItemTemplateSelector DefaultSelector
    {
        get
        {
            if (_templateSelector == null)
            {
                _templateSelector = GetResource<PopupItemTemplateSelector>(nameof(PopupItemTemplateSelector));
            }
            return _templateSelector;

        }
    }

    internal T GetResource<T>(string resourceName)
        where T : class
    {
        if (Application.Current.Resources.TryGetValue(resourceName, out object value))
        {
            if (value is T resource)
            {
                return resource;
            }
            throw new Exception($"Resource '{resourceName}' is not of type '{typeof(T).Name}'");
        }
        else
        {
            throw new Exception($"'{typeof(T).Name}' '{resourceName}' was not found.");
        }
    }

    #endregion Resources
}
