using System.ComponentModel.DataAnnotations;
namespace Infrastructure.Helpers;

public class CheckBoxRequired : ValidationAttribute
{
    public override bool IsValid(object? value) => value is bool b && b;
}


/* 

Denna klass är en anpassad valideringsattribut som utökar `ValidationAttribute`.

Syftet med `CheckBoxRequired` är att säkerställa att en kryssruta är ikryssad 
i användargränssnittet. Metoden `IsValid` kontrollerar om det angivna värdet 
är av typen bool och att det är sant (dvs. kryssrutan är ikryssad).

Denna klass kan användas i modeller där det krävs bekräftelse från användaren, 
till exempel godkännande av användarvillkor eller integritetspolicy, genom att 
dekorera den relevanta boolska egenskapen med `[CheckBoxRequired]`. 

 */
