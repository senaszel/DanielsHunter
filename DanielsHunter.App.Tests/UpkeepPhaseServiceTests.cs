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
        [Fact]
        public void Upkeep_Should_MakeAppropriateChangesToGameState()
        {
            Game game_testScenario = new TestScenario().PrepareTestScenario1();
            int initialTurnCounter = game_testScenario.gameState.TurnCounter;

            game_testScenario.upkeepPhaseService.Upkeep();

            game_testScenario.gameState.Outcome.Should().Be(GameOutcomeEnum.PENDING);
            game_testScenario.gameState.TurnCounter.Should().BeGreaterThan(initialTurnCounter);
            (game_testScenario.gameState.TurnCounter -= 1).Should().Be(initialTurnCounter);
        }
    }
}
