using BuberDinner.Application.Common.Interfaces.Presistence;
using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Application.UnitTest.Menus.Commands.TestUtils;
using BuberDinner.Application.XUnitTest.TestUtils.Menus.Extensions;
using FluentAssertions;
using Moq;

namespace BuberDinner.Application.UnitTest.Menus.Commands.CreateMenu
{
    public class CreateMenuCommandHandlerTests
    {
        private readonly CreateMenuCommanHandler _handler;
        private readonly Mock<IMenuRepository> _mockMenuRepository;

        public CreateMenuCommandHandlerTests()
        {
            _mockMenuRepository = new Mock<IMenuRepository>();
            _handler = new CreateMenuCommanHandler(_mockMenuRepository.Object);
        }
        //T1: SUT - Logical Component we're testing
        //T2: Scenario - What we're testing
        //T3: Expected Outcome - What we expact the logical component

        [Theory]
        [MemberData(nameof(ValidCreateMenuCommand))]
        public async Task HandleCreateMenuCommand_WhenMenuIsValid_ShouldCreateAndReturnMenuAsync(CreateMenuCommand createMenuCommand)
        {
            ////Arrange
            //var createMenuCommand = CreateMenuCommandUtils.CreateCommand();
            //Act
            var result = await _handler.Handle(createMenuCommand, default);
            //Assert
            result.IsError.Should().BeFalse();
            result.Value.ValidateCreatedForm(createMenuCommand);
            _mockMenuRepository.Verify(m => m.Add(result.Value), Times.Once());
        }

        public static IEnumerable<object[]> ValidCreateMenuCommand()
        {
            yield return new[] { CreateMenuCommandUtils.CreateCommand() };

            yield return new[]
            {
                CreateMenuCommandUtils.CreateCommand(
                    sections: CreateMenuCommandUtils.CreateSectionsCommand(sectionCount: 3,
                    items: CreateMenuCommandUtils.CreateItemsCommand(itemCount: 3)))
            };
        }
    }
}
