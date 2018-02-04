using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgainArt.Models
{
    public class Gallery
    {
        private Alert _alert;

        public Alert Alert
        {
            get {
                if (_alert == null)
                {
                    _alert = new Alert();
                }
                return _alert; }
            set { _alert = value; }
        }

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

        private List<ArtWork> _lstArtWorkCategory;

        public List<ArtWork> LstArtWorkCategory
        {
            get
            {
                if (_lstArtWorkCategory == null)
                {
                    _lstArtWorkCategory = new List<ArtWork>();
                }
                return _lstArtWorkCategory;
            }
            set
            {
                _lstArtWorkCategory = value;
            }
        }

        private List<ArtWork> _lstArtWork;

        public List<ArtWork> LstArtWork
        {
            get
            {
                if (_lstArtWork == null)
                {
                    _lstArtWork = new List<ArtWork>();
                }
                return _lstArtWork;
            }
            set
            {
                _lstArtWork = value;
            }
        }

        private Email _email;
        public Email Email
        {
            get
            {
                if (_email == null)
                {
                    _email = new Email();
                }
                return _email;
            }
            set { _email = value; }
        }
    }
}