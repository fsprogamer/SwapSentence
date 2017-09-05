using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.IO;

namespace T9.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        private static FileStream fsLarge;
        private static FileStream fsSmall;

        private const int fsSmallSize = 887;
        private const int fsLargeSize = 28443;

        private const string strExpectedSmall = @"100
 
yes
no
foo bar
hello world
hddq
kkyhoyre
uzfcnb
acx
rbgddvtcw 
hclntbql uu
wdcugsavyc
tlw
pmtrkiiay
 c
xezwcgdnbeeqe
xbdkseuxgqlkx
cjedbfsw
hsyfsxei
kehnuvvyffd
iednzsvei
cgvudnyjnp
klqrk
kiaoqhfirmu
ym fw pzdbw
jdz
borbesw
ckjsgrrr 
pvi elns
owpnkykbovps
hqkwe yozri
ijg yb
nqdoazstpgkysf
msszwreoc
ndfxj teg
ufaviwl
wxhscjasjne k
pbaamphpelja
 opkrduk
kjihlh
cxbdnkmchcyt
rpuluy
oepgumcc
wgaduzdluecjv
rdzo
kzr
du
f njh ppynzc
ddl
kkeuuh 
gzo
ep
lrfwpvrwswnbro
uf
wijamwj
nvqiepe
rt
acwaxeh
cqmgd uhcldds
uxryfve
uonjrx
hfjrplomjw
zbcvzb
qsjacnxv
ecvskxckxt
yyxmdsnvvpjrp
qmwjid
ovzjiizibnz
zyyrvraxdc ga
vqsufbrbt
pyfxxzz
r lultcbltjp
fmqzvvt x
wkvpbjqnu
ptzhkkxoyrjs
eix
olih
eblhxhang
gwlc
bzqhsfaal 
ecoanr
uvkqtluuekf
knc
crknhjyxplzh
suqotqfdnb
vcm
idosqppcl
zdayayeijgsk
jhnbrk
eocyoktsgruu
wpk
ajnxkbxqoj tr
msan
xnkxog
haoznacoh
kw
ys
jc utumijxbn
rmcfbojv
ibuiqcawfvhm
";

        private string[] strArraySmall = new string[] { " ",
                                                        "yes",
                                                        "no",
                                                        "foo bar"
                                                      };

        private string[] strEncoded = new string[] { "0",
                                                     "999337777",
                                                     "66 666",
                                                     "333666 666022 2777" };

        [TestInitialize]
        public void TestInitialize()
        {
            var directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var path = string.Format("{0}\\{1}", directory, "C-small-practice.in");
            fsSmall = new FileStream(path, FileMode.Open);
            Debug.WriteLine("File opened {0}", path);
            path = string.Format("{0}\\{1}", directory, "C-large-practice.in");
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
        public void ProcessFile_Large_Size_Test()
        {
            string stdIn = Program.ProcessFile(fsLarge).Result;
            Assert.AreEqual(stdIn.Length, fsLargeSize);
        }
        [TestMethod()]
        public void SplitOnSentences_100_Test()
        {
            string[] strResult = Program.SplitOnSentences(strExpectedSmall);
            Assert.IsTrue(string.Equals(strResult[0], "100", StringComparison.OrdinalIgnoreCase));
        }
        [TestMethod()]
        public void EncodeString_Space_Test()
        {
            string strResult = Program.EncodeString(strArraySmall[0]);
            Debug.WriteLine("Compare {0} {1}", strEncoded[0], strResult);
            Assert.IsTrue(string.Equals(strEncoded[0], strResult, StringComparison.OrdinalIgnoreCase));            
        }

        [TestMethod()]
        public void EncodeString_OneWord_Test()
        {
            string strResult = Program.EncodeString(strArraySmall[1]);
            Debug.WriteLine("Compare {0} {1}", strEncoded[1], strResult);
            Assert.IsTrue(string.Equals(strEncoded[1], strResult, StringComparison.OrdinalIgnoreCase));
        }

        [TestMethod()]
        public void EncodeString_OneButton_Test()
        {
            string strResult = Program.EncodeString(strArraySmall[2]);
            Debug.WriteLine("Compare {0} {1}", strEncoded[2], strResult);
            Assert.IsTrue(string.Equals(strEncoded[2], strResult, StringComparison.OrdinalIgnoreCase));
        }
        [TestMethod()]
        public void EncodeString_TwoWord_Test()
        {
            string strResult = Program.EncodeString(strArraySmall[3]);
            Debug.WriteLine("Compare {0} {1}", strEncoded[3], strResult);
            Assert.IsTrue(string.Equals(strEncoded[3], strResult, StringComparison.OrdinalIgnoreCase));
        }
    }
}