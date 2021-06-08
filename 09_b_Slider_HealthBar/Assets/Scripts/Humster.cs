using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Humster : MonoBehaviour
{
	[SerializeField] private float _maxHealth;

	public event UnityAction<float> ChangedHealth;

	private float _health;

	public float MaxHealth => _maxHealth;
	public float Health => _health;

	private void Awake()
	{
		_health = _maxHealth;
	}

	private void Start()
	{
		ChangedHealth?.Invoke(_health / _maxHealth);
	}

	public void AddValueToHealth(float value)
	{
		if ((_health + value) <= _maxHealth && (_health + value) >= 0)
		{
			AddHealth(value);
			return;
		}

		if ((_health + value) > _maxHealth && _health < _maxHealth)
		{
			AddHealth(_maxHealth - _health);
			return;
		}

		if ((_health + value) < 0 && _health > 0)
		{
			AddHealth(-_health);
			return;
		}
	}

	private void AddHealth(float value)
	{
		_health += value;

		ChangedHealth?.Invoke(_health / _maxHealth);
	}
}
