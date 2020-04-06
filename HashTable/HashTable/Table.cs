using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class Table
    {
        private List<MusicGroup> infoMusicGroup;
        private int maxSizeTable;
        private List<bool> flagEmploymentCell;
        //string descriptor, int amount comprarison with another descriptors
        private Dictionary<string, int> amountComparison;
        private double averageAmountComparison;
        public Table(int maxSizeTable = 10)
        {
            this.maxSizeTable = maxSizeTable;
            infoMusicGroup = new List<MusicGroup>();
            flagEmploymentCell = new List<bool>();
            amountComparison = new Dictionary<string, int>();
            MusicGroup tempGroup = new MusicGroup("NULL", "NULL", 0, "NULL", 0);
            for (int i = 0; i < this.maxSizeTable; i++)
            {
                infoMusicGroup.Add(tempGroup);
                flagEmploymentCell.Add(false);
            }
        }
        public void Insert(MusicGroup musicGroup)
        {
            int index = this.HashFunction(musicGroup);
            if(flagEmploymentCell[index])
            {
                MusicGroup tempGroup = infoMusicGroup[index];
                while (tempGroup.Next != null)
                {
                    tempGroup = tempGroup.Next;
                }
                tempGroup.Next = musicGroup;
            }
            else
            {
                infoMusicGroup[index] = musicGroup;
                flagEmploymentCell[index] = true;
            }
        }
        public void ShowTable()
        {
            for (int i = 0; i < 119; i++)
                Console.Write("=");
            Console.WriteLine();
            Console.WriteLine("|{5,-3}|{0,-7}|{1,-40}|{2,-4}|{3,-40}|{4,-4}|", "Descriptor", "Name of group", "Year", "Genres", "Amount of album", "#");
            for (int i = 0; i < 119; i++)
                Console.Write("=");
            Console.WriteLine();
            int x = 0;
            foreach (MusicGroup musicGroup in infoMusicGroup)
            {
                MusicGroup tempGroup = musicGroup;
                while (tempGroup != null)
                {
                    Console.WriteLine("|{5,-3}|{0,-10}|{1,-40}|{2,-4}|{3,-40}|{4,-15}|", tempGroup.Descriptor, tempGroup.NameGroup, tempGroup.YearOfCreation, tempGroup.NameGenres, tempGroup.AmountOfAlbums, x);
                    tempGroup = tempGroup.Next; 
                }
                x++;
            }
            for (int i = 0; i < 119; i++)
                Console.Write("=");
            Console.WriteLine();
        }
        public void ShowStatistics()
        {
            this.averageAmountComparison = 0;
            foreach(KeyValuePair<string,int> keyValuePair in amountComparison)
            {
                Console.WriteLine("Descriptor {0} compared {1} times", keyValuePair.Key, keyValuePair.Value);
                averageAmountComparison += keyValuePair.Value;
            }
            averageAmountComparison /= amountComparison.Count;
            Console.WriteLine("Average amount of Comparison: {0}", averageAmountComparison);
        }
        public void Search(string descriptor)
        {
            int counter = 0;
            bool flagBreak = false;
            for (int i = 0; i < infoMusicGroup.Count; i++)
            {
                if (flagBreak)
                    break;
                MusicGroup tempGroup = infoMusicGroup[i];
                while (tempGroup != null)
                {
                    counter++;
                    if (descriptor == tempGroup.Descriptor)
                    {
                        Console.WriteLine("Result of search");
                        for (int j = 0; j < 119; j++)
                            Console.Write("=");
                        Console.WriteLine();
                        Console.WriteLine("|{5,-3}|{0,-10}|{1,-40}|{2,-4}|{3,-40}|{4,-15}|", tempGroup.Descriptor, tempGroup.NameGroup, tempGroup.YearOfCreation, tempGroup.NameGenres, tempGroup.AmountOfAlbums, i);
                        for (int j = 0; j < 119; j++)
                            Console.Write("=");
                        Console.WriteLine();
                        amountComparison.Add(descriptor, counter);
                        flagBreak = true;
                        break;
                    }
                    tempGroup = tempGroup.Next;
                }
            }
        }
        private int HashFunction(MusicGroup musicGroup)
        {
            int index = new int();
            char firstLetterDescriptor = musicGroup[0];
            char secondLetterDescriptor = musicGroup[1];
            index = (firstLetterDescriptor + secondLetterDescriptor) % maxSizeTable;
            return index;
        }
    }
}
