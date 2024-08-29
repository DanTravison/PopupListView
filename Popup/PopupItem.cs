using System.Diagnostics;
using System.Windows.Input;

namespace PopupListView.Popup;

internal class PopupItem : ICommand
{
    public static readonly PopupItem Separator = new PopupItem();

    private PopupItem()
    {
        IsSeparator = true;
        CanExecuteChanged?.Invoke(this, EventArgs.Empty);
    }

    public PopupItem(string text, string description = null)
    {
        Text = text;
        if (!string.IsNullOrEmpty(description))
        {
            Description = description;
            HasDescription = true;
        }
    }

    public PopupItem(string text)
    {
        Text = text;
    }
    public string Text
    {
        get;
    }

    public string Description
    {
        get;
    }


    public bool IsSeparator
    {
        get;
    }

    public bool HasDescription
    {
        get;
    }


    public bool CanExecute(object parameter)
    {
        return true;
    }

    public void Execute(object parameter)
    {
        Trace.WriteLine($"PopupItem.Execute: {Text}");
    }

    public event EventHandler CanExecuteChanged;
}

