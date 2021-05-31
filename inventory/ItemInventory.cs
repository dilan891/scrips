using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInventory : MonoBehaviour
{
    public int id;
    public string type;
    public string description;
    public Sprite icon;

    [HideInInspector]
    public bool pickeUp;


}
