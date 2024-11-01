namespace SurveyBasket.Contracts.Responses
{
    public record PollResponse (
        int Id,
        string Tittle ,
        string Summary,
        bool IsPublised,
        DateOnly StartsAt,
        DateOnly EndsAt
        );
    //{
    //    public int Id { get; set; }
    //    public string Tittle { get; set; } = string.Empty;
    //    public string Description { get; set; } = string.Empty;
    //}
}
