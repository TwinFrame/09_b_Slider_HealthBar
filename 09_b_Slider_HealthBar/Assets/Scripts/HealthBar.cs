using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HealthBar : MonoBehaviour
{
	[SerializeField] private Humster _player;
	[SerializeField] private float _speed;

	private Slider _healthBar;
	private float _targetValue;
	private Coroutine _ñhangeSliderValueJob;

	private void OnEnable()
	{
		_healthBar = GetComponent<Slider>();
		_player.ChangedHealth += OnSetSliderValue;
	}

	private void OnDisable()
	{
		_player.ChangedHealth -= OnSetSliderValue;
	}

	private void Start()
	{
		_healthBar.value = _healthBar.maxValue = _player.Health / _player.MaxHealth;
	}

	private void OnSetSliderValue(float value)
	{
		_targetValue = value;

		if (_ñhangeSliderValueJob != null)
			StopCoroutine(_ñhangeSliderValueJob);

		_ñhangeSliderValueJob = StartCoroutine(ChangeSliderValue(_targetValue));
	}

	private IEnumerator ChangeSliderValue(float targetValue)
	{
		while (_healthBar.value != targetValue)
		{
			_healthBar.value = Mathf.MoveTowards(_healthBar.value, targetValue, _speed * Time.deltaTime);

			yield return null;
		}
	}
}
