using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuController : MonoBehaviour
{

    ItemManager ętemManager = new ItemManager();

    public List<itemData> _itemData = new List<itemData>();
    private void Start()
    {
        //ętemManager.firstTimeSave(_itemData);
    }
}
