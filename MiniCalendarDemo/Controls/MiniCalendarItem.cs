using System;
using System.Globalization;
using System.Linq;
using Avalonia;
using Avalonia.Collections.Pooled;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Input;
using Avalonia.Interactivity;

namespace MiniCalendarDemo.Controls;

public class MiniCalendarItem : TemplatedControl
{
    private const int NumberOfDaysPerWeek = 7;

    private const string PART_ElementHeaderText = "PART_HeaderText";
    private const string PART_ElementPreviousButton = "PART_PreviousButton";
    private const string PART_ElementNextButton = "PART_NextButton";
    private const string PART_ElementMonthView = "PART_MonthView";

    internal Grid? MonthView { get; set; }

    private TextBlock? _headerTextBlock;
    private Button? _nextButton;
    private Button? _previousButton;

    internal MiniCalendar? Owner { get; set; }

    private readonly System.Globalization.Calendar _calendar = new GregorianCalendar();

    /// <summary>
    /// Gets the button that displays the previous page of the calendar when
    /// it is clicked.
    /// </summary>
    internal Button? PreviousButton
    {
        get { return _previousButton; }
        private set
        {
            if (_previousButton != null)
                _previousButton.Click -= PreviousButton_Click;

            _previousButton = value;

            if (_previousButton != null)
            {
                _previousButton.IsVisible = true;
                _previousButton.Click += PreviousButton_Click;
                _previousButton.Focusable = false;
            }
        }
    }

    /// <summary>
    /// Gets the button that displays the next page of the calendar when it
    /// is clicked.
    /// </summary>
    internal Button? NextButton
    {
        get { return _nextButton; }
        private set
        {
            if (_nextButton != null)
                _nextButton.Click -= NextButton_Click;

            _nextButton = value;

            if (_nextButton != null)
            {
                _nextButton.IsVisible = true;
                _nextButton.Click += NextButton_Click;
                _nextButton.Focusable = false;
            }
        }
    }

    internal TextBlock? HeaderTextBlock
    {
        get { return _headerTextBlock; }
        private set
        {
            _headerTextBlock = value;

            if (_headerTextBlock != null)
            {
                _headerTextBlock.Focusable = false;
            }
        }
    }

    internal void PreviousButton_Click(object? sender, RoutedEventArgs e)
    {
        if (Owner != null)
        {
            Owner.Focus();

            Button b = (Button)sender!;
            if (b.IsEnabled)
            {
                Owner.OnPreviousClick();
            }
        }
    }

    internal void NextButton_Click(object? sender, RoutedEventArgs e)
    {
        if (Owner != null)
        {
            Owner.Focus();

            Button b = (Button)sender!;
            if (b.IsEnabled)
            {
                Owner.OnNextClick();
            }
        }
    }

    /// <summary>
    /// Builds the visual tree for the
    /// <see cref="T:System.Windows.Controls.Primitives.CalendarItem" />
    /// when a new template is applied.
    /// </summary>
    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        HeaderTextBlock = e.NameScope.Find<TextBlock>(PART_ElementHeaderText);
        MonthView = e.NameScope.Find<Grid>(PART_ElementMonthView);
        PreviousButton = e.NameScope.Find<Button>(PART_ElementPreviousButton);
        NextButton = e.NameScope.Find<Button>(PART_ElementNextButton);

