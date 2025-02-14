# Домашнее задание по КПО №1

## Оглавление
[1.Инструкция](#инструкция)

[2.Пояснения](#пояснения)

[3.SOLID moment](#solidmoment)


# Инструкция

Демонстрация работоспособности написанного кода находится в файле Program.cs папки MoscowZoo. Достаточно открыть sln и запустить проект MoscowZooAccounting.

**ВАЖНО!** В проекта MoscowZooAccounting.Tests есть тесты, которые могут дать неверный результат: это **IInventoryTests.cs** и **KindAnimalsListInformerTests.cs** (а именно тест GetInfo_ShouldReturnExpectedString()). И нужно перезапустить отдельно (пожалуйста), так как в них проверяется свойство Number, которое в моей реализации постоянно меняется при добавлении животных и предметов. А так как тесты запускаются каждый раз в другом порядке, то и Number каждый раз в этих тестах разный.


# Пояснения

1. **Abstractions** - директория с интерфейсами
   - IAlive - по условию;
   - IClinicProvider - интерфейс для клиники с методом для проверки здоровья животных;
   - IInfoProvider - интерфейс для предоставления информации определённого рода с соответствующим методом;
   - IInventory - по условию;
   - IInventoryStorageProvider - интерфейс для хранения инвентаря (животных и предметов) с геттером;
   - IItemsProvider - интерфейс для хранения предметов с геттером;
   - IZoo - интерфейс для хранения животных с геттером.
   
2. **Animals** - директория с классами животных, определенными в условии
   - иерархия классов: Animal -> Herbo -> Monkey, Rabbit и Animal -> Predator -> Tiger, Wolf;
   - классы Animal, Herbo и Predator - абстрактные по смыслу;
   - свойство KindnessLevel хранится в Herbo;
   - в конструкторе Animal при неверных значениях Food и HealthLevel выбирается рандомное значение в заданном диапазоне;
   - метод Info() возвращает строку со всей информацией о животном;
   - у KindnessLevel такой же диапазон значений, как и у HealthLevel (от 1 до 10).

3. **Services**
   - Зоопарк разделен на два класса: MoscowZoo и MoscowZooItemsStorage для удобства и разделения обязанностей двух классов. В одном хранятся животные, а в другом - предметы;
   - класс UniqueNumberProvider статичный, предназначен для генерации последовательных номеров для инвентаризируемых сущностей;
   - в классе InventoryStorage хранятся все инвентаризируемые сущности; 
   - делегат InventoryHandler используется для определения события появления нового инвентаря (животного или предмета). В MoscowZoo и MoscowZooItemsStorage присутствуют event'ы, оповещающие InventoryStorage о появлении инвентаря. В InventoryStorage обработчик события - AddInventory;
   - класс VetClinic предназначен для проверки здоровья животных;
   - классы AnimalCountInformer, FoodCountInformer, InventoryCountInformer, KindAnimalsListProvider разделяют обязанности по составлению отчетов о зоопарке: отчет о кол-ве животных, отчеты о потребляемой в день еде, отчет об инвентаре, список животных для контактного зоопарка.

4. **Program.cs** - демонстрация работоспособности программы с несколькими кейсами


# [SOLID moment](#solidmoment)
1. **S (Single Responsibility)** - используется повсеместно)). Вместо создания единого класса Zoo для хранения там всего (животных, предметов) созданы классы MoscowZoo и MoscowZooItemsStorage. Вместо хранения методов для составления отчетов о зоопарке в том же Zoo или создания отдельного класса для них имплементированы 4 отдельных класса - AnimalCountInformer, FoodCountInformer, InventoryCountInformer, KindAnimalsListProvider.
   
2. **O (Open-Closed)** - используется в методах по составлению отчетов, где выводится полная информация о животных: не нужно проверять конкретный тип (Herbo или Predator) для вывода доп. информации, такой как KindnessLevel. Также используется в методе IsAnimalHealthy в классе VetClinic, где также не нужно проверять тип конкретного объекта. При расширении иерархии класса Animal не придется менять данные методы.
   
3. **L (Liskov Substitution)** - производные классы Monkey, Rabbit могут заменять во всех методах своего предка Herbo. Аналогично для Tiger, Wolf - Predator; Computer, Table - Thing.
  
4. **I (Interface Segregation)** - все интерфейсы в проекте не перегружены, выполняют одну задачу. Например, IClinicProvider содержит только один метод, связанный с проверкой здоровья животного.
   
5. **D (Dependency Inversio)** - ни один высокоуровневый модуль не зависит от низкоуровневого, и большинство классов зависит от абстраций. Например, MoscowZoo зависит от IClinicProvider, который реализует класс VetClinic. Классы AnimalCountInformer, FoodCountInformer, KindAnimalsListProvider зависят от IZoo, реализуемый MoscowZoo, а InventoryCountInformer - от IInventoryStorageProvider, реализуемый InventoryStorage.

