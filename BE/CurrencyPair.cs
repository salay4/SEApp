namespace BE
{
    public class CurrencyPair
    {
        public int CurrencyPairId { get; set; }
        public string PairName { get; set; }
        public decimal MinValue { get; set; }
        public decimal MaxValue { get; set; }
    }
}
