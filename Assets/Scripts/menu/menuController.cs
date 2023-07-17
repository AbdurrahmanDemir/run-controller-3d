using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuController : MonoBehaviour
{

    ItemManager ýtemManager = new ItemManager();

    public List<itemData> _itemData = new List<itemData>();
    private void Start()
    {
        //ýtemManager.firstTimeSave(_itemData);
    }
}
