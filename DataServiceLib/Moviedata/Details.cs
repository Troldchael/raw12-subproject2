namespace DataServiceLib.Moviedata
{
    public class Details
    {
        //properties
        public string TitleId { get; set; }
        public string Startyear { get; set; }
        public string EndYear { get; set; }
        public int? RunTimeMinutes { get; set; } //int? used to fix that some values are null in the DB

        //navigation poperties
        //public string Type { get; set; } //dummy
    }
}