using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeAreFighters3D.BattleUnit;

public class BaseController : MonoBehaviour,IBaseController
{
    private IHealth health;
    private IHealthUI healthUI;
    public int BaseHealth { set => throw new System.NotImplementedException(); }

    private void Awake() 
    {
        health = GetComponent<IHealth>();
        healthUI = GetComponent<IHealthUI>();
    }

    private void Start()
    {
        Debug.Log("Ghhhhh");
        UpdateData(100);
    }

    public void UpdateData(int maxHealth)
    {
        health.MaxHealth = maxHealth;
        healthUI.MaxHealth = maxHealth;

    }
    private void Damage(int damageAmount)
    {
        Debug.Log("Ghhhhh");
        var currentHealth = health.GotDamage(damageAmount);
        healthUI.UpdateHealthInUI(currentHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("Game Over");
        }
    }
}

public interface IBaseController 
{
    public int BaseHealth { set; }

}