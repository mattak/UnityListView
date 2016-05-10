using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemAdapter : MonoBehaviour
{
    public RectTransform prefab;
    private int number = 0;

    public void Add(string message)
    {
        number++;
        var item = Instantiate(prefab) as RectTransform;
        item.SetParent(this.transform, false);

        var text = item.GetComponentInChildren<Text>();
        text.text = number.ToString() + ". " + message;
    }
}