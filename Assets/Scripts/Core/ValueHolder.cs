namespace Core
{
    internal class ValueHolder<TValue> : ValueHolder
    {
        public TValue Value;

        public override string GetStringValue()
        {
            return Value.ToString();
        }
    }

    internal abstract class ValueHolder
    {
        public abstract string GetStringValue();
    }
}