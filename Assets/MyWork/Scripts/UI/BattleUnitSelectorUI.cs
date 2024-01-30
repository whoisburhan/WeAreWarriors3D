using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUnitSelectorUI : MonoBehaviour
{
    [SerializeField] private Image battleUnitImg;
    [SerializeField] private Text battleUnitName;
    [SerializeField] private Text battleUnitPurchasePrice;

    public void SetBattleUnitSelectorUI(Sprite battleUnitImg, string name, int purchasePrice) 
    {
        this.battleUnitImg.sprite = battleUnitImg;
        battleUnitName.text = name;
        battleUnitPurchasePrice.text = CoinInTextForm.CoinInText(purchasePrice);
    }

    public void IsPurchased(bool isPurchased) 
    {
        if(isPurchased) battleUnitPurchasePrice.transform.parent.gameObject.SetActive(false);
        else battleUnitPurchasePrice.transform.parent.gameObject.SetActive(true);
    }
}
