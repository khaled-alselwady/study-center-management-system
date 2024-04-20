using System;

namespace StudyCenterUI.GlobalClasses
{
    public class clsFormat
    {
        public static string DateToShort(DateTime? Dt1)
        {

            return Dt1?.ToString("dd/MMM/yyyy");
        }

    }
}
