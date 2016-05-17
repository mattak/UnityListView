using UnityEngine;
using UnityEngine.UI;

public class AddButton: MonoBehaviour
{
    public RectTransform prefab;
    public RectTransform addTo;
    private int number = 0;

    public void Start()
    {
        var button = this.GetComponent<Button>();
        button.onClick.AddListener(Add);
    }

    public void Add()
    {
        this.Add("sample message");
    }

    public void Add(string message)
    {
        number++;
        var item = Instantiate(prefab) as RectTransform;
        item.SetParent(this.addTo.transform, false);

        var text = item.GetComponentInChildren<Text>();
        text.text = number.ToString() + ". " + message;
    }
}