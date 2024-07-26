namespace JT.Mentoring.CodeKata;

public class BookCalculator
{
    private readonly int SingleBookPrice = 8;

    private Dictionary<int, decimal> _discounts = new() {
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
        decimal totalPrice = 0;

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

        foreach (var basket in basketCollection)
        {
            totalPrice += basket.Count * SingleBookPrice * _discounts[basket.Count];
        }

        return totalPrice;
    }
}
