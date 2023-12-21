using BookShop.Models.Queries.Abstractions;

namespace BookShop.Models.Queries
{
    public class GetAuthorListQuery : IPagedQuery<AuthorModel>
    {
        public GetAuthorListQuery(int currentPage, int rowCount)
        {
            CurrentPage = currentPage;
            RowCount = rowCount;
        }

        public int CurrentPage { get; private set; }

        public int RowCount { get; private set; }
    }
}