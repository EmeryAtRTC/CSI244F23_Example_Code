using IntroToLinq.Models;

namespace LinqDemo.Data
{
    public interface IAlbumList
    {
        List<Album> GetAlbums();
    }
}