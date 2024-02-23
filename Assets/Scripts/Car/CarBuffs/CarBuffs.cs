using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBuffs : MonoBehaviour 
{
    private static CarBuffs _instance;
    public static CarBuffs Instance => _instance;

    public SpeedController SpeedController;
    public CarHighlight CarHighlight;
    public CarHP CarHP;

    private Dictionary<BuffId, Buff> _buffsDatabase = new Dictionary<BuffId, Buff>();
    private List<Buff> _enabledBuffs = new List<Buff>();
    private List<Buff> _buffsToApply = new List<Buff>();
    private List<Buff> _buffsToVanish = new List<Buff>();

    public void Awake()
    {
        _instance = this;
        _buffsDatabase.Add(BuffId.Slow, new SlowBuff());
        _buffsDatabase.Add(BuffId.Magnet, new MagnetBuff());
        _buffsDatabase.Add(BuffId.Shield, new ShieldBuff());
        _buffsDatabase.Add(BuffId.Nitro, new NitroBuff());

        foreach (var buff in _buffsDatabase.Values) buff.Init(this);
    }

    public void ApplyBuff(BuffId buffId)
    {
        var buff = _buffsDatabase[buffId];
        if (!_enabledBuffs.Contains(buff)) _buffsToApply.Add(buff);
    }

    public void VanishBuff(BuffId buffId)
    {
        var buff = _buffsDatabase[buffId];
        if (_enabledBuffs.Contains(buff) && !_buffsToApply.Contains(buff)) _buffsToVanish.Add(buff);
    }

    public void Update()
    {
        foreach (var buff in _buffsToVanish)
        {
            _enabledBuffs.Remove(buff);
            buff.Disable();
        }
        _buffsToVanish.Clear();
        foreach (var buff in _buffsToApply)
        {
            _enabledBuffs.Add(buff);
            buff.Enable();
        }
        _buffsToApply.Clear();
        foreach (var buff in _enabledBuffs)
        {
            buff.OnUpdate();
        }
    }

}