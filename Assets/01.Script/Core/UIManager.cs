using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoSingleTon<UIManager>
{
    #region �÷��̾� ī�� UI ����
    [Header("�÷��̾� ī�� UI ����")]
    [SerializeField] private TextMeshProUGUI characterCardName;
    [SerializeField] private TextMeshProUGUI characterCardDesc;
    [SerializeField] private Image characterCardProfile;
    #endregion

    public void SetCharacterCardInfo(CharacterData data)
    {
        characterCardName.text = data.name;
        characterCardDesc.text = data.desc;
        characterCardProfile.sprite = data.profile;
    }
}
