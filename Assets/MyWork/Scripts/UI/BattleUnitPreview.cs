using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUnitPreview : MonoBehaviour
{
    [SerializeField] private Image m_UnitIcon;
    [SerializeField] private Text m_UnitProductionCost;

    public void UpdateUnitPreview(Sprite unitSprite, int unitProductionCost) 
    {
        m_UnitIcon.sprite = unitSprite;
        m_UnitProductionCost.text = unitProductionCost.ToString();
    }
}
