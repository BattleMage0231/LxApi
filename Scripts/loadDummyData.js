const entries = db.getCollection('Entries')

entries.deleteMany({})

entries.insertMany(
    [
        {
            "_t": ["BaseEntry", "FREntry", "FRNounEntry"],
            "Class": "Noun",
            "Key": "chat",
            "Definition": "Un petit mammifère carnivore domestique.",
            "Notes": "Animal de compagnie courant.",
            "Examples": ["Le chat dort sur le canapé.", "J'ai vu un chat noir."],
            "Synonyms": ["félin", "minou"],
            "MainGender": "Masculine",
            "MainNumber": "Singular",
            "Forms": [
                {
                    "Key": "chats",
                    "Notes": "Forme plurielle.",
                    "Gender": "Masculine",
                    "Number": "Plural"
                }
            ]
        },
        {
            "_t": ["BaseEntry", "FREntry", "FRVerbEntry"],
            "Class": "Verb",
            "Key": "manger",
            "Definition": "Manger quelque chose.",
            "Notes": "Verbe régulier en -er.",
            "Examples": ["Je mange une pomme.", "Ils mangent ensemble."],
            "Synonyms": ["déguster", "consommer"],
            "Transitivity": "Transitive",
            "Forms": [
                {
                    "Key": "Je mange",
                    "Notes": "Première personne du singulier au présent de l'indicatif.",
                    "Person": "FirstSingular",
                    "Type": "IndicativePresent"
                },
                {
                    "Key": "Nous mangeons",
                    "Notes": "Première personne du pluriel au présent de l'indicatif.",
                    "Person": "FirstPlural",
                    "Type": "IndicativePresent"
                }
            ]
        },
        {
            "_t": ["BaseEntry", "FREntry", "FRAdjectiveEntry"],
            "Class": "Adjective",
            "Key": "grand",
            "Definition": "De grande taille.",
            "Notes": "Adjectif irrégulier.",
            "Examples": ["Un grand homme.", "Des grands arbres."],
            "Synonyms": ["gros", "énorme"],
            "Forms": [
                {
                    "Key": "grande",
                    "Notes": "Féminin singulier.",
                    "Gender": "Feminine",
                    "Number": "Singular"
                },
                {
                    "Key": "grands",
                    "Notes": "Masculin pluriel.",
                    "Gender": "Masculine",
                    "Number": "Plural"
                },
                {
                    "Key": "grandes",
                    "Notes": "Féminin pluriel.",
                    "Gender": "Feminine",
                    "Number": "Plural"
                }
            ]
        },
        {
            "_t": ["BaseEntry", "FREntry", "FRAdverbEntry"],
            "Class": "Adverb",
            "Key": "rapidement",
            "Definition": "De manière rapide.",
            "Notes": "Dérivé de l'adjectif 'rapide'.",
            "Examples": ["Il court rapidement.", "Elle a fini rapidement."],
            "Synonyms": ["vite", "promptement"],
            "Forms": []
        },
        {
            "_t": ["BaseEntry", "FREntry", "FRPrepositionEntry"],
            "Class": "Preposition",
            "Key": "avec",
            "Definition": "En compagnie de.",
            "Notes": "Indique l'accompagnement.",
            "Examples": ["Je suis avec lui.", "Elle parle avec moi."],
            "Synonyms": ["en compagnie de", "accompagné de"],
            "Forms": []
        },
        {
            "_t": ["BaseEntry", "FREntry", "FRPronounEntry"],
            "Class": "Pronoun",
            "Key": "nous",
            "Definition": "Pronom de la première personne du pluriel.",
            "Notes": "Utilisé pour désigner un groupe comprenant la personne qui parle.",
            "Examples": ["Nous sommes prêts.", "Ils parlent de nous."],
            "Synonyms": ["on", "nous-mêmes"],
            "Forms": []
        },
        {
            "_t": ["BaseEntry", "FREntry", "FRArticleEntry"],
            "Class": "Article",
            "Key": "le",
            "Definition": "L'article défini masculin singulier.",
            "Notes": "Utilisé avant un nom masculin singulier.",
            "Examples": ["Le chat est noir.", "Je vois le livre."],
            "Synonyms": [],
            "Forms": []
        },
        {
            "_t": ["BaseEntry", "FREntry", "FRConjunctionEntry"],
            "Class": "Conjunction",
            "Key": "et",
            "Definition": "Et.",
            "Notes": "Utilisé pour connecter des mots, des phrases ou des clauses.",
            "Examples": ["Elle et lui.", "Je mange et je bois."],
            "Synonyms": ["ainsi que", "et aussi"],
            "Forms": []
        },
        {
            "_t": ["BaseEntry", "FREntry", "FRVerbEntry"],
            "Class": "Verb",
            "Key": "être",
            "Definition": "Exister ou se trouver.",
            "Notes": "Verbe irrégulier.",
            "Examples": ["Je suis heureux.", "Ils sont partis."],
            "Synonyms": ["exister", "se trouver"],
            "Transitivity": "Intransitive",
            "Forms": [
                {
                    "Key": "Je suis",
                    "Notes": "Première personne du singulier au présent de l'indicatif.",
                    "Person": "FirstSingular",
                    "Type": "IndicativePresent"
                },
                {
                    "Key": "Nous sommes",
                    "Notes": "Première personne du pluriel au présent de l'indicatif.",
                    "Person": "FirstPlural",
                    "Type": "IndicativePresent"
                }
            ]
        },
        {
            "_t": ["BaseEntry", "FREntry", "FRAdjectiveEntry"],
            "Class": "Adjective",
            "Key": "bleu",
            "Definition": "De couleur bleue.",
            "Notes": "Adjectif régulier.",
            "Examples": ["Un ciel bleu.", "Des yeux bleus."],
            "Synonyms": ["azur", "céruléen"],
            "Forms": [
                {
                    "Key": "bleue",
                    "Notes": "Féminin singulier.",
                    "Gender": "Feminine",
                    "Number": "Singular"
                },
                {
                    "Key": "bleus",
                    "Notes": "Masculin pluriel.",
                    "Gender": "Masculine",
                    "Number": "Plural"
                },
                {
                    "Key": "bleues",
                    "Notes": "Féminin pluriel.",
                    "Gender": "Feminine",
                    "Number": "Plural"
                }
            ]
        },
        {
            "_t": ["BaseEntry", "FREntry", "FRNounEntry"],
            "Class": "Noun",
            "Key": "chien",
            "Examples": ["Le chien aboie.", "Elle promène son chien."],
            "Synonyms": ["canidé", "toutou"],
            "MainGender": "Masculine",
            "MainNumber": "Singular",
            "Forms": [
                {
                    "Key": "chiens",
                    "Gender": "Masculine",
                    "Number": "Plural"
                }
            ]
        },
        {
            "_t": ["BaseEntry", "FREntry", "FRVerbEntry"],
            "Class": "Verb",
            "Key": "parler",
            "Definition": "Communiquer avec des mots.",
            "Examples": ["Je parle français.", "Ils parlent entre eux."],
            "Transitivity": "Intransitive",
            "Forms": [
                {
                    "Key": "Je parle",
                    "Person": "FirstSingular",
                    "Type": "IndicativePresent"
                },
                {
                    "Key": "Nous parlons",
                    "Person": "FirstPlural",
                    "Type": "IndicativePresent"
                }
            ]
        },
        {
            "_t": ["BaseEntry", "FREntry", "FRAdjectiveEntry"],
            "Class": "Adjective",
            "Key": "rouge",
            "Definition": "De couleur rouge.",
            "Examples": ["Une pomme rouge.", "Un mur rouge."],
            "Synonyms": ["cramoisi", "écarlate"],
            "Forms": [
                {
                    "Key": "rouge",
                    "Gender": "Masculine",
                    "Number": "Singular"
                },
                {
                    "Key": "rouges",
                    "Gender": "Masculine",
                    "Number": "Plural"
                }
            ]
        },
        {
            "_t": ["BaseEntry", "FREntry", "FRAdverbEntry"],
            "Class": "Adverb",
            "Key": "lentement",
            "Examples": ["Il marche lentement.", "Parle lentement s'il te plaît."],
            "Synonyms": ["doucement", "paisiblement"],
            "Forms": []
        },
        {
            "_t": ["BaseEntry", "FREntry", "FRPrepositionEntry"],
            "Class": "Preposition",
            "Key": "sans",
            "Definition": "Indique l'absence.",
            "Examples": ["Je pars sans toi.", "Il vit sans peur."],
            "Synonyms": ["dépourvu de", "privé de"],
            "Forms": []
        },
        {
            "_t": ["BaseEntry", "FREntry", "FRPronounEntry"],
            "Class": "Pronoun",
            "Key": "lui",
            "Examples": ["Je lui parle.", "Elle pense à lui."],
            "Synonyms": ["à lui", "le"],
            "Forms": []
        },
        {
            "_t": ["BaseEntry", "FREntry", "FRArticleEntry"],
            "Class": "Article",
            "Key": "un",
            "Definition": "Article indéfini masculin singulier.",
            "Examples": ["Un chat est sur le toit.", "J'ai un ami."],
            "Forms": []
        },
        {
            "_t": ["BaseEntry", "FREntry", "FRConjunctionEntry"],
            "Class": "Conjunction",
            "Key": "ou",
            "Examples": ["Tu veux du café ou du thé?", "Venez demain ou après-demain."],
            "Synonyms": ["ou bien", "sinon"],
            "Forms": []
        },
        {
            "_t": ["BaseEntry", "FREntry", "FRVerbEntry"],
            "Class": "Verb",
            "Key": "courir",
            "Definition": "Se déplacer rapidement.",
            "Transitivity": "Intransitive",
            "Examples": ["Je cours tous les matins.", "Ils courent dans le parc."],
            "Forms": [
                {
                    "Key": "Je cours",
                    "Person": "FirstSingular",
                    "Type": "IndicativePresent"
                },
                {
                    "Key": "Nous courons",
                    "Person": "FirstPlural",
                    "Type": "IndicativePresent"
                }
            ]
        },
        {
            "_t": ["BaseEntry", "FREntry", "FRNounEntry"],
            "Class": "Noun",
            "Key": "maison",
            "Notes": "Lieu de résidence.",
            "Examples": ["La maison est grande.", "Nous avons acheté une nouvelle maison."],
            "Synonyms": ["domicile", "habitation"],
            "MainGender": "Feminine",
            "MainNumber": "Singular",
            "Forms": [
                {
                    "Key": "maisons",
                    "Gender": "Feminine",
                    "Number": "Plural"
                }
            ]
        },
        {
            "_t": ["BaseEntry", "FREntry", "FRAdjectiveEntry"],
            "Class": "Adjective",
            "Key": "petit",
            "Examples": ["Un petit garçon.", "Une petite maison."],
            "Synonyms": ["minuscule", "réduit"],
            "Forms": [
                {
                    "Key": "petite",
                    "Gender": "Feminine",
                    "Number": "Singular"
                },
                {
                    "Key": "petits",
                    "Gender": "Masculine",
                    "Number": "Plural"
                },
                {
                    "Key": "petites",
                    "Gender": "Feminine",
                    "Number": "Plural"
                }
            ]
        },
        {
            "_t": ["BaseEntry", "FREntry", "FRAdverbEntry"],
            "Class": "Adverb",
            "Key": "vite",
            "Definition": "Rapidement.",
            "Examples": ["Parle vite.", "Elle a fini vite."],
            "Synonyms": ["rapidement", "promptement"],
            "Forms": []
        },
        {
            "_t": ["BaseEntry", "FREntry", "FRPrepositionEntry"],
            "Class": "Preposition",
            "Key": "sous",
            "Examples": ["Le chat est sous la table.", "Je me cache sous le lit."],
            "Synonyms": ["en dessous de", "au-dessous de"],
            "Forms": []
        },
        {
            "_t": ["BaseEntry", "FREntry", "FRPronounEntry"],
            "Class": "Pronoun",
            "Key": "elle",
            "Definition": "Pronom personnel féminin.",
            "Examples": ["Elle est belle.", "Je l'ai vue hier."],
            "Synonyms": ["à elle", "la"],
            "Forms": []
        },
        {
            "_t": ["BaseEntry", "FREntry", "FRArticleEntry"],
            "Class": "Article",
            "Key": "les",
            "Definition": "Article défini pluriel.",
            "Examples": ["Les enfants jouent.", "Je vois les fleurs."],
            "Forms": []
        },
        {
            "_t": ["BaseEntry", "FREntry", "FRConjunctionEntry"],
            "Class": "Conjunction",
            "Key": "mais",
            "Examples": ["Il veut venir, mais il ne peut pas.", "Je l'aime bien, mais..."],
            "Synonyms": ["cependant", "pourtant"],
            "Forms": []
        },
        {
            "_t": ["BaseEntry", "FREntry", "FRVerbEntry"],
            "Class": "Verb",
            "Key": "faire",
            "Examples": ["Je fais mes devoirs.", "Nous faisons une promenade."],
            "Synonyms": ["réaliser", "effectuer"],
            "Transitivity": "Transitive",
            "Forms": [
                {
                    "Key": "Je fais",
                    "Person": "FirstSingular",
                    "Type": "IndicativePresent"
                },
                {
                    "Key": "Nous faisons",
                    "Person": "FirstPlural",
                    "Type": "IndicativePresent"
                }
            ]
        },
        {
            "_t": ["BaseEntry", "FREntry", "FRNounEntry"],
            "Class": "Noun",
            "Key": "école",
            "Examples": ["L'école est fermée aujourd'hui.", "Je vais à l'école."],
            "Synonyms": ["établissement scolaire", "institution"],
            "MainGender": "Feminine",
            "MainNumber": "Singular",
            "Forms": [
                {
                    "Key": "écoles",
                    "Gender": "Feminine",
                    "Number": "Plural"
                }
            ]
        },
        {
            "_t": ["BaseEntry", "FREntry", "FRAdjectiveEntry"],
            "Class": "Adjective",
            "Key": "heureux",
            "Definition": "État de contentement ou de satisfaction.",
            "Examples": ["Il est très heureux.", "Une famille heureuse."],
            "Synonyms": ["content", "joyeux"],
            "Forms": [
                {
                    "Key": "heureuse",
                    "Gender": "Feminine",
                    "Number": "Singular"
                },
                {
                    "Key": "heureux",
                    "Gender": "Masculine",
                    "Number": "Plural"
                },
                {
                    "Key": "heureuses",
                    "Gender": "Feminine",
                    "Number": "Plural"
                }
            ]
        },
        {
            "_t": ["BaseEntry", "FREntry", "FRAdverbEntry"],
            "Class": "Adverb",
            "Key": "souvent",
            "Examples": ["Je viens souvent ici.", "Elle lit souvent."],
            "Synonyms": ["fréquemment", "régulièrement"],
            "Forms": []
        },
        {
            "_t": ["BaseEntry", "FREntry", "FRPrepositionEntry"],
            "Class": "Preposition",
            "Key": "chez",
            "Examples": ["Je vais chez le médecin.", "Elle est chez elle."],
            "Synonyms": ["au domicile de", "à la résidence de"],
            "Forms": []
        },
        {
            "_t": ["BaseEntry", "FREntry", "FRPronounEntry"],
            "Class": "Pronoun",
            "Key": "toi",
            "Examples": ["C'est pour toi.", "Je pense à toi."],
            "Synonyms": ["tu", "te"],
            "Forms": []
        },
        {
            "_t": ["BaseEntry", "FREntry", "FRArticleEntry"],
            "Class": "Article",
            "Key": "des",
            "Examples": ["Des amis sont venus.", "Je veux des pommes."],
            "Forms": []
        },
        {
            "_t": ["BaseEntry", "FREntry", "FRConjunctionEntry"],
            "Class": "Conjunction",
            "Key": "ni",
            "Examples": ["Je ne veux ni café ni thé.", "Il n'a ni argent ni temps."],
            "Synonyms": ["et pas", "non plus"],
            "Forms": []
        }
    ]
)

entries.find().forEach(printjson);
