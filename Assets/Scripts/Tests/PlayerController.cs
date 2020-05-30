using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private int _healthValue;
    public int HealthValue
    {
        get => _healthValue;
        set
        {
            _healthValue = value;
            UpdateHealthText();
            if (_healthValue <= 0)
            {
                Death();
            }
        }
    }
    private float _lastBeHitTime = 0;

    public float beHitProtectTime = 1f;
    public int maxHealthValue;
    public Color fullHealthColor;
    public Color zeroHealthColor;
    public Text healthText;
    public Text beHitTimeText;

    private void Start()
    {
        HealthValue = maxHealthValue;
        _lastBeHitTime = beHitProtectTime;
    }

    private void Update()
    {
        UpdateBeHitLastTime();
    }

    public void SimpleBeHit(int damage)
    {
        if (_lastBeHitTime > beHitProtectTime)
        {
            HealthValue -= damage;
            _lastBeHitTime = 0;
        }
    }
    private void Death()
    {
        Destroy(gameObject);
    }
    private void UpdateHealthText()
    {
        if (!healthText)
        {
            return;
        }
        healthText.text = HealthValue.ToString();
        healthText.color = Color.Lerp(zeroHealthColor, fullHealthColor, HealthValue * 1f / maxHealthValue);
    }
    private void UpdateBeHitLastTime()
    {
        _lastBeHitTime += Time.deltaTime;
        if (beHitTimeText)
        {
            beHitTimeText.text = Mathf.Max(0, beHitProtectTime - _lastBeHitTime).ToString();//这里是视图效果和功能无关
        }
    }
}
