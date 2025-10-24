using System;
using System.Collections.Generic;

namespace Core
{
    public class PlayerData
    {
        public event Action<string> ValueChanged;
        
        public static readonly PlayerData Instance = new();
        
        private readonly Dictionary<string, ValueHolder> _valueHoldersByEntityKey = new();
        
        public TValue GetEntityValue<TEntity, TValue>(TEntity entity, TValue defaultValue = default) 
            where TEntity : EntityInfoBase<TValue>
        {
            if (_valueHoldersByEntityKey.TryGetValue(entity.Key, out var valueHolder))
            {
                return ((ValueHolder<TValue>)valueHolder).Value;
            }

            valueHolder = new ValueHolder<TValue>(defaultValue);
            _valueHoldersByEntityKey[entity.Key] = valueHolder;
                
            return defaultValue;
        }
        
        public void SetEntityValue<TEntity, TValue>(TEntity entity, TValue value) 
            where TEntity : EntityInfoBase<TValue>
        {
            if (_valueHoldersByEntityKey.TryGetValue(entity.Key, out var valueHolder))
            {
                ((ValueHolder<TValue>)valueHolder).Value = value;
            }
            else
            {
                valueHolder = new ValueHolder<TValue>(value);
                _valueHoldersByEntityKey[entity.Key] = valueHolder;
            }

            ValueChanged?.Invoke(entity.Key);
        }
    }
}