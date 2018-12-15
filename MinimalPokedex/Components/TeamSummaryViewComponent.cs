using Microsoft.AspNetCore.Mvc;
using MinimalPokedex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinimalPokedex.Components
{
    public class TeamSummaryViewComponent : ViewComponent
    {
        private Team team;

        public TeamSummaryViewComponent(Team teamService)
        {
            team = teamService;
        }
        public IViewComponentResult Invoke()
        {
            return View(team);
        }
    }
}
