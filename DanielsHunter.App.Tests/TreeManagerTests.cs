using DanielsHunter.App.Concrete;
using DanielsHunter.App.Manager;
using FluentAssertions;
using Moq;
using System.Linq;
using Xunit;

namespace DanielsHunter.App.Tests
{
    public class TreeManagerTests
    {
        [Fact]
        public void GrowTreesAroundPlayer_ShouldGrowTreesAroundPlayer()
        {
            Game game = new TestScenario().PrepareTestScenario1();

            TreeManager treeManager = new Mock<TreeManager>().Object;
            treeManager.GrowTreesAroundPlayer(game);

            game.boardService.Board.PlayArea.Should().ContainMatch("###  ", "# #  ", "###  ");
        }

    }
}
