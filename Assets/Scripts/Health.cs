using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] float maxHP = 20, currentHP;

    [SerializeField] Image healthBar;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
    }

    public void ApplyDamage(float value)
    {
        currentHP -= value;
        UpdateHealthBar();

        if (currentHP <= 0)
        {
            currentHP = 0;
            MyEvents.Update.Invoke(transform.position.x, transform.position.y, transform.position.z);
            gameObject.SetActive(false);
        }
    }

    public void Heal(float value)
    {
        currentHP += value;
        UpdateHealthBar();

        if (currentHP >= maxHP) 
        {
            currentHP = maxHP;
        }
    }

    void UpdateHealthBar()
    {
        healthBar.transform.localScale = new Vector3((currentHP / maxHP), 1, 1);
    }
}
