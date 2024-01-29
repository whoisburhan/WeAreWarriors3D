using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUnitSelectorUI : MonoBehaviour
{
    [SerializeField] private Image battleUnitImg;
    [SerializeField] private Text battleUnitName;
    [SerializeField] private Text battleUnitPurchasePrice;

    private void Start()
    {
        Debug.Log(PurchasePriceInText(500));
        Debug.Log(PurchasePriceInText(5400));
        Debug.Log(PurchasePriceInText(12334400));
    }

    public void SetBattleUnitSelectorUI(Sprite battleUnitImg, string name, int purchasePrice) 
    {
        this.battleUnitImg.sprite = battleUnitImg;
        battleUnitName.text = name;
        battleUnitPurchasePrice.text = PurchasePriceInText(purchasePrice);
    }

    public void IsPurchased(bool isPurchased) 
    {
        if(isPurchased) battleUnitPurchasePrice.transform.parent.gameObject.SetActive(false);
        else battleUnitPurchasePrice.transform.parent.gameObject.SetActive(true);
    }

    private string PurchasePriceInText(int purchasePrice) 
    {
        if(purchasePrice < 1000) return purchasePrice.ToString();
        else if(purchasePrice >= 1000 && purchasePrice < 1000000) return (purchasePrice /1000f).ToString("F1")+"K";
        else return (purchasePrice / 1000000f).ToString("F1")+"M";
    }
}
