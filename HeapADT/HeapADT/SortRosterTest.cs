/* SortRosterTest.cs
 * test SortRoster.cs with player object
 * 
 * revision history:
 *  chris mosey 22.03.2015: created, tested, finished
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHLPlayer;
using NUnit.Framework;

namespace HeapADT
{
    class SortRosterTest
    {
        SortRoster roster;
        string file1;
        string file2;
        string file3;
        Player player;

        [SetUp]
        public void initialize()
        {
            roster = new SortRoster(10);
            file1 = "c:/PlayerSet1.xml";
            file2 = "c:/PlayerSet2.xml";
            file3 = "c:/Empty.xml";
        }

        [Test]
        public void testSort1()
        {
            player = new Player(3, "Donald", "Reverse");
            roster.SetFileName(file1);
            roster.ReadRoster();
            Assert.AreEqual(player, roster.Fetch());
        }

        [Test]
        public void testSort2()
        {
            player = new Player(66, "Chris", "Fwd");
            roster.SetFileName(file2);
            roster.ReadRoster();
            roster.Fetch();
            Assert.AreEqual(player, roster.Fetch());
        }

        [Test]
        public void testNoXMLFile()
        {
            Assert.Throws<ArgumentNullException>(() => roster.ReadRoster());
        }

        [Test]
        public void testXMLEmpty()
        {
            roster.SetFileName(file3);
            Assert.Throws<ArgumentException>(() => roster.ReadRoster());
        }
    }
}
