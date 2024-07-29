namespace JWT.Contracts;

public record GetUsersRequest(string? Search, string? SortItem, string? SortOrder);