using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopScript : MonoBehaviour
{

    public GameObject Ship1Image;
    public GameObject Ship2Image;
    public GameObject Ship3Image;
    public GameObject Ship4Image;
    public GameObject Ship5Image;

    // 6 ships
    // 1: default
    static bool[] Items = new bool[]
        {true, false, false, false, false, false};

    // the correspinding price of ship
    static int[] Price = new int[] {0, 1, 1, 2, 2, 2};


    private int selectedItem = 0;


    public void ChooseSelectedItem(int Itemselected)
    {
        selectedItem = Itemselected;
        Debug.Log(selectedItem);
        PriceUpdater.ChangeItemSelected(Price[Itemselected]);
    }

    public void BuyShip()
    {
        int coins = StatusOfGame.GetCoins();

        Debug.Log(selectedItem);

        if (coins >= Price[selectedItem] & Items[selectedItem] == false)
        {
            StatusOfGame.MinusCoins(Price[selectedItem]);
            Items[selectedItem] = true;
            InventoryScript.BoughtItem(selectedItem);
            Price[selectedItem] = -1;
            PriceUpdater.ChangeItemSelected(Price[selectedItem]);
            Debug.Log("Bought Item: " + selectedItem);
        }
    }

    public void SelectedImageShip(int ImageNumber)
    {
        if (ImageNumber == 1)
        {
            Ship1Image.SetActive(true);
            Ship2Image.SetActive(false);
            Ship3Image.SetActive(false);
            Ship4Image.SetActive(false);
            Ship5Image.SetActive(false);

        }
        else if (ImageNumber == 2)
        {
            Ship1Image.SetActive(false);
            Ship2Image.SetActive(true);
            Ship3Image.SetActive(false);
            Ship4Image.SetActive(false);
            Ship5Image.SetActive(false);
        }
        else if (ImageNumber == 3)
        {
            Ship1Image.SetActive(false);
            Ship2Image.SetActive(false);
            Ship3Image.SetActive(true);
            Ship4Image.SetActive(false);
            Ship5Image.SetActive(false);
        }
        else if (ImageNumber == 4)
        {
            Ship1Image.SetActive(false);
            Ship2Image.SetActive(false);
            Ship3Image.SetActive(false);
            Ship4Image.SetActive(true);
            Ship5Image.SetActive(false);
        }
        else if (ImageNumber == 5)
        {
            Ship1Image.SetActive(false);
            Ship2Image.SetActive(false);
            Ship3Image.SetActive(false);
            Ship4Image.SetActive(false);
            Ship5Image.SetActive(true);
        }
    }
}