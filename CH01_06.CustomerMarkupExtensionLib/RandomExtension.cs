using System;
using System.Windows.Markup;

namespace CH01_06.CustomMarkupExtensionLib
{
    public class RandomExtension : MarkupExtension
    {
        readonly int _from, _to;
        static readonly Random _rnd = new Random();
        public RandomExtension(int from, int to)
        {
            _from = from; _to = to;
        }
        public RandomExtension(int to) : this(0, to)
        {
        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return (double)_rnd.Next(_from, _to);
        }
    }
}
