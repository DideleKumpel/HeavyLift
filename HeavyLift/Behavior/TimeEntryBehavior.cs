using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavyLift.Behavior
{
    internal class TimeEntryBehavior : Behavior<Entry>
    {
        public int MaxValue { get; set; } = 59;

        protected override void OnAttachedTo(Entry bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.Keyboard = Keyboard.Numeric;
            bindable.MaxLength = 2;
            bindable.TextChanged += OnTextChanged;
            bindable.Unfocused += OnUnfocused;
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= OnTextChanged;
            bindable.Unfocused -= OnUnfocused;
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is Entry entry)
            {
                // only nums
                string filtered = new string(entry.Text?.Where(char.IsDigit).ToArray() ?? []);
                if (int.TryParse(filtered, out var number))
                {
                    if (number > MaxValue)
                        number = MaxValue;

                    entry.Text = number.ToString();
                }
                else
                {
                    entry.Text = "";
                }
            }
        }

        private void OnUnfocused(object sender, FocusEventArgs e)
        {
            if (sender is Entry entry && int.TryParse(entry.Text, out var number))
            {
                // format to 2 digits 
                entry.Text = number.ToString("D2");
            }
        }

    }
}
