namespace WindowOverlaySample;

public partial class MainPage : ContentPage
{
    private FrameworkWindowOverlay? overlay;

    public MainPage()
    {
        InitializeComponent();
    }

    void OnAddOverlayButtonClicked(System.Object sender, System.EventArgs e)
    {
        if (Window != null)
        {
            overlay ??= new FrameworkWindowOverlay(Window);

            Window.AddOverlay(overlay);
        }
    }

    void OnRemoveOverlayButtonClicked(System.Object sender, System.EventArgs e)
    {
        if (overlay != null)
        {
            Window.RemoveOverlay(overlay);
        }
    }
}

public class FrameworkWindowOverlay : Microsoft.Maui.WindowOverlay
{
    public FrameworkWindowOverlay(IWindow window) : base(window)
    {
        AddWindowElement(new WindowOverlayElement());
    }
}

public class WindowOverlayElement : IWindowOverlayElement
{
    public bool Contains(Point point)
    {
        return true;
    }

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        canvas.FillColor = Colors.Red;
        canvas.FillRectangle(new Rect(dirtyRect.X, dirtyRect.Y, 100, 100));
    }
}
