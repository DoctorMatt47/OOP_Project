using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NextWave.Domain.Enums;

namespace NextWave.Domain
{
    public static class Mapping
    {
        public static string GetPosition(Lane lane, Role role) => (lane, role) switch
        {
            (Lane.MID, Role.SOLO) => "Middle",
            (Lane.MID, Role.DUO) => "Middle",
            (Lane.TOP, Role.SOLO) => "Top",
            (Lane.TOP, Role.DUO) => "Top",
            (Lane.JUNGLE, Role.NONE) => "Jungle",
            (Lane.BOTTOM, Role.DUO_CARRY) => "Bottom",
            (Lane.BOTTOM, Role.DUO_SUPPORT) => "Support",
            _ => "None"
        };

        public static string GetPosition(string lane, string role)
        {
            if (Enum.TryParse(lane, true, out Lane laneParsed) 
                && Enum.TryParse(role, true, out Role roleParsed))
                return GetPosition(laneParsed, roleParsed);
            return "None";
        }

        public static string GetRankedType(RankedType rankedType) => rankedType switch
        {
            RankedType.RANKED_SOLO_5x5 => "Ranked Solo/Duo",
            RankedType.RANKED_TEAM_5x5 => "Ranked Flex",
            _ => "None"
        };

        public static string GetRankedType(string rankedType)
        {
            return Enum.TryParse(rankedType, true, out RankedType rankedTypeParsed) 
                ? GetRankedType(rankedTypeParsed) : "None";
        }
    }
}
