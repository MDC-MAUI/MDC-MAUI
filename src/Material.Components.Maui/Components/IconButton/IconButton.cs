using System.ComponentModel;

namespace Material.Components.Maui;

public sealed class IconButton
    : TouchGraphicView,
        IElement,
        IIconElement,
        IBackgroundElement,
        IOutlineElement,
        IElevationElement
{
    protected override void ChangeVisualState()
    {
        this.IsVisualStateChanging = true;
        var state = this.ViewState switch
        {
            ViewState.Normal => "normal",
            ViewState.Hovered => "hovered",
            ViewState.Pressed => "pressed",
            ViewState.Disabled => "disabled",
            _ => "normal",
        };
        VisualStateManager.GoToState(this, state);
        this.IsVisualStateChanging = false;

        if (!this.IsFocused)
            this.Invalidate();
    }

    public static readonly BindableProperty IconDataroperty = IIconElement.IconDataProperty;
    public static readonly BindableProperty IconColorProperty = IIconElement.IconColorProperty;
    public static readonly BindableProperty IconOpacityProperty = IIconElement.IconOpacityProperty;

    public static readonly BindableProperty OutlineWidthProperty =
        IOutlineElement.OutlineWidthProperty;
    public static readonly BindableProperty OutlineColorProperty =
        IOutlineElement.OutlineColorProperty;
    public static readonly BindableProperty OutlineOpacityProperty =
        IOutlineElement.OutlineOpacityProperty;
    public static readonly BindableProperty ElevationProperty = IElevationElement.ElevationProperty;

    public string IconData
    {
        get => (string)this.GetValue(IconDataroperty);
        set => this.SetValue(IconDataroperty, value);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public PathF IconPath { get; set; }

    public Color IconColor
    {
        get => (Color)this.GetValue(IconColorProperty);
        set => this.SetValue(IconColorProperty, value);
    }

    public float IconOpacity
    {
        get => (float)this.GetValue(IconOpacityProperty);
        set => this.SetValue(IconOpacityProperty, value);
    }

    public Color OutlineColor
    {
        get => (Color)this.GetValue(OutlineColorProperty);
        set => this.SetValue(OutlineColorProperty, value);
    }

    public int OutlineWidth
    {
        get => (int)this.GetValue(OutlineWidthProperty);
        set => this.SetValue(OutlineWidthProperty, value);
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public float OutlineOpacity
    {
        get => (float)this.GetValue(OutlineOpacityProperty);
        set => this.SetValue(OutlineOpacityProperty, value);
    }

    [TypeConverter(typeof(ElevationConverter))]
    public Elevation Elevation
    {
        get => (Elevation)this.GetValue(ElevationProperty);
        set => this.SetValue(ElevationProperty, value);
    }

    public IconButton()
    {
        this.Drawable = new IconButtonDrawable(this);
    }

    protected override void Dispose(bool disposing)
    {
        if (disposing) { }
        base.Dispose(disposing);
    }
}