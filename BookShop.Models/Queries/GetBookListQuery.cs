using BookShop.Models.Queries.Abstractions;

namespace BookShop.Models.Queries
{
    public class GetBookListQuery : IPagedQuery<BookModel>
    {
        public GetBookListQuery(int authorId, int currentPage, int rowCount)
        {
            AuthorId = authorId;
            CurrentPage = currentPage;
            RowCount = rowCount;
        }
        public int AuthorId { get; private set; }
        public int CurrentPage { get; private set; }
        public int RowCount { get; private set; }
    }
}
