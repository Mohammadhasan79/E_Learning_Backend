namespace E_Learning_Backend.Core.DTOs.ContentDto
{
    public class CreateContentDto
    {
        public string Type { get; set; } = "Video";
        public string Url { get; set; } = string.Empty;
    }
}
