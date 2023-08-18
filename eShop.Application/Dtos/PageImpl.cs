namespace eShop.Application.Dtos
{
    public class PageImpl<T>
    {
        public List<T> Payload { get; set; }
        public int size { get; set; }
        public int page { get; set; }
        public int totalPage { get; set; }
        public int totalElement { get; set; }
    }
}
