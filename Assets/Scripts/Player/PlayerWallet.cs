using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallet : MonoBehaviour
{
    [SerializeField] private CoinsCollector _coinCollector;

    [SerializeField] private int _coinAmount;

    private void Start()
    {
        _coinAmount = 0;
    }

    private void OnEnable()
    {
        _coinCollector.CoinChanged += AddCoin;
    }

    private void OnDisable()
    {
        _coinCollector.CoinChanged -= AddCoin;
    }

    private void AddCoin()
    {
        _coinAmount++;

        //Debug.Log(_coinAmount);
    }
}
