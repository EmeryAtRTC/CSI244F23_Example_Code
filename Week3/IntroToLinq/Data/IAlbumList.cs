using IntroToLinq.Models;

namespace IntroToLinq.Data
{
    public interface IAlbumList
    {
        List<Album> GetAlbums();
    }
}