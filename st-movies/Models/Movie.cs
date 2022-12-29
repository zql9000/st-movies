namespace st_movies.Models;

public class Movie
{
    public bool adult { get; set; }
    public string backdrop_path
    {
        get => $"https://image.tmdb.org/t/p/original{_backdrop_path}";
        set { _backdrop_path = value; }
    }
    public List<int> genre_ids { get; set; }
    public int id { get; set; }
    public string original_language { get; set; }
    public string original_title { get; set; }
    public string overview { get; set; }
    public double popularity { get; set; }
    public string poster_path
    {
        get => $"https://image.tmdb.org/t/p/original{_poster_path}";
        set { _poster_path = value; }
    }
    public string release_date { get; set; }
    public string title { get; set; }
    public bool video { get; set; }
    public double vote_average { get; set; }
    public int vote_count { get; set; }
    
    public string thumbnail_poster_path => $"https://image.tmdb.org/t/p/w92{_poster_path}";
    public string thumbnail_backdrop_path => $"https://image.tmdb.org/t/p/w300{_backdrop_path}";
    public string short_overview => overview.Substring(0,100) + "..." ;

    private string _backdrop_path;
    private string _poster_path;
}
