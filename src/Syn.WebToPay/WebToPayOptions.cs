namespace Syn.WebToPay;

public class WebToPayOptions
{
    public string SignPassword { get; set; } = null!;
    public int ProjectId { get; set; }
    public bool TestMode { get; set; }
}