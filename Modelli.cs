internal class Modelli : IProcessRequest
{
    public class Manager : RefundEvaluator
    {
        public override void EvaluateRefundRequest(RefundRequest request)
        {
            if (request.Amount > 2500)
            {
                ProcessRefundRequest(request);
                return;
            }

            if (request.Amount > 0 && request.Amount <= 400)
            {
                ProcessRefundRequest(request, this);
            }
            else if (Successor != null)
            {
                Successor.EvaluateRefundRequest(request);
            }
        }


    }

    public class Operational_Manager : RefundEvaluator
    {
        public override void EvaluateRefundRequest(RefundRequest request)
        {
            if (request.Amount > 400 && request.Amount <= 1000)
            {
                ProcessRefundRequest(request, this);
            }
            else if (Successor != null)
            {
                Successor.EvaluateRefundRequest(request);
            }
        }
    }

    public class CEO : RefundEvaluator
    {
        public override void EvaluateRefundRequest(RefundRequest request)
        {
            if (request.Amount > 1000)
            {
                ProcessRefundRequest(request, this);
            }
            else
            {
                ProcessRefundRequest(request);
            }
        }
    }

    public static void ProcessRefundRequest(RefundRequest request, RefundEvaluator model = null)
    {
        if (model != null)
        {
            File.AppendAllLines("spese_elaborate.txt", [$"{request.Date:dd/MM/yyyy};{request.Category};{request.Description};APPROVATA;{model.Role};{CalculateRefund(request)}"]);
        }
        else
        {
            File.AppendAllLines("spese_elaborate.txt", [$"{request.Date:dd/MM/yyyy};{request.Category};{request.Description};RESPINTA;-;-"]);
        }
    }

    public static double CalculateRefund(RefundRequest request)
    {
        {
            return request.Category switch
            {
                "Viaggio" => request.Amount + 50,
                "Alloggio" => request.Amount,
                "Vitto" => request.Amount * 0.7,
                "Altro" => request.Amount * 0.1,
                _ => 0,
            };
        }
    }
}

