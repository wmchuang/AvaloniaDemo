using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Metadata;
using Avalonia.Controls.Primitives;
using Avalonia.Data;

namespace MiniCalendarDemo.Controls;

[TemplatePart(PART_ElementRoot, typeof(Panel))]
public class MiniCalendar : TemplatedControl
{
    internal const int RowsPerMonth = 4;
    internal const int ColumnsPerMonth = 14;

    private const string PART_ElementRoot = "PART_Root";
    private const string PART_ElementMonth = "PART_CalendarItem";

    internal MiniCalendarItem? MonthControl
    {
        get
        {
            if (Root != null && Root.Children.Count > 0)
            {
                return Root.Children[0] as MiniCalendarItem;
            }

            return null;
        }
    }

    internal Panel? Root { get; set; }

    internal DateTime DisplayDateInternal { get; private set; }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        Root = e.NameScope.Find<Panel>(PART_ElementRoot);
        DisplayDateInternal = DateTimeHelper.DiscardDayTime(DateTime.Today);

        if (Root != null)
        {
            MiniCalendarItem? month = e.NameScope.Find<MiniCalendarItem>(PART_ElementMonth);

            if (month != null)
            {
                month.Owner = this;
            }
        }
    }

    public DayOfWeek FirstDayOfWeek => DateTimeHelper.GetCurrentDateFormat().FirstDayOfWeek;

    internal void OnPreviousClick()
    {
        DateTime? d = DateTimeHelper.AddMonths(DateTimeHelper.DiscardDayTime(DisplayDateInternal), -1);
        if (d.HasValue)
        {
            DisplayDateInternal = d.Value;
        }

        MiniCalendarItem? monthControl = MonthControl;
        if (monthControl != null)
            monthControl.UpdateMonthMode();
    }

    internal void OnNextClick()
    {
        DateTime? d = DateTimeHelper.AddMonths(DateTimeHelper.DiscardDayTime(DisplayDateInternal), 1);
        if (d.HasValue)
        {
            DisplayDateInternal = d.Value;
        }

        MiniCalendarItem? monthControl = MonthControl;
        if (monthControl != null)
            monthControl.UpdateMonthMode();
    }

    public string Marks
    {
        get => GetValue(MarksProperty);
        set => SetValue(MarksProperty, value);
    }

    public static readonly StyledProperty<string> MarksProperty = AvaloniaProperty.Register<MiniCalendar, string>
    (
        nameof(Marks),
        defaultBindingMode: BindingMode.TwoWay
    );

    public string MarkText
    {
        get => GetValue(MarkTextProperty);
        set => SetValue(MarkTextProperty, value);
    }

    public static readonly StyledProperty<string> MarkTextProperty = AvaloniaProperty.Register<MiniCalendar, string>
    (
        nameof(MarkText)
    );

    /// <summary>
    /// Defines the <see cref="SelectedDate"/> property.
    /// </summary>
    public static readonly StyledProperty<DateTime?> SelectedDateProperty =
        AvaloniaProperty.Register<CalendarDatePicker, DateTime?>(
            nameof(SelectedDate),
            enableDataValidation: true,
            defaultBindingMode: BindingMode.TwoWay);

    public DateTime? SelectedDate
    {
        get => GetValue(SelectedDateProperty);
        set => SetValue(SelectedDateProperty, value);
    }
}