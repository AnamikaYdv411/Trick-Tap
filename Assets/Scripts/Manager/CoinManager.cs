// CoinManager.cs
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;
    public int TotalCoins { get; private set; }

    void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else Destroy(gameObject);
    }

    public void AddCoins(int amount)
    {
        TotalCoins += amount;
        Debug.Log("Coins: " + TotalCoins);
    }

    public void ResetCoins() => TotalCoins = 0; // call when restarting a run
}