using System;
using System.Collections.Generic;

namespace Core
{
    public class PlayerData
    {
        public event Action<Type> ValueChanged;
        
        public static readonly PlayerData Instance = new();
        
        private readonly Dictionary<Type, ValueHolder> _valueHoldersByEntityKey = new();

        public TValue GetEntityValue<TEntity, TValue>(TValue defaultValue = default) 
            where TEntity : EntityInfoBase<TValue>
        {
            var entityType = typeof(TEntity);
            
            if (_valueHoldersByEntityKey.TryGetValue(entityType, out var valueHolder))
            {
                return ((ValueHolder<TValue>)valueHolder).Value;
            }

            valueHolder = new ValueHolder<TValue>(defaultValue);
            _valueHoldersByEntityKey[entityType] = valueHolder;
                
            return defaultValue;
        }
        
        public void SetEntityValue<TEntity, TValue>(TValue value) 
            where TEntity : EntityInfoBase<TValue>
        {
            var entityType = typeof(TEntity);

            if (_valueHoldersByEntityKey.TryGetValue(entityType, out var valueHolder))
            {
                ((ValueHolder<TValue>)valueHolder).Value = value;
            }
            else
            {
                valueHolder = new ValueHolder<TValue>(value);
                _valueHoldersByEntityKey[entityType] = valueHolder;
            }

            ValueChanged?.Invoke(entityType);
        }
    }
}