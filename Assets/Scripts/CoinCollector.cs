using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCollector : MonoBehaviour
{
    int coins;
    [SerializeField] Text counter;
    [SerializeField] AudioSource coinCollectedSound;
    

    void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.CompareTag("Coin")) {
            Destroy(collision.gameObject);
            coins++;
            counter.text = "Coins: " + coins;
            coinCollectedSound.Play();
        }
    }
}
