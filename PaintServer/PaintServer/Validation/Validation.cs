using System.Text.RegularExpressions;

namespace PaintServer.Helpers
{
    public class Validation
    {
        public bool EmailValidate(string email)
        {
           return Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
        }

        public (bool result, string message) PasswordValidate(string password)
        {
            bool result = false;
            string message;

            if (Regex.IsMatch(password, @"^(?=.{8,16}$).*$"))
            {
                result = true;
            }
            else
            {
                message = TextMessages.txtIncorrectPasswordLength;
                return (result, message);
            }

            if (result && Regex.IsMatch(password, @"^(?=.*?[a-z]).*$"))
            {

            }
            else
            {
                result = false;
                message = TextMessages.txtNoSmallCharactersInPassword;
                return (result, message);
            }

            if (result && Regex.IsMatch(password, @"^(?=.*?[A-Z]).*$"))
            {

            }
            else
            {
                result = false;
                message = TextMessages.txtNoCapitalCharactersInPassword;
                return (result, message);
            }

            if (result && Regex.IsMatch(password, @"^(?=.*?[0-9]).*$"))
            {

            }
            else
            {
                result = false;
                message = TextMessages.txtNoDigitsInPassword;
                return (result, message);
            }

                message = TextMessages.txtPasswordOk;
                return (result, message);

            



        }

        public BoolStringType NewUserValidation (string firstName, string lastName, string email, string password)
        {
            bool isValid = true;
            
            string ValidationMessage = "";

            Validation validation = new Validation();

            if (validation.EmailValidate(email) == false)
            {
                isValid = false;
                ValidationMessage += TextMessages.txtLoginIsNotEmail + "\n";
            }
            if (validation.FirstLastNameValidation(firstName) == false)
            {
                isValid = false;
                ValidationMessage += TextMessages.txtIncorrectNameLength + "\n";
            }
            if (validation.FirstLastNameValidation(lastName) == false)
            {
                isValid = false;
                ValidationMessage += TextMessages.txtIncorrectNameLength + "\n";
            }

            var validationResult = validation.PasswordValidate(password);
            if (validationResult.result == false)
            {
                isValid = false;
                ValidationMessage += validationResult.message + "\n";
            }
            return new BoolStringType() { BooleanValue = isValid, StringValue = ValidationMessage };
        }
        public bool FirstLastNameValidation(string name)
        {
            return name.Length >= 2 && name.Length <= 30;
        }
    }
}
