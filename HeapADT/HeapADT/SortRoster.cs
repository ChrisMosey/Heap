/* SortRoster.cs
 * Sorts xml file
 * 
 * Revision History: 
 *  Chris Mosey: 15.03.2015: created
 * 
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using NHLPlayer;
using System.IO;

namespace HeapADT
{
    class SortRoster
    {
        private int maxSize;
        private string fileName;
        private Heap<Player> heap;

        public SortRoster(int maxSize)
        {
            this.maxSize = maxSize;
            heap = new Heap<Player>(maxSize);
        }

        public SortRoster(int maxSize, string fileName)
        {
            this.maxSize = maxSize;
            SetFileName(fileName);
            heap = new Heap<Player>(maxSize);
        }

        public void SetFileName(string fileName)
        {
            this.fileName = fileName;

            if (!File.Exists(fileName))
            {
                throw new ArgumentException("Incorrect fileName");
            }
        }

        public void ReadRoster()
        {
            XDocument doc = XDocument.Load(fileName);
            if (!doc.Root.Elements().Any())
            {
                throw new ArgumentException("XML file empty");
            }
            var players = doc.Descendants("player");
            Player playerInsert;
            foreach (var player in players)
            {
                int jerseyNumber = int.Parse(player.Element("jersey").Value);
                string playerName = player.Element("Name").Value;
                string position = player.Element("Position").Value;
                playerInsert = new Player(jerseyNumber, playerName, position);
                heap.Insert(playerInsert);
            }
        }

        public Player Fetch()
        {
            return heap.getMin();
        }
    }
}
