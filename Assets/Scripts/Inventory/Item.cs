using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public int id = 0;
    new public string name = "unknown";
    public string description = "";
    public Sprite icon = null;

}
