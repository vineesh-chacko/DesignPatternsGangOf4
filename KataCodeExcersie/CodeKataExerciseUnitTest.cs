using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeKataExercise
{
    [TestClass()]
    public class CodeKataExerciseUnitTest
    {

        #region String Wrapper
        
        [TestMethod]
        public void NotSplit_EmtpyString()
        {

            Assert.AreEqual("", Wrapper.Wrap("", 0));
        }

        [TestMethod]
        public void NotSplit_WhenColumnsBiggerThanText()
        {
            Assert.AreEqual("this is a test", Wrapper.Wrap("this is a test", 20));
        }

        [TestMethod]
        public void SplitSingleWord_WhenColumnsSmallerThanText()
        {
            Assert.AreEqual("very\nlong", Wrapper.Wrap("verylong", 4));
            Assert.AreEqual("very\nlong\ntext", Wrapper.Wrap("verylongtext", 4));
            Assert.AreEqual("very\nvery\nlong\ntext", Wrapper.Wrap("veryverylongtext", 4));
        }

        [TestMethod]
        public void SplitSentenceFromSpaces()
        {
            Assert.AreEqual("two\nwor\nds", Wrapper.Wrap("two words", 3));
            Assert.AreEqual("words\nwords", Wrapper.Wrap("words words", 7));
            Assert.AreEqual("words\nwords\nwords", Wrapper.Wrap("words words words", 7));
            Assert.AreEqual("two\ntwo\ntwo", Wrapper.Wrap("two two two", 3));

        }

        [TestMethod]
        public void SpaceAtTheBeginning()
        {
            Assert.AreEqual(" two\ntwo\ntwo", Wrapper.Wrap(" two two two", 4));

        }

        #endregion

        #region String Calculator

        #endregion

        #region FizzBuzz
        [TestMethod]
        public void TestFizzBuzz()
        {
            var fizzBuzz = new FizzBuzz();
            Assert.AreEqual("1", fizzBuzz.FizzBuzzKata(1));
            Assert.AreEqual("2", fizzBuzz.FizzBuzzKata(2));
            Assert.AreEqual("Fizz", fizzBuzz.FizzBuzzKata(3));
            Assert.AreEqual("4", fizzBuzz.FizzBuzzKata(4));
            Assert.AreEqual("Buzz", fizzBuzz.FizzBuzzKata(5));
            Assert.AreEqual("Buzz", fizzBuzz.FizzBuzzKata(10));
            Assert.AreEqual("FizzBuzz", fizzBuzz.FizzBuzzKata(15));
        }

        #endregion
    }
}
