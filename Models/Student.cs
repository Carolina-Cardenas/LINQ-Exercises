namespace LinqExercises.Models;
public class Student
{
    public int Id { get; set; }
        // ↑ PROPIEDAD llamada Id: guardará la identificación.
    // int: número entero, por ejemplo 1.
    // get: permite consultar el valor guardado.
    // set: permite asignar o reemplazar ese valor.


    public string Name { get; set; } = "";
        // ↑ PROPIEDAD llamada Name: guardará el nombre.
    // string: texto, por ejemplo "Anna".
    // = "": comienza con un texto vacío.

    public int Age { get; set; }
        // ↑ PROPIEDAD llamada Age: guardará la edad.


   public string ClassName { get; set; } = "";
        // ↑ PROPIEDAD llamada className: guardará el nombre de la clase.
    // string: texto, por ejemplo "1A".
    // = "": comienza con un texto vacío.

    public int Score { get; set; }
        // ↑ PROPIEDAD llamada Score: guardará la puntuación.

}
