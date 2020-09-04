using DanielsHunter.App.Concrete;
using DanielsHunter.App.Helpers;
using DanielsHunter.App.Manager;
using DanielsHunter.Domain.Entity;
using DanielsHunter.Domain.Enum;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DanielsHunter.App.Tests
{
    public class UpkeepPhaseServiceTests
    {
        public Game PrepareTestScenario()
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
            var mockUpkeepPhaseServiceObject = new Mock<UpkeepPhaseService>(mockGameObject).Object;
            var mockGameStateObject = new Mock<GameState>().Object;
            mockGameStateObject.TurnCounter = 1;
            var mockGameStateManager = new Mock<GameStateManager>(mockGameStateObject).Object;
            mockGameObject.boardService = mockBoardServiceObject;
            mockGameObject.assetManager = mockAssetManagerObject;
            mockGameObject.assetService = mockAssetServiceObject;
            mockGameObject.boardService = mockBoardServiceObject;
            mockGameObject.userService = mockUserServiceObject;
            mockGameObject.upkeepPhaseService = mockUpkeepPhaseServiceObject;
            mockGameObject.gameState = mockGameStateObject;
            mockGameObject.gameStateManager = mockGameStateManager;
            return mockGameObject;
        }
        [Fact]
        public void Upkeep_Should_MakeAppropriateChangesToGameState()
        {
            Game testScenario = PrepareTestScenario();
            int initialTurnCounter = testScenario.gameState.TurnCounter;

            testScenario.upkeepPhaseService.ManageCounters();

            testScenario.gameState.Outcome.Should().Be(GameOutcomeEnum.PENDING);
            testScenario.gameState.TurnCounter.Should().BeGreaterThan(initialTurnCounter);
            (testScenario.gameState.TurnCounter -= 1).Should().Be(initialTurnCounter);
        }
    }
}
