
public class RefundRequest
{
    public DateTime Date { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public double Amount { get; set; }

    public RefundRequest(DateTime date, string category, string description, double amount)
    {
        Date = date;
        Category = category;
        Description = description;
        Amount = amount;
    }

}

