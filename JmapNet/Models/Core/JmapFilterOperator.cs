namespace JmapNet.Models.Core;

// TODO: implement filter operators
[PublicAPI]
public record JmapFilterOperator<T>
{
    public FilterOperator Operator { get; init; }
    public IList<JmapFilterOperator<T>> Conditions { get; init; } = new List<JmapFilterOperator<T>>();
    public T? Thing { get; init; }

    public JmapFilterOperator(FilterOperator @operator, IList<JmapFilterOperator<T>> conditions)
    {
        Operator = @operator;
        Conditions = conditions;
    }

    public JmapFilterOperator(T? thing)
    {
        Thing = thing;
        Operator = FilterOperator.None;
    }
}
