
using SurveyBasket.Persistence;

namespace SurveyBasket.Services
{
    public class PollServices(ApplicationDbContext context ) : IPollServices
    {
        private readonly ApplicationDbContext _context = context;
        //public static readonly List<Poll> _polls = [
        //    new Poll
        //    {
        //        Id = 1,
        //        Tittle = "Poll 1",
        //        Summary = "My first poll"
        //    }
        //];
        public  async Task<IEnumerable<Poll>> GetAllAsync() =>
            await _context.polls.AsNoTracking().ToListAsync();  //no need any change in this list when return me 


        public async Task<Poll?> GetAync(int id)=> 
            await _context.polls.FindAsync(id);

        public async Task<Poll> AddAync(Poll poll)
        {
            await _context.AddAsync(poll);
            await _context.SaveChangesAsync();
            return poll;
        }

        //public bool Update(int id, Poll poll)
        //{
        //    var CurrentPoll = Get(id);
        //    if (CurrentPoll is  null) 
        //        return false;

        //    CurrentPoll.Tittle = poll.Tittle;
        //    CurrentPoll.Summary = poll.Summary;

        //    return true;
        //}

        //public bool Delete(int id)
        //{
        //    var poll = Get(id);
        //    if (poll is null) 
        //        return false;

        //    _polls.Remove(poll);
        //    return true;


        //}
    }
}
