using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopDescriptionScript : MonoBehaviour
{
    string Description = "Description";

    string Description1 = "Description: number 1";

    string Description2 = "Description: number 2";

    string Description3 = "Description: number 3";

    string Description4 = "Description: number 4";

    string Description5 = "Description: number 5";

    string Description6 = "Description: number 6";

    public string InventoryDescription(int itemNumber)
    {
        Debug.Log("Selected Description: " + itemNumber);
        if (itemNumber == 1)
        {
            Description = Description1;
        }
        else if (itemNumber == 2)
        {
            Description = Description2;
        }
        else if (itemNumber == 3)
        {
            Description = Description3;
        }
        else if (itemNumber == 4)
        {
            Description = Description4;
        }
        else if (itemNumber == 5)
        {
            Description = Description5;
        }
        else if (itemNumber == 6)
        {
            Description = Description6;
        }

        return Description;
    }


    public void ChangeDescription(int itemNumber)
    {
        GetComponent<Text>().text = InventoryDescription(itemNumber);
    }
}