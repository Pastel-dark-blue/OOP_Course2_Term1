using System;
using System.Xml.Serialization;

namespace Laba14
{
    [Serializable]
    public class Company
    {
        public string company = "";
    }

    [XmlInclude(typeof(FeatureFilm))]
    [Serializable]
    public class Film
    {
        public string Title { get; set; }

        public Company FilmCompany { get; set; }

        public int DurationMinutes { get; set; }

        [NonSerialized]
        public float rating = 0;
    }

    [Serializable]
    public class FeatureFilm : Film
    {  }
}
