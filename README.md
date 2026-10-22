# Generics

Учебный проект по обобщениям (generics) и делегатам в C# / .NET 6: собственные обобщённые коллекции, универсальные сортировки с делегатом-компаратором, численное интегрирование (обычное и параллельное) и WPF-интерфейс для работы со всем этим.

## Структура решения

| Проект | Назначение |
|---|---|
| `ClassLibraryGenerics` | Библиотека классов (net6.0) |
| `ConsoleAppGenerics` | Консольный пример: сравнение времени `Integral` и `IntegralParallel` для x² на 100 000 000 шагов |
| `WPFInterface` | Графический интерфейс на WPF (net6.0-windows) |
| `TestProjectGenerics` | Модульные тесты на MSTest |

## Возможности библиотеки

### Коллекции
- `Container<T>` — абстрактный базовый класс контейнера: `Add`, `Remove`, `Peek`, `ToString`, `GetInfo`.
- `MyStack<T>` — стек на массиве.
- `MyQueue<T>` — очередь на кольцевом буфере.

Обе коллекции удваивают вместимость при заполнении.

### Сортировки (`Sorter`)
Обобщённые методы `BubbleSort`, `InsertSort`, `MergeSort`, `QuickSort`. Каждый принимает массив, компаратор `Func<T, T, int>` и флаг `ascending` (по возрастанию / по убыванию).

### Интегрирование (`Mathematics`)
- `Integral` — вычисление определённого интеграла методом трапеций.
- `IntegralParallel` — то же самое, но значения функции считаются параллельно через `Parallel.For`.

### Модели данных
`Car`, `Student`, `Rectangle`: конструктор по умолчанию заполняет поля случайными данными, а статические методы `Comparer*` (например, `Student.ComparerAverageMark`, `Car.ComparerComplex`, `Rectangle.ComparerArea`) можно передавать в сортировки как делегаты.

## WPF-интерфейс

- **Интеграл** — выбор функции (x², x, sin(x), cos(x)), пределов интегрирования, количества шагов и режима (параллельно / не параллельно). Выводит результат и время вычисления.
- **Коллекции** — стек или очередь из автомобилей, студентов или прямоугольников; кнопки «Добавить», «Удалить», «Очистить».
- **Сортировка** — выбор типа данных, поля для сравнения, метода сортировки и количества элементов (от 2 до 10 000, ползунком). Выводит время сортировки.

## Пример использования

```csharp
using ClassLibraryGenerics;

// Сортировка студентов по среднему баллу
Student[] students = Enumerable.Range(0, 10).Select(_ => new Student()).ToArray();
Sorter.QuickSort(students, Student.ComparerAverageMark, true);

// Интеграл x^2 на [0, 1]
double res = Mathematics.Integral(x => x * x, 0, 1, 1000);

// Стек автомобилей
var stack = new MyStack<Car>();
stack.Add(new Car());
Car top = stack.Remove();
```

## Требования и запуск

Нужен .NET 6 SDK. WPF-интерфейс работает только в Windows.

```
dotnet build Generics.sln
dotnet run --project ConsoleAppGenerics
dotnet run --project WPFInterface
dotnet test TestProjectGenerics
```

## Тесты

- `SortUnitTest` — все четыре сортировки.
- `StackQueueUnitTest` — стек и очередь для `Rectangle`, `Car`, `Student`.
- `IntegralUnitTest` — обычное и параллельное интегрирование.
