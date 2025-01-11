
internal interface IProcessRequest
{

    abstract static void Process(RefundRequest request, RefundLimit model = null);

    abstract static double CalculateRefund(RefundRequest request);

}

