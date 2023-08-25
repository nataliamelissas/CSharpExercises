using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace CSharpTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Exercises_ReverseWords_ShouldReverse()
        {
            string expected = "life wonderful a what";
            string input = "what a wonderful life";

            Assert.AreEqual(expected, CSharpExercises.Exercises.ReverseWords(input));
        }
    }
}