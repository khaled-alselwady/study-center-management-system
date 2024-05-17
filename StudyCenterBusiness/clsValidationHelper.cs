using System;

namespace StudyCenterBusiness
{
    /// <summary>
    /// A helper class for performing various validation checks on entities.
    /// </summary>
    public static class clsValidationHelper
    {
        /// <summary>
        /// Validates an entity based on the provided validation checks.
        /// </summary>
        /// <typeparam name="T">The type of the entity to validate.</typeparam>
        /// <param name="entity">The entity instance to validate.</param>
        /// <param name="idCheck">A function to check the validity of the entity's ID. This can be null if no ID check is required.</param>
        /// <param name="valueCheck">A function to check the validity of the entity's values. This can be null if no value check is required.</param>
        /// <param name="dateCheck">A function to check the validity of the entity's dates. This can be null if no date check is required.</param>
        /// <param name="additionalChecks">
        /// An array of additional validation checks, each with an associated error message.
        /// Each check is a tuple containing a function to validate the condition and a string error message.
        /// </param>
        /// <returns>True if the entity passes all validation checks, otherwise false.</returns>
        public static bool Validate<T>(
            T entity,
            Func<T, bool> idCheck,
            Func<T, bool> valueCheck,
            Func<T, bool> dateCheck = null,
            params (Func<T, bool> condition, string errorMessage)[] additionalChecks)
        {
            if (idCheck != null && !idCheck(entity))
            {
                return false;
            }

            if (valueCheck != null && !valueCheck(entity))
            {
                return false;
            }

            if (dateCheck != null && !dateCheck(entity))
            {
                return false;
            }

            foreach (var (condition, errorMessage) in additionalChecks)
            {
                if (!condition(entity))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Checks if the given nullable value has a value.
        /// </summary>
        /// <typeparam name="T">The type of the nullable value.</typeparam>
        /// <param name="value">The nullable value to check.</param>
        /// <returns>True if the value has a value, otherwise false.</returns>
        public static bool HasValue<T>(T? value) where T : struct
        {
            return value.HasValue;
        }

        /// <summary>
        /// Checks if the given string is not null, empty, or whitespace.
        /// </summary>
        /// <param name="value">The string to check.</param>
        /// <returns>True if the string is not null, empty, or whitespace, otherwise false.</returns>
        public static bool IsNotEmpty(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// Checks if an entity exists in the database based on the provided check function.
        /// </summary>
        /// <param name="existsCheck">A function that checks if the entity exists in the database.</param>
        /// <returns>True if the entity exists, otherwise false.</returns>
        public static bool ExistsInDatabase(Func<bool> existsCheck)
        {
            return existsCheck();
        }

        /// <summary>
        /// Checks if the given date is not valid based on the specified comparison with the reference date.
        /// </summary>
        /// <param name="date">The date to check.</param>
        /// <param name="referenceDate">The reference date to compare against.</param>
        /// <param name="isBefore">If true, checks if the date is before the reference date; if false, checks if the date is after the reference date.</param>
        /// <returns>True if the date is not valid based on the comparison, otherwise false.</returns>
        public static bool DateIsNotValid(DateTime date, DateTime referenceDate, bool isBefore = true)
        {
            return isBefore ? date.Date < referenceDate.Date : date.Date > referenceDate.Date;
        }
    }
}
