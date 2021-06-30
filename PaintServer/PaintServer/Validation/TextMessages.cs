

namespace PaintServer.Helpers
{
    public static class TextMessages
    {
        
        
        public static string txtDuplicateLogin
        { get => "Duplicate login. Can't create user with the same login"; }
        
        // под вопросом
        public static string txtLoginIsNotEmail
        { get => "Incorrect login. Login must be valid e-mail address"; }

        public static string txtIncorrectNameLength
        { get => "First name and Last name can't be shorter than 2 characters, and longer than 30 characters"; }

        public static string txtIncorrectPasswordLength
        { get => "Password's length should be from 8 to 16 characters"; }

        public static string txtNoSmallCharactersInPassword
        { get => "Password should contain at least one small letter"; }

        public static string txtNoCapitalCharactersInPassword
        { get => "Password should contain at least one capital letter"; }

        public static string txtNoDigitsInPassword
        { get => "Password should contain at least one digit"; }

        public static string txtPasswordOk
        { get => "Ok"; }

        public static string txtDiferentPasswords
        { get => "Entered passwords are not equal"; }

        public static string txtConfirmSaveOnExit
        { get => "Are you really want to exit? All unsaved data will be lost."; }










    }
}
