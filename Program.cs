using TowerOffense;
using TowerOffense.Scenes.Example;
using TowerOffense.Scenes.Title;
using TowerOffense.Scenes.Test;

public class Program {
    private static void Main(string[] args) {
        using var game = new TOGame();
        TOGame.Scenes.PushScene<DisplayTestScene>();
        game.Run();
    }
}
