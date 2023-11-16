namespace BookstoreSystem
{
    internal class Order
    {
        private string _CustomerName;
        private List<Book> _OrderedBooks;
        private double _TotalPrice;
        private int    _Discount;

        public Order(string CustomerName)
        {
            _CustomerName = CustomerName;
            _OrderedBooks = new List<Book>();
            _TotalPrice   = 0;
            _Discount     = 0;
        }

        public void AddOrderedBook(Book OneBook)
        {
            _OrderedBooks.Add(OneBook);
        }

        public bool hasBooks()
        {
            return _OrderedBooks.Count > 0;
        }

        public int GetDiscout()
        {
            return _Discount;
        }
        public void SetDiscout(int Discount)
        {
            _Discount = Discount;
        }

        private double CalculateTotalPrice()
        {
            _TotalPrice = 0;
            foreach (var OrderedBook in _OrderedBooks)
            {
                _TotalPrice += OrderedBook.GetPrice();
            }
            return _TotalPrice;
        }

        public void DisplayOrderDetails()
        {
            CalculateTotalPrice();
            double DiscountedTotalPrice = Math.Round(_TotalPrice - (_TotalPrice * _Discount / 100), 2);

            int index = 1;
            string BookList = String.Empty;
            foreach (var OrderedBook in _OrderedBooks)
            {
                BookList += $"\n {index}. {OrderedBook.GetDetails()}";
                index++;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            string TextToWrite = $"""

                ORDER SUMMARY
                Customer Name: {_CustomerName}
                Ordered Books: {BookList}
                Total Price: ${_TotalPrice}
                Discount Applied: {_Discount}%
                Discounted Total Price: ${DiscountedTotalPrice}

                """;
            Console.Write(TextToWrite);
        }

    }

}
