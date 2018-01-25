using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgainArt.Models
{
    public class Gallery
    {
        private Artist _artist;

        public Artist Artist
        {
            get
            {
                if (_artist == null)
                {
                    _artist = new Artist();
                }
                return _artist;
            }
            set { _artist = value; }
        }


        private ArtWork _artWork;

        public ArtWork ArtWork
        {
            get
            {
                if (_artWork == null)
                {
                    _artWork = new ArtWork();
                }
                return _artWork;
            }
            set { _artWork = value; }
        }

    }
}