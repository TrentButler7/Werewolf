namespace WerewolfNS.Enums
{
    class ActionTypeAttribute(CharacterNightActionType actionType) : Attribute
    {
        public CharacterNightActionType ActionType { get; private set; } = actionType;
    }

    class CharachterTypeAttribute(CharacterType characterType) : Attribute
    {
        public CharacterType CharachterType { get; private set; } = characterType;
    }

    public enum CharacterNightActionType
    {
        EachNight,
        EachNightStar,
        YouStartKnowing,
        WhenYouDie,
        SetupOnly,
        Passive,
        Daytime
    }
}
