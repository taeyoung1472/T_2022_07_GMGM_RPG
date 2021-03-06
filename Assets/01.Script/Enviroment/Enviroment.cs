using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enviroment : MonoBehaviour
{
    [SerializeField] private SpriteButton[] spriteButton;
    [SerializeField] private float offset;
    public void Start()
    {
        for (int i = 0; i < spriteButton.Length; i++)
        {
            spriteButton[i].transform.position = new Vector3(0, offset + transform.position.y, transform.position.z);
        }
    }
    public void FocusButton(SpriteButton targetBtn)
    {
        for (int i = 0; i < spriteButton.Length; i++)
        {
            spriteButton[i].gameObject.SetActive(false);
        }
        targetBtn.gameObject.transform.position = Vector3.up * offset;
    }
}
