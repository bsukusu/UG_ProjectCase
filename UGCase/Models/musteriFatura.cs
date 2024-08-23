namespace UGCase.Models
{
    public class musteriFatura
    {
        public int Id { get; set; }
        public int musteriId { get; set; }
        public DateTime faturaTarihi { get; set; }
        public decimal faturaTutari { get; set; }
        public DateTime? odemeTarihi { get; set; }

        public musteri Musteri { get; set; }
    }
}
