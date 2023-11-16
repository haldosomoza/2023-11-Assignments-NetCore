namespace BookstoreSystem
{

    internal abstract class Book
    {

        private string _Title;
        private string _Author;
        private double _Price;

        public Book() { 
            _Title  = String.Empty;
            _Author = String.Empty;
            _Price  = 0;
        }

        public Book(string Title, string Author, double Price)
        {
            _Title  = Title;
            _Author = Author;
            _Price  = Price;
        }

        public string GetTitle() { return _Title; }
        public double GetPrice() { return _Price; }

        public virtual string GetDetails()
        {
            return $"\"{_Title}\" by {_Author} - ${_Price}";
        }

    }

}
