using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    [Header("Setup Fields")]
    public int id;
    private Image healthBar;

    #region Setup
    private void Start()
    {
        EventHandler.instance.updateHealth += UpdateHealth;
        healthBar = GetComponent<Image>();
    }

    private void OnDestroy()
    {
        EventHandler.instance.updateHealth -= UpdateHealth;
    }
    #endregion Setup

    public void UpdateHealth(int _id, float _health)
    {
        if (id == _id)
        {
            healthBar.fillAmount = _health;
        }
    }
}
