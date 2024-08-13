namespace LxApi.Models.Languages;

using FRForm = BaseForm;

public class FRAdjectiveEntry : FREntry {
    public Dictionary<FRGender, Dictionary<FRNumber, FRForm>> MainForms { get; set; } = [];
}
