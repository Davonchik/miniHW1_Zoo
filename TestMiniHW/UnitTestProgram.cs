// using System;
// using System.IO;
// using Xunit;
// using miniHW_1_AslanyanDG; // пространство имён с Program
//
// namespace miniHW_1_AslanyanDG.Tests
// {
//     public class ProgramTests
//     {
//         /// <summary>
//         /// Тест проверяет, что при выборе опции выхода (ввод "5") программа завершается без ошибок
//         /// и в выводе присутствуют основные элементы меню.
//         /// </summary>
//         [Fact]
//         public void Main_ExitImmediately_NoCrash()
//         {
//             // Arrange: симулируем ввод "5" для выхода
//             var input = "5\n";
//
//             using (var sw = new StringWriter())
//             {
//                 var originalIn = Console.In;
//                 var originalOut = Console.Out;
//                 try
//                 {
//                     Console.SetIn(new StringReader(input));
//                     Console.SetOut(sw);
//
//                     // Act: запускаем приложение
//                     Program.Main(Array.Empty<string>());
//                     var output = sw.ToString();
//
//                     // Assert: проверяем наличие меню и пункта "Выход"
//                     Assert.Contains("Выберите действие:", output);
//                     Assert.Contains("5. Выход", output);
//                 }
//                 finally
//                 {
//                     Console.SetIn(originalIn);
//                     Console.SetOut(originalOut);
//                 }
//             }
//         }
//
//         /// <summary>
//         /// Тест проверяет, что при некорректном выборе (например, "abc") 
//         /// приложение выводит сообщение об ошибке и затем повторно показывает меню.
//         /// </summary>
//         [Fact]
//         public void Main_InvalidInput_ShowsErrorMessageAndMenuAgain()
//         {
//             // Arrange: ввод некорректного значения, затем "5" для выхода
//             var input = "abc\n5\n";
//
//             using (var sw = new StringWriter())
//             {
//                 var originalIn = Console.In;
//                 var originalOut = Console.Out;
//                 try
//                 {
//                     Console.SetIn(new StringReader(input));
//                     Console.SetOut(sw);
//
//                     // Act
//                     Program.Main(Array.Empty<string>());
//                     var output = sw.ToString();
//
//                     // Assert: проверяем, что вывод содержит сообщение об ошибке и пункты меню
//                     Assert.Contains("Неверный выбор, попробуйте еще раз.", output);
//                     Assert.Contains("Выберите действие:", output);
//                     Assert.Contains("5. Выход", output);
//                 }
//                 finally
//                 {
//                     Console.SetIn(originalIn);
//                     Console.SetOut(originalOut);
//                 }
//             }
//         }
//         
//         // [Fact]
//         // public void Main_AddAnimalFlow_DisplaysSuccessMessage()
//         // {
//         //     // Arrange: формируем последовательность ввода согласно логике меню
//         //     var input = "1\n"   // выбираем "Добавить животное"
//         //               + "1\n"   // выбираем тип: Кролик
//         //               + "Lion\n"// имя животного
//         //               + "10\n"  // кг еды в сутки
//         //               + "707\n" // уровень здоровья
//         //               + "1\n"   // номер животного
//         //               + "7\n"   // уровень доброты
//         //               + "5\n";  // выбираем "Выход"
//         //
//         //     using (var sw = new StringWriter())
//         //     {
//         //         var originalIn = Console.In;
//         //         var originalOut = Console.Out;
//         //         try
//         //         {
//         //             Console.SetIn(new StringReader(input));
//         //             Console.SetOut(sw);
//         //
//         //             // Act
//         //             Program.AddAnimalMenu();
//         //             var output = sw.ToString();
//         //
//         //             // Assert: проверяем, что в выводе присутствует сообщение об успешном добавлении
//         //             Assert.Contains("Животное Lion успешно принято в зоопарк", output);
//         //         }
//         //         finally
//         //         {
//         //             Console.SetIn(originalIn);
//         //             Console.SetOut(originalOut);
//         //         }
//         //     }
//         // }
//     }
// }
