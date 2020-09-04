using DanielsHunter.App.Concrete;
using DanielsHunter.App.Helpers;
using DanielsHunter.App.Manager;
using DanielsHunter.Domain.Entity;
using DanielsHunter.Domain.Enum;
using FluentAssertions;
using Moq;
using System.Linq;
using Xunit;

namespace DanielsHunter.App.Tests
{
    public class DanielManagerTests
    {
               [Fact]
        public void PlaceDanielAtRandomPlaceOnTheBoard_Should_PlaceDanielAtRandomPlaceOnTheBoard()
        {
            Game game_testScenario = new TestScenario().PrepareTestScenario1();
            DanielManager danielManager = new Mock<DanielManager>(game_testScenario.assetService.GetAsset(AssetsNamesEnum.Daniel.ToString())).Object;

            danielManager.PlaceDanielAtRandomPlaceOnTheBoard(game_testScenario);

            game_testScenario.boardService.Board
                .PlayArea[game_testScenario.assetService.GetAsset(AssetsNamesEnum.Daniel.ToString()).Y]
                .Should().Contain(new Daniel().Symbol);
        }

        [Fact]
        public void RunDaniel_Shuld_MakeDanielRun()
        {
            Game game_testScenario = new TestScenario().PrepareTestScenario1();
            DanielManager danielManager = new Mock<DanielManager>(game_testScenario.assetService.GetAsset(AssetsNamesEnum.Daniel.ToString())).Object;

            (int x, int y) oldDanielsKey = game_testScenario.assetService.GetAsset(AssetsNamesEnum.Daniel.ToString()).Key;
            do
            {
                danielManager.RunDaniel(game_testScenario);
            } while (game_testScenario.assetService.GetAsset(AssetsNamesEnum.Daniel.ToString()).Key.Equals(oldDanielsKey));
            // This test may look odd because I call RunDaniel() as many times as is neccessary to achieve condition I am testing in Assert Phase. But the method itself may return situation identical to initial. So at least I check that it goes out of the loop. And Assets Count as well. 

            game_testScenario.assetService.GetAsset(AssetsNamesEnum.Daniel.ToString()).Key
                .Should().NotBe(oldDanielsKey);
            game_testScenario.assetService.Items.Should().HaveCount(2);
        }
    }
}
