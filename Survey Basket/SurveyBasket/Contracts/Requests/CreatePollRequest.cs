
namespace SurveyBasket.Contracts.Requests
{
    public record CreatePollRequest (
        
        string Tittle ,
        string Summary,
        bool IsPublised,
        DateOnly StartsAt,
        DateOnly EndsAt

        );
    
}
