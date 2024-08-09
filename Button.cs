using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Media;

class MainClass
{
    static Canvas canvas;

    static Random rand;
    public static void Main(string[] args)
    {
        AppBuilder
            .Configure<Application>()
            .UsePlatformDetect()
            .Start(AppMain, args);
    }

    public static void AppMain(Application app, string[] args)
    {
        app.Styles.Add(new Avalonia.Themes.Fluent.FluentTheme());
        app.RequestedThemeVariant = Avalonia.Styling.ThemeVariant.Light;

        rand = new Random();

        var win = new Window
        {
            Title = "Avalonia C# Buttons",
            Width = 800,
            Height = 600,
            Background = Brushes.Orange,
        };

        var dockPanel = new DockPanel();

        win.Content = dockPanel;

        var grid = new Grid
        {
            Background = Brushes.White,
            RowDefinitions = RowDefinitions.Parse("100"),
            ColumnDefinitions = ColumnDefinitions.Parse("*, *")
        };

        grid.SetValue(DockPanel.DockProperty, Dock.Top);

        dockPanel.Children.Add(grid);

        var recButton = new Button
        {
            Content = "Rectangles",
            FontSize = 24,
            Margin = Thickness.Parse("10"),
            HorizontalContentAlignment = HorizontalAlignment.Center,
            VerticalContentAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Stretch,
            VerticalAlignment = VerticalAlignment.Stretch,
        };

        recButton.Click += DrawRectangles;

        recButton.SetValue(Grid.ColumnProperty, 0);
        grid.Children.Add(recButton);

        var cirButton = new Button
        {
            Content = "Circles",
            FontSize = 24,
            Margin = Thickness.Parse("10"),
            HorizontalContentAlignment = HorizontalAlignment.Center,
            VerticalContentAlignment = VerticalAlignment.Center,
            HorizontalAlignment = HorizontalAlignment.Stretch,
            VerticalAlignment = VerticalAlignment.Stretch,
        };

        cirButton.Click += DrawCircles;

        cirButton.SetValue(Grid.ColumnProperty, 1);
        grid.Children.Add(cirButton);

        canvas = new Canvas {Background = Brushes.Black, };

        dockPanel.Children.Add(canvas);

        win.Show();
        app.Run(win);
    }

    static void DrawRectangles(object s, RoutedEventArgs e)
    {
        canvas.Children.Clear();

        float cw = (float)canvas.Bounds.Width;
        float ch = (float)canvas.Bounds.Height;

        for (int i = 0; i < 100; ++i)
        {
            var b = new SolidColorBrush();

            b.Color = new Color(0XFF, 
                (byte)(256 * rand.NextDouble()),
                (byte)(256 * rand.NextDouble()),
                (byte)(256 * rand.NextDouble()));

            float x = cw * (float)rand.NextDouble();
            float y = ch * (float)rand.NextDouble();

            float w = (cw - x) * (float)rand.NextDouble();
            float h = (ch - y) * (float)rand.NextDouble();

            Rectangle r = new Rectangle{Fill = b, Width = w, Height = h};

            r.SetValue(Canvas.LeftProperty, x);
            r.SetValue(Canvas.TopProperty, y);

            canvas.Children.Add(r);
        }
    }

    static void DrawCircles(object s, RoutedEventArgs e)
    {
        canvas.Children.Clear();

        float cw = (float)canvas.Bounds.Width;
        float ch = (float)canvas.Bounds.Height;

        for (int i = 0; i < 100; ++i)
        {
            var b = new SolidColorBrush();

            b.Color = new Color(0XFF, 
                (byte)(256 * rand.NextDouble()),
                (byte)(256 * rand.NextDouble()),
                (byte)(256 * rand.NextDouble()));

            float x = cw * (float)rand.NextDouble();
            float y = ch * (float)rand.NextDouble();

            float w = (cw - x) * (float)rand.NextDouble();
            float h = (ch - y) * (float)rand.NextDouble();

            Ellipse c = new Ellipse{Fill = b, Width = w, Height = h};
 
            c.SetValue(Canvas.LeftProperty, x);
            c.SetValue(Canvas.TopProperty, y);

            canvas.Children.Add(c);
        }
    }
}