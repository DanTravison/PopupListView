namespace PopupListView.Popup;

/// <summary>
/// Provides a <see cref="DataTemplateSelector"/> for an <see cref="PopupItem"/>.
/// </summary>
/// <remarks>
/// Consumers may use this class to customize <see cref="PopupItem"/> 
/// <see cref="DataTemplate"/> instances
/// </remarks>
public sealed class PopupItemTemplateSelector : DataTemplateSelector
{
    /// <summary>
    /// Provides a <see cref="DataTemplate"/> for a <see cref="PopupItem"/> separator.
    /// </summary>
    public DataTemplate Separator
    {
        get;
        set;
    }

    /// <summary>
    /// Provides a <see cref="DataTemplate"/> for a <see cref="PopupItem"/>
    /// with a <see cref="PopupItem.Text"/> and <see cref="PopupItem.HasDescription"/> equals false.
    /// </summary>
    public DataTemplate Text
    {
        get;
        set;
    }

    /// <summary>
    /// Provides a <see cref="DataTemplate"/> for a <see cref="PopupItem"/>
    /// with a <see cref="PopupItem.Text"/> and <see cref="PopupItem.HasDescription"/> equals true.
    /// </summary>
    public DataTemplate Description
    {
        get;
        set;
    }


    /// <summary>
    /// Selects the <see cref="DataTemplate"/> for an <see cref="PopupItem"/>.
    /// </summary>
    /// <param name="item">The item to query.</param>
    /// <param name="container">Not used.</param>
    /// <returns>
    /// The <see cref="DataTemplate"/> for the <paramref name="item"/>; otherwise, 
    /// a null reference if <paramref name="item"/> is not an <see cref="PopupItem"/>.
    /// </returns>
    protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
    {
        if (item is PopupItem menuItem)
        {
            if (menuItem.IsSeparator)
            {
                return Separator;
            }
            else if (menuItem.HasDescription)
            {
                return Description;
            }
            else
            {
                return Text;
            }
        }

        return null;
    }
}
