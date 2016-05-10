using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ItemAdapter : MonoBehaviour
{
    public RectTransform prefab;

    public void Add(string message)
    {
        var item = Instantiate(prefab) as RectTransform;
        item.SetParent(this.transform, false);

        var text = item.GetComponentInChildren<Text>();
        text.text = message;
    }
}