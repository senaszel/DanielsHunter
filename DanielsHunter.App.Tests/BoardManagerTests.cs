using DanielsHunter.App.Manager;
using DanielsHunter.Domain.Common;
using DanielsHunter.Domain.Entity;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using Xunit;

namespace DanielsHunter.App.Tests
{
    public class BoardManagerTests
    {
        [Fact]
        public void RemoveSymbolFromPlayArea_ShouldContainOnlyEmptyFields()
        {
            var boardMockObject = new Mock<Board>(1, 1, 1).Object;
            new ScreenManager(new Screen(boardMockObject)).InitialisePlayArea();

            //ass
            boardMockObject.PlayArea.Should().NotContainNulls();
            boardMockObject.PlayArea.Should().OnlyContain(o => o == " ");
            boardMockObject.PlayArea.ToList().ForEach(x => x.Should().ContainAll(" "));
        }

        [Fact]
        public void RemoveSymbolFromPlayArea()
        {
            //arr
            Daniel daniel = new Daniel(0, 0);
            var boardMock = new Mock<Board>(1, 1, 1);
            new ScreenManager(new Screen(boardMock.Object)).InitialisePlayArea();
            new BoardManager(boardMock.Object).InsertSymbolIntoPlayArea(daniel);
            boardMock.SetReturnsDefault(boardMock.Object);
            //act
            new BoardManager(boardMock.Object).RemoveSymbolFromPlayArea(daniel.Key);
            //ass
            boardMock.Object.PlayArea[0].Should().ContainAll(" ");
        }

        [Fact]
        public void RemoveSymbolFromPlayArea_ShouldNotContainDanielSymbol()
        {
            var danielSymbol = new Daniel().Symbol;
            User user = new User(0, 0, 0, 0);
            var boardMockObject = new Mock<Board>(1, 1, 1).Object;
            new ScreenManager(new Screen(boardMockObject)).InitialisePlayArea();
            new BoardManager(boardMockObject).InsertSymbolIntoPlayArea(user);
            var boardManager = new BoardManager(boardMockObject);
            //act
            boardManager.RemoveSymbolFromPlayArea(user.Key);
            //ass
            boardMockObject.PlayArea.Should().NotContain(danielSymbol);
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
            var boardMockObject = new Mock<Board>(board_width, board_height, 0).Object;
            new ScreenManager(new Screen(boardMockObject)).InitialisePlayArea();
            
            
            new BoardManager(boardMockObject).InsertSymbolIntoPlayArea(daniel);

            boardMockObject.PlayArea[daniel_y].Should().NotBeNullOrEmpty();
            boardMockObject.PlayArea[daniel_y].Should().Contain(daniel.Symbol);
        }

    }
}
