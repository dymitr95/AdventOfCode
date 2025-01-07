namespace Day21;

public class FunctionCache<T1, T2, T3, TResult>
{
    private readonly Dictionary<Tuple<T1, T2, T3>, TResult> _cache = new Dictionary<Tuple<T1, T2, T3>, TResult>();
    private readonly Func<T1, T2, T3, TResult> _computeFunction;

    public FunctionCache(Func<T1, T2, T3, TResult> computeFunction)
    {
        _computeFunction = computeFunction;
    }

    public TResult GetValue(T1 param1, T2 param2, T3 param3)
    {
        var key = Tuple.Create(param1, param2, param3);

        if (_cache.TryGetValue(key, out TResult result))
        {
            return result;
        }
        
        result = _computeFunction(param1, param2, param3);
        _cache[key] = result;
        return result;
    }
}