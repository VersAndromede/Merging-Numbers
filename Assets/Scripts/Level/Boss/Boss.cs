using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Boss : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] public float InvulnerabilityTime;

    [field: SerializeField] public Health Health { get; private set; }
    [field: SerializeField] public int Damage { get; private set; }
    [field: SerializeField] public float RechargeTime { get; private set; }

    private WaitForSeconds _rechargeTime;
    private bool _isInvulnerable = true;
    private bool _initialized;
    private int _damageTaken;

    private void Start()
    {
        const int MaxHealthValue = 250;

        _rechargeTime = new WaitForSeconds(RechargeTime);
        Health.Init(MaxHealthValue);
    }

    public void Init(int damageTaken)
    {
        if (_initialized)
            throw new InvalidOperationException("You cannot re-initialize.");

        if (damageTaken < 0)
            throw new ArgumentOutOfRangeException();

        _damageTaken = damageTaken;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_isInvulnerable == false)
        {
            Health.TakeDamage(_damageTaken);
            _isInvulnerable = true;
            StartCoroutine(MakeVulnerable());
        }
    }

    public IEnumerator MakeVulnerable()
    {
        yield return _rechargeTime;
        _isInvulnerable = false;
    }
}