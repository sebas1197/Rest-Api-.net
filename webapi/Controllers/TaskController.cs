using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

[ApiController]
[Route("api/tasks")]

public class EventsController : ControllerBase
{
    public readonly TaskService _taskService;

    public EventsController(TaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpGet]
    //[HttpGet("list")]
    public ActionResult<List<Tasks>> GetAll()
    {
        return Ok(_taskService.GetAll());
    }

    [HttpGet("poke")]
    public async Task<IActionResult> getPokemons()
    {
        HttpClient _httpClient = new HttpClient();
        var pokemons = await _httpClient.GetFromJsonAsync<Object>($"https://pokeapi.co/api/v2/pokemon/");
        List<string> names = new List<string>();
        JObject data = JObject.Parse(pokemons.ToString());
        JArray results = (JArray)data["results"];
        foreach (JToken result in results)
        {
            names.Add(result["name"].ToString());
        }


        return Ok(names);
    }

    [HttpPost]
    public ActionResult Create(ModelTask task)
    {
        _taskService.Create(task);
        return Ok();
    }

    [HttpPut("{id}")]
    public ActionResult Update(int id, ModelTask task)
    {
        _taskService.Update(id, task);
        return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id, ModelTask task)
    {
        _taskService.Delete(id, task);
        return Ok();
    }

}

