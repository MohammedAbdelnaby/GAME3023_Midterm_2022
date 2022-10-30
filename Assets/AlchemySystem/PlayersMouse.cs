using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class PlayersMouse : MonoBehaviour
{
    private Item item = null;
    [SerializeField]
    private Image image;

    public Item Item { get => item; set => item = value; }

    private void Start()
    {
        image.sprite = null;
    }
    // Update is called once per frame
    void Update()
    {
        ItemOnPointer();
        ChangeAlpha();
    }
    private void ItemOnPointer()
    {
        image.transform.position = Input.mousePosition;
        if (item != null)
        {
            image.sprite = item.icon;
        }
        else
        {
            image.sprite = null;
        }
    }


    public void ChangeAlpha()
    {
        if (item == null)
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0.0f);
        }
        else
        {
            image.color = new Color(image.color.r, image.color.g, image.color.b, 0.5f);
        }
    }
}
