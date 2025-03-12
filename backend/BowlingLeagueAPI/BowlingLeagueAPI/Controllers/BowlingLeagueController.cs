using BowlingLeagueAPI.Data;
using BowlingLeagueAPI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BowlingLeagueAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class BowlingLeagueController : ControllerBase
{
    private BowlingLeagueContext _context;

    public BowlingLeagueController(BowlingLeagueContext temp)
    {
        _context = temp;
    }

    [HttpGet(Name = "BowlingLeague")]
    public List<BowlerViewModel> Get()
    {
       var bowlersList = _context.Bowlers.Include(b => b.Team)
           .Select(b => new BowlerViewModel
           {
               BowlerId = b.BowlerId,
               BowlerFirstName = b.BowlerFirstName,
               BowlerMiddleInit = b.BowlerMiddleInit,
               BowlerLastName = b.BowlerLastName,
               BowlerAddress = b.BowlerAddress,
               BowlerCity = b.BowlerCity,
               BowlerState = b.BowlerState,
               BowlerZip = b.BowlerZip,
               BowlerPhoneNumber = b.BowlerPhoneNumber,
               TeamName = b.Team.TeamName
           })
           .ToList();;
       return bowlersList;
    }
}