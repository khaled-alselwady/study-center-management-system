using System;

namespace StudyCenterUI.GlobalClasses
{
    public class clsErrorLogger
    {
        private Action<string, Exception> _logAction;

        public clsErrorLogger(Action<string, Exception> logAction)
        {
            _logAction = logAction;
        }

        public void LogError(string errorType, Exception ex)
        {
            _logAction?.Invoke(errorType, ex);
        }
    }
}
