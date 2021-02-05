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
        public static string GetPositionString(Lane lane, Role role) => (lane, role) switch
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

        public static string GetPositionString(string lane, string role)
        {
            if (Enum.TryParse(lane, true, out Lane laneParsed) 
                && Enum.TryParse(role, true, out Role roleParsed))
                return GetPositionString(laneParsed, roleParsed);
            return "None";
        }

        public static string GetRankedTypeString(RankedType rankedType) => rankedType switch
        {
            RankedType.RANKED_SOLO_5x5 => "Ranked Solo/Duo",
            RankedType.RANKED_FLEX_SR => "Ranked Flex",
            _ => "Ranked"
        };

        public static string GetRankedTypeString(string rankedType)
        {
            return Enum.TryParse(rankedType, true, out RankedType rankedTypeParsed) 
                ? GetRankedTypeString(rankedTypeParsed) : "Ranked";
        }

        public static string GetEmblemString(EmblemType emblemType) => emblemType switch
        {
            EmblemType.IRON => "Iron",
            EmblemType.BRONZE => "Bronze",
            EmblemType.SILVER => "Silver",
            EmblemType.GOLD => "Gold",
            EmblemType.PLATINUM => "Platinum",
            EmblemType.DIAMOND => "Diamond",
            EmblemType.MASTER => "Master",
            EmblemType.GRANDMASTER => "Grandmaster",
            EmblemType.CHALLENGER => "Challenger",
        };

        public static string GetEmblemString(string emblemType)
        {
            return Enum.TryParse(emblemType, true, out EmblemType emblemTypeParsed)
                ? GetEmblemPath(emblemTypeParsed) : "None";
        }

        public static string GetEmblemPath(EmblemType emblemType)
        {
            return "Emblem_"+ GetEmblemString(emblemType) + ".png";
        }

        public static string GetEmblemPath(string emblemType)
        {
            return Enum.TryParse(emblemType, true, out EmblemType emblemTypeParsed)
                ? GetEmblemPath(emblemTypeParsed) : "None";
        }

        public static string GetPositionPath(EmblemType emblemType, Lane lane, Role role)
        {
            var emblem = GetEmblemString(emblemType);
            var position = GetPositionString(lane, role);
            if (emblem == "None" || position == "None")
                return "None.png";
            return "Position_" + emblem + "-" + position + ".png";
        }

        public static string GetPositionPath(string emblemType, string lane, string role)
        {
            if (Enum.TryParse(lane, true, out Lane laneParsed)
                && Enum.TryParse(role, true, out Role roleParsed)
                && Enum.TryParse(emblemType, true, out EmblemType emblemTypeParsed))
                return GetPositionPath(emblemTypeParsed, laneParsed, roleParsed);
            var a = 0;
            return "None.png";
        }
    }
}
