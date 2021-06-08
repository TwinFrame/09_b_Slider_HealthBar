using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HealthBar : MonoBehaviour
{
	[SerializeField] private Humster _player;
	[SerializeField] private int _speed;

	private Slider _healthBar;
	private float _targetValue;

	private void OnEnable()
	{
		_healthBar = GetComponent<Slider>();
		_player.ChangedHealth += ChangeTargetValue;
	}

	private void OnDisable()
	{
		_player.ChangedHealth -= ChangeTargetValue;
	}

	private void Start()
	{
		_healthBar.value = _healthBar.maxValue = _player.Health / _player.MaxHealth;
	}

	private void FixedUpdate()
	{
		_healthBar.value = Mathf.MoveTowards(_healthBar.value, _targetValue, _speed * 0.001f);
	}

	private void ChangeTargetValue(float value)
	{
		_targetValue = value;
	}
}
