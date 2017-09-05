using SwapSentence;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Diagnostics;

namespace SwapSentence.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        private static FileStream fsLarge;
        private static FileStream fsSmall;

        private const int fsSmallSize = 55;
        private const int fsLargeSize = 35002;

        private const string strExpectedSmall = @"5
this is a test
foobar
all your base
class
pony along";

        private string[] strArraySmall = new string[] { "5",
                                                        "this is a test",
                                                        "foobar",
                                                        "all your base",
                                                        "class",
                                                        "pony along"
                                                      };

        private string[] strReverseArraySmall = new string[] {
                                                        "test a is this",
                                                        "foobar",
                                                        "base your all",
                                                        "class",
                                                        "along pony"
                                                      };
        private string[] strReverseFirst = new string[] { "test","a", "is", "this" };
        private string[] strFirst = new string[] { "this", "is", "a", "test" };

        [TestInitialize]
        public void TestInitialize()
        {
            var directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var path = string.Format("{0}\\{1}", directory, "B-small-practice.in");
            fsSmall = new FileStream(path, FileMode.Open);
            Debug.WriteLine("File opened {0}", path);
            path = string.Format("{0}\\{1}", directory, "B-large-practice.in");
            fsLarge = new FileStream(path, FileMode.Open);
            Debug.WriteLine("File opened {0}", path);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            fsSmall.Close();
            Debug.WriteLine("File closed {0}", fsSmall.Name);
            fsLarge.Close();
            Debug.WriteLine("File closed {0}", fsLarge.Name);
        }

        [TestMethod()]
        public void ProcessFile_Null_Test()
        {
            string stdIn = Program.ProcessFile(null).Result;
            Assert.AreEqual(null, stdIn);
        }
        [TestMethod()]
        public void ProcessFile_Small_Size_Test()
        {
            string stdIn = Program.ProcessFile(fsSmall).Result;
            Assert.AreEqual(stdIn.Length, fsSmallSize);
        }
        [TestMethod()]
        public void ProcessFile_Small_Test()
        {
            string stdIn = Program.ProcessFile(fsSmall).Result;
            StringAssert.Equals(stdIn, strExpectedSmall);
        }
        
        [TestMethod()]
        public void ProcessFile_Large_Size_Test()
        {
            string stdIn = Program.ProcessFile(fsLarge).Result;
            Assert.AreEqual(stdIn.Length, fsLargeSize);
        }
        [TestMethod()]
        public void SplitOnSentences_Test()
        {
            string[] strResult = Program.SplitOnSentences(strExpectedSmall);
            CollectionAssert.AreEqual(strResult, strArraySmall);
        }

        [TestMethod()]
        public void SplitOnWords_Test()
        {
            string[] strResult = Program.SplitOnWords(strArraySmall[1]);
            CollectionAssert.AreEqual(strResult, strFirst);
        }

        [TestMethod()]
        public void ReverseWords_Test()
        {
            string[] strActual = Program.ReverseWords(strFirst);
            CollectionAssert.AreEqual(strReverseFirst, strActual);
        }

        [TestMethod()]
        public void ReverseWords_empty_empty_Test()
        {
            string[] strIn = new string[] { };
            string[] strExpected = new string[] { };
            string[] strActual = Program.ReverseWords(strIn);
            CollectionAssert.AreEqual(strExpected, strActual);
        }

        [TestMethod()]
        public void JoinWordsTest()
        {
            string strResult = Program.JoinWords(strReverseFirst);
            StringAssert.Equals(strReverseArraySmall[1], strResult );
        }
    }
}