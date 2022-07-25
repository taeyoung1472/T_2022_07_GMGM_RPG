using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField] private int randomItemDropCount;
    [SerializeField] private ItemDataSO[] items;

    private bool isOpened = false;

    public void Test()
    {
        if (!isOpened)
        {
            isOpened = true;
            foreach (var item in items)
                print($"{item.name}�� {item.prefab.dropableCount}����ŭ ���Դ�!");
            for (int i = 0; i < randomItemDropCount; i++)
            {
                if (Generate() != null)
                    print($"{Generate().name}�� ���Դ�!");
            }
        }
    }
    public ItemDataSO Generate()
    {
        int totalWeight = 0;
        int check = 0;
        for (int i = 0; i < items.Length; i++)//�� ����ġ �� ���ϱ�
        {
            totalWeight += items[i].dropWeight;
        }

        int rand = Random.Range(1, totalWeight + 1);
        for (int i = 0; i < items.Length; i++)//�ϳ��ϳ� ���ذ��鼭 ����ġ �ȿ� �ִ��� üũ
        {
            check += items[i].dropWeight;
            if (rand <= check)
            {
                return items[i];
            }
        }
        return null;
    }
}