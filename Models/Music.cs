using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MusicCollectionApi.Models
{
    //Album is the principal entity to Song
    public class Album
    {
        public int AlbumId { get; set; }
        [Required]
        public string? AlbumName { get; set; }
        [Required]
        public int? Published { get; set; }
        //Koppling till Song
        public List<Song>? Song { get; set; }
    }

    // Song is the dependent entity to Album
    public class Song
    {
        public int SongId { get; set; }
        [Required]
        public string? Artist { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public int? Length { get; set; }
        public string? Category { get; set; }
        //koppling till album

        public int AlbumId { get; set; }
        public Album? Album { get; set; }
    }

}

// Kommandot för att "scaffolda" fram controller för API'et är:

// dotnet aspnet-codegenerator controller -name AlbumController -api -async -m Album -dc MusicContext -outDir Controllers

// dotnet aspnet-codegenerator controller -name SongController -api -async -m Song -dc MusicContext -outDir Controllers