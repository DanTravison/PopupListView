using PopupListView.Popup;

namespace PopupListView;

public partial class MainPage : ContentPage
{
    MainViewModel _model = new();

    TapGestureRecognizer _gesture = new()
    {
        Buttons = ButtonsMask.Secondary
    };

    public MainPage()
    {
        InitializeComponent();
        _gesture.Tapped += OnTapped;
        base.Content.GestureRecognizers.Add(_gesture);
    }

    void OnTapped(object sender, TappedEventArgs e)
    {
        if (sender is View view)
        {
            Point? point = e.GetPosition(view);
            if (point.HasValue)
            {
                PopupMenu menu = new(_model.Items)
                {
                    StartX = (int)Math.Round(point.Value.X),
                    StartY = (int)Math.Round(point.Value.Y),
                };
                _ = ShowMenu(menu);
            }
        }
    }

    private async Task ShowMenu(PopupMenu menu)
    {
        PopupItem item = await menu.ShowAsync();
        if (item != null)
        {
            _ = DisplayAlert
            (
                "Menu Action", item.Text, "OK"
            );
        }
    }
}
