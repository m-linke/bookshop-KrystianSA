using BookShop.Models.Queries.Abstractions;

namespace BookShop.Models.Queries
{
    public class GetBookListQuery : IQuery<BookModel>
    {
        public GetBookListQuery(int authorId)
        {
            AuthorId = authorId;
        }
        public int AuthorId;
    }
}
