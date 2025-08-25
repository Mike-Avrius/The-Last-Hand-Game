using System;
using System.Collections.Generic;
using UnityEngine;

public class CoinsSpawner : MonoBehaviour
{
    // public Transform spawner;
    public float verticalOffset = 0.1f;

    //list to store spawned and hiden coins
    public List<GameObject> spawnedCoins = new List<GameObject>();
    public Stack<GameObject> hidenCoins = new Stack<GameObject>(); 
    
    //spawn as much as opponetn has coins with verticalOffset
    public void Spawn(GameObject coinprefabb, Transform parent, int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject newCoin = Instantiate(coinprefabb, parent);
            newCoin.transform.localPosition = new Vector3(0, i * verticalOffset, 0);
            newCoin.tag = "Coin";
            newCoin.name = $"Coin number {i + 1}";
            spawnedCoins.Add(newCoin);
        }

    }
    
    
    // I use a list to store all the coins and hide the last coins by adding them
    //    to the stack. The stack works on the principle of First In Last Out, 
    //      since the coins are hidden from above the last coin in the stack will be
    //           on the border with the List and so as the first coin it will be restored
    public void DeleteCoin()
    {
        if (spawnedCoins.Count > 0)
        {
            GameObject coinToDelete = spawnedCoins[spawnedCoins.Count - 1];
            spawnedCoins.RemoveAt(spawnedCoins.Count - 1); 
            hidenCoins.Push(coinToDelete);
            coinToDelete.tag = "Hidden Coin";
            coinToDelete.SetActive(false);
        }
    }
    public void RestoreCoins()
    {
        if (hidenCoins.Count > 0)
        {
            GameObject coinToShow = hidenCoins.Pop();  
            coinToShow.SetActive(true);
            coinToShow.tag = "Coin";
            spawnedCoins.Add(coinToShow); 
        }
    }
    public void StartHidingCoins(int coinAmount)
    {
        for (int i = 0; i < coinAmount; i++)
        {
            if (spawnedCoins.Count > 0)
            {
                GameObject coinToHide = spawnedCoins[spawnedCoins.Count - 1];
                coinToHide.tag = "Hidden Coin";
                coinToHide.SetActive(false);
                hidenCoins.Push(coinToHide); 
                spawnedCoins.RemoveAt(spawnedCoins.Count - 1); 
            }
        }
    }
}
