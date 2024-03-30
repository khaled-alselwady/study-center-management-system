using System.Windows.Forms;

namespace StudyCenter.GlobalClasses
{
    public static class clsStandardMessages
    {
        public static void ShowSuccess(string entityType)
        {
            MessageBox.Show($"{entityType} data saved successfully.", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowError(string entityType)
        {
            MessageBox.Show($"Failed to save {entityType.ToLower()} data.", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowError(string entityType, string errorMessage)
        {
            MessageBox.Show($"Failed to save {entityType.ToLower()} data. {errorMessage}",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowValidationErrorMessage(string errorMessage = "Some fields are not valid! Put the mouse over the red icon(s) to see the error.")
        {
            MessageBox.Show(errorMessage, "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
