using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    // Game object of the images
    public GameObject Ship1Image;
    public GameObject Ship2Image;
    public GameObject Ship3Image;
    public GameObject Ship4Image;
    public GameObject Ship5Image;
    public GameObject Ship6Image;


    // Game object of the buttons
    public GameObject Ship2Button;
    public GameObject Ship3Button;
    public GameObject Ship4Button;
    public GameObject Ship5Button;
    public GameObject Ship6Button;



    int SelectedInventoryItem = 1;


    static bool[] haveItems = new bool[]
        {true, false, false, false, false, false};

    static int shipImage = 1;

    private void Update()
    {
        SelectedImageShip(shipImage);

        // Check to see if item was bought
        if (haveItems[1] == true)
        {
            Ship2Button.SetActive(true);
        }

        if (haveItems[2] == true)
        {
            Ship3Button.SetActive(true);
        }

        if (haveItems[3] == true)
        {
            Ship4Button.SetActive(true);
        }

        if (haveItems[4] == true)
        {
            Ship5Button.SetActive(true);
        }

        if (haveItems[5] == true)
        {
            Ship6Button.SetActive(true);
        }


    }

    public void SelectShip(int shipNumber)
    {
        SelectedInventoryItem = shipNumber;


        /*
        Debug.Log("Selected Ship: " + shipNumber);

        SelectedImageShip(shipNumber);

        if (haveItems[shipNumber - 1] == true) {

            StatusOfGame.SelectShipType(shipNumber);
        }
        */
    }


    public void SelectItem()
    {
        if (haveItems[SelectedInventoryItem - 1] == true)
        {

            shipImage = SelectedInventoryItem;
            StatusOfGame.SelectShipType(SelectedInventoryItem);

        }
    }

    static public void BoughtItem(int itemNumber)
    {
        haveItems[itemNumber] = true;
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
            Ship6Image.SetActive(false);
        }
        else if (ImageNumber == 2)
        {
            Ship1Image.SetActive(false);
            Ship2Image.SetActive(true);
            Ship3Image.SetActive(false);
            Ship4Image.SetActive(false);
            Ship5Image.SetActive(false);
            Ship6Image.SetActive(false);
        }
        else if (ImageNumber == 3)
        {
            Ship1Image.SetActive(false);
            Ship2Image.SetActive(false);
            Ship3Image.SetActive(true);
            Ship4Image.SetActive(false);
            Ship5Image.SetActive(false);
            Ship6Image.SetActive(false);
        }
        else if (ImageNumber == 4)
        {
            Ship1Image.SetActive(false);
            Ship2Image.SetActive(false);
            Ship3Image.SetActive(false);
            Ship4Image.SetActive(true);
            Ship5Image.SetActive(false);
            Ship6Image.SetActive(false);
        }
        else if (ImageNumber == 5)
        {
            Ship1Image.SetActive(false);
            Ship2Image.SetActive(false);
            Ship3Image.SetActive(false);
            Ship4Image.SetActive(false);
            Ship5Image.SetActive(true);
            Ship6Image.SetActive(false);
        }
        else if (ImageNumber == 6)
        {
            Ship1Image.SetActive(false);
            Ship2Image.SetActive(false);
            Ship3Image.SetActive(false);
            Ship4Image.SetActive(false);
            Ship5Image.SetActive(false);
            Ship6Image.SetActive(true);
        }
    }

}