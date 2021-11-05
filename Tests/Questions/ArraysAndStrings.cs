using System;
using NUnit.Framework;
using Playground.Questions.ArraysAndStrings;

namespace Tests.Questions
{
    public class ArraysAndStrings
    {
        [Test]
        public void Test_UniqueCharacters()
        {
            // Given a string, see if you can detect whether it contains only 
            // unique characters
            // character comparison is ordinal 
            // 

            var sut = new HasUniqueCharacters();
            Assert.IsTrue(HasUniqueCharacters.Assert("abcdef"));
            Assert.IsFalse(HasUniqueCharacters.Assert("HelloWorld"));
            Assert.IsTrue(HasUniqueCharacters.Assert("Hela Word"));
            Assert.IsTrue(HasUniqueCharacters.Assert("Pp"));
            Assert.IsTrue(HasUniqueCharacters.Assert(")(*&^%$#@!"));
            Assert.IsFalse(HasUniqueCharacters.Assert("Aa@  "));
        }

        [Test]
        public void Test_IsPermutation()
        {
            // given two strings, check if one is permutation of the other

            var sut = new IsPermutation();
            Assert.IsTrue(IsPermutation.Assert("aba", "baa"));
            Assert.IsTrue(IsPermutation.Assert("apollonas", "sanoallop"));
            Assert.IsFalse(IsPermutation.Assert("aba", "bac"));
            Assert.IsTrue(IsPermutation.Assert("a", "a"));
            Assert.IsTrue(IsPermutation.Assert("", ""));
        }

        [Test]
        public void Test_URLify()
        {
            // Replace all the spaces in a string with the 
            // ASCII symbol for space %20. Assume you are given the length of the 
            // final string

            var sut = new URLify();
            
            Assert.AreEqual("A%20custom%20string", sut.Execute("A custom string", 13));
            Assert.AreEqual("nospace", sut.Execute("nospace", 13));
            Assert.AreEqual("with%20leading%20space", sut.Execute("   with leading space", 16));
            Assert.AreEqual("with%20trailing%20space", sut.Execute("   with trailing space   ", 17));
        }

        [Test]
        public void Test_Palindrome()
        {
            // given a string, check if it is a palindrome
            var sut = new IsPalindrome();
            
            Assert.IsTrue(IsPalindrome.Assert("anna"));
            Assert.IsTrue(IsPalindrome.Assert("mom"));
            Assert.IsTrue(IsPalindrome.Assert("dad"));
            Assert.IsFalse(IsPalindrome.Assert("sister"));
            Assert.IsTrue(IsPalindrome.Assert(""));
            Assert.IsTrue(IsPalindrome.Assert("k"));
            Assert.IsTrue(IsPalindrome.Assert("aa"));
            Assert.IsTrue(IsPalindrome.Assert("alongnola"));
        }

        [Test]
        public void Test_OneWay()
        {
            // there are three types of edits you can perform on a string
            // insert char, remove char, replace char. Given two strings 
            // check if they are one or zero edits away.
            
            var sut = new OneWayDetector();
            
            Assert.IsTrue(sut.Assert("acustomstring", "acustomstrang"));
            Assert.IsFalse(sut.Assert("abap", "abobp"));
            Assert.IsTrue(sut.Assert("same", "same"));
            Assert.IsTrue(sut.Assert("", "a"));
            Assert.IsFalse(sut.Assert("", "aa"));
            Assert.IsFalse(sut.Assert("abcdf", "adf"));
            Assert.IsTrue(sut.Assert("abcdfefg", "abcdefg"));
            Assert.IsTrue(sut.Assert("a", "b"));
            Assert.IsTrue(sut.Assert("a", ""));
        }

        [Test]
        public void Test_Compressor()
        {
            // given a string with repeated characters ( i.e. "aabbb") write 
            // an algorithm that will compress the string down to the character, 
            // followed by the number of times it appears in the string (i.e. a2b3)
            // If the compressed string is not smaller than the original, return the original

            var sut = new Compressor();
            
            Assert.AreEqual("a3b3", sut.Execute("aaabbb"));
            Assert.AreEqual("ab", sut.Execute("ab"));
            Assert.AreEqual("aabc", sut.Execute("aabc"));
            Assert.AreEqual("a1b5c1", sut.Execute("abbbbbc"));
            Assert.AreEqual("avvvc", sut.Execute("avvvc"));
            Assert.AreEqual("a4b6c3d1e1f2g3", sut.Execute("aaaabbbbbbcccdeffggg"));
            Assert.AreEqual("", sut.Execute(""));
            Assert.AreEqual("a", sut.Execute("a"));
        }
    }
}
