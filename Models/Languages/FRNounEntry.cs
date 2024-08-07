namespace LxApi.Models.Languages;

public enum FRNounFormType {
    MasculineSingular, MasculinePlural, FeminineSingular, FemininePlural
}

public class FRNounForm : BaseForm {
    public FRGender? Gender { get; set; }

    public FRNumber? Number { get; set; }
}

public class FRNounEntry : FREntry {
    public FRGender? MainGender { get; set; }

    public FRNumber? MainNumber { get; set; }

    public List<FRNounForm> Forms { get; set; } = [];
}
