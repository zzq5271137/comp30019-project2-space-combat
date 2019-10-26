using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUpdater : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*
        GameObject gameObject = GameObject.Find("StatusOfGame");
        if(gameObject == null) {
            Debug.LogError("Failed to find Status of Game");
        }

        StatusOfGame gameStatus = gameObject.GetComponent<StatusOfGame>();
        */

        GetComponent<Text>().text = "Coins: " + StatusOfGame.coins;

    }
}
