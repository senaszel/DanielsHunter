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
        public (Game, DanielManager) PrepareTestScenario()
        {
            var mockBoardObject = new Mock<Board>(5, 5, 5).Object;
            var mockUserObject = new Mock<User>(1, 1, 1, 1).Object;
            var mockUserServiceObject = new Mock<UserService>().Object;
            mockUserServiceObject.AddItem(mockUserObject);
            var mockScreenObject = new Mock<Screen>(mockBoardObject).Object;
            var mockInitialisationHelperObject = new Mock<InitialisationHelper>().Object;
            mockInitialisationHelperObject.InitialisePlayArea(mockScreenObject);
            var mockBoardServiceObject = new Mock<BoardService>().Object;
            mockBoardServiceObject.AddItem(mockBoardObject);
            var mockBoardManagerObject = new Mock<BoardManager>(mockBoardObject).Object;
            var mockDanielObject = new Mock<Daniel>(1, 1).Object;
            var mockAssetServiceObject = new Mock<AssetService>().Object;
            mockAssetServiceObject.AddItem(mockUserObject);
            mockAssetServiceObject.AddItem(mockDanielObject);
            var mockDanielManagerObject = new Mock<DanielManager>(mockDanielObject).Object;
            var mockAssetManagerObject = new Mock<AssetManager>(mockAssetServiceObject, mockBoardManagerObject).Object;
            var mockGameObject = new Mock<Game>().Object;
            mockGameObject.boardService = mockBoardServiceObject;
            mockGameObject.assetManager = mockAssetManagerObject;
            mockGameObject.assetService = mockAssetServiceObject;
            mockGameObject.boardService = mockBoardServiceObject;
            mockGameObject.userService = mockUserServiceObject;

            return (mockGameObject, mockDanielManagerObject);
        }

        [Fact]
        public void PlaceDanielAtRandomPlaceOnTheBoard_Should_PlaceDanielAtRandomPlaceOnTheBoard()
        {
            (Game game, DanielManager danielManager) = PrepareTestScenario();

            danielManager.PlaceDanielAtRandomPlaceOnTheBoard(game);

            game.boardService.Board
                .PlayArea[game.assetService.GetAsset(AssetsNamesEnum.Daniel.ToString()).Y]
                .Should().Contain(new Daniel().Symbol);
        }

        [Fact]
        public void RunDaniel_Shuld_MakeDanielRun()
        {
            (Game game, DanielManager danielManager) = PrepareTestScenario();
            var oldDanielsKey = game.assetService.GetAsset(AssetsNamesEnum.Daniel.ToString()).Key;
            do
            {
                danielManager.RunDaniel(game);
            } while (game.assetService.GetAsset(AssetsNamesEnum.Daniel.ToString()).Key.Equals(oldDanielsKey));
            // This test may look odd becouse I call RunDaniel() as many times as is neccessary to achieve condition I am testing in Assert Phase. But the method itself may return situation identical to initial. So at least I check that it goes out of the loop. And Assets Count as well. 

            game.assetService.GetAsset(AssetsNamesEnum.Daniel.ToString()).Key
            .Should().NotBe(oldDanielsKey);
            game.assetService.Items.Should().HaveCount(2);
        }
    }
}
