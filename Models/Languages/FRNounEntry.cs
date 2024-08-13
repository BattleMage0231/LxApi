namespace LxApi.Models.Languages;

using FRForm = BaseForm;

public class FRNounEntry : FREntry {
    public FRGender? MainGender { get; set; }

    public FRNumber? MainNumber { get; set; }

    public Dictionary<FRGender, Dictionary<FRNumber, FRForm>> MainForms { get; set; } = [];
}
