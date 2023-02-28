using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class BossHealth : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private float _invulnerabilityTime;

    [field: SerializeField] public Health Health { get; private set; }

    private Coroutine _makeVulnerableJob;
    private WaitForSeconds _rechargeTime;
    private int _damageTaken;
    private bool _isInvulnerable = true;

    public void Init(int damageTaken)
    {
        const int MaxHealthValue = 250;

        if (damageTaken < 0)
            throw new ArgumentOutOfRangeException();

        _rechargeTime = new WaitForSeconds(_invulnerabilityTime);
        _damageTaken = damageTaken;
        Health.Init(MaxHealthValue);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_isInvulnerable == false )
        {
            Health.TakeDamage(_damageTaken);
            _isInvulnerable = true;
            _makeVulnerableJob = StartCoroutine(MakeVulnerable());
        }
    }

    public IEnumerator MakeVulnerable()
    {
        yield return _rechargeTime;
        _isInvulnerable = false;
    }

    public void MakeInvulnerable()
    {
        if (_makeVulnerableJob != null)
            StopCoroutine(_makeVulnerableJob);

        _isInvulnerable = true;
    }
}