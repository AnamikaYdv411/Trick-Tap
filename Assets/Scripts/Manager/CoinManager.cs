using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private static CoinManager _instance;
    public static CoinManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("CoinManager (Auto)");
                _instance = go.AddComponent<CoinManager>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }

    public int TotalCoins { get; private set; }

    void Awake()
    {
        if (_instance == null) { _instance = this; DontDestroyOnLoad(gameObject); }
        else if (_instance != this) Destroy(gameObject);
    }

    public void AddCoins(int amount)
    {
        TotalCoins += amount;
        Debug.Log("Coins: " + TotalCoins);
    }

    public void ResetCoins() => TotalCoins = 0;
}