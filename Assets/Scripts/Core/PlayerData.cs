using System;
using System.Collections.Generic;

namespace Core
{
    public class PlayerData
    {
        public event Action<string> ValueChanged;
        
        public static readonly PlayerData Instance = new();
        
        private readonly Dictionary<string, ValueHolder> _valueHoldersByEntityKey = new();

        public void RegisterEntity<TEntity, TValue>(TEntity entity, TValue defaultValue = default)
            where TEntity : EntityInfoBase<TValue>
        {
            if (_valueHoldersByEntityKey.TryGetValue(entity.Key, out var valueHolder))
            {
                return;
            }

            valueHolder = new ValueHolder<TValue>(defaultValue);
            _valueHoldersByEntityKey[entity.Key] = valueHolder;
        }

        public TValue GetEntityValue<TEntity, TValue>(TEntity entity) 
            where TEntity : EntityInfoBase<TValue>
        {
            if (_valueHoldersByEntityKey.TryGetValue(entity.Key, out var valueHolder))
            {
                return ((ValueHolder<TValue>)valueHolder).Value;
            }
                
            return default;
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