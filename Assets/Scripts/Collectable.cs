using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerManager.numberOfCoins += 5;
            Debug.Log("Coins: "+PlayerManager.numberOfCoins);
            Destroy(gameObject);
        }
    }
}
