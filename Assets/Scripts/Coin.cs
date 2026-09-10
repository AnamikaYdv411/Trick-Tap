// Coin.cs — goes on the coin prefab, collider set to "Is Trigger"
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int value = 1;
    public GameObject collectVFX;   // optional particle burst
    public AudioClip collectSFX;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        CoinManager.Instance.AddCoins(value);

        if (collectVFX) Instantiate(collectVFX, transform.position, Quaternion.identity);
        if (collectSFX) AudioSource.PlayClipAtPoint(collectSFX, transform.position);

        gameObject.SetActive(false); // or Destroy(gameObject)
    }
}