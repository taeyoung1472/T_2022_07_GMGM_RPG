using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class InventoryHandler : MonoBehaviour
{
    public static InventoryHandler Instance;

    public Dictionary<ItemDataSO, VirtualItem> itemsDic = new Dictionary<ItemDataSO, VirtualItem>();

    public Transform ItemContent;
    public GameObject InventoryItem;

    public ItemController[] InventoryItems;
    private void Awake()
    {
        Instance = this;
    }
    public void Add(ItemDataSO itemDataSO)
    {
        if (itemsDic.ContainsKey(itemDataSO))//�̹� �������� �ִ°��
        {
            if (itemDataSO.maxStackAbleCount > itemsDic[itemDataSO].Amount)//���� ���ϼ� �ִ� ���������� ������
            {
                itemsDic[itemDataSO].Amount++;
            }
            else
            {
                //�߰��ؾ��� ��ũ���� ������ 64�Ը԰� �Ǹ������� �ϸ� �ϳ� �� ���ݾ� �ٵ� �̰� ���߿� �����غ���
            }
        }
        else//�ƴѰ��
        {
            itemsDic.Add(itemDataSO, new VirtualItem(itemDataSO, Instantiate(InventoryItem, ItemContent)));
        }
        #region Legarcy
        /*if (itemDataSO.IsStackable())//�ʿ� ������
{
    if (itemsDic.ContainsKey(itemDataSO))//�̹� �������� �ִ°��
    {
        if(itemDataSO.maxStackAbleCount > itemsDic[itemDataSO].amount)//���� ���ϼ� �ִ� ���������� ������
        {
            itemsDic[itemDataSO].amount++;
        }
        else
        {
            //�߰��ؾ��� ��ũ���� ������ 64�Ը԰� �Ǹ������� �ϸ� �ϳ� �� ���ݾ� �ٵ� �̰� ���߿� �����غ���
        }
    }
    else//�ƴѰ��
    {
        itemsDic.Add(itemDataSO, new VirtualItem(itemDataSO));
    }
    /*bool itemAlreadyInInventory = false;
    foreach (VirtualItem invenitem in Items.Values)
    {
        if (invenitem.itemType == itemDataSO.itemType)
        {
            invenitem.amout ++;
            itemAlreadyInInventory = true;
        }
    }
    if (!itemAlreadyInInventory)
    {
        Items.Add(itemDataSO);
    }
}
else
{
    itemsDic.Add(itemDataSO);
}*/
        #endregion
    }
    public void Remove(ItemDataSO itemDataSO)
    {
        Destroy(itemsDic[itemDataSO].uiContent);
        itemsDic.Remove(itemDataSO);//�ȰŰ��� 
    }

    public void ListItems()//�״ϱ� �̰� ���� Ű���� �� �����ϰ� �����ϰ� �̷����� �޸� �ս��� ���̳��� GC�� ���̵��� ������ �ڵ���
    {
        /*foreach (Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }
        foreach(ItemDataSO item in itemsDic.Keys)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("NameText").GetComponent<TextMeshProUGUI>();
            var itemIcon = obj.transform.Find("ItemSprite").GetComponent<Image>();
            var itemAmout = obj.transform.Find("AmountText").GetComponent<TextMeshProUGUI>();
            itemName.text = item.name;
            itemIcon.sprite = item.profileImage;
            if (item.amout > 1)
            {
                itemAmout.SetText(item.amout.ToString());
            }
            else
            {
                itemAmout.SetText("");
            }
        }*/
    }
}
public class VirtualItem
{
    //�����ϰ� ���� �Ƹ�? �ϴ�
    public VirtualItem(ItemDataSO _data, GameObject _uiContent)
    {
        data = _data;
        uiContent = _uiContent;
        var itemName = uiContent.transform.Find("NameText").GetComponent<TextMeshProUGUI>();
        var itemIcon = uiContent.transform.Find("ItemSprite").GetComponent<Image>();
        var itemAmout = uiContent.transform.Find("AmountText").GetComponent<TextMeshProUGUI>();
        itemName.text = data.name;
        itemIcon.sprite = data.profileImage;
        amountText = itemAmout;
    }//�̰� ���鶧�ݾ� �׷��ϱ� Data �־��ְ� �̰� �����ڸ� ȣ���ؾ��� ��
    public ItemDataSO data;
    private int amount = 1;//�ϴ� �������� amount �ʱⰡ���� 0��
    public int Amount { get { return amount; } set
        {
            amountText.SetText($"{value}");
            amount = value;
        } 
    }
    public GameObject uiContent;
    TextMeshProUGUI amountText = null;//���߾�
}