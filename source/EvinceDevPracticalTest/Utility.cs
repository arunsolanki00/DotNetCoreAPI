namespace EvinceDevPracticalTest
{
    public class Utility
    {
        public enum Gender
        {

        }
    }

    public class ResponseClass<T>
    {
        public bool? IsSuccess { get; set; }
        public T Data { get; set; }
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }
}
