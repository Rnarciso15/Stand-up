namespace StandUp.Presentation.Web.Services;

public sealed class CompareService
{
    private readonly List<string> _plates = [];

    public event Action? Changed;
    public IReadOnlyList<string> Plates => _plates;
    public int Count => _plates.Count;

    public bool Has(string plate) => _plates.Contains(plate);

    public void Toggle(string plate)
    {
        if (_plates.Contains(plate))
            _plates.Remove(plate);
        else if (_plates.Count < 3)
            _plates.Add(plate);
        Changed?.Invoke();
    }

    public void Remove(string plate) { _plates.Remove(plate); Changed?.Invoke(); }
    public void Clear()              { _plates.Clear();        Changed?.Invoke(); }
}
