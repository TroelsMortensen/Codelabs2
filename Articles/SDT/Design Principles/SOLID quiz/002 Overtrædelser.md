# Identificering af Overtrædelser af SOLID-principper

![Laptop with sun](Resources/LaptopWithSun.jpg)

## Hvorfor er det vigtigt at spotte dårligt design?

Forestil dig, at du skal rette en fejl i et stort kodeprojekt, men du kan ikke finde ud af, hvor fejlen opstår, fordi koden er rodet og uoverskuelig. Måske har du prøvet at tilføje en ny funktion, men det ender med at ødelægge noget andet. Det er frustrerende og tidskrævende – og det kunne måske være undgået, hvis designfejl var blevet opdaget tidligere. At kunne identificere dårligt design i kode er en værdifuld kompetence, der sparer tid, minimerer fejl og gør dit arbejde sjovere.

Når du har gennemført denne lektion, vil du opnå følgende læringsmål:

1) Genkende typiske overtrædelser af SOLID-principper
2) Analysere kode for designfejl
3) Vurdere, hvordan dårligt design påvirker software

Overtrædelser af SOLID-principperne opstår ofte i praksis – selv for erfarne udviklere. Det kan skyldes tidspres, manglende kendskab til principperne eller fordi man arbejder videre på gammel kode, der ikke er designet med SOLID for øje. Mange har oplevet at arve kode, hvor det er svært at finde hoved og hale i, eller hvor små ændringer skaber uventede problemer. Når du forstår, hvorfor disse overtrædelser opstår, bliver det lettere at spotte dem – og undgå dem fremover.

![Yarn](Resources/Yarn.jpg)

## Billedet af en klasse med for mange ansvarsområder

En klasse, der både håndterer brugerinput, datalagring og visning på én gang, er et klassisk eksempel på en overtrædelse af SOLID-principperne. Dette kaldes ofte en "God Class" eller en klasse med for mange ansvarsområder.

Visuelt kan du ofte genkende det på meget lange klasser eller metoder, mange afhængigheder eller uklare navne. Hold øje med kode, der føles svær at overskue – det er ofte et tegn på, at et SOLID-princip er brudt.

## Eksempler på overtrædelser af SOLID-principper

Udvid hver sektion for at se et konkret kodeeksempel på en overtrædelse af hvert SOLID-princip. Hver forklaring viser, hvad der går galt, og hvorfor det bryder princippet.

<Quiz>
{
  "Type": "ExpandableDetails",
  "Details": [
    {
      "Header": "Single Responsibility Principle (SRP)",
      "Content": "<p><b>Kodeeksempel:</b> En <code>UserManager</code>-klasse, der både håndterer brugerdata, validering og e-mail-udsendelse.<br> <b>Problem:</b> Klassen har flere ansvarsområder, hvilket gør den svær at vedligeholde og teste.</p>"
    },
    {
      "Header": "Open/Closed Principle (OCP)",
      "Content": "<p><b>Kodeeksempel:</b> En <code>ReportGenerator</code>-klasse, hvor du skal ændre eksisterende kode for at tilføje nye rapporttyper.<br> <b>Problem:</b> Klassen er ikke åben for udvidelse uden at ændre i det eksisterende, hvilket bryder princippet.</p>"
    },
    {
      "Header": "Liskov Substitution Principle (LSP)",
      "Content": "<p><b>Kodeeksempel:</b> En <code>Rectangle</code>-klasse, der arves af en <code>Square</code>-klasse, hvor <code>Square</code> ændrer opførslen, så ikke alle rektangel-operationer virker korrekt.<br> <b>Problem:</b> Underklassen kan ikke uden videre erstatte basisklassen, hvilket bryder princippet.</p>"
    },
    {
      "Header": "Interface Segregation Principle (ISP)",
      "Content": "<p><b>Kodeeksempel:</b> Et stort <code>IMultifunctionDevice</code>-interface, som kræver, at alle implementeringer skal have print, scan og fax – også hvis de kun skal kunne én ting.<br> <b>Problem:</b> Klasser tvinges til at implementere metoder, de ikke har brug for.</p>"
    },
    {
      "Header": "Dependency Inversion Principle (DIP)",
      "Content": "<p><b>Kodeeksempel:</b> En <code>OrderProcessor</code>-klasse, der direkte opretter en <code>SqlDatabase</code>-instans.<br> <b>Problem:</b> Klassen er afhængig af en konkret implementering i stedet for et abstrakt interface.</p>"
    }
  ]
}
</Quiz>

