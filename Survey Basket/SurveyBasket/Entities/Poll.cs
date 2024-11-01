namespace SurveyBasket.Entities;

public sealed class Poll
{
    public int Id { get; set; }
    public string Tittle { get; set; }=string.Empty;
    public string Summary { get; set; } = string.Empty;
    public bool IsPublised {  get; set; }
    public DateOnly StartsAt { get; set; }
    public DateOnly EndsAt { get;set; }

}