        PopulateGrids();
    }

    public static readonly StyledProperty<ITemplate<Control>?> DayTitleTemplateProperty =
        AvaloniaProperty.Register<CalendarItem, ITemplate<Control>?>(
            nameof(DayTitleTemplate),
            defaultBindingMode: BindingMode.OneTime);

    public ITemplate<Control>? DayTitleTemplate
    {
        get => GetValue(DayTitleTemplateProperty);
        set => SetValue(DayTitleTemplateProperty, value);
    }

    private void PopulateGrids()
    {
        if (MonthView != null)
        {
            var childCount = MiniCalendar.RowsPerMonth + MiniCalendar.RowsPerMonth * MiniCalendar.ColumnsPerMonth;
            using var children = new PooledList<Control>(childCount);

            for (int i = 0; i < MiniCalendar.ColumnsPerMonth; i++)
            {
                if (DayTitleTemplate?.Build() is Control cell)
                {
                    cell.DataContext = string.Empty;
                    cell.SetValue(Grid.RowProperty, 0);
                    cell.SetValue(Grid.ColumnProperty, i);
                    children.Add(cell);
                }
            }

            EventHandler<PointerPressedEventArgs> cellMouseLeftButtonDown = Cell_MouseLeftButtonDown;

            for (int i = 1; i < MiniCalendar.RowsPerMonth; i++)
            {
                for (int j = 0; j < MiniCalendar.ColumnsPerMonth; j++)
                {
                    var cell = new MiniCalendarDayButton();


                    cell.SetValue(Grid.RowProperty, i);
                    cell.SetValue(Grid.ColumnProperty, j);
                    cell.CalendarDayButtonMouseDown += cellMouseLeftButtonDown;
                    children.Add(cell);
                }
            }

            MonthView.Children.AddRange(children);

            UpdateMonthMode();
            MonthView.IsVisible = true;
        }
    }

    internal void Cell_MouseLeftButtonDown(object? sender, PointerPressedEventArgs e)
    {
        if (Owner != null)
        {
            Owner.Focus();
            if (sender is MiniCalendarDayButton b)
            {
                if (b.IsEnabled && !b.IsBlackout && b.DataContext is DateTime selectedDate)
                {
                    Owner.SelectedDate = selectedDate;
                    UpdateMonthMode();
                }
            }

        }
    }

    private DateTime _currentMonth;

    internal void UpdateMonthMode()
    {
        if (Owner != null)
        {
            _currentMonth = Owner.DisplayDateInternal;
        }
        else
        {
            _currentMonth = DateTime.Today;
        }

        SetMonthModeHeaderText();

        if (MonthView != null)
        {
            SetDayTitles();
            SetCalendarDayButtons(_currentMonth);
        }
    }

    private void SetMonthModeHeaderText()
    {
        if (HeaderTextBlock != null)
        {
            if (Owner != null)
            {
                HeaderTextBlock.Text = Owner.DisplayDateInternal.ToString("yyyy年M月份");
                HeaderTextBlock.IsEnabled = true;
            }
            else
            {
                HeaderTextBlock.Text = DateTime.Today.ToString("Y", DateTimeHelper.GetCurrentDateFormat());
            }
        }
    }

    private void SetDayTitles()
    {
        for (int childIndex = 0; childIndex < MiniCalendar.ColumnsPerMonth; childIndex++)
        {
            var daytitle = MonthView!.Children[childIndex];
            if (Owner != null)
            {
                daytitle.DataContext = DateTimeHelper.GetCurrentDateFormat()
                    .ShortestDayNames[(childIndex + (int)Owner.FirstDayOfWeek) % NumberOfDaysPerWeek];
            }
            else
            {
                daytitle.DataContext = DateTimeHelper.GetCurrentDateFormat().ShortestDayNames[
                    (childIndex + (int)DateTimeHelper.GetCurrentDateFormat().FirstDayOfWeek) % NumberOfDaysPerWeek];
            }
        }
    }

    private void SetCalendarDayButtons(DateTime firstDayOfMonth)
    {
        int lastMonthToDisplay = PreviousMonthDays(firstDayOfMonth);
        DateTime dateToAdd;

        if (DateTimeHelper.CompareYearMonth(firstDayOfMonth, DateTime.MinValue) > 0)
        {
            // DisplayDate is not equal to DateTime.MinValue we can subtract
            // days from the DisplayDate
            dateToAdd = _calendar.AddDays(firstDayOfMonth, -lastMonthToDisplay);
        }
        else
        {
            dateToAdd = firstDayOfMonth;
        }

        int count = MiniCalendar.RowsPerMonth * MiniCalendar.ColumnsPerMonth;

        for (int childIndex = MiniCalendar.ColumnsPerMonth; childIndex < count; childIndex++)
        {
            MiniCalendarDayButton childButton = (MiniCalendarDayButton)MonthView!.Children[childIndex];


            var content = dateToAdd.Day.ToString(DateTimeHelper.GetCurrentDateFormat());
            childButton.Content = content;
            SetButtonState(childButton, dateToAdd, content);

            childButton.DataContext = dateToAdd;

            if (DateTime.Compare(DateTimeHelper.DiscardTime(DateTime.MaxValue), dateToAdd) > 0)
            {
                // Since we are sure DisplayDate is not equal to
                // DateTime.MaxValue, it is safe to use AddDays 
                dateToAdd = _calendar.AddDays(dateToAdd, 1);
            }
            else
            {
                // DisplayDate is equal to the DateTime.MaxValue, so there
                // are no trailing days
                childIndex++;
                for (int i = childIndex; i < count; i++)
                {
                    childButton = (MiniCalendarDayButton)MonthView.Children[i];
                    // button needs a content to occupy the necessary space
                    // for the content presenter
                    childButton.Content = i.ToString(DateTimeHelper.GetCurrentDateFormat());
                    childButton.IsEnabled = false;
                    childButton.Opacity = 0;
                }

                return;
            }
        }
    }

    private void SetButtonState(MiniCalendarDayButton childButton, DateTime dateToAdd, string content)
    {
        if (Owner != null)
        {
            var marks = Owner.Marks?.Split(',').ToArray();
            childButton.MarkText = Owner.MarkText;

            childButton.IsMark = marks?.Any(x => x == content) ?? false;
            childButton.Opacity = 1;

          
            childButton.IsEnabled = true;

            // SET IF THE DAY IS INACTIVE OR NOT: set if the day is a
            // trailing day or not
            childButton.IsInactive = (DateTimeHelper.CompareYearMonth(dateToAdd, Owner.DisplayDateInternal) != 0);

            // SET IF THE DAY IS TODAY OR NOT
            childButton.IsToday = dateToAdd == DateTime.Today;

            // SET IF THE DAY IS SELECTED OR NOT
            childButton.IsSelected = false;
            childButton.IsSelected |= (DateTimeHelper.CompareDays(dateToAdd, Owner.SelectedDate ?? DateTime.MinValue) == 0);
        }
    }

    /// <summary>
    /// How many days of the previous month need to be displayed.
    /// </summary>
    private int PreviousMonthDays(DateTime firstOfMonth)
    {
        DayOfWeek day = _calendar.GetDayOfWeek(firstOfMonth);
        int i;

        if (Owner != null)
        {
            i = ((day - Owner.FirstDayOfWeek + NumberOfDaysPerWeek) % NumberOfDaysPerWeek);
        }
        else
        {
            i = ((day - DateTimeHelper.GetCurrentDateFormat().FirstDayOfWeek + NumberOfDaysPerWeek) %
                 NumberOfDaysPerWeek);
        }

        if (i == 0)
        {
            return NumberOfDaysPerWeek;
        }
        else
        {
            return i;
        }
    }
}