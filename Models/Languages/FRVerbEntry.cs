namespace LxApi.Models.Languages;

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

public class FRVerbForm : BaseForm {
    public FRPerson? Person;

    public FRVerbConjugationType? Type;
}

public class FRVerbEntry : FREntry {
    public FRVerbTransitivity? Transitivity { get; set; }

    public List<FRVerbForm> Forms { get; set; } = [];
}
