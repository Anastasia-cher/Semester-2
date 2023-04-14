namespace Game.Tests;

public class MapTests
{
    private Map? map;

    [Test()]
    public void ShouldThrowAnExceptionWhenMapWithoutCharacter()
    {
        Assert.Throws<CharacterNotFoundException>(() 
            => map = new Map("MapWithoutCharacter.txt"));
    }

    [Test()]
    public void ShouldThrowAnExceptionWhenThereIsMoreThanOneCharacter()
    {
        Assert.Throws<MoreThanOneCharacterException>(() 
            => map = new Map("MapWithTwoCharacters.txt"));
    }

    [Test()]
    public void CharacterPositionTestShouldWork()
    {
        map = new Map("MapForCharacterPosition.txt");
        Assert.That(map.CharacterPosition, Is.EqualTo((2, 1)));
    }

    [Test()]
    public void ShouldWorkWhenSettingACharacterPosition()
    {
        map = new Map("MapForCharacterPosition.txt");
        Assert.That(map.CharacterPosition, Is.EqualTo((2, 1)));

        Assert.IsFalse(map.SetCharacterPosition(2, 1));
        Assert.IsTrue(map.SetCharacterPosition(1, 1));
        Assert.That(map.CharacterPosition, Is.EqualTo((1, 1)));
    }

    [Test()]
    public void ShouldNotWorkWhenSettingACharacterPositionOutsideOfMap()
    {
        map = new Map("MapForCharacterPosition.txt");
        Assert.IsFalse(map.SetCharacterPosition(3, 1));
        Assert.IsFalse(map.SetCharacterPosition(0, 3));
    }

    [Test()]
    public void ShouldNotWorkWhenSettingACharacterToANegativeCharacterPosition()
    {
        map = new Map("MapForCharacterPosition.txt");
        Assert.IsFalse(map.SetCharacterPosition(-1, -2));
    }
}