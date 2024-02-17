using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private TMP_Text PlayerOnePoints;
    [SerializeField] private TMP_Text PlayerTwoPoints;
    
    public void UpdateUI(int playerOnePoints, int playerTwoPoints)
    {
        PlayerOnePoints.text = playerOnePoints.ToString();
        PlayerTwoPoints.text = playerTwoPoints.ToString();
    }
}