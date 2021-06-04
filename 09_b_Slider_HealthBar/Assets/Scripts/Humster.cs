using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Humster : MonoBehaviour
{
	[SerializeField] private float _maxHealth;
	[SerializeField] private Slider _healthBar;

	private float _health;
	private float _targetValue;

	private void Awake()
	{
		_targetValue = _healthBar.value = _healthBar.maxValue = _health = _maxHealth;
	}

	private void FixedUpdate()
	{
		_healthBar.value = Mathf.MoveTowards(_healthBar.value, _targetValue, 0.5f);
	}

	public void CheckValue(float value)
	{
		if ((_health + value) <= _maxHealth && (_health + value) >= 0)
		{
			ChangeHealth(_health + value);
			return;
		}

		if ((_health + value) > _maxHealth && _health < _maxHealth)
		{
			ChangeHealth(_maxHealth);
			return;
		}

		if ((_health + value) < 0 && _health > 0)
		{
			ChangeHealth(0f);
			return;
		}

	}

	private void ChangeHealth(float value)
	{
		_health = value;

		_targetValue = _health;
	}
}
