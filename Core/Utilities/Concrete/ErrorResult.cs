using CaseProject.Core.Utilities.Results.Concrete;

namespace Core.Utilities.Concrete
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(false, message)
        {
        }

        public ErrorResult() : base(false)
        {
        }
    }
}