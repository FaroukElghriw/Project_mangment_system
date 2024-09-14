using Project_management_system.Enums;

namespace Project_management_system.Exceptions
{
    public class BusinessException:Exception
    {
        public ErrorCode ErrorCode { get; set; }
        public BusinessException(ErrorCode errorCode, string message) : base(message)
        {
            ErrorCode = errorCode;
        }
    }
}
