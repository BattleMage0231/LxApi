namespace LxApi.Models.Languages;

using FRForm = BaseForm;

public enum FRPerson {
    FirstSingular, SecondSingular, ThirdSingular, FirstPlural, SecondPlural, ThirdPlural
}

public enum FRVerbConjugationType {
    IndicativePresent, Imperfect,
    CompoundPast, SimplePast, PerfectPast, 
    SimpleFuture, PerfectFuture,
    SubjunctivePresent, SubjunctivePast,
    ConditionalPresent, ConditionalPast,
    ImperativePresent,
    Infinitive, PresentParticiple, PastParticiple
}

public enum FRVerbTransitivity {
    Transitive, Intransitive
}

public class FRVerbEntry : FREntry {
    public FRVerbTransitivity? Transitivity { get; set; }

    public Dictionary<FRVerbConjugationType, Dictionary<FRPerson, FRForm>> MainForms { get; set; } = [];
}
