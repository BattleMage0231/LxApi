namespace LxApi.Models.Languages;

public class FRAdverbForm : BaseForm {}

public class FRAdverbEntry : FREntry {
    public List<FRAdverbForm> Forms { get; set; } = [];
}

public class FRArticleForm : BaseForm {}

public class FRArticleEntry : FREntry {
    public List<FRArticleForm> Forms { get; set; } = [];
}

public class FRConjunctionForm : BaseForm {}

public class FRConjunctionEntry : FREntry {
    public List<FRConjunctionForm> Forms { get; set; } = [];
}

public class FRPrepositionForm : BaseForm {}

public class FRPrepositionEntry : FREntry {
    public List<FRPrepositionForm> Forms { get; set; } = [];
}

public class FRPronounForm : BaseForm {}

public class FRPronounEntry : FREntry {
    public List<FRPronounForm> Forms { get; set; } = [];
}

public class FROtherForm : BaseForm {}

public class FROtherEntry : FREntry {
    public List<FROtherForm> Forms { get; set; } = [];
}
