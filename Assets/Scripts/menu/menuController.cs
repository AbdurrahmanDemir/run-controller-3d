using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuController : MonoBehaviour
{

    ItemManager �temManager = new ItemManager();

    public List<itemData> _itemData = new List<itemData>();
    private void Start()
    {
        //�temManager.firstTimeSave(_itemData);
    }
}
