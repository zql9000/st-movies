using CommunityToolkit.Mvvm.Input;
using st_movies.Models;
using st_movies.Services;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace st_movies.ViewModels;

public partial class MainViewModel : BaseViewModel
{
    public ObservableCollection<Movie> Movies { get; } = new();

    private int currentPage = 0;
    private string lastSearchText = string.Empty;
    private readonly MovieService movieService;
    
    public MainViewModel(MovieService movieService)
	{
        this.movieService = movieService;
        Title = "Search movies";
    }

    [RelayCommand]
    private async Task SearchMovies(string searchText)
    {
        if (string.IsNullOrEmpty(searchText)) return;
        if (!searchText.Equals(lastSearchText)) Movies.Clear();

        try
        {
            IsBusy = true;

            var response = await movieService.SearchMovies(searchText, ++currentPage);
            foreach (var movie in response.results)
            {
                Movies.Add(movie);
            }
            lastSearchText = searchText;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get movies: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {
            IsBusy = false;
        }
    }
}
