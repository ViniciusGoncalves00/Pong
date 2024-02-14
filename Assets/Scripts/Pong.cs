using UnityEngine;
using UnityEngine.SceneManagement;

public class Pong : MonoBehaviour
{
    [SerializeField] private ModeManager _modeManager;
    [SerializeField] private UI UI;

    public int PointsToVictory = 5;
    public int PlayerOnePoints { get; private set; }
    public int PlayerTwoPoints { get; private set; }

    private void Update()
    {
        if (PlayerOnePoints >= PointsToVictory || PlayerTwoPoints >= PointsToVictory)
        {
            _modeManager.ModeMachine.ChangeMode(_modeManager.NoMode);
            SceneManager.LoadScene("MainMenuScene");
        }
    }

    public void UpdatePoints(int playerOnePoints, int playerTwoPoints)
    {
        PlayerOnePoints += playerOnePoints;
        PlayerTwoPoints += playerTwoPoints;

        UI.UpdateUI(PlayerOnePoints, PlayerTwoPoints);
    }
}