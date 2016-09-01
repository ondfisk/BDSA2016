using System;
using System.IO;
using Xunit;

namespace BDSA2016.Lecture01.App.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void Main_when_run_prints_Hello_World()
        {
            // Arrange
            var writer = new StringWriter();
            Console.SetOut(writer);

            // Act
            Program.Main(null);

            // Assert
            Assert.Equal("Hello World!", 
                writer.GetStringBuilder().ToString().TrimEnd());
        }

        [Fact]
        public void Main_when_run_with_Brain_prints_Hello_Brain()
        {
            // Arrange
            var writer = new StringWriter();
            Console.SetOut(writer);

            string[] args = { "Brain" };

            // Act
            Program.Main(args);

            // Assert
            Assert.Equal("Hello Brain!",
                writer.GetStringBuilder().ToString().TrimEnd());
        }
    }
}
