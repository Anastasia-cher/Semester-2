namespace Game.Tests;

public class GameTests
{
    private Game game;

    [SetUp]
    public void Initialize() 
        => game = new Game("MapForGame.txt", (left, top) => { });

    [Test()]
    public void OnLeftTest()
    {
        game.OnLeft(this, EventArgs.Empty);
        Assert.That(game.GameMap.CharacterPosition, Is.EqualTo((1, 1)));

        game.OnLeft(this, EventArgs.Empty);
        Assert.That(game.GameMap.CharacterPosition, Is.EqualTo((1, 1)));
    }

    [Test()]
    public void OnRightTest()
    {
        game.OnRight(this, EventArgs.Empty);
        Assert.That(game.GameMap.CharacterPosition, Is.EqualTo((3, 1)));

        game.OnRight(this, EventArgs.Empty);
        Assert.That(game.GameMap.CharacterPosition, Is.EqualTo((3, 1)));
    }

    [Test()]
    public void UpTest()
    {
        game.Up(this, EventArgs.Empty);
        Assert.That(game.GameMap.CharacterPosition, Is.EqualTo((2, 0)));

        game.Up(this, EventArgs.Empty);
        Assert.That(game.GameMap.CharacterPosition, Is.EqualTo((2, 0)));
    }

    [Test()]
    public void DownTest()
    {
        game.Down(this, EventArgs.Empty);
        Assert.That(game.GameMap.CharacterPosition, Is.EqualTo((2, 2)));

        game.Down(this, EventArgs.Empty);
        Assert.That(game.GameMap.CharacterPosition, Is.EqualTo((2, 2)));
    }
}