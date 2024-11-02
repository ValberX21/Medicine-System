namespace GoodAPI.Dto
{
    public class ResponseDto
    {
        public bool IsSuccess { get; set; } = true;
        public object Result { get; set; } = new object();
        public string DisplayMessage { get; set; } = "";
        public List<string> ErrorMessage { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}
