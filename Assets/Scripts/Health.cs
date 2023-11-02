using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [SerializeField]
    // 控制生命值
    private Slider _healthSlider;

    /// <summary>
    /// 生命值
    /// </summary>
    public float Health
    {
        get
        {
            return _healthSlider.value;
        }

        set
        {
            _healthSlider.value = value;
        }
    }

    private void Start()
    {
    }

    /// <summary>
    /// 傷害
    /// </summary>
    /// <param name="value">傷害值</param>
    public void Damage(float value)
    {
        _healthSlider.value -= value;
    }

    /// <summary>
    /// 治療
    /// </summary>
    /// <param name="value">治療值</param>
    public void Heal(float value)
    {
        _healthSlider.value += value;
    }

    /// <summary>
    /// 完全恢復
    /// </summary>
    public void RecoverFully()
    {
        _healthSlider.value = _healthSlider.maxValue;
    }
}