using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WeAreFighters3D.Data;

public class BattleUnitPreviewHolder : MonoBehaviour
{
    [SerializeField] private List<BattleUnitPreview> m_BattleUnitPreviews;

    private void OnEnable() => GameData.OnUpdateTireData += UpdatePreviews;

    private void OnDisable() => GameData.OnUpdateTireData -= UpdatePreviews;

    private void UpdatePreviews(BattleUnitTireData tireData, int purchasedBattleUnitIndex)
    {
        for (int i = 0; i < m_BattleUnitPreviews.Count; i++)
        {
            if (i < tireData.UnitTireData.Count)
            {
                var unitTireData = tireData.UnitTireData[i];
                m_BattleUnitPreviews[i].UpdateUnitPreview(unitTireData.UnitPortrait, unitTireData.UnitGenerationCost);

                if (purchasedBattleUnitIndex >= i) m_BattleUnitPreviews[i].gameObject.SetActive(true);
                else m_BattleUnitPreviews[i].gameObject.SetActive(false);
            }
        }
    }


}
