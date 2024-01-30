using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeAreFighters3D.BattleUnit;

public class BaseController : MonoBehaviour,IBaseController
{
    private IHealth health;
    private IHealthUI healthUI;

    private int baseHealth;
    public int BaseHealth 
    {
        set
        {
            baseHealth = value;
            UpdateData(value);
        }
    }

    private void Awake() 
    {
        health = GetComponent<IHealth>();
        healthUI = GetComponent<IHealthUI>();
    }

    private void OnEnable() => GameManager.OnGameEnd += Reset;
    private void OnDisable() => GameManager.OnGameEnd -= Reset;
    private void Start()
    {
       // UpdateData(100);
    }

    public void UpdateData(int maxHealth)
    {
        health.MaxHealth = maxHealth;
        healthUI.MaxHealth = maxHealth;

    }
    private void Damage(int damageAmount)
    {
        var currentHealth = health.GotDamage(damageAmount);
        healthUI.UpdateHealthInUI(currentHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("Game Over");
            if (gameObject.CompareTag("Player")) 
            {
                GameManager.OnGameEnd?.Invoke();
            }
            else 
            {
                GameManager.OnGameEnd?.Invoke();
            }      
        }
    }

    private void Reset()
    {
        UpdateData(baseHealth); // Test Reset, Not Ideal Way :|
    }
}

public interface IBaseController 
{
    public int BaseHealth { set; }

}