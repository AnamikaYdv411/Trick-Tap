// Coin.cs — goes on the coin prefab, collider set to "Is Trigger"
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        CoinManager.Instance.AddCoins(value);

        if (AudioManager.Instance != null) AudioManager.Instance.PlayCoin();

        gameObject.SetActive(false);
    }
}