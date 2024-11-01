


namespace SurveyBasket.Controllers
{
    [Route("api/[controller]")]  
    [ApiController]
    public class PollsController(IPollServices pollServices) : ControllerBase
    {
        private readonly IPollServices _pollServices = pollServices;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var polls = await _pollServices.GetAllAsync();
            var response = polls.Adapt<IEnumerable<PollResponse>>();
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {

            var poll =await  _pollServices.GetAync(id);
            if (poll is null)
                return NotFound();

            var response = poll.Adapt<PollResponse>();
            return Ok(response);
        }
        [HttpPost("")]
        public async Task<IActionResult> Add([FromBody] CreatePollRequest Request)
        {
            var newpoll =await _pollServices.AddAync(Request.Adapt<Poll>());
            return CreatedAtAction(nameof(Get), new { id = newpoll.Id }, newpoll);
        }
        //[HttpPut("{id}")]
        //public IActionResult Update([FromRoute]int id ,[FromBody] CreatePollRequest Request)
        //{
        //    var IsUpdated = _pollServices.Update(id, Request.Adapt<Poll>());
        //    if(! IsUpdated)
        //        return NotFound();
        //    return NoContent();
        //}
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    var IsDeleted = _pollServices.Delete(id);
        //    if(! IsDeleted)     // id is not exist
        //        return NotFound();

        //    return NoContent();     //id is exist
        //}

    }
}
