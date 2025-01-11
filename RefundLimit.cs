public abstract class RefundLimit
{
    public RefundLimit Successor { get; protected set; }

    public string Role { get
        {
            return GetType().Name;
        }
    }
    public void SetSuccessor(RefundLimit successor)
    {
        Successor = successor;
    }

    public abstract void CheckRefundaility(RefundRequest request);
}


