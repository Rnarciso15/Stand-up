namespace StandUp.Application.Vehicles;

public sealed record VehicleSearchFilter(
    string? Brand,
    string? Model,
    string? Fuel,
    int? KmMin,
    int? KmMax,
    int? PriceMin,
    int? PriceMax,
    string? Color,
    bool? IsMotorcycle,
    bool IsSold,
    int Page = 1,
    int PageSize = 25,
    string? SortBy = "price",
    bool Desc = false);
