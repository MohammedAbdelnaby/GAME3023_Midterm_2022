using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class PlayersMouse : MonoBehaviour
{
    public Item item = null;
    [SerializeField]
    private Image image;
    private void Start()
    {
        image.sprite = null;
    }
    // Update is called once per frame
    void Update()
    {
        ItemOnPointer();
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


    public void ChangeAlpha(float value)
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, value);
    }
}
