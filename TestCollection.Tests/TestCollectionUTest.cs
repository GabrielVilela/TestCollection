using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using TestCollection.Application.Services;
using TestCollection.Application.Services.Interfaces;
using TestCollection.Application.ViewModels;
using TestCollection.Domain.Entities;
using TestCollection.Domain.Interfaces;
using TestCollection.Util.Interfaces;
using System.Linq;

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
            var test4 = testColl.Add("ano.nascimento", 1984, "amanda");
            Assert.IsFalse(test4);
            var test5 = testColl.Add("ano.nascimento", 1990, "caio");
            Assert.IsFalse(test4);

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
            testColl.Add("ano.nascimento", 1987, "amanda");
            Assert.AreEqual(3, testColl.IndexOf("ano.nascimento", "amanda"));
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
            List<string> list = new List<string>();

            list.Add("ciro");
            list.Add("ciro");
            list.Add("adam");
            list.Add("amanda");
            list.Add("caio");
            testColl.Add("ano.nascimento", 1983, "amanda");
            testColl.Add("ano.nascimento", 1982, "ciro");
            testColl.Add("ano.nascimento", 1982, "ciro");
            testColl.Add("ano.nascimento", 1984, "caio");
            testColl.Add("ano.nascimento", 1983, "adam");
            CollectionAssert.AreEqual(list.OrderBy(x=>x).Distinct().ToList(),(List<string>)testColl.Get("ano.nascimento", 0, 3));
            CollectionAssert.AreEqual(list.OrderBy(x => x).Distinct().ToList(), (List<string>)testColl.Get("ano.nascimento", 0, 4));
            list.Remove("ciro");
            list.Remove("ciro");
            CollectionAssert.AreEqual(list.OrderBy(x => x).Distinct().ToList(), (List<string>)testColl.Get("ano.nascimento", 1, 3));
            list.Remove("caio");
            CollectionAssert.AreEqual(list.OrderBy(x => x).Distinct().ToList(), (List<string>)testColl.Get("ano.nascimento", 1, 2));
            CollectionAssert.AreEqual(list.OrderBy(x => x).Distinct().ToList(), (List<string>)testColl.Get("ano.nascimento", 1, -2));
        }
        //teste com mock;
        [TestMethod]
        public void AddMock()
        {
            var testMock = new Mock<ITestCollectionService>();
           
            var mapper = new Mock<IMapper>();
            TestItem amanda = new TestItem() { Key = "ano.nascimento", SubIndex =1983, Value="amanda"};
            TestItemViewModel amandaViewModel = new TestItemViewModel() { Key = "ano.nascimento", SubIndex = 1983, Value = "amanda" };
            TestItem caio = new TestItem() { Key = "ano.nascimento", SubIndex = 1983, Value = "caio" };
            TestItemViewModel caioViewModel = new TestItemViewModel() { Key = "ano.nascimento", SubIndex = 1983, Value = "caio" };

            testMock.Setup(x => x.Add(amanda)).Returns(true);
            testMock.Setup(x => x.Add(caio)).Returns(false);

            mapper.Setup(x => x.Map<TestItem>(amandaViewModel)).Returns(amanda);
            mapper.Setup(x => x.Map<TestItem>(caioViewModel)).Returns(caio);

            ITestCollectionAppService testCollectionAppService = new TestCollectionAppService(testMock.Object, mapper.Object);
            Assert.IsTrue(testCollectionAppService.Add(amandaViewModel));
            Assert.IsFalse(testCollectionAppService.Add(caioViewModel));
        }
    }
}
