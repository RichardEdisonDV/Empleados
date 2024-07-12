using FluentValidation.Results;

namespace Application.Exceptions
{
    public class ValidationException : Exception
    {
        public List<string> Errors { get; }
        public const string DefaultMessage = "One or more validation errors ocurred";

        public ValidationException() : base()
        {
            Errors = [];
        }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            foreach (var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }

    }
}
