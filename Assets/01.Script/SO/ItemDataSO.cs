using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/ItemData")]
public class ItemDataSO : ScriptableObject
{
    public int id;
    [Header("�⺻ ���")]
    public Sprite profileImage;
    public RareRate rareRate;
    public string name = "������ �̸�";
    [TextArea(5, 1)]
    public string desc = "������ ����";
    public int maxStackAbleCount = 32;
    [Header("Drop ����")]
    public int dropWeight = 1;
    public enum ItemType
    {
        Production,
        Food
    }
    public ItemType itemType;


}