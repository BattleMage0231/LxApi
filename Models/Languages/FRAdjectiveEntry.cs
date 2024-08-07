namespace LxApi.Models.Languages;

public class FRAdjectiveForm : BaseForm {
    public FRGender? Gender { get; set; }

    public FRNumber? Number { get; set; }
}

public class FRAdjectiveEntry : FREntry {
    public List<FRAdjectiveForm> Forms { get; set; } = [];
}
