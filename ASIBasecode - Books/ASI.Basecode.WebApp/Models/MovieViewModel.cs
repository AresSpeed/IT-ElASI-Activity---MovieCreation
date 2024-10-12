using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System;

public class MovieViewModel
{
    [JsonPropertyName("Title")]
    [Required(ErrorMessage = "Title is required.")]
    public string Title { get; set; }

    [JsonPropertyName("Director")]
    [Required(ErrorMessage = "Director's name is required.")]
    public string Director { get; set; }

    [JsonPropertyName("Description")]
    [Required(ErrorMessage = "Description is required.")]
    public string Description { get; set; }

    [JsonPropertyName("ReleaseDate")]
    [Required(ErrorMessage = "Release date is required.")]
    public DateTime ReleaseDate { get; set; }

    [JsonPropertyName("ImageUrl")]
    [Required(ErrorMessage = "Image URL is required.")]
    public string ImageUrl { get; set; }
}
