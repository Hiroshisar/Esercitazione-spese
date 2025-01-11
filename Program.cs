// **********************************************************
// * POPOLA spese.txt CON LE SEGUENTI RICHIESTE DI RIMBORSO *
// **********************************************************

/*
List<RefundRequest> requests = new List<RefundRequest>
    {
        new RefundRequest(new DateTime(2021, 1, 1), "Viaggio", "Viaggio a Milano", 300),
        new RefundRequest(new DateTime(2022, 9, 2), "Viaggio", "Viaggio a Roma", 556.85),
        new RefundRequest(new DateTime(2021, 6, 13), "Alloggio", "Hotel", 120.85),
        new RefundRequest(new DateTime(2024, 1, 18), "Vitto", "Cena aziendale", 3000),
        new RefundRequest(new DateTime(2020, 2, 5), "Altro", "Scarpe per l'amante", 15000),
        new RefundRequest(new DateTime(2021, 10, 28), "Alloggio", "Hilton Hotel", 1500),
        new RefundRequest(new DateTime(2018, 3, 19), "Altro", "Benzina", 401.54),
        new RefundRequest(new DateTime(2023, 7, 20), "Vitto", "Albergo a Bari", 899),
    };
foreach (RefundRequest request in requests)
{
    File.AppendAllLines("spese.txt", [$"{request.Date:dd/MM/yyyy};{request.Category};{request.Description};{request.Amount}"]);
}
*/

Modelli.Manager manager = new();
Modelli.Operational_Manager operaionalManager = new();
Modelli.CEO ceo = new();

manager.SetSuccessor(operaionalManager);
operaionalManager.SetSuccessor(ceo);

foreach(string expenseLine in File.ReadAllLines("spese.txt"))
{
    string[] values = expenseLine.Split(';');
    RefundRequest request = new(DateTime.Parse(values[0]), values[1], values[2], double.Parse(values[3]));
    manager.CheckRefundaility(request);
}
