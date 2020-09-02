using DanielsHunter.App.Concrete;
using DanielsHunter.Domain.Common;
using DanielsHunter.Domain.Entity;
using FluentAssertions;
using Moq;
using System.Net.NetworkInformation;
using Xunit;

namespace DanielsHunter.App.Tests
{
    public class AssetServiceTests
    {
        [Theory]
        [InlineData("Daniel")]
        [InlineData("User")]
        public void GetAsset_Should_ReturnAssetByName(string name)
        {
            var mockDaniel = new Mock<Daniel>(1, 1);
            var mockUser = new Mock<User>(1, 2, 3, 4);
            var mockAsserService = new Mock<AssetService>();
            mockAsserService.Object.AddItem(mockDaniel.Object);
            mockAsserService.Object.AddItem(mockUser.Object);

            var actual = mockAsserService.Object.GetAsset(name).Name;
            var expected = name;

            Assert.Equal(expected, actual);
            actual.Should().Be(name);
        }

        [Fact]
        public void GetAsset_Should_ReturnAssetByKey() 
        {
            var mockDaniel = new Mock<Daniel>(1, 1);
            var mockAssertService = new Mock<AssetService>();

            mockAssertService.Object.AddToAssets(mockDaniel.Object);
            Asset actual = mockAssertService.Object.GetAsset(mockDaniel.Object.Key);

            Assert.Equal(mockDaniel.Object, actual);
            actual.Should().Be(mockDaniel.Object);
        }


        [Fact]
        public void AddToAssetService_Should_AddDaniel()
        {
            //arr
            var daniel = new Daniel(0, 0);
            var mockAssetServiceObject = new Mock<AssetService>().Object;

            //act
            mockAssetServiceObject.AddToAssets(daniel);

            //ass
            mockAssetServiceObject.GetAsset(daniel.Key).Should().BeOfType(typeof(Daniel));
            mockAssetServiceObject.GetAsset(daniel.Key).Should().Be(daniel);
            mockAssetServiceObject.Should().NotBeNull();
            mockAssetServiceObject.Items.Should().HaveCount(1);
        }

        [Fact]
        public void RemoveFromAssets_Should_RemoveDaniel()
        {
            var mockDaniel = new Mock<Daniel>(1, 1);
            var mockAssetService = new Mock<AssetService>();

            mockAssetService.Object.AddToAssets(mockDaniel.Object);
            mockAssetService.Object.RemoveFromAssets(mockDaniel.Object);

            mockAssetService.Object.Items.Should().BeEmpty();
        }

        [Fact]
        public void IsAsset_Should_ReturnFalse_byKey()
        {
            var mockAssetService = new Mock<AssetService>();

            bool actual = mockAssetService.Object.IsAsset(new Daniel(2, 43).Key);

            Assert.False(actual);
            actual.Should().BeFalse();
        }

        [Fact]
        public void IsAsset_Should_ReturnFalse_byAsset()
        {
            var mockAssetService = new Mock<AssetService>();

            bool actual = mockAssetService.Object.IsAsset(new User(1,2,3,4).Name);

            Assert.False(actual);
            actual.Should().BeFalse();
        }
    }
}
