namespace BookShop.Models
{
    public class AuthorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string NameAndSurname
        {
            get
            {
                return $"{Name} {Surname}";
            }
        }
    }
}