using MdToHtmlConversion;
using MdToHtmlConversion.Models.Segments;

namespace Tests;

public class HintToDetailsTests
{
    [Fact]
    public void HintPartsSpreadAcrossMultipleSegmentsAreMergedIntoOneSegment()
    {
        List<PageSegment> segments = MasterConverter.ConvertMarkdownToHtml(MarkdownTest, "");
        Assert.Equal(10, segments.Count);
    }

    private const string MarkdownTest = """
                                        # Exercise - Print a Triangle

                                        ## Task
                                        Write a Java program that uses nested `for` loops to print a triangle of `*` characters. The triangle should have a height specified by the user.

                                        ### Example Input:
                                        ```
                                        Enter the height of the triangle: 5
                                        ```

                                        ### Example Output:
                                        ```
                                        *
                                        **
                                        ***
                                        ****
                                        *****
                                        ```

                                        <hint title="Hint 1">

                                        Use an outer loop to iterate through the rows and an inner loop to print the `*` characters for each row.

                                        </hint>

                                        <hint title="Hint 2">

                                        The outer loop should run from 1 to the height specified by the user, and the inner loop should run from 1 to the current row number, given by the outer loop's index.

                                        </hint> 
                                        """;
}