
internal class Modelli : IProcessRequest
{
    public class Manager : RefundLimit
    {
        public override void CheckRefundaility(RefundRequest request)
        {
            if (request.Amount > 2500)
            {
                Process(request);
                return;
            }

            if (request.Amount > 0 && request.Amount <= 400)
            {
                Process(request, this);
            }
            else if (Successor != null)
            {
                Successor.CheckRefundaility(request);
            }
        }


    }

    public class Operational_Manager : RefundLimit
    {
        public override void CheckRefundaility(RefundRequest request)
        {
            if (request.Amount > 400 && request.Amount <= 1000)
            {
                Process(request, this);
            }
            else if (Successor != null)
            {
                Successor.CheckRefundaility(request);
            }
        }
    }

    public class CEO : RefundLimit
    {
        public override void CheckRefundaility(RefundRequest request)
        {
            if (request.Amount > 1000)
            {
                Process(request, this);
            }
            else
            {
                Process(request);
            }
        }
    }

    public static void Process(RefundRequest request, RefundLimit model = null)
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

