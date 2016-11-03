// media files, music files, and playlists
// GC

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlaylist
{
    // a media file, base class for music, photo, video etc.
    public abstract class MediaFile                                      
    {
        private String fileName;

        // read/write property
        public String FileName 
        {
            get
            {
                return fileName;
            }
            set
            {
                // validate - filename must be specified
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("filename must not be null or empty");
                }
                else
                {
                    fileName = value;
                }
            }
        }
       
        // 1 constructor, filename must be specified
        protected MediaFile(String fileName)
        {
            FileName = fileName;
        }

        // inherited member from Object
        public override string ToString()
        {
            return "Filename: " + fileName;
        }
    }

    // possible genres for a music file
    public enum MusicGenre { Pop, Rock, Dance, HipHop, Wrap, Other }

    // a music file isa media file
    public class MusicFile : MediaFile
    {
        // fields
        private String title;
        private String artist;
        private MusicGenre genre;

        // read only property
        public String Title
        {
            get
            {
                return title;
            }
        }

        // read only property
        public String Artist
        {
            get
            {
                return artist;
            }
        }

        // read only property
        public MusicGenre Genre
        {
            get
            {
                return genre;
            }
        }
      

        // validate that title and artist are not blank
        public MusicFile(String filename, String title, String artist, MusicGenre genre) : base(filename)
        {
            if (String.IsNullOrEmpty(title))
            {
                throw new ArgumentException("title must not be null or empty");
            }
            else if (String.IsNullOrEmpty(artist))
            {
                throw new ArgumentException("artist must not be null or empty");
            }

            // set fields
            this.title = title;
            this.artist = artist;
            this.genre = genre;
            
        }

        // if not genre specified then set to "Other"
        public MusicFile(String filename, String title, String artist) : this(filename, title, artist, MusicGenre.Other)
        {
            // chained
        }

        // inherited member from MediaFile
        public override string ToString()
        {
            return base.ToString() + " Title: " + Title + " Artist: " + Artist + " Genre: " + Genre.ToString();
        }
    
    }

    // a playlist of music files
    public class Playlist : IEnumerable
    {
        public String Name { get; set; }
        List<MusicFile> tracks;                     // collection of tracks

        // constructor
        public Playlist(String name)
        {
            this.Name = name;
            tracks = new List<MusicFile>();
        }

        // read only property to get tracks
        public Collection<MusicFile> Tracks
        {
            get
            {
                return new Collection<MusicFile> (tracks);
            }
        }


        // add a track to playlist if it does not exist already i.e. a track with same title and artist exists in playlist already
        public void AddTrack(MusicFile track)
        {

            if (tracks == null)                            // empty
            {
                tracks.Add(track);
            }
            else
            {
                // look for a duplicate
                bool duplicate = false;
                foreach (MusicFile t in tracks)
                {
                    if ((track.Title == t.Title) && (track.Artist == t.Artist))
                    {
                        duplicate = true;
                        break;
                    }
                }

                if (duplicate)
                {
                    throw new ArgumentException("Exception: track " + track.Title + " " + track.Artist + " is already in the track list");
                }
                else
                {
                    tracks.Add(track);                  //no duplicate, add to list of tracks
                }
            }
        }

        // indexer - return a collection of music files for specified genre
        public IEnumerable<MusicFile> this[MusicGenre genre]
        {
            get
            {
                var tracksForGenre = tracks.Where(t => t.Genre == genre);           // LINQ query, select the whole music file
                return tracksForGenre;
            }
        }


        // iterate over tracks in collection
        public IEnumerator GetEnumerator()
        {
            foreach (MusicFile m in tracks)
            {
                yield return m;
            }
        }

    }
}
