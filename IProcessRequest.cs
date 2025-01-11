
internal interface IProcessRequest
{

    abstract static void ProcessRefundRequest(RefundRequest request, RefundEvaluator model = null);

    abstract static double CalculateRefund(RefundRequest request);

}

