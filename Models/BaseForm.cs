namespace LxApi.Models;

public abstract class BaseForm {
    public string Key { get; set; } = null!;

    public string? Notes { get; set; }
}
