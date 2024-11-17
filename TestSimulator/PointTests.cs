using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Simulator;
using Xunit;

namespace TestSimulator;

public class PointTests
{

    [Theory]
    [InlineData(0, 0, "(0, 0)")]
    [InlineData(5, 10, "(5, 10)")]
    [InlineData(-1, -1, "(-1, -1)")]
    [InlineData(123, 456, "(123, 456)")]
    public void ToString_ShouldReturnCorrectFormat(int x, int y, string expected)
    {
        // Arrange
        var point = new Point(x, y);

        // Act
        var result = point.ToString();

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(5, 5, Direction.Left, 4, 5)]
    [InlineData(5, 5, Direction.Right, 6, 5)]
    [InlineData(5, 5, Direction.Up, 5, 6)]
    [InlineData(5, 5, Direction.Down, 5, 4)]
    [InlineData(0, 0, Direction.Left, -1, 0)]
    [InlineData(0, 0, Direction.Down, 0, -1)]
    [InlineData(19, 19, Direction.Right, 20, 19)]
    [InlineData(19, 19, Direction.Up, 19, 20)]
    public void Next_ShouldReturnCorrectPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var point = new Point(x, y);
        // Act
        var nextPoint = point.Next(direction);
        // Assert
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(5, 5, Direction.Left, 4, 6)]
    [InlineData(5, 5, Direction.Right, 6, 4)]
    [InlineData(5, 5, Direction.Up, 6, 6)]
    [InlineData(5, 5, Direction.Down, 4, 4)]
    [InlineData(0, 0, Direction.Left, -1, 1)]
    [InlineData(0, 0, Direction.Down, -1, -1)]
    [InlineData(19, 19, Direction.Right, 20, 18)]
    [InlineData(19, 19, Direction.Up, 20, 20)]
    public void NextDiagonal_ShouldReturnCorrectPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var point = new Point(x, y);
        // Act
        var nextPoint = point.NextDiagonal(direction);
        // Assert
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

}

