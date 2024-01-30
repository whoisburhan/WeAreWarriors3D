using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WeAreFighters3D.Data;

public class UpgradeUI : MonoBehaviour
{
    [SerializeField] private List<BattleUnitSelectorUI> battleUnitSelectorUIs;
    [Space]
    [SerializeField] private Text m_NextMeatGenerationSpeedText;
    [SerializeField] private Text m_NextMeatGenerationSpeedCostText;
    [SerializeField] private Button m_NextMeatGenerationSpeedButton;
    [Space]
    [SerializeField] private Text m_NextBaseHpText;
    [SerializeField] private Text m_NextBaseHpCostText;
    [SerializeField] private Button m_NextBaseHpButton;

    int baseHpUpgradeCost, meatGenerationSpeedUpgradeCost;

    private void Start()
    {
        m_NextBaseHpButton.onClick.RemoveAllListeners();
        m_NextBaseHpButton.onClick.AddListener(BuyBaseMaxHp);

        m_NextMeatGenerationSpeedButton.onClick.RemoveAllListeners();
        m_NextMeatGenerationSpeedButton.onClick.AddListener(BuyMeatProductionSpeed);
    }

    private void OnEnable()
    {
        GameData.OnUpdateTireData += UpdateUpgradeUI;
        GameData.OnUpdatNextMeatProductionSpeed += UpdateMeatProductionSpeedInUI;
        GameData.OnUpdateNextBaseHp += UpdateBaseHPinUI;
    }

    private void OnDisable()
    {
        GameData.OnUpdateTireData -= UpdateUpgradeUI;
        GameData.OnUpdatNextMeatProductionSpeed -= UpdateMeatProductionSpeedInUI;
        GameData.OnUpdateNextBaseHp -= UpdateBaseHPinUI;
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

    private void UpdateMeatProductionSpeedInUI(MeatData meatData) 
    {
        m_NextMeatGenerationSpeedText.text = meatData.MeatGeneratePerSecond.ToString() + "/s";
        m_NextMeatGenerationSpeedCostText.text = meatData.UpgradePrice.ToString();
        meatGenerationSpeedUpgradeCost = meatData.UpgradePrice;
    }

    private void UpdateBaseHPinUI(BaseHealth baseHealthData) 
    {
        m_NextBaseHpText.text = baseHealthData.MaxHealth.ToString();
        m_NextBaseHpCostText.text = baseHealthData.UpgradePrice.ToString();
        baseHpUpgradeCost = baseHealthData.UpgradePrice;
    }

    private void BuyMeatProductionSpeed() 
    {
        if(GameData.OnGetTotalCoin() > meatGenerationSpeedUpgradeCost) 
        {
            GameData.OnIncreaseMeatGeneartionSpeedIndex?.Invoke();
            GameData.OnUpdateTotalCoin(-baseHpUpgradeCost);
        }
    }

    private void BuyBaseMaxHp() 
    {
        if (GameData.OnGetTotalCoin() > baseHpUpgradeCost)
        {
            GameData.OnIncreaseBaseHpIndex?.Invoke();
            GameData.OnUpdateTotalCoin(-baseHpUpgradeCost);
        }
    }
}
