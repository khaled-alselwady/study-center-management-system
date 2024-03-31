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

        public static DialogResult ShowDeleteConfirmation(string entityType)
        {
            return MessageBox.Show($"Are you sure you want to delete this {entityType.ToLower()}?",
                "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);
        }

        public static void ShowDeletionSuccess(string entityType)
        {
            MessageBox.Show($"The {entityType.ToLower()} was successfully deleted.",
                "Deletion Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowDeletionFailure(string entityType)
        {
            MessageBox.Show($"Failed to delete the {entityType.ToLower()}.",
                "Deletion Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowDeletionFailure(string entityType, string instructionMessage)
        {
            MessageBox.Show($"Failed to delete the {entityType.ToLower()}. {instructionMessage}",
                "Deletion Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowMissingDataMessage(string entityType, int? entityID)
        {
            MessageBox.Show($"No {entityType} found with ID: {entityID}", "Missing Data",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
