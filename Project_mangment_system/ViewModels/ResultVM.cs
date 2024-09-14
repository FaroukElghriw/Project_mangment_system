using Project_management_system.Enums;

namespace Project_management_system.ViewModels
{
    public class ResultVM<T>
    {

            public bool IsSuccess { get; set; }
            public T Data { get; set; }
            public string Message { get; set; }

            public ErrorCode ErrorCode { get; set; }


            public static ResultVM<T> Sucess<T>(T data, string message = "")
            {
                return new ResultVM<T>
                {
                    IsSuccess = true,
                    Data = data,
                    Message = message,
                    ErrorCode = ErrorCode.NoError,
                };
            }

            public static ResultVM<T> Faliure(ErrorCode errorCode, string message)
            {
                return new ResultVM<T>
                {
                    IsSuccess = false,
                    Data = default,
                    Message = message,
                    ErrorCode = errorCode,
                };
            }
        }
    }

