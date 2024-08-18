using Microsoft.EntityFrameworkCore;
using Tunify.Data;
using Tunify.Model;
using Tunify.Repositories.Services;

namespace TestProject1
{
    public class UnitTest1
    {
        private readonly TunifyDbContext _tunifyDbContext;
        private readonly PlayListService _playListService;

        public UnitTest1()
        {
            var options = new DbContextOptionsBuilder<TunifyDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                            .Options;

            _tunifyDbContext = new TunifyDbContext(options);
            _playListService = new PlayListService(_tunifyDbContext);
        }

        [Fact]
        public async Task GetSongsForPlaylistTest()
        {
            // Arrange: Add playlist-song relationships to the in-memory database

            _tunifyDbContext.Songs.AddRange(new List<Songs> {
                 new Songs {SongID=1,  Title = "JohnDoe", Genre = "johndoe@example.com",ArtistID=1 },
                new Songs { SongID=2, Title = "Mark",    Genre =    "Mark@example.com" ,ArtistID=2}
     });

            _tunifyDbContext.PlayList.AddRange(new List<PlayList> {
         new PlayList { PlayListID=1, PlayListName = "HowYourLife",CreatedDate = new DateTime(2021,11,10) },
         new PlayList { PlayListID=2, PlayListName = "FunG", CreatedDate = new DateTime(2019,11,10) }
     });
            _tunifyDbContext.PlayListSongs.Add(new PlayListSong { PlayListID = 1, SongID = 1, PlayListSongID = 1 });
            _tunifyDbContext.PlayListSongs.Add(new PlayListSong { PlayListID = 2, SongID = 1, PlayListSongID = 2 });

            //new PlayListSong { PlayListID = 1, SongID = 1, PlayListSongID = 1 },
            //   new PlayListSong { PlayListID = 2, SongID = 1, PlayListSongID = 2 });
            await _tunifyDbContext.SaveChangesAsync();

            // Act: Retrieve songs for the given playlist ID
            var result = await _playListService.GetSongsByPlaylist(1);

            // Assert: Verify the results
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}