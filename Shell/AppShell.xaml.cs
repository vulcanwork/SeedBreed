namespace SeedBreed;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("SourceView", typeof(Views.SourceView));
    }
}
