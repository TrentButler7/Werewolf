namespace WerewolfNS.Enums
{
    class ActionTypeAttribute(CharacterNightActionType actionType) : Attribute
    {
        public CharacterNightActionType ActionType { get; private set; } = actionType;
    }

    public enum CharacterNightActionType
    {
        EachNight,
        EachNightStar,
        YouStartKnowing
    }
}
