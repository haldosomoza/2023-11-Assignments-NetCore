namespace BookstoreSystem
{

    internal class NonFictionBook : Book
    {

        private string _Topic;

        public NonFictionBook() : base()
        { 
            _Topic = String.Empty;
        }

        public NonFictionBook(string Topic, string Title, string Author, double Price) : base(Title, Author, Price) 
        {
            _Topic = Topic;
        }

        public override String GetDetails()
        {
            return "Non-Fiction - " + base.GetDetails();
        }

    }

}
