namespace E_Association.Application.Queries.Request
{
    public class AssociationModel
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public decimal Amount { set; get; }
        public int Capacity { set; get; }
        public DateTime StatAt { set; get; }
        public DateTime EndAt { set; get; }
    }
}