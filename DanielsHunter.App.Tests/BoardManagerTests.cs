using DanielsHunter.App.Helpers;
using DanielsHunter.App.Manager;
using DanielsHunter.Domain.Entity;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Moq;
using System.Linq;
using Xunit;

namespace DanielsHunter.App.Tests
{
    public class BoardManagerTests
    {
        [Fact]
        public void RemoveSymbolFromPlayArea_ShouldContainOnlyEmptyFields()
        {
            var mockBoardObject = new Mock<Board>(1, 1, 1).Object;
            var mockScreenObject = new Mock<Screen>(mockBoardObject).Object;
            var mockInitialisationHelperObject = new Mock<InitialisationHelper>().Object;
            mockInitialisationHelperObject.InitialisePlayArea(mockScreenObject);

            //ass
            mockBoardObject.PlayArea.Should().NotContainNulls();
            mockBoardObject.PlayArea.Should().OnlyContain(o => o == " ");
            mockBoardObject.PlayArea.ToList().ForEach(x => x.Should().ContainAll(" "));
        }

        [Fact]
        public void RemoveSymbolFromPlayArea_Should_RemoveDanielsSymbolByKey()
        {
            //arr
            var mockDanielObject = new Mock<Daniel>(1,1).Object;
            var boardMockObject = new Mock<Board>(10, 10, 1).Object;
            var mockScreenObject = new Mock<Screen>(boardMockObject).Object;
            var mockInitialisationHelperObject = new Mock<InitialisationHelper>().Object;
            mockInitialisationHelperObject.InitialisePlayArea(mockScreenObject);
            new BoardManager(boardMockObject).InsertSymbolIntoPlayArea(mockDanielObject);
            //act
            new BoardManager(boardMockObject).RemoveSymbolFromPlayArea(mockDanielObject.Key);
            //ass
            boardMockObject.PlayArea.ToList().ForEach(x => x.Should().ContainAll(" "));
        }

        [Fact]
        public void RemoveSymbolFromPlayArea_ShouldNotContainDanielSymbol()
        {
            var danielSymbol = new Daniel().Symbol;
            var mockUserObject = new Mock<User>(1,1,1,1).Object;
            var mockBoardObject = new Mock<Board>(20, 20, 1).Object;
            var mockScreenObject = new Mock<Screen>(mockBoardObject).Object;
            var mockInitialisationHelperObject = new Mock<InitialisationHelper>().Object;
            mockInitialisationHelperObject.InitialisePlayArea(mockScreenObject);
            var boardManager = new BoardManager(mockBoardObject);
            boardManager.InsertSymbolIntoPlayArea(mockUserObject);
            //act
            boardManager.RemoveSymbolFromPlayArea(mockUserObject.Key);
            //ass
            mockBoardObject.PlayArea.Should().NotContain(danielSymbol);
        }

        [Theory]
        [InlineData(4, 5, 10, 10)]
        [InlineData(8, 1, 10, 10)]
        [InlineData(0, 0, 10, 10)]
        [InlineData(0, 9, 10, 10)]
        [InlineData(9, 0, 10, 10)]
        public void InsertSymbolIntoPlayArea_ShouldInsertDanielSymbol(int daniel_x, int daniel_y,int board_width,int board_height)
        {
            Daniel daniel = new Daniel(daniel_x, daniel_y);
            var mockBoardObject = new Mock<Board>(board_width, board_height, 0).Object;
            var mockScreenObject = new Mock<Screen>(mockBoardObject).Object;
            var mockInitialisationHelperObject = new Mock<InitialisationHelper>().Object;
            mockInitialisationHelperObject.InitialisePlayArea(mockScreenObject);
            
            
            new BoardManager(mockBoardObject).InsertSymbolIntoPlayArea(daniel);

            mockBoardObject.PlayArea[daniel_y].Should().NotBeNullOrEmpty();
            mockBoardObject.PlayArea[daniel_y].Should().Contain(daniel.Symbol);
        }

    }
}
