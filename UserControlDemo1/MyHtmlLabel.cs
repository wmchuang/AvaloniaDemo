using Avalonia;
using Avalonia.Controls.Html;
using Avalonia.Media;
using Avalonia.Media.Immutable;
using TheArtOfDev.HtmlRenderer.Core.Entities;

namespace UserControlDemo1;


public class MyHtmlLabel : HtmlLabel
{
    private Size RenderSize => new Size(Bounds.Width, Bounds.Height);

    public override void Render(DrawingContext context)
    {
        context.FillRectangle(Brushes.Blue, new Rect(RenderSize));

        if (BorderThickness != new Thickness(0) && BorderBrush != null)
        {
            var brush = new ImmutableSolidColorBrush(Colors.Black);
            if (BorderThickness.Top > 0)
                context.FillRectangle(brush, new Rect(0, 0, RenderSize.Width, BorderThickness.Top));
            if (BorderThickness.Bottom > 0)
                context.FillRectangle(brush,
                    new Rect(0, RenderSize.Height - BorderThickness.Bottom, RenderSize.Width, BorderThickness.Bottom));
            if (BorderThickness.Left > 0)
                context.FillRectangle(brush, new Rect(0, 0, BorderThickness.Left, RenderSize.Height));
            if (BorderThickness.Right > 0)
                context.FillRectangle(brush,
                    new Rect(RenderSize.Width - BorderThickness.Right, 0, BorderThickness.Right, RenderSize.Height));
        }

        var htmlWidth = HtmlWidth(RenderSize);
        var htmlHeight = HtmlHeight(RenderSize);
        if (_htmlContainer != null && htmlWidth > 0 && htmlHeight > 0)
        {
            using (context.PushClip(new Rect(Padding.Left + BorderThickness.Left, Padding.Top + BorderThickness.Top,
                       htmlWidth, (int)htmlHeight)))
            {
                _htmlContainer.Location = new Point(Padding.Left + BorderThickness.Left,
                    Padding.Top + BorderThickness.Top);
                _htmlContainer.PerformPaint(context,
                    new Rect(Padding.Left + BorderThickness.Left, Padding.Top + BorderThickness.Top, htmlWidth,
                        htmlHeight));
            }

            if (!_lastScrollOffset.Equals(_htmlContainer.ScrollOffset))
            {
                _lastScrollOffset = _htmlContainer.ScrollOffset;
                InvokeMouseMove();
            }
        }

        base.Render(context);
    }
}