using System;
using UnityEngine;
using Cysharp.Threading.Tasks;

public class Weapon : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponSetting _setting;

    private int _currentBuletsCount;
    private bool _canShoot;

    public bool CanShoot => _canShoot;
    public int CurrentBulletsCount => _currentBuletsCount;
    public IWeaponSetting Setting => _setting;

    private void Awake()
    {
        _currentBuletsCount = _setting.BulletsInClip;
        _canShoot = true;
    }

    public void SpendBullet()
    {
        if (--_currentBuletsCount < 0)
        {
            _currentBuletsCount = 0;
            _canShoot = false;
        }
    }

    public void Reload()
    {
        if (_currentBuletsCount == _setting.BulletsInClip)
            return;

        ReloadAsync().Forget();
    }

    public void WaitShootDelay()
    {
        if (_currentBuletsCount <= 0) 
            return;

        WaitShootDelayAsync().Forget();
    }

    private async UniTaskVoid ReloadAsync()
    {
        _canShoot = false;

        await UniTask.Delay(TimeSpan.FromSeconds(_setting.ReloadTime));

        _currentBuletsCount = _setting.BulletsInClip;
        _canShoot = true;
    }

    private async UniTaskVoid WaitShootDelayAsync()
    {
        _canShoot = false;
        await UniTask.Delay(TimeSpan.FromSeconds(_setting.ShootDelay));
        _canShoot = true;
    }
}
