namespace Lab3_Review_Test;
using Lab3_Review;

public class UnitTest1
{
    public static TheoryData<int[]> frequencyTestData()
    {
        return new TheoryData<int[]>
    {
        // Test array with duplicates
        new int[] { 1, 1, 2, 2, 3, 3, 3, 1, 1, 5, 5, 6, 7, 8, 2, 1, 1 },

        // Test array with all elements being the same
        new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1 },

        // Test array with no duplicates
        new int[] { 1, 8, 7, 6, 5, 4, 3, 2, 9 },

        // Test array with multiple numbers appearing the same amount of times
        new int[] { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5 }
    };
    }

    public static TheoryData<int[]> maxTestData()
    {
        return new TheoryData<int[]>
    {

        // Test array with all elements being the same
        new int[] { 123, 123, 123, 123, 123, 123, 123, 123, 123 },

        new int[] { 5, 25, 99, 123, 78, 96, -555, 108, 4 }

    };
    }

    [Theory]
    [InlineData("2 2 2")]
    public void Multiply3Args_With3Numbers_ReturnsProduct(string numString)
    {
        int expectedValue = 8;

        int actualValue = Program.Multiply3Args(numString);

        Assert.Equal(expectedValue, actualValue);
    }

    [Theory]
    [InlineData("2 2 2 2")]
    public void Multiply3Args_WithMoreThan3Numbers_ReturnsProductofFirst3(string numString)
    {
        int expectedValue = 8;

        int actualValue = Program.Multiply3Args(numString);

        Assert.Equal(expectedValue, actualValue);
    }

    [Theory]
    [InlineData("2 2")]
    public void Multiply3Args_WithLessThan3Numbers_ReturnsZero(string numString)
    {
        int expectedValue = 0;

        int actualValue = Program.Multiply3Args(numString);

        Assert.Equal(expectedValue, actualValue);
    }
    [Theory]
    [InlineData("2 2 -2")]
    public void Multiply3Args_WithNegativeNumber_ReturnsProduct(string numString)
    {
        int expectedValue = -8;

        int actualValue = Program.Multiply3Args(numString);

        Assert.Equal(expectedValue, actualValue);
    }
    [Fact]
    public void FindAverage_Test()
    {
        decimal[] inputNums = { 2, 2, 8 };
        decimal expectedValue = 4;

        decimal actualValue = Program.FindAverage(inputNums);

        Assert.Equal(expectedValue, actualValue);
    }

    [Fact]
    public void FindAverage_WithZeros_ReturnsZero()
    {
        decimal[] inputNums = { 0, 0, 0 };
        decimal expectedValue = 0;

        decimal actualValue = Program.FindAverage(inputNums);

        Assert.Equal(expectedValue, actualValue);
    }

    [Theory]
    [MemberData(nameof(frequencyTestData))]
    public void MostFrequentIntIn_DifferentSizes(int[] a)
    {
        int expectedResult = 1;
        int actualResult = Program.MostFrequentIntIn(a);
        Assert.Equal(expectedResult, actualResult);
    }
    [Theory]
    [MemberData(nameof(maxTestData))]
    public void MaximumValueIn_Test(int[] a)
    {
        int expectedResult = 123;
        int actualResult = Program.MaximumValueIn(a);
        Assert.Equal(expectedResult, actualResult);
    }

    [Theory]
    [InlineData("This is a sentence about important things", new string[] { "This: 4", "is: 2", "a: 1", "sentence: 8", "about: 5", "important: 9", "things: 6" })]
    [InlineData("Hello, world!", new string[] { "Hello,: 6", "world!: 6" })]
    [InlineData("One,two,three.", new string[] { "One,two,three.: 14" })]
    public void GetWordsWithCharacterCount_ValidInput_ReturnsCorrectArray(string sentence, string[] expectedOutput)
    {
        // Arrange

        // Act
        string[] result = Program.GetWordsWithCharacterCount(sentence);

        // Assert
        Assert.Equal(expectedOutput, result);
    }

    [Fact]
    public void GetWordsWithCharacterCount_EmptyInput_ReturnsEmptyArray()
    {
        // Arrange
        string sentence = "";

        // Act
        string[] result = Program.GetWordsWithCharacterCount(sentence);

        // Assert
        Assert.Empty(result);
    }


}
