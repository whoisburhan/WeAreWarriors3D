using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WeAreFighters3D.Data;

public class UpgradeUI : MonoBehaviour
{
    [SerializeField] private List<BattleUnitSelectorUI> battleUnitSelectorUIs;

    private void OnEnable()
    {
        GameData.OnUpdateTireData += UpdateUpgradeUI;
    }

    private void OnDisable()
    {
        GameData.OnUpdateTireData -= UpdateUpgradeUI;
    }

    public void UpdateUpgradeUI(BattleUnitTireData tireData, int CurrentTireUnlockedBattleUnitIndex) 
    {
        for(int i = 0; i< battleUnitSelectorUIs.Count; i++) 
        {
            if(i < tireData.UnitTireData.Count) 
            {
                var unitTireData = tireData.UnitTireData[i];
                battleUnitSelectorUIs[i].SetBattleUnitSelectorUI(unitTireData.UnitPortrait, unitTireData.UnitName, unitTireData.UnitUnlockPrice);
                
                if (CurrentTireUnlockedBattleUnitIndex >= i) battleUnitSelectorUIs[i].IsPurchased(true);
                else battleUnitSelectorUIs[i].IsPurchased(false);
            }
        }
    }
}
