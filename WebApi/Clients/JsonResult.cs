namespace WebApi.Clients
{
    public class JsonResult<T> where T : class
    {
        public bool IsSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public T Data { get; set; }
    }
}
