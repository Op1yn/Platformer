using System;
using UnityEngine;

public class CoinsCollector : MonoBehaviour
{
    public event Action CoinChanged;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Coin>(out _))
        {
            CoinChanged?.Invoke();
            other.gameObject.SetActive(false);
        }
    }
}
