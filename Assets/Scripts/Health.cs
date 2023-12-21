using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;


    private void Start()
    {
        currentHealth = maxHealth;
    }
    private void Update()
    {
        if(currentHealth <= 0)
        {
            Debug.Log("We died");
        }
    }
    public void DealDamage(float _value)
    {
        if ((currentHealth - _value) < 0)
        {
            currentHealth = 0;
        }
        else 
        {
            currentHealth -= _value;
        }

    }

    public void Heal(float _value)
    {

        if ((currentHealth + _value) > maxHealth)
        {
            currentHealth = maxHealth;
        }
        else
        {
            currentHealth += _value;
        }
       
    }
}
