using BLL.Classes.File;
using BLL.Classes.Sort;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace BLL_Test
{
    [TestClass]
    public class ContentSorterTest
    {
        [TestMethod]
        public void SortByNameAsc()
        {
            var a = new Content("1", ".mp3", "C");
            var b = new Content("2", ".dat", "C");
            var c = new Content("3", ".dat", "C");
            var d = new Content("4", ".json", "D");
            var e = new Content("5", ".sql", "D");

            List<Content> list = new List<Content>() { e, d, c, b, a };
            var expected = new List<Content>() { a, b, c, d, e };


            list.Sort(new SortBynameAsc());

            CollectionAssert.AreEqual(expected, list);
        }

        [TestMethod]
        public void SortByExtensionAsc()
        {
            var a = new Content("1", ".mp3", "C");
            var b = new Content("2", ".dat", "C");
            var c = new Content("3", ".dat", "C");
            var d = new Content("4", ".json", "D");
            var e = new Content("5", ".sql", "D");

            List<Content> list = new List<Content>() { e, d, c, b, a };
            var expected = new List<Content>() { c, b, d, a, e };

            list.Sort(new SortByExtensionAsc());

            CollectionAssert.AreEqual(expected, list);
        }

        [TestMethod]
        public void SortByNameDesc()
        {
            var a = new Content("1", ".mp3", "C");
            var b = new Content("2", ".dat", "C");
            var c = new Content("3", ".dat", "C");
            var d = new Content("4", ".json", "D");
            var e = new Content("5", ".sql", "D");

            List<Content> list = new List<Content>() { e, d, c, b, a };
            var expected = new List<Content>() { e,d,c,b,a };


            list.Sort(new SortByNameDesc());

            CollectionAssert.AreEqual(expected, list);
        }

/*        [TestMethod]
        public void SortByExtensionDesc()
        {
            var a = new Content("1", ".mp3", "C");
            var b = new Content("2", ".dat", "C");
            var c = new Content("3", ".dat", "C");
            var d = new Content("4", ".json", "D");
            var e = new Content("5", ".sql", "D");

            List<Content> list = new List<Content>() { a, b, c, d, e };
            var expected = new List<Content>() { e, d, c, b, a };

            list.Sort(new SortByExtensionDesc());

            CollectionAssert.AreEqual(expected, list);
        }*/

    }
}
