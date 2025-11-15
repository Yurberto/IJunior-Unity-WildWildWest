using System;
using System.Collections.Generic;

public class WeaponChanger : IWeaponChanger
{
    private const int MainWeaponIndex = 0;
    private const int SecondWeaponIndex = 1;

    private List<Weapon> _weapons;
    private Weapon _current;
    private int _currentIndex;

    public event Action Changed;

    public Weapon Current
    {
        get => _current;
        private set
        {
            _current = value;
            Changed?.Invoke();
        }
    }

    public WeaponChanger(List<Weapon> weapons)
    {
        _weapons = weapons;
    }

    public void SetMain()
    {
        if (Current != _weapons[MainWeaponIndex]) 
            Current = _weapons[MainWeaponIndex];
    }

    public void SetSecond()
    {
        if (Current != _weapons[SecondWeaponIndex])
            Current = _weapons[SecondWeaponIndex];
    }

    public void SetNext()
    {
        if (++_currentIndex >= _weapons.Count)
        {
            _currentIndex = MainWeaponIndex;
        }

        Current = _weapons[_currentIndex];
    }
}
