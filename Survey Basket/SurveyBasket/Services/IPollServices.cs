namespace SurveyBasket.Services
{
    public interface IPollServices
    {
        Task<IEnumerable<Poll>>GetAllAsync();
        Task<Poll?> GetAync(int id);
        Task<Poll> AddAync(Poll poll);

        //bool Update(int id , Poll poll);

        //bool Delete(int id);
    }
}
