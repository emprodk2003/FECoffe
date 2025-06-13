namespace FECoffe.DTO.Banks
{
    public class Datum
    {
        public int id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public string bin { get; set; }
        public string shortName { get; set; }
        public string logo { get; set; }
        public int transferSupported { get; set; }
        public int lookupSupported { get; set; }

    }

    public class Bank
    {
        public string code { get; set; }
        public string desc { get; set; }
        public IList<Datum> data { get; set; }
    }
}
