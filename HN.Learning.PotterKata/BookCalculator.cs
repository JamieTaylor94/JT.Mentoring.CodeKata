namespace HN.Learning.PotterKata;

public class BookCalculator
{
    private const int SingleBookPrice = 8;

    private readonly Dictionary<int, decimal> _discounts = new() {
        { 0, 0 },
        { 1, 1 },
        { 2, 0.95m },
        { 3, 0.9m },
        { 4, 0.8m },
        { 5, 0.75m}
    };

    public decimal Calculate(string[] books)
    {
        var basketCollection = new List<List<string>>();

        foreach (var book in books)
        {
            bool isBookAdded = false;

            foreach (var basket in basketCollection)
            {
                if (!basket.Contains(book))
                {
                    basket.Add(book);
                    isBookAdded = true;
                    break;
                }
            }

            if (!isBookAdded)
            {
                basketCollection.Add([book]);
            }
        }

        return basketCollection.Sum(basket => basket.Count * SingleBookPrice * _discounts[basket.Count]);
    }
}
