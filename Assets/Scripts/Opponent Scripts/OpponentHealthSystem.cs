using System;
using UnityEngine;

public class OpponentHealthSystem : MonoBehaviour
{
    private int _MinusOpponentCoins = DifficultyChoiseManager._OpponentCoins;
    public GameObject coinsPrefab;
    public Transform coinsSpawnerPoint;

    public int maximumCoins = 8;

    public CoinsSpawner coinSpawner;

    public Animator _OpponentAnimator;
    public LampAnimationTrigger _LampAnimationTrigger;
    
    
    //spawn coins and check animator
    void Start()
    {
        if (coinsPrefab != null)
        {
           coinSpawner.Spawn(coinsPrefab, coinsSpawnerPoint, maximumCoins);
           coinSpawner.StartHidingCoins(_MinusOpponentCoins);
        }
        if (_OpponentAnimator == null)
        {
           Debug.Log($"Attach animator");
        }
    }

    //make visible last hiden coin
    public void OpponentSituatuinWon()
    {
        coinSpawner.RestoreCoins();
    }

    //check for opponent global lost animation
    private void Update()
    {
        if (_LampAnimationTrigger.opponentToGo)
        {
            _OpponentAnimator.SetTrigger("NeedToGoBack");
        }
    }
}
