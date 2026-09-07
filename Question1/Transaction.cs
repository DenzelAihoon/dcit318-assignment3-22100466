namespace Question1;

public record Transaction(
    int Id,
    DateTime Date,
    decimal Amount,
    string Category
);
