// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see https://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System;

namespace CalendarDemo.Calendar
{
    /// <summary>
    /// Provides data for the
    /// <see cref="E:CalendarDemo.Calendar.CalendarDatePicker.DateValidationError" />
    /// event.
    /// </summary>
    public class CalendarDatePickerDateValidationErrorEventArgs : EventArgs
    {
        private bool _throwException;

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="T:CalendarDemo.Calendar.CalendarDatePickerDateValidationErrorEventArgs" />
        /// class.
        /// </summary>
        /// <param name="exception">
        /// The initial exception from the
        /// <see cref="E:CalendarDemo.Calendar.CalendarDatePicker.DateValidationError" />
        /// event.
        /// </param>
        /// <param name="text">
        /// The text that caused the
        /// <see cref="E:CalendarDemo.Calendar.CalendarDatePicker.DateValidationError" />
        /// event.
        /// </param>
        public CalendarDatePickerDateValidationErrorEventArgs(Exception exception, string text)
        {
            Text = text;
            Exception = exception;
        }

        /// <summary>
        /// Gets the initial exception associated with the
        /// <see cref="E:CalendarDemo.Calendar.CalendarDatePicker.DateValidationError" />
        /// event.
        /// </summary>
        /// <value>
        /// The exception associated with the validation failure.
        /// </value>
        public Exception Exception { get; private set; }

        /// <summary>
        /// Gets the text that caused the
        /// <see cref="E:CalendarDemo.Calendar.CalendarDatePicker.DateValidationError" />
        /// event.
        /// </summary>
        /// <value>
        /// The text that caused the validation failure.
        /// </value>
        public string Text { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether
        /// <see cref="P:CalendarDemo.Calendar.CalendarDatePickerDateValidationErrorEventArgs.Exception" />
        /// should be thrown.
        /// </summary>
        /// <value>
        /// True if the exception should be thrown; otherwise, false.
        /// </value>
        /// <exception cref="T:System.ArgumentException">
        /// If set to true and
        /// <see cref="P:CalendarDemo.Calendar.CalendarDatePickerDateValidationErrorEventArgs.Exception" />
        /// is null.
        /// </exception>
        public bool ThrowException
        {
            get => _throwException;
            set
            {
                if (value && Exception == null)
                {
                    throw new ArgumentException("Cannot Throw Null Exception");
                }

                _throwException = value;
            }
        }
    }
}
