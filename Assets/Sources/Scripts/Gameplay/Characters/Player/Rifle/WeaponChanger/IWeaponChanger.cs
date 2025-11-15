using System;

public interface IWeaponChanger
{
    public event Action Changed;

    public void SetMain();
    public void SetSecond();
    public void SetNext();
}
