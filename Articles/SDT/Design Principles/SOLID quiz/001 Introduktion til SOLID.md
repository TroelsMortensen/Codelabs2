# Introduktion til SOLID og dets Betydning

![Laptop](Resources/Laptop.jpg)

## Hvorfor er godt softwaredesign vigtigt?

Forestil dig, at du skal rette en fejl i et stort kodeprojekt, hvor alt er viklet ind i hinanden. Hver gang du ændrer én ting, går noget andet i stykker. Det føles som at trække i én tråd og se hele sweateren gå op. Mange udviklere har oplevet frustrationen ved at vedligeholde eller udvide kode, der mangler struktur. Heldigvis findes der principper, der kan hjælpe dig med at undgå dette kaos og gøre dit arbejde både lettere og sjovere.

I denne lektion får du et overblik over, hvad SOLID er, og hvorfor principperne er vigtige for dig som udvikler. Du vil lære, hvordan de kan gøre din kode mere robust og nemmere at arbejde med.

1) Forstå baggrunden for SOLID
2) Kende de fem principper
3) Forstå hvorfor SOLID-principperne er vigtige
4) Kunne nævne fordelene ved at bruge SOLID

![Overskuelighed](Resources/OverskuelighedKontraKaos.jpg)

## Overskuelighed kontra kaos

Dårligt softwaredesign fører ofte til "spaghetti code" – kode, der er svær at forstå og endnu sværere at ændre. Det kan gøre selv små opgaver tidskrævende og frustrerende. Heldigvis findes der gennemprøvede principper, som kan hjælpe dig med at skabe struktur og overblik i din kodebase.

SOLID er et akronym, der blev introduceret af Robert C. Martin i begyndelsen af 2000’erne. Principperne blev hurtigt populære i softwareudviklingsmiljøet, fordi de hjælper udviklere med at skrive kode, der er nemmere at vedligeholde og udvide. SOLID bygger på erfaringer fra mange års softwareudvikling og er i dag anerkendt som en grundsten i professionelt softwaredesign.

## SOLID-principper: Flashcards

Brug disse flashcards til at lære og huske de fem SOLID-principper. Hvert kort indeholder navnet på princippet, en kort forklaring og et ultrakort eksempel.

<Quiz>
{
  "Type": "FlashCardSet",
  "Title": "De fem SOLID-principper",
  "Cards": [
    {
      "Front": "Single Responsibility Principle",
      "Back": "En klasse skal kun have én grund til at ændre sig.<br><i>Eksempel:</i> En klasse håndterer kun brugerdata, ikke filhåndtering."
    },
    {
      "Front": "Open/Closed Principle",
      "Back": "Softwareenheder skal være åbne for udvidelse, men lukkede for ændring.<br><i>Eksempel:</i> Tilføj nye funktioner via arv, uden at ændre eksisterende kode."
    },
    {
      "Front": "Liskov Substitution Principle",
      "Back": "Objekter af en underklasse skal kunne bruges i stedet for deres superklasse.<br><i>Eksempel:</i> En firkant kan erstatte en rektangel, uden fejl."
    },
    {
      "Front": "<b>I</b>: Interface Segregation Principle",
      "Back": "Klasser skal ikke tvinges til at implementere interfaces, de ikke bruger.<br><i>Eksempel:</i> Del store interfaces op i mindre, specifikke."
    },
    {
      "Front": "<b>D</b>: Dependency Inversion Principle",
      "Back": "Høj-niveau moduler skal ikke afhænge af lav-niveau moduler, men af abstraktioner.<br><i>Eksempel:</i> Brug interfaces fremfor konkrete klasser."
    }
  ]
}
</Quiz>

## Hvorfor er SOLID vigtigt?

Udforsk de vigtigste grunde til, at SOLID-principperne gør en forskel i din hverdag som udvikler. Klik på hver sektion for at læse mere om fordelene og se konkrete eksempler.

<Quiz>
{
  "Type": "ExpandableDetails",
  "Details": [
    {
      "Header": "Lettere vedligeholdelse",
      "Content": "Når kode følger SOLID-principperne, bliver det lettere at finde og rette fejl. Du kan hurtigt forstå, hvad hver del af koden gør, og ændringer påvirker sjældent andre dele af systemet.<br><i>Eksempel:</i> Hvis en klasse kun har ét ansvar, kan du rette fejl i den uden at bekymre dig om utilsigtede bivirkninger andre steder."
    },
    {
      "Header": "Større fleksibilitet",
      "Content": "SOLID gør det nemmere at tilføje nye funktioner eller ændre eksisterende adfærd uden at skulle omskrive store dele af koden.<br><i>Eksempel:</i> Ved at bruge interfaces kan du udskifte eller udvide funktionalitet uden at ændre på resten af systemet."
    },
    {
      "Header": "Mindre risiko for fejl",
      "Content": "God struktur minimerer risikoen for, at ændringer skaber nye fejl. Hver del af koden har klare grænser og ansvar.<br><i>Eksempel:</i> Når du udvider funktionalitet via arv eller interfaces, undgår du at bryde eksisterende kode."
    },
    {
      "Header": "Bedre samarbejde i teams",
      "Content": "Med SOLID bliver det lettere for flere udviklere at arbejde sammen. Koden er opdelt i overskuelige enheder, så alle kan fokusere på deres del.<br><i>Eksempel:</i> En udvikler kan arbejde på brugergrænsefladen, mens en anden arbejder på datalagring – uden at træde hinanden over tæerne."
    },
    {
      "Header": "Skalerbarhed",
      "Content": "SOLID-principperne gør det muligt at bygge systemer, der kan vokse over tid. Nye krav kan implementeres uden at kompromittere eksisterende funktionalitet.<br><i>Eksempel:</i> Når nye moduler skal tilføjes, kan de integreres uden at ændre på det, der allerede virker."
    }
  ]
}
</Quiz>

![Samarbejde](Resources/Samarbejde.jpg)

## SOLID i praksis: Forskellen det gør

Når et team arbejder med SOLID-principperne, bliver hverdagen lettere: færre fejl, hurtigere udvikling og mere tilfredse udviklere. Projekter, der ikke bruger SOLID, ender ofte med rod, frustration og spildt tid. SOLID giver dig og dit team et fælles sprog og en klar retning for, hvordan god kode skal se ud.

<Quiz>
{
  "Type": "SingleChoiceQuiz",
  "Question": "<p>Hvilket af følgende er <b>IKKE</b> et SOLID-princip?</p>",
  "Options": [
    {
      "Text": "Single Responsibility Principle",
      "IsCorrect": false
    },
    {
      "Text": "Separation of Concerns",
      "IsCorrect": true
    },
    {
      "Text": "Interface Segregation Principle",
      "IsCorrect": false
    },
    {
      "Text": "Dependency Inversion Principle",
      "IsCorrect": false
    }
  ],
  "Shuffle": true,
  "Hint": "Kun ét af svarene optræder ikke som bogstav i SOLID-akronymet.",
  "Explanation": "Separation of Concerns er et vigtigt designprincip, men indgår ikke i SOLID-akronymet. De fire andre er alle en del af SOLID: Single Responsibility, Interface Segregation og Dependency Inversion Principle."
}
</Quiz>

SOLID-principperne giver dig et stærkt fundament for at skrive struktureret og fleksibel kode, der kan vokse med dine behov. Når du bruger SOLID, bliver det nemmere at vedligeholde og udvide dine projekter.

I næste lektion lærer du, hvordan du kan genkende overtrædelser af SOLID-principperne i kode – og hvorfor det er vigtigt at spotte dem tidligt.