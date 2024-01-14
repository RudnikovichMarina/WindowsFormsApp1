using NUnit.Framework.Internal;
using WindowsFormsApp1;


using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace TestProject3
{
    public class Tests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_Sort()
        {
            Sort sort = new Sort();
            int[] Array = new int[10] { 34, 11, 23, 56, 6, 47, 18, 1, 45, 38 };
            int[] ArrayKey = new int[10] {1, 6, 11, 18, 23, 34, 38, 45, 47, 56 };
            sort.HeapSort(Array);
            Assert.AreEqual(ArrayKey, Array);
        }
        
    }
}