using System.Text.Json.Serialization;

namespace FreeCourse.Shared.Dtos
{
    public class ResponseDto<T>
    {
        public T Data { get; private set; }

        [JsonIgnore]
        public int StatusCode { get; set; }

        [JsonIgnore]
        public bool IsSuccess { get; private set; }

        public List<String> Errors { get; private set; }

        //Static Factory Method
        public static ResponseDto<T> Success(T data, int StatusCode)
        {
            return new ResponseDto<T> { Data = data, StatusCode = StatusCode, IsSuccess=true };
        }

        public static ResponseDto<T> Success(int StatusCode)
        {
            return new ResponseDto<T> {Data=default(T), StatusCode = StatusCode, IsSuccess=true };
        }

        public static ResponseDto<T> Fail(List<string> errors, int StatusCode)
        {
            return new ResponseDto<T> {Errors = errors, StatusCode = StatusCode, IsSuccess=false };
        }
        public static ResponseDto<T> Fail(string error,int StatusCode)
        {
            return new ResponseDto<T> {Errors = new List<string>{ error}, StatusCode = StatusCode, IsSuccess=true };
        }
    }
}