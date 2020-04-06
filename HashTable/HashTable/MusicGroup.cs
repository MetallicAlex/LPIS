using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class MusicGroup
    {
        private string descriptor;
        private string nameGroup;
        private int yearOfCreation;
        private string nameGenres;
        private int amountOfAlbums;
        private MusicGroup nextMusicGroup;
        public MusicGroup(string descriptor, string nameGroup, int yearOfCreation, string nameGenres, int amountOfAlbums)
        {
            this.Descriptor = descriptor;
            this.NameGroup = nameGroup;
            this.YearOfCreation = yearOfCreation;
            this.NameGenres = nameGenres;
            this.AmountOfAlbums = amountOfAlbums;
            this.nextMusicGroup = null;
        }
        public string Descriptor
        {
            set { this.descriptor = value; }
            get { return this.descriptor; }
        }
        public string NameGroup
        {
            set { this.nameGroup = value; }
            get { return this.nameGroup; }
        }
        public int YearOfCreation
        {
            set { this.yearOfCreation = value; }
            get { return this.yearOfCreation; }
        }
        public string NameGenres
        {
            set { this.nameGenres = value; }
            get { return this.nameGenres; }
        }
        public int AmountOfAlbums
        {
            set { this.amountOfAlbums = value; }
            get { return this.amountOfAlbums; }
        }
        public char this[int index]
        {
            get { return descriptor[index]; }
        }
        public MusicGroup Next
        {
            set { nextMusicGroup = value; }
            get { return nextMusicGroup; }
        }
    }
}
