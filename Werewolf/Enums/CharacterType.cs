namespace WerewolfNS.Enums
{
    //The order of these, determines the order of operation
    public enum CharacterType
    {
        [ActionType(CharacterNightActionType.EachNightStar)]
        Monk,

        [ActionType(CharacterNightActionType.EachNightStar)]
        Werewolf,

        [ActionType(CharacterNightActionType.EachNight)]
        Empath,
    }
}
