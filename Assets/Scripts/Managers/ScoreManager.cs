using System;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public UiManager uiManager;
    public PlayerHealthSystem _playerHealthSystem;
    private int lifeSCore = 1;

    // methods update the player's coins/lives equating them to the chosen difficulty
    private void Start()
    {
        uiManager.UpdateUI(_playerHealthSystem.playerCoins = DifficultyChoiseManager._PlayerCoins);
    }

    // increases the number by 1 and updates the ui
    public void IncreaseScore()
    {
        _playerHealthSystem.playerCoins += lifeSCore;
        uiManager.UpdateUI(_playerHealthSystem.playerCoins);
    }
    
    // Downcreases the number by 1 and updates the ui
    public void DowncreaseScore()
    {
        _playerHealthSystem.playerCoins -= lifeSCore;
        uiManager.UpdateUI(_playerHealthSystem.playerCoins);
    }
    
}