<Quiz>
{
  "Type": "StepGuide",
  "Details": [
    {
      "Header": "Introduktion til analyse af SOLID-overtrædelser",
      "Content": "<p>Når du skal vurdere, om kode overholder SOLID-principperne, kan du følge en systematisk fremgangsmåde. Her er en enkel proces, du kan bruge:</p>"
    },{
      "Header": "Læs koden grundigt",
      "Content": "<p>Gennemgå koden og få et overblik over, hvad de enkelte klasser og metoder gør. Notér, hvis noget virker uklart eller rodet.</p>"
    },
    {
      "Header": "Se efter store klasser og metoder",
      "Content": "<p>Identificer klasser eller metoder, der fylder meget eller har mange forskellige funktioner. Det kan være tegn på, at ansvarsområderne ikke er klart adskilt.</p>"
    },
    {
      "Header": "Undersøg afhængigheder",
      "Content": "<p>Tjek om klasser er tæt koblet til konkrete implementeringer eller har mange afhængigheder. Overvej, om det ville være nemt at udskifte dele af koden.</p>"
    },
    {
      "Header": "Sammenlign med SOLID-principperne",
      "Content": "<p>Hold de konkrete principper op mod din analyse. Spørg dig selv: Bryder denne kode et eller flere SOLID-principper? Hvorfor – og hvordan kunne det forbedres?</p>"
    },
    {
      "Header": "Opsummering af analyseprocessen",
      "Content": "<p>Ved at følge disse trin kan du systematisk identificere designfejl og få øje på, hvor koden kan forbedres med SOLID-principperne.</p>"
    }
  ]
}
</Quiz>

<Quiz>
{
  "Type": "SingleChoiceQuiz",
  "Question": "<p>Hvilket udsagn beskriver bedst en overtrædelse af <b>Single Responsibility Principle</b>?</p>",
  "Options": [
    {
      "Text": "En klasse, der håndterer både brugerautentifikation og rapportgenerering",
      "IsCorrect": true
    },
    {
      "Text": "En klasse, der kun validerer brugerinput",
      "IsCorrect": false
    },
    {
      "Text": "En klasse, der implementerer et enkelt interface",
      "IsCorrect": false
    },
    {
      "Text": "En klasse, der er nem at teste",
      "IsCorrect": false
    }
  ],
  "Shuffle": true,
  "Hint": "Hvis en klasse har flere ansvarsområder, kan ændringer i én del påvirke den anden.",
  "Explanation": "En klasse, der både håndterer brugerautentifikation og rapportgenerering, har mere end ét ansvar og overtræder dermed Single Responsibility Principle. De andre eksempler har kun ét ansvar eller beskriver en god egenskab."
}

</Quiz>

![Kaos vs Samarbejde](Resources/KaosVsSamarbejde.jpg)

## Før og efter: At identificere designfejl

Når du lærer at identificere designfejl, kan du forvandle en uoverskuelig og fejlbehæftet kodebase til en mere struktureret og samarbejdsvillig løsning. Det gør det lettere at samarbejde, rette fejl og tilføje nye funktioner – og det giver større arbejdsglæde for hele teamet.

Nu har du lært at genkende typiske designfejl og overtrædelser af SOLID-principperne. I næste lektion dykker vi ned i, hvordan du kan omskrive kode, så den følger SOLID-principperne og bliver mere robust og fleksibel.