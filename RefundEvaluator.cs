public abstract class RefundEvaluator
{
    public RefundEvaluator Successor { get; protected set; }

    public string Role { get
        {
            return GetType().Name;
        }
    }
    public void SetSuccessor(RefundEvaluator successor)
    {
        Successor = successor;
    }

    public abstract void EvaluateRefundRequest(RefundRequest request);
}


