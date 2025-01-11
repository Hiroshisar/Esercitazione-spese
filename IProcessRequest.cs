
internal interface IProcessRequest
{

    abstract static void Process(bool IsRefundable, RefundRequest request, RefundLimit model = null);

    abstract static double CalculateRefund(RefundRequest request);

}

