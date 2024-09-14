namespace Project_management_system.Enums
{
    public enum ErrorCode
    {
        NoError=0,
        //1000:2000 user errors
        UserEmailNotFound = 1000,

        //2000:3000 otp
        InvalidOTP = 3000,
        BadRequest=4000
    }
}
