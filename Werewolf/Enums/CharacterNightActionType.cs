namespace WerewolfNS.Enums
{
    [AttributeUsage(AttributeTargets.Field)]
    class ActionTypeAttribute(CharacterNightActionType actionType) : Attribute
    {
        public CharacterNightActionType ActionType { get; private set; } = actionType;
    }

    [AttributeUsage(AttributeTargets.Field)]
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
