using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using MinimalPokedex.Infrastructure;

namespace MinimalPokedex.Models
{
    public class SessionTeam : Team
    {
        public static Team GetTeam(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
            .HttpContext.Session;
            SessionTeam team = session?.GetJson<SessionTeam>("Team")
            ?? new SessionTeam();
            team.Session = session;
            return team;
        }

        [JsonIgnore]
        public ISession Session { get; set; }

        public override void AddPokemon(Pokemon pokemon, int type1id, int? type2id)
        {
            base.AddPokemon(pokemon, type1id, type2id);
            Session.SetJson("Team", this);
        }
        public override void RemovePokemon(Pokemon pokemon, int index)
        {
            base.RemovePokemon(pokemon, index);
            Session.SetJson("Team", this);
        }
        public override void Clear()
        {
            base.Clear();
            Session.Remove("Team");
        }

    }
}
