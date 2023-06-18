namespace BasicMvvm
{
    public interface IDataModel
    {
        string Data { get; set; }
        string? Reverse();
    }
}
