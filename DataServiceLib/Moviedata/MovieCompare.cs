namespace DataServiceLib.Moviedata
{
    public class MovieCompare
    {
        //trying to make an compare class for moviecompare, that contains data from Actors, Details, Genres and Movies
        //not sure this will be used

        //properties
        public Movies TitleId { get; set; }
        public Movies PrimaryTitle { get; set; }

        public Genres Genre { get; set; }

        public Details Startyear { get; set; }
        public Details EndYear { get; set; }
        public Details RunTimeMinutes { get; set; } //int? used to fix that some values are null in the DB

        public Actors Nconst { get; set; }
        public Actors PrimaryName { get; set; }


        //navigation poperties
        //public string Type { get; set; } //dummy
    }
}