namespace MiniBlog.Core.Contracts.Photos.Queries.GetAllCategory
{
    public class PhotoDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public bool IsActive { get; private set; }
    }
}
