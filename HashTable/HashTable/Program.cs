using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTable
{
    class Program
    {
        static void Main(string[] args)
        {
            string descriptor;
            Table table = new Table(10);
            table.Insert(new MusicGroup("ENG1", "Iron Maiden", 1975, "Heavy Metal", 16));
            table.Insert(new MusicGroup("ENG2", "Judas Priest", 1969, "Heavy Metal", 18));
            table.Insert(new MusicGroup("ENG3", "Motorhead", 1975, "Heavy Metal", 23));
            table.Insert(new MusicGroup("ENG4", "Paradise Lost", 1988, "Death-Doom,Gothic Metal", 14));
            table.Insert(new MusicGroup("ITA1", "Lacuna Coil", 1996, "Gothic Metal", 9));
            table.Insert(new MusicGroup("ITA2", "Nanowar", 2003, "Heavy,Power, Metal", 4));
            table.Insert(new MusicGroup("NED1", "Epica", 2003, "Symphonic, Gothic Metal", 8));
            table.Insert(new MusicGroup("NED2", "Within Temptation", 1996, "Symphonic, Gothic Metal", 7));
            table.Insert(new MusicGroup("NED3", "Delain", 2002, "Symphonic Metal", 6));
            table.Insert(new MusicGroup("FIN1", "Nightwish", 1996, "Symphonic Metal", 9));
            table.Insert(new MusicGroup("FIN2", "Finntroll", 1997, "Volk Metal", 7));
            table.Insert(new MusicGroup("SWE1", "Arch Enemy", 1996, "Melodic Death Metal", 11));
            table.Insert(new MusicGroup("SWE5", "Arch Enemy", 1996, "Melodic Death Metal", 11));
            table.Insert(new MusicGroup("SWE2", "Tiamat", 1989, "Death,Doom,Gothic Metal", 10));
            table.Insert(new MusicGroup("SWE3", "Opeth", 1990, "Death-Doom,Progressive Metal,Rock", 13));
            table.Insert(new MusicGroup("SWE4", "Therion", 1989, "Symphonic Metal", 15));
            table.Insert(new MusicGroup("BLR1", "Litvintroll", 2005, "Volk Metal", 2));
            table.Insert(new MusicGroup("POL1", "Vader", 1983, "Death,Trash Metal", 11));
            table.Insert(new MusicGroup("RUS1", "Louna", 2008, "Alternative Rock", 7));
            table.Insert(new MusicGroup("RUS2", "Aria", 1985, "Heavy Metal", 13));
            table.Insert(new MusicGroup("FRA1", "Gojira", 1996, "Death, Progressive, Groove Metal", 6));
            table.Insert(new MusicGroup("SWI1", "Eluveitie", 2002, "Volk Metal", 8));
            table.Insert(new MusicGroup("NOR1", "Sirenia", 2001, "Symphonic, Gothic Metal", 9));
            table.Insert(new MusicGroup("NOR2", "Tristania", 1996, "Symphonic, Gothic Metal", 7));
            table.Insert(new MusicGroup("GER1", "Kreator", 1982, "Trash Metal", 13));
            table.Insert(new MusicGroup("GER2", "Blind Guardian", 1984, "Power Metal", 11));
            table.Insert(new MusicGroup("BRA1", "Sepultura", 1984, "Trash Metal", 15));
            table.Insert(new MusicGroup("USA1", "Slayer", 1981, "Trash Metal", 12));
            table.Insert(new MusicGroup("USA2", "Megadeth", 1983, "Trash Metal", 15));
            table.Insert(new MusicGroup("USA3", "Metallica", 1981, "Trash Metal", 10));
            table.Insert(new MusicGroup("USA4", "Anthrax", 1981, "Trash Metal", 11));
            table.Insert(new MusicGroup("CAN1", "Annihilator", 1984, "Trash Metal", 17));
            table.ShowTable();
            table.Search("ENG4");
            table.Search("GER1");
            table.Search("USA1");
            table.Search("SWI1");
            table.Search("FRA1");
            table.ShowStatistics();
            bool flagQuit = false;
            while(!flagQuit)
            {
                Console.Write("Enter command: ");
                string command = Console.ReadLine();
                switch(command)
                {
                    case "insert":
                        Console.Write("Descriptor: ");
                        descriptor = Console.ReadLine();
                        Console.Write("Name of group: ");
                        string nameOfGroup = Console.ReadLine();
                        Console.Write("Year: ");
                        int year = Convert.ToInt16(Console.ReadLine());
                        Console.Write("Genres: ");
                        string genres = Console.ReadLine();
                        Console.Write("Amount of album: ");
                        int amountOfAlbum = Convert.ToInt16(Console.ReadLine());
                        table.Insert(new MusicGroup(descriptor, nameOfGroup, year, genres, amountOfAlbum));
                        break;
                    case "search":
                        Console.Write("Descriptor: ");
                        descriptor = Console.ReadLine();
                        table.Search(descriptor);
                        break;
                    case "table":
                        table.ShowTable();
                        break;
                    case "result":
                        table.ShowStatistics();
                        break;
                }
                Console.Write("Next [y/n]?: ");
                char character = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (character == 'y')
                    flagQuit = false;
                else if (character == 'n')
                    flagQuit = true;
                else Console.WriteLine("Inserted false character");
            }
        }
    }
}
