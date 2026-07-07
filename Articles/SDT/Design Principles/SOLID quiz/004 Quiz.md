# Quiz

Test din forståelse af SOLID-principperne, herunder Single Responsibility, Open/Closed og de øvrige designprincipper, der gør kode mere vedligeholdelig og udvidelig. Find ud af, om du kan spotte typiske designfejl som klasser med flere ansvarsområder eller mange afhængigheder og vælge den rette refaktorisering.

## 1

Match hver bogstavforkortelse i SOLID med det korrekte principnavn. Opgaven tester, om du kan genkende og skelne de fem officielle principper i akronymet.

<Quiz>
{
  "Type": "MatchPair",
  "Title": "Match SOLID Letters to Their Principles",
  "Pairs": [
    {
      "Prompt": "S",
      "Answer": "Single Responsibility Principle"
    },
    {
      "Prompt": "O",
      "Answer": "Open/Closed Principle"
    },
    {
      "Prompt": "L",
      "Answer": "Liskov Substitution Principle"
    },
    {
      "Prompt": "I",
      "Answer": "Interface Segregation Principle"
    },
    {
      "Prompt": "D",
      "Answer": "Dependency Inversion Principle"
    }
  ]
}
</Quiz>

## 2

<Quiz>
{
  "Type": "SingleChoiceQuiz",
  "Question": "<p>Hvilken situation er det tydeligste eksempel på en overtrædelse af Single Responsibility Principle?</p>",
  "Options": [
    {
      "Text": "En klasse, der er nem at teste og har få afhængigheder",
      "IsCorrect": false
    },
    {
      "Text": "En klasse, der både håndterer brugerinput, gemmer data og sender e-mails",
      "IsCorrect": true
    },
    {
      "Text": "En klasse, der kun validerer brugerdata før oprettelse",
      "IsCorrect": false
    },
    {
      "Text": "En klasse, der implementerer ét interface til rapportvisning",
      "IsCorrect": false
    }
  ],
  "Shuffle": true,
  "Hint": "Overvej om klassen kun har ét ansvar eller blander flere opgaver sammen.",
  "Explanation": "En klasse, der både håndterer brugerinput, gemmer data og sender e-mails, har flere ansvarsområder og overtræder Single Responsibility Principle. De andre giver kun ét ansvar til klassen."
}
</Quiz>

## 3

<Quiz>
{
  "Type": "MultipleChoiceQuiz",
  "Question": "<p>Du gennemgår en klasse i et eksisterende kodeprojekt. Klassen afhænger direkte af mange andre konkrete klasser til for eksempel datalagring, validering, logning og visning. Hvad er den bedste vurdering af denne klasse som tegn på designfejl?</p>",
  "Options": [
    {
      "Text": "Det betyder først og fremmest, at klassen følger princippet om ét ansvar, fordi den samler flere funktioner.",
      "IsCorrect": false
    },
    {
      "Text": "Det viser primært, at klassen er fleksibel, fordi den samarbejder med mange dele af systemet.",
      "IsCorrect": false
    },
    {
      "Text": "Det tyder på tæt kobling og for mange ansvarer, som kan gøre klassen svær at vedligeholde og ændre.",
      "IsCorrect": true
    },
    {
      "Text": "Det er især et tegn på god testbarhed, fordi mange konkrete afhængigheder gør adfærden tydeligere.",
      "IsCorrect": false
    }
  ],
  "Shuffle": true,
  "Hint": "Overvej hvordan direkte afhængighed af mange konkrete klasser påvirker vedligeholdelse, ansvar og fleksibilitet.",
  "Explanation": "Når en klasse afhænger direkte af mange konkrete klasser, opstår der tæt kobling og typisk også for mange ansvarer. Dette bryder SOLID-principperne og gør koden vanskeligere at vedligeholde og ændre i fremtiden. Mange direkte afhængigheder til konkrete klasser er et tydeligt tegn på tæt kobling og ofte uklare eller for mange ansvarer."
}
</Quiz>


## 4

<Quiz>
{
  "Type": "SingleChoiceQuiz",
  "Question": "<p>Hvad beskriver bedst baggrunden for <b>SOLID</b> og dets formål i softwareudvikling?</p>",
  "Options": [
    {
      "Text": "SOLID er et akronym for fem designprincipper, der gør kode lettere at vedligeholde og udvide.",
      "IsCorrect": true
    },
    {
      "Text": "SOLID er en testmetode til at måle, hvor hurtigt kode kan afvikles i produktion.",
      "IsCorrect": false
    },
    {
      "Text": "SOLID er navnet på en programmeringssprogsstandard med regler for objektorienteret syntaks.",
      "IsCorrect": false
    },
    {
      "Text": "SOLID er en metode til at samle alle funktioner i få klasser for at gøre systemet mere overskueligt.",
      "IsCorrect": false
    }
  ],
  "Shuffle": true,
  "Hint": "Tænk på hvad SOLID-principperne hjælper med i forhold til kodekvalitet og design.",
  "Explanation": "SOLID er en samling af fem designprincipper, der hjælper udviklere med at skrive fleksibel, vedligeholdbar og udvidbar software. De tre forkerte svar beskriver ikke formålet med eller baggrunden for SOLID."
}
</Quiz>

## 5

<Quiz>
{
  "Type": "MultipleChoiceQuiz",
  "Question": "<p>Du refaktorerer en eksisterende klasse, som er blevet svær at forstå og vedligeholde. Hvilken ændring viser bedst, at du anvender <b>SOLID</b>-principper til at gøre koden mere overskuelig, fleksibel og nemmere at vedligeholde uden at ændre funktionaliteten?</p>",
  "Options": [
    {
      "Text": "At omskrive klassen hurtigere med færre test for at gøre koden enklere at arbejde videre med",
      "IsCorrect": false
    },
    {
      "Text": "At tilføje nye funktioner direkte i den eksisterende klasse, så hele løsningen forbliver samlet",
      "IsCorrect": false
    },
    {
      "Text": "At opdele klassen i mindre enheder med tydelige ansvarsområder og lade afhængigheder gå gennem abstraktioner",
      "IsCorrect": true
    },
    {
      "Text": "At samle validering, datalagring og rapportering i samme klasse for at holde logikken ét sted",
      "IsCorrect": false
    }
  ],
  "Shuffle": true,
  "Hint": "SOLID-principper hjælper ofte med at organisere kode omkring klare ansvarsområder og løse koblinger.",
  "Explanation": "Ved at opdele klassen i mindre enheder med tydelige ansvarsområder (Single Responsibility Principle) og bruge abstraktioner til afhængigheder (Dependency Inversion Principle), gør du koden mere overskuelig, fleksibel og nemmere at vedligeholde. De andre svar modsiger SOLID-principperne."
}
</Quiz>