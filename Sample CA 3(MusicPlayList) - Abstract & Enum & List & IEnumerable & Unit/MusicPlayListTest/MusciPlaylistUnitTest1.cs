// some unit tests for MediaFile, MusicFile andPlaylist

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicPlaylist;

namespace MusicPlayListTest
{
    [TestClass]
    public class MusciPlaylistUnitTest1
    {
        // title not be blank 
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]   
        public void TestValidation1() 
        {
            MusicFile track1 = new MusicFile("t1.mp3", "", "Likki Li", MusicGenre.Dance);
        }

        // artist not be blank
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestValidation2()
        {
            MusicFile track1 = new MusicFile("t1.mp3", "I follow Rivers", "", MusicGenre.Dance);
        }

        // artist should not be null
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestValidation3()
        {
            MusicFile track1 = new MusicFile("t1.mp3", "I follow Rivers", null);
        }

        // construct some objects and check properties have been set correctly
        [TestMethod]
        public void TestConstructors()
        {
            MusicFile track1 = new MusicFile("t1.mp3", "I follow Rivers", "Likki Li", MusicGenre.Dance);
            MusicFile track2 = new MusicFile("t4.mp3", "Were the people", "Empire of the Sun");
            Assert.AreEqual(track1.Title, "I follow Rivers");
            Assert.AreEqual(track1.Artist, "Likki Li");
            Assert.AreEqual(track1.Genre, MusicGenre.Dance);
            Assert.AreEqual(track2.Genre, MusicGenre.Other);
        }

        // test add to playlist
        [TestMethod]
        public void TestAdd1()
        {
            MusicFile track1 = new MusicFile("t1.mp3", "I follow Rivers", "Likki Li", MusicGenre.Dance);
            MusicFile track2 = new MusicFile("t2.mp3", "Since I Left You", "The Avalanches", MusicGenre.Dance);

            Playlist playlist = new Playlist("Cool Tunes");
            playlist.AddTrack(track1);
            playlist.AddTrack(track2);

            CollectionAssert.Contains(playlist.Tracks, track1);
            CollectionAssert.Contains(playlist.Tracks, track2);
        }

        // test that a duplicate track in terms of artist & title combination cannot be added
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestAdd2()
        {
            MusicFile track1 = new MusicFile("t1.mp3", "I follow Rivers", "Likki Li", MusicGenre.Dance);
           
            Playlist playlist = new Playlist("Cool Tunes");
            playlist.AddTrack(track1);
            playlist.AddTrack(new MusicFile("t1.mp3", "I follow Rivers", "Likki Li", MusicGenre.Dance));

        }

        // test read-only indexer
        [TestMethod]
        public void TestIndexer()
        {
            MusicFile track1 = new MusicFile("t1.mp3", "I follow Rivers", "Likki Li", MusicGenre.Dance);
            MusicFile track2 = new MusicFile("t2.mp3", "Since I Left You", "The Avalanches", MusicGenre.Dance);
            MusicFile track3 = new MusicFile("t3.mp3", "Run to the Hills", "Iron Maiden", MusicGenre.Rock);
      
            Playlist playlist = new Playlist("Cool Tunes");
            playlist.AddTrack(track1);
            playlist.AddTrack(track2);
            playlist.AddTrack(track3);
           
            // make a List of dance tracks added
            List<MusicFile> danceTracks = new List<MusicFile>();
            danceTracks.Add(track1);
            danceTracks.Add(track2);

            // make a List of dance tracks as determined by indexer
            List<MusicFile> playlistDanceTracks = new List<MusicFile>();
            foreach (MusicFile t in playlist[MusicGenre.Dance])
            {
                playlistDanceTracks.Add(t);
            }

            // both lists should be equal
            CollectionAssert.AreEqual(danceTracks, playlistDanceTracks);

        }

    }
}
