using System;
using Xunit;
using Lab01.Domain;
using static Lab01.Domain.Playlist;
using System.Collections.Generic;
using System.Collections;
using FluentAssertions;
using System.Linq;

namespace Lab01.Domain.Tests
{
    public class PlaylistTests
    {
        [Fact] // detta behöver xunit för att veta att det är en test, om man inte har denna och kör dotnet test, hittas inga tester. 
        public void Playlist_should_be_active()
        {
            // arrange
            var sut = new Playlist();

            // act
            sut.IsActive = true;

            // assert - hur ska jag verifiera att saker är som förväntat, (en del av)

            Assert.True(sut.IsActive);
            //sut.IsActive.Should().BeTrue();
        }

        [Fact]
        public void Playlist_must_not_be_null()
        {
            //Arrange
            var sut = new Playlist();

            //Act
            sut.Title = "första";

            //Assert
            Assert.NotNull(sut.Title);

        }

        [Fact]
        public void Playlist_must_not_be_Empty()
        {
            //Arrange
            var sut = new Playlist();

            //Act
            sut.Title = "andra";

            //Assert
            Assert.NotEmpty(sut.Title);

        }

        // Can add songs to a playlist.
        [Fact]
        public void Add_songs_to_playlist()
        {
            //Arrange
            var sut = new Playlist();

            //Act
            sut.AddSong(new Song());

            //Assert
            Assert.True(sut.Songs.Count() > 0);
            // Assert.NotEmpty(sut.Songs); samma sak

        }

        [Fact]
        public void New_playlist_has_empty_song_list()
        {
            //Arrange
            var sut = new Playlist();

            //Assert
            Assert.Empty(sut.Songs);
        }


        [Fact]  //förstår inte
        public void Song_added_to_playlist_is_same_object_instance()
        {
            //Arrange
            var sut = new Playlist();
            var song = new Song();

            //Act
            sut.AddSong(song);

            //Assert
            Assert.Equal(song, sut.Songs[0]);
        }

        [Fact]
        public void songs_by_abba_not_allowed()
        {
            //Arrange
            var sut = new Playlist();
            var song = new Song() { Artist = "ABBA" };

            //Act
            sut.AddSong(song);

            //Assert
            Assert.Throws<InvalidOperationException>(() => sut.AddSong(song));
        }

        [Fact]
        public void playlist_can_be_cleared()
        {
            //Arrange
            var sut = new Playlist();

            //Act
            sut.AddSong(new Song()); // måste ha denna för att se om det fungerar... INGEN bra lösning dock..
            sut.Clear(); // vi kan inte testa clera utan att lägga till låt, då finns inget att cleare:a....

            //Assert
            Assert.Empty(sut.Songs);
        }

        [Fact]
        public void playlist_adds_current_year_as_title_prefix()
        {
            //Arrange
            var sut = new Playlist();

            //Act
            sut.AddSong(new Song() { Title = "My Song Title", Artist = "C" });
            sut.AddSong(new Song() { Title = "A song with A in beginning", Artist = "B" });

            //Assert
            Assert.Equal(sut.Songs[0].Title, "2021 My Song Title");
        }


        [Fact]
        public void playlist_orderd_by_artist_then_title()
        {
            //Arrange
            var sut = new Playlist();

            //Act
            sut.AddSong(new Song() { Title = "My Song Title", Artist = "C" });
            sut.AddSong(new Song() { Title = "A song with A in beginning", Artist = "B" });

            //Assert
            Assert.Equal(sut.Songs[0].Artist, "B");
        }




        [Theory]
        [InlineData(5, 2, 7)]
        [InlineData(10, 10, 20)]
        public void add_two_numbers(int x, int y, int expetedResult)
        {
            //Arrange
            var calculator = new Calculator();

            //Act
            var result = calculator.Add(x, y);

            //Assert
            Assert.Equal(expetedResult, result);


        }


    }
}
