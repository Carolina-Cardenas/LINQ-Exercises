using System;
using System.Collections.Generic;
using System.Linq;
using LinqExercises.Models;
// ↑ Permite utilizar la clase Student que escribimos en Models/Student.cs.


namespace LinqExercises;

internal class Program
//       ↑ CLASE llamada Program: contiene el inicio del programa.
{
  private static void Main()
    {
        List<Student> students = new List<Student>
        // ↑ LISTA: reúne objetos Student.
        // students es la variable con la que accedemos a esa lista.
        {
            new Student { Id = 1, Name = "Anna", Age = 19, ClassName = "A", Score = 85 },
            new Student { Id = 2, Name = "Bertil", Age = 22, ClassName = "B", Score = 72 },
            new Student { Id = 3, Name = "Cecilia", Age = 20, ClassName = "A", Score = 91 },
            new Student { Id = 4, Name = "David", Age = 24, ClassName = "C", Score = 64 },
            new Student { Id = 5, Name = "Eva", Age = 19, ClassName = "B", Score = 85 },
            new Student { Id = 6, Name = "Felix", Age = 21, ClassName = "A", Score = 77 },
            new Student { Id = 7, Name = "Gustav", Age = 23, ClassName = "C", Score = 58 },
            new Student { Id = 8, Name = "Hanna", Age = 20, ClassName = "B", Score = 95 }
            // ↑ Cada new Student crea un objeto estudiante.
            // Dentro de { } asignamos valores a sus propiedades.
            // Name = "Anna" utiliza el set de la propiedad Name.
        };
            List<Student> olderStudents = students
            .Where(student => student.Age > 20)
            .ToList();

             // ↑ CONSULTA LINQ:
        // students: lista que consultamos.
        // Where: filtra según la condición escrita entre paréntesis.
        // student: nombre temporal de cada estudiante que comprobamos.
        // student.Age > 20: comprueba si su edad es mayor que 20.
        // ToList(): recorre la consulta y crea una lista con las coincidencias.
        // olderStudents: variable para acceder a esa nueva lista.

        Console.WriteLine("Students older than 20:");

       
        foreach (Student student in olderStudents)
         // ↑ REPETICIÓN: toma un estudiante del resultado cada vez.
        // Ejecuta lo que está dentro de { } para cada uno.
        {
            Console.WriteLine ($"{student.Name}: {student.Age} years old.");

             // ↑ Consulta Name y Age mediante sus get.
            // Muestra el nombre y la edad del estudiante actual.
        }

     List<Student> highScoringStudents = students
            .Where(student => student.Score > 80)
            .ToList();
            // ↑ students: utiliza la misma lista de ocho estudiantes.
// Where: filtra los estudiantes.
// student.Score: consulta la puntuación del estudiante actual.
// > 80: acepta solamente puntuaciones mayores que 80.
// ToList(): obtiene las coincidencias y las reúne en una nueva lista.
// highScoringStudents: variable para acceder a esa lista.


        Console.WriteLine("\nStudents with a score higher than 80:");
        // ↑ \n agrega un salto de línea para separar los resultados.

        foreach (Student student in highScoringStudents)
        // ↑ Recorre los estudiantes que pasaron el filtro.
        {
            Console.WriteLine($"{student.Name}: {student.Score} points.");
              // ↑ Consulta y muestra el nombre y la puntuación.
        }


        List<string> studemtNames = students
            .Select(student => student.Name)
            .ToList();
         // ↑ students: la lista original de ocho estudiantes.
// Select: obtiene la información que indicamos de cada estudiante.
// student: representa al estudiante que se está consultando.
// student.Name: obtiene su nombre mediante get.
// ToList(): recorre la consulta y reúne los nombres en una nueva lista.
//
// List<string>: el resultado contiene textos.
// Antes teníamos objetos Student; aquí obtenemos sus nombres.
// studentNames: variable para acceder a esa lista de nombres
  
        Console.WriteLine("\nStudent names:");
        // ↑ \n agrega un salto de línea para separar los resultados.

        foreach (string name in studemtNames)
        // ↑ Recorre la lista de nombres.
        {
            Console.WriteLine(name);
            // ↑ Muestra el nombre actual.
        }

      
      
     var studentSummaries = students
    .Select(student => new
    {
        Name = student.Name,
        Score = student.Score
    })
    .ToList();
// ↑ Select: prepara un resultado para cada estudiante.
//
// new { ... }: crea un objeto con las propiedades que escribimos.
// No aparece un nombre de clase después de new:
// así reconoces la creación de un objeto de tipo anónimo.
//
// Name = student.Name:
// izquierda: Name es la propiedad del nuevo objeto.
// derecha: student.Name consulta el nombre del estudiante original.
//
// Score = student.Score:
// copia la puntuación al nuevo objeto.
//
// ToList(): reúne los nuevos objetos en una lista.
//
// var: C# deduce el tipo de la variable a partir del resultado.
// No significa que pueda guardar cualquier tipo de dato.

Console.WriteLine("\nStudent names and scores:");

foreach (var summary in studentSummaries)
// ↑ summary permite acceder a cada objeto del resultado.
// Usamos var porque ese objeto tiene un tipo sin nombre escrito por nosotros.
{
    Console.WriteLine($"{summary.Name}: {summary.Score} points.");
}




List<Student> studentsByAge = students
    .OrderBy(student => student.Age)
    .ToList();
// ↑ students: lista original de estudiantes.
//
// OrderBy: ordena de menor a mayor.
// student.Age: indica qué dato se utiliza para ordenar.
// Aquí comparamos las edades.
//
// ToList(): reúne los estudiantes en una nueva lista ordenada.
// studentsByAge: variable para acceder a esa lista.
// La lista original students conserva su orden.

Console.WriteLine("\nStudents sorted by age:");

foreach (Student student in studentsByAge)
// ↑ Recorre la nueva lista siguiendo el orden de las edades.
{
    Console.WriteLine($"{student.Name}: {student.Age} years old.");
}


   List<Student> studentsByScore = students
    .OrderByDescending(student => student.Score)
    .ToList();
// ↑ OrderByDescending: ordena de mayor a menor.
// student.Score: indica que comparamos las puntuaciones.
// ToList(): reúne el resultado en una nueva lista.
// studentsByScore: variable para acceder a esa lista ordenada.
// La lista original students conserva su orden.

Console.WriteLine("\nStudents sorted by score, highest first:");

foreach (Student student in studentsByScore)
// ↑ Recorre los estudiantes empezando por la puntuación más alta.
{
    Console.WriteLine($"{student.Name}: {student.Score} points.");
}


int totalStudents = students.Count();
// ↑ int: el resultado es un número entero.
// totalStudents: variable que guarda ese número.
// students: lista que consultamos.
// Count(): cuenta todos sus elementos.
// Los paréntesis vacíos indican que no agregamos una condición.
Console.WriteLine($"\nTotal students: {totalStudents}");
 
int classAStudents = students.Count(student => student.ClassName == "A");
// ↑ Count(...): cuenta los que cumplen la condición.
// student: representa a cada estudiante que se comprueba.
// student.ClassName: consulta su grupo.
// == "A": comprueba si ese grupo es igual a "A".
// == COMPARA dos valores; = ASIGNA un valor.


Console.WriteLine($"Students in class A: {classAStudents}");

// EJERCICIO: obtener los tres primeros estudiantes.
List<Student> firstThreeStudents = students
    .Take(3)
    .ToList();
// ↑ Take(3): obtiene los primeros tres elementos de la lista.
// El número entre paréntesis indica CUÁNTOS obtener.
// ToList(): reúne el resultado en una nueva lista.
// La lista original conserva sus ocho estudiantes.

Console.WriteLine("\nFirst three students:");

foreach (Student student in firstThreeStudents)
{
    Console.WriteLine(student.Name);
} // ← Aquí termina este foreach.


// EJERCICIO: obtener los dos estudiantes con mayor puntuación.
List<Student> topTwoStudents = students
    .OrderByDescending(student => student.Score)
    .Take(2)
    .ToList();
// ↑ OrderByDescending: primero ordena por puntuación,
// empezando por la más alta.
// Take(2): después obtiene los dos primeros de ese orden.
// ToList(): reúne esos dos estudiantes en una nueva lista.

Console.WriteLine("\nTop two students:");

foreach (Student student in topTwoStudents)
{
    Console.WriteLine($"{student.Name}: {student.Score} points.");
} // ← Aquí termina este foreach.



// EJERCICIO: obtener los nombres de las clases sin repetir.
List<string> uniqueClasses = students
    .Select(student => student.ClassName)
    .Distinct()
    .ToList();
// ↑ Select: obtiene el grupo de cada estudiante.
// Antes de Distinct tenemos: A, B, A, C, B, A, C, B.
// Distinct(): deja una sola aparición de cada valor.
// ToList(): reúne los textos resultantes en una nueva lista.

Console.WriteLine("\nUnique classes:");

foreach (string className in uniqueClasses)
// ↑ string: cada elemento de esta lista es un texto.
{
    Console.WriteLine(className);
} // ← Termina el primer foreach.


// EJERCICIO: obtener las edades sin repetir.
List<int> uniqueAges = students
    .Select(student => student.Age)
    .Distinct()
    .ToList();
// ↑ Select: obtiene las edades.
// Distinct(): evita repetir una misma edad en el resultado.
// List<int>: esta lista contiene números enteros.

Console.WriteLine("\nUnique ages:");

foreach (int age in uniqueAges)
// ↑ int: cada elemento de esta lista es un número entero.
{
    Console.WriteLine(age);
} // ← Termina el segundo foreach.



bool hasPerfectScore = students.Any(student => student.Score == 100);
// ↑ bool: guardamos una respuesta verdadera o falsa.
// Any: pregunta si AL MENOS UNO cumple la condición.
// student.Score == 100: comprueba si su puntuación es igual a 100.
// Any devuelve true cuando encuentra una coincidencia.
// Si ninguno cumple, devuelve false.


Console.WriteLine($"\nDoes anyone have 100 points? {hasPerfectScore}");


bool allStudentsPassed = students.All(student => student.Score >= 50);
// ↑ All: pregunta si TODOS cumplen la condición.
// >= significa "mayor o igual que".
// Si encuentra un estudiante con menos de 50, devuelve false.
// Si todos cumplen, devuelve true.

Console.WriteLine($"Does everyone have at least 50 points? {allStudentsPassed}");


     
     Student? firstStudentInClassB = students
    .FirstOrDefault(student => student.ClassName == "B");

    Console.WriteLine("\nFirst student in class B:");


    if (firstStudentInClassB != null)
        // ↑ != null: comprueba que sí encontramos un estudiante.
        // Solo consultamos su nombre si existe.
        {
            
           Console.WriteLine(firstStudentInClassB.Name);
        }

        else
{
        Console.WriteLine("No student found in class B.");
}

 Student selectedStudent = students
 .Single(student => student.Id == 3);
 // ↑ Single: exige EXACTAMENTE UNA coincidencia.
// student.Id == 3: busca al estudiante cuya identificación es 3.
// Si no encuentra ninguno o encuentra varios, lanza una excepción.
// Con nuestros datos, existe exactamente uno: Cecilia.

Console.WriteLine($"\nStudent with ID 3: {selectedStudent.Name}");


// EJERCICIO: agrupar estudiantes por clase.
var studentsByClass = students
    .GroupBy(student => student.ClassName);
// ↑ GroupBy: reúne los estudiantes que comparten el mismo dato.
// student.ClassName: indica que agrupamos por clase.
// var: C# deduce el tipo de la variable a partir del resultado.
// studentsByClass: permite acceder a la consulta de grupos.

Console.WriteLine("\nStudents grouped by class:");

foreach (var group in studentsByClass)
// ↑ PRIMER FOREACH: recorre los grupos A, B y C.
// Al recorrer la consulta, se realiza la agrupación.
{
    Console.WriteLine($"Class {group.Key}:");
    // ↑ group.Key: consulta el valor que identifica al grupo.
    // Por ejemplo, "A".

    foreach (Student student in group)
    // ↑ SEGUNDO FOREACH: recorre los estudiantes de ESTE grupo.
    // Está dentro del primero porque cada grupo contiene estudiantes.
    {
        Console.WriteLine($"- {student.Name}");
    }

} 

int totalScore = students.Sum(student => student.Score);
double averageScore = students.Average(student => student.Score);
int lowestScore = students.Min(student => student.Score);
// ↑ Min: devuelve el menor valor de Score.
// Devuelve la puntuación, no el objeto estudiante.


// EJERCICIO: obtener la puntuación más alta.
int highestScore = students.Max(student => student.Score);
// ↑ Max: devuelve el mayor valor de Score.
// Devuelve la puntuación, no el objeto estudiante.


// Mostramos los cuatro resultados.
Console.WriteLine("\nScore calculations:");
Console.WriteLine($"Total score: {totalScore}");
Console.WriteLine($"Average score: {averageScore}");
Console.WriteLine($"Lowest score: {lowestScore}");
Console.WriteLine($"Highest score: {highestScore}");



    }
}



