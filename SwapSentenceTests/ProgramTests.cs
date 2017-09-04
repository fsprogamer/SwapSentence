using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SwapSentence.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void ReverseWords_empty_empty()        
        {
            string strIn = string.Empty;
            string strExpected = string.Empty;
            // act 
            string strActual = Program.ReverseWords(strIn);
            //assert
            Assert.AreEqual(strExpected, strActual);
        }
    }
}