
using TowerOffense;
using TowerOffense.Scenes.TestScene;

internal class Program {
    private static void Main(string[] args) {
        using var game = new TOGame();
        TOGame.Scenes.PushScene<ExampleScene>();
        game.Run();
    }
}