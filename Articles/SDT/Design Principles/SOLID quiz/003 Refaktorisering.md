# Refaktorisering med SOLID i Praksis

![Spaghetti Code](Resources/SpaghettiAndCode.jpg)

## Refaktorisering: Vejen til bedre kode

Har du nogensinde siddet med kode, der føles som en labyrint? Måske er det svært at tilføje nye funktioner, eller du frygter at ændre noget, fordi det kan skabe fejl andre steder. Refaktorisering er nøglen til at vende frustrationen til tilfredshed. Med SOLID-principperne får du en struktureret tilgang, der gør det lettere at rydde op i koden og skabe et stærkt fundament for fremtiden.

Når du arbejder med denne lektion, får du konkrete værktøjer til at forbedre din kode gennem refaktorisering. Her er, hvad du kan forvente at lære:

1) Anvende SOLID-principper til refaktorisering
2) Følge trinvis metode til kodeforbedring
3) Integrere SOLID i daglig udviklingspraksis

Refaktorisering betyder at omskrive eksisterende kode, så den bliver mere overskuelig, fleksibel og nemmere at vedligeholde – uden at ændre funktionaliteten. Det bliver ofte nødvendigt, når kodebasen vokser, kravene ændrer sig, eller teknisk gæld hober sig op. SOLID-principperne fungerer som et kompas, der guider dig til at tage de rigtige valg undervejs i refaktoreringsprocessen.

![Two abstract monitors](Resources/TwoAbstractMonitors.jpg)

## Fra rodet til robust kode

Forestil dig en klasse, der håndterer alt fra brugerinput til databaseopdatering og rapportgenerering. Før refaktorisering er koden uoverskuelig og svær at teste. Efter refaktorisering – med SOLID-principperne som guide – er ansvarsområderne delt op, og koden er blevet mere enkel, læsbar og nem at udvide. Det gør både udvikling og vedligeholdelse langt lettere.

<Quiz>
{
  "Type": "StepGuide",
  "Details": [
    {
      "Header": "Introduktion til refaktorering med SOLID",
      "Content": "<p>At refaktorere med SOLID-principperne handler om at forbedre din kodebases struktur og vedligeholdelse. Her får du en trinvis guide til, hvordan du kan anvende SOLID i praksis.</p>"
    },
    {
      "Header": "Forstå kodebasen",
      "Content": "<p>Læs koden grundigt igennem og identificér områder, der er svære at forstå, vedligeholde eller udvide.</p>"
    },
    {
      "Header": "Identificér problemområder",
      "Content": "<p>Se efter store klasser, lange metoder, eller steder hvor mange ting er blandet sammen. Notér hvor SOLID-principperne ikke følges.</p>"
    },
    {
      "Header": "Vælg relevante SOLID-principper",
      "Content": "<p>Udpeg hvilke principper der kan hjælpe med at løse de konkrete problemer, fx SRP for at dele ansvar eller DIP for at mindske afhængigheder.</p>"
    },
    {
      "Header": "Omskriv og test",
      "Content": "<p>Refaktorer koden trin for trin. Test løbende for at sikre, at funktionaliteten ikke ændres undervejs.</p>"
    },
    {
      "Header": "Dokumentér og reflekter",
      "Content": "<p>Beskriv de ændringer, du har lavet, og overvej hvordan SOLID-principperne har forbedret koden. Brug erfaringerne i fremtidige projekter.</p>"
    },
    {
      "Header": "Opsummering af refaktorering med SOLID",
      "Content": "<p>Ved at følge disse trin kan du systematisk forbedre din kode ved hjælp af SOLID-principperne. Det gør koden mere robust, fleksibel og lettere at vedligeholde.</p>"
    }
  ]
}
</Quiz>

<Quiz>
{
  "Type": "ExpandableDetails",
  "Details": [
    {
      "Header": "SRP: Del ansvar op",
      "Content": "En stor klasse <i>UserManager</i> håndterer både brugerdata, validering og rapportering. Del klassen op i mindre klasser, så hver kun har ét ansvar. Det gør koden mere overskuelig og nemmere at teste."
    },
    {
      "Header": "OCP: Gør koden udvidbar",
      "Content": "En metode <i>CalculateSalary</i> ændres ofte, når nye løntyper tilføjes. Brug arv eller interfaces, så nye løntyper kan tilføjes uden at ændre eksisterende kode. Det mindsker risikoen for fejl."
    },
    {
      "Header": "LSP: Udskift uden problemer",
      "Content": "En underklasse <i>TemporaryEmployee</i> bryder forventningerne fra <i>Employee</i> og skaber fejl. Refaktorer så alle underklasser kan bruges på samme måde som basisklassen, uden at bryde funktionaliteten."
    },
    {
      "Header": "ISP: Små, fokuserede interfaces",
      "Content": "Et interface <i>IWorker</i> kræver, at alle implementerer både <i>Work</i> og <i>Eat</i>. Del det op i mindre interfaces, så klasser kun skal implementere det, de faktisk bruger. Det gør koden mere fleksibel."
    },
    {
      "Header": "DIP: Afhængigheder via abstraktion",
      "Content": "En klasse <i>OrderProcessor</i> opretter selv sine afhængigheder. Refaktorer så afhængigheder leveres udefra via interfaces. Det gør koden lettere at teste og udskifte komponenter i."
    }
  ]
}
</Quiz>

<Quiz>
{
  "Type": "SingleChoiceQuiz",
  "Question": "<p>Hvilket trin er mest afgørende for at sikre, at refaktorisering følger SOLID-principperne?</p>",
  "Options": [
    {
      "Text": "At identificere ansvar og afhængigheder i koden",
      "IsCorrect": true
    },
    {
      "Text": "At tilføje flere funktioner uden test",
      "IsCorrect": false
    },
    {
      "Text": "At ignorere eksisterende tests",
      "IsCorrect": false
    },
    {
      "Text": "At skrive så lidt kode som muligt",
      "IsCorrect": false
    }
  ],
  "Shuffle": true,
  "Hint": "Refaktorisering starter med at forstå struktur og ansvar i koden.",
  "Explanation": "Det vigtigste første trin i en SOLID-orienteret refaktorisering er at identificere ansvar og afhængigheder, så du kan omlægge kode på en måde, der understøtter principperne. De andre valg bidrager ikke til robust refaktorisering."
}
</Quiz>

![Three monitors](Resources/ThreeMonitors.jpg)

## Arbejdsglæde med god kode

En udvikler, der arbejder med velstruktureret og SOLID-baseret kode, oplever færre fejl, hurtigere udvikling og større arbejdsglæde. Når refaktorisering bliver en naturlig del af hverdagen, bliver det både sjovere og mere effektivt at udvikle software.

Continued
Nu har du lært, hvordan du kan bruge SOLID-principperne til at refaktorisere kode og skabe bedre software. Ved at arbejde systematisk med ansvar, afhængigheder og struktur styrker du både kodekvaliteten og din egen arbejdsglæde. Tag principperne med dig i dine fremtidige projekter – og oplev, hvordan de kan gøre en forskel hver dag. Tak for din indsats og held og lykke med din videre læring!