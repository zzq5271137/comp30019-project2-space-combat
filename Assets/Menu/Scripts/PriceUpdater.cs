using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PriceUpdater : MonoBehaviour
{

    static private int itemSelected = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (itemSelected == -1) {
            GetComponent<Text>().text = "Price: N/A";
        } else {
            GetComponent<Text>().text = "Price: " + itemSelected;
        }
    }

    static public void ChangeItemSelected(int itemNumber) {
        itemSelected = itemNumber;
    }

}
