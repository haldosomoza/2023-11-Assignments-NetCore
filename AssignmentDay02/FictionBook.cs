namespace BookstoreSystem
{

    internal class FictionBook : Book
    {

        private string _Genre;

        public FictionBook() : base()
        {
            _Genre  = String.Empty;
        }

        public FictionBook(string Genre, string Title, string Author, double Price) : base(Title, Author, Price) 
        {
            _Genre = Genre;
        }

        public override String GetDetails()
        {
            return "Fiction - " + base.GetDetails();
        }

    }

}
