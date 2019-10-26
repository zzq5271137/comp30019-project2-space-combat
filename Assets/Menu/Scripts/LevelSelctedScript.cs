using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelctedScript : MonoBehaviour
{

    int itemCount = 1;

    public void Change_Level(int itemNumber) {
        itemCount = itemNumber;
    }

}
