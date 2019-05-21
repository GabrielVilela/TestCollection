using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
using TestCollection.Util.Interfaces;

namespace TestCollection.Tests
{
    [TestClass]
    public class TestCollectionUTest
    {
        [TestMethod]
        public void Add()
        {
            ITestCollection testColl = new Util.TestCollection();
            var test1 = testColl.Add("ano.nascimento", 1983, "amanda");
            Assert.IsTrue(test1);
            var test2 = testColl.Add("ano.nascimento", 1983, "amanda");
            Assert.IsFalse(test2);
            var test3 = testColl.Add("ano.nascimento", 1984, "caio");
            Assert.IsTrue(test3);

        }
        [TestMethod]
        public void IndexOf()
        {
            ITestCollection testColl = new Util.TestCollection();
            testColl.Add("ano.nascimento", 1983, "amanda");
            testColl.Add("ano.nascimento", 1982, "ciro");
            testColl.Add("ano.nascimento", 1984, "caio");
            testColl.Add("ano.nascimento", 1983, "adam");
            Assert.AreEqual(2,testColl.IndexOf("ano.nascimento","amanda"));
            Assert.AreEqual(0, testColl.IndexOf("ano.nascimento", "ciro"));
            Assert.AreEqual(3, testColl.IndexOf("ano.nascimento", "caio"));
            Assert.AreEqual(1, testColl.IndexOf("ano.nascimento", "adam"));
        }
        [TestMethod]
        public void Remove()
        {
            ITestCollection testColl = new Util.TestCollection();
            testColl.Add("ano.nascimento", 1983, "amanda");
            testColl.Add("ano.nascimento", 1982, "ciro");
            testColl.Add("ano.nascimento", 1984, "caio");
            testColl.Add("ano.nascimento", 1983, "adam");
            Assert.IsTrue(testColl.Remove("ano.nascimento"));
            Assert.IsFalse(testColl.Remove("cidade.sp"));
        }
        [TestMethod]
        public void RemoveValuesFromSubIndex()
        {
            ITestCollection testColl = new Util.TestCollection();
            testColl.Add("ano.nascimento", 1983, "amanda");
            testColl.Add("ano.nascimento", 1982, "ciro");
            testColl.Add("ano.nascimento", 1984, "caio");
            testColl.Add("ano.nascimento", 1983, "adam");
            testColl.Add("cidade.sp", 2000, "franca");
            Assert.IsTrue(testColl.RemoveValuesFromSubIndex("ano.nascimento",1983));
            Assert.IsFalse(testColl.RemoveValuesFromSubIndex("ano.nascimento", 1990));
            Assert.IsFalse(testColl.RemoveValuesFromSubIndex("ano.formatura", 1983));
            Assert.IsFalse(testColl.RemoveValuesFromSubIndex("cidade.sp", 1983));
            Assert.IsTrue(testColl.RemoveValuesFromSubIndex("cidade.sp", 2000));
        }
        [TestMethod]
        public void Get()
        {
            ITestCollection testColl = new Util.TestCollection();
            IList list = new List<string>();

            list.Add("ciro");
            list.Add("adam");
            list.Add("amanda");
            list.Add("caio");
            testColl.Add("ano.nascimento", 1983, "amanda");
            testColl.Add("ano.nascimento", 1982, "ciro");
            testColl.Add("ano.nascimento", 1984, "caio");
            testColl.Add("ano.nascimento", 1983, "adam");
            CollectionAssert.AreEqual(list,(List<string>)testColl.Get("ano.nascimento", 0, 3));
            CollectionAssert.AreEqual(list, (List<string>)testColl.Get("ano.nascimento", 0, 4));
            list.Remove("ciro");
            CollectionAssert.AreEqual(list, (List<string>)testColl.Get("ano.nascimento", 1, 3));
            list.Remove("caio");
            CollectionAssert.AreEqual(list, (List<string>)testColl.Get("ano.nascimento", 1, 2));
        }
    }
}
