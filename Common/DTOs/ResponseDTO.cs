namespace BookStoreManagement.Common.DTOs
{
    public class ResponseDTO<T>
    {
        public bool Success { get; set; } = false;
        public string? Message { get; set; }
        public T? Data { get; set; }
    }
}
