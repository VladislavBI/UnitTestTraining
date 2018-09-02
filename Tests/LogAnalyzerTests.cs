using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTtTrain;

namespace Tests
{
    [TestFixture]
    public class LogAnalyzerTests
    {
        private LogAnalyzer m_analyzer;

        [SetUp]
        public void Setup()
        {
            m_analyzer = new LogAnalyzer();
        }


        [TestCase("goodExtension.slf", true)]
        [TestCase("goodExtension.SLF", true)]
        [TestCase("badExtensio.foo", false)]
        [Category("Fast Tests")]
        public void IsValidFileExt_VariousExtension_CheckThem
            (string file, bool expected)
        {

            bool result = m_analyzer.IsValidFileExt(file);

            Assert.AreEqual(expected, result);
        }
        [Test]
        public void IsValidFileName_EmptyFileName_ThrowException()
        {
            var ex = Assert.Catch<ArgumentNullException>(() =>
            m_analyzer.IsValidFileExt(string.Empty));

            Assert.IsTrue(ex.Message.Contains("File name has to be provided"));
        }

        [TestCase("badName.foo", false)]
        [TestCase("goodName.slf", true)]
        public void IsValidFileName_WhenCalled_ChangesWasLastFileNameValid
            (string file, bool result)
        {
            m_analyzer.IsValidFileExt(file);
            Assert.AreEqual(m_analyzer.WasLastFileNameValid, result);
        }
        [TearDown]
        public void TearDown()
        {
            m_analyzer = null;
        }
    }
}
