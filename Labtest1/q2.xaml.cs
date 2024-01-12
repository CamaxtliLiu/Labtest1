using Microsoft.Maui.Controls;
using System;
using System.Text.RegularExpressions;

namespace Labtest1
{
    public partial class q2 : ContentPage
    {
        private static readonly Regex phoneRegex = new Regex(@"^\d{11}$", RegexOptions.Compiled);

        public q2()
        {
            InitializeComponent();
            PhoneEntry.TextChanged += OnPhoneEntryTextChanged;
            PasswordEntry.TextChanged += OnPasswordEntryTextChanged;
            TermsAndConditionsCheckbox.CheckedChanged += OnTermsAndConditionsCheckboxChanged;
        }

        private void OnPhoneEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            bool isValid = IsValidPhoneNumber(e.NewTextValue);
            InvalidPhoneNumberLabel.IsVisible = !isValid;
            CheckRegisterButtonEnabled();
        }

        private void OnPasswordEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            bool isValid = IsValidPassword(e.NewTextValue);
            InvalidPasswordLabel.IsVisible = !isValid;
            CheckRegisterButtonEnabled();
        }

        private void OnTermsAndConditionsCheckboxChanged(object sender, CheckedChangedEventArgs e)
        {
            CheckRegisterButtonEnabled();
        }

        private void OnTermsAndConditionsLabelTapped(object sender, EventArgs e)
        {
            TermsAndConditionsCheckbox.IsChecked = !TermsAndConditionsCheckbox.IsChecked;
        }

        private void CheckRegisterButtonEnabled()
        {
            RegisterButton.IsEnabled = IsValidPhoneNumber(PhoneEntry.Text)
                                       && IsValidPassword(PasswordEntry.Text)
                                       && TermsAndConditionsCheckbox.IsChecked;
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return phoneNumber != null && phoneRegex.IsMatch(phoneNumber);
            return !string.IsNullOrWhiteSpace(phoneNumber) && Regex.IsMatch(phoneNumber, @"^\d{10,11}$");
        }

        private bool IsValidPassword(string password)
        {
            return !string.IsNullOrEmpty(password) && password.Length >= 6;
        }
    }
}
