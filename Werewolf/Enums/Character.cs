namespace WerewolfNS.Enums
{
    //The order of these, determines the order of process operation
    public enum Character
    {
        [ActionType(CharacterNightActionType.EachNightStar)]
        [CharachterType(CharacterType.Townsfolk)]
        Monk,

        [ActionType(CharacterNightActionType.EachNightStar)]
        [CharachterType(CharacterType.Demon)]
        Imp,

        [ActionType(CharacterNightActionType.EachNight)]
        [CharachterType(CharacterType.Townsfolk)]
        Empath,

        [ActionType(CharacterNightActionType.YouStartKnowing)]
        [CharachterType(CharacterType.Townsfolk)]
        Washerwoman,

        [ActionType(CharacterNightActionType.YouStartKnowing)]
        [CharachterType(CharacterType.Townsfolk)]
        Librarian,

        [ActionType(CharacterNightActionType.YouStartKnowing)]
        [CharachterType(CharacterType.Townsfolk)]
        Chef,

        [ActionType(CharacterNightActionType.YouStartKnowing)]
        [CharachterType(CharacterType.Townsfolk)]
        Investigator,

        [ActionType(CharacterNightActionType.WhenYouDie)]
        [CharachterType(CharacterType.Townsfolk)]
        Ravenkeeper,

        [ActionType(CharacterNightActionType.EachNightStar)]
        [CharachterType(CharacterType.Townsfolk)]
        Undertaker,

        [ActionType(CharacterNightActionType.EachNightStar)]
        [CharachterType(CharacterType.Townsfolk)]
        Soldier,

        [ActionType(CharacterNightActionType.Passive)]
        [CharachterType(CharacterType.Townsfolk)]
        Mayor,

        [ActionType(CharacterNightActionType.Daytime)]
        [CharachterType(CharacterType.Townsfolk)]
        Slayer,

        [ActionType(CharacterNightActionType.Passive)]
        [CharachterType(CharacterType.Townsfolk)]
        Virgin,

        [ActionType(CharacterNightActionType.EachNight)]
        [CharachterType(CharacterType.Townsfolk)]
        FortuneTeller,

        [ActionType(CharacterNightActionType.Passive)]
        [CharachterType(CharacterType.Outsider)]
        Butler,

        [ActionType(CharacterNightActionType.Passive)]
        [CharachterType(CharacterType.Outsider)]
        Saint,

        [ActionType(CharacterNightActionType.Passive)]
        [CharachterType(CharacterType.Outsider)]
        Reculse,

        [ActionType(CharacterNightActionType.Passive)]
        [CharachterType(CharacterType.Outsider)]
        Drunk,

        [ActionType(CharacterNightActionType.SetupOnly)]
        [CharachterType(CharacterType.Minion)]
        Baron,

        [ActionType(CharacterNightActionType.EachNight)]
        [CharachterType(CharacterType.Minion)]
        Spy,

        [ActionType(CharacterNightActionType.EachNight)]
        [CharachterType(CharacterType.Minion)]
        Poisoner,

        [ActionType(CharacterNightActionType.Passive)]
        [CharachterType(CharacterType.Minion)]
        ScarletWomen

    }
}
