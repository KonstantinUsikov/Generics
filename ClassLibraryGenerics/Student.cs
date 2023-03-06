namespace ClassLibraryGenerics
{
    /// <summary>
    /// Класс "Студент".
    /// </summary>
    public class Student : IType
    {
        #region Поля
        public static string[] mensLastNames = new string[] { "Иванов", "Миронов", "Усиков", "Орлов", "Рогов", "Воробьёв", "Доронин", "Филатов", "Трофимов", "Ермаков", "Моисеев", "Князев", "Лебедев", "Рябов", "Михеев", "Капустин", "Кузьмин", "Баранов", "Герасимов", "Евсеев", "Кулаков", "Носков", "Котов", "Некрасов", "Григорьев", "Никонов", "Афанасьев", "Степанов", "Белов", "Воронцов" };
        public static string[] mensFirstNames = new string[] { "Артём", "Максим", "Константин", "Дмитрий", "Алексей", "Святослав", "Афанасий", "Платон", "Ярослав", "Ефим", "Григорий", "Тихон", "Вадим", "Эдуард", "Леонид", "Борис", "Юрий", "Данила", "Александр", "Семён", "Василий", "Глеб", "Богдан", "Артур", "Денис", "Илья", "Виталий", "Филипп", "Иван", "Александр" };
        public static string[] mensPatronomics = new string[] { "Владимирович", "Александрович", "Дмитриевич", "Сергеевич", "Никитич", "Алексеевич", "Святославович", "Афанасьевич", "Ярославович", "Ефимович", "Григорьевич", "Тихонович", "Вадимович", "Эдуардович", "Леонидович", "Борисович", "Юрьевич", "Данилович", "Александрович", "Семёнович", "Васильевич", "Глебович", "Богданович", "Артурович", "Денисович", "Ильич", "Витальевич", "Филиппович", "Иванович", "Максимович" };

        private static string[] femaleLastNames = new string[] { "Иванова", "Миронова", "Усикова", "Орлова", "Рогова", "Воробьёва", "Доронина", "Филатова", "Трофимова", "Ермакова", "Моисеева", "Князева", "Лебедева", "Рябова", "Михеева", "Капустина", "Кузьмина", "Баранова", "Герасимова", "Евсеева", "Кулакова", "Носкова", "Котова", "Некрасова", "Григорьева", "Никонова", "Афанасьева", "Степанова", "Белова", "Воронцова" };
        private static string[] femaleFirstNames = new string[] { "Наталья", "София", "Яна", "Екатерина", "Злата", "Ника", "Галина", "Лилиана", "Альбина", "Валентина", "Анжелика", "Вера", "Людмила", "Светлана", "Карина", "Кристина", "Лидия", "Майя", "Александра", "Элеонора", "Любовь", "Варвара", "Дарья", "Лариса", "Ульяна", "Маргарита", "Юлиана", "Анфиса", "Раиса" };
        private static string[] femalePatronomics = new string[] { "Владимировна", "Александровна", "Дмитриевна", "Сергеевна", "Никитична", "Алексеевна", "Святославовна", "Афанасьевна", "Ярославовна", "Ефимовна", "Григорьевна", "Тихоновна", "Вадимовна", "Эдуардовна", "Леонидовна", "Борисовна", "Юрьевна", "Даниловна", "Александровна", "Семёновна", "Васильевна", "Глебовна", "Богдановна", "Артуровна", "Денисовна", "Ильинична", "Витальевна", "Филипповна", "Ивановна", "Максимовна" };

        private static string[] genders = new string[] { "Мужской", "Женский" };

        private string lastName;  // фамилия
        private string firstName;  // имя
        private string patronymic;  // отчество
        private int age;  // возраст
        private double height;  // рост (см)
        private double weight;  // вес (кг)
        private double averageMark;  // средний балл

        /// <summary>
        /// Фамилия студента.
        /// </summary>
        public string LastName
        {
            get { return lastName; }
        }

        /// <summary>
        /// Имя студента.
        /// </summary>
        public string FirstName
        {
            get { return firstName; }
        }

        /// <summary>
        /// Отчество студента.
        /// </summary>
        public string Patronymic
        {
            get { return patronymic; }
        }

        /// <summary>
        /// Возраст студента.
        /// </summary>
        public int Age
        {
            get { return age; }
        }

        /// <summary>
        /// Рост студента (см).
        /// </summary>
        public double Height
        {
            get { return height; }
        }

        /// <summary>
        /// Вес студента (кг).
        /// </summary>
        public double Weight
        {
            get { return weight; }
        }

        /// <summary>
        /// Средний балл студента.
        /// </summary>
        public double AverageMark
        {
            get { return averageMark; }
        }
        #endregion

        #region Конструкторы
        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public Student()
        {
           
            Random r = new Random();
            string gender;
            gender = genders[r.Next(0, genders.Length)];
            if (gender == "Мужской")
            {
                lastName = mensLastNames[r.Next(0, mensLastNames.Length - 1)];
                firstName = mensFirstNames[r.Next(0, mensFirstNames.Length - 1)];
                patronymic = mensPatronomics[r.Next(0, mensPatronomics.Length - 1)];
            }
            else
            {
                lastName = femaleLastNames[r.Next(0, femaleLastNames.Length - 1)];
                firstName = femaleFirstNames[r.Next(0, femaleFirstNames.Length - 1)];
                patronymic = femalePatronomics[r.Next(0, femalePatronomics.Length - 1)];
            }
            age = r.Next(1, 100);
            height = r.Next(140, 210);
            weight = r.Next(45, 110);
            averageMark = 2 + r.NextDouble() * 3;
        }

        /// <summary>
        /// Конструктор по переданным параметрам.
        /// </summary>
        public Student(string lastName, string firstName, string patronymic, int age, double height, double weight, double averageMark)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.patronymic = patronymic;
            this.age = age;
            this.height = height;
            this.weight = weight;
            this.averageMark = averageMark;
        }
        #endregion

        #region Переопределение ToString()
        /// <summary>
        /// Переопределение метода ToString().
        /// </summary>
        /// <returns> строковое представление полей класса </returns>
        public override string ToString()
        {
            return $"ФИО: {lastName} {firstName} {patronymic}\n" + $"Возраст: {age}\n" + $"Рост: {height}\n" +  $"Вес: {weight}\n" + $"Средний Балл: {averageMark}";
        }
        #endregion

        #region Методы для сравнения
        /// <summary>
        /// Сравнение студентов по фамилии (по алфавиту).
        /// </summary>
        /// <param name="s1"> первый студент </param>
        /// <param name="s2"> второй студент </param>
        /// <returns> Если результат "больше" : 1; "меньше" : -1; "равно" : 0 </returns>
        public static int ComparerLastNameAlphabet(Student s1, Student s2)
        {
            return s1.LastName.CompareTo(s2.LastName);
        }

        /// <summary>
        /// Сравнение студентов по фамилии (по длине).
        /// </summary>
        /// <param name="s1"> первый студент </param>
        /// <param name="s2"> второй студент </param>
        /// <returns> Если результат "больше" : 1; "меньше" : -1; "равно" : 0 </returns>
        public static int ComparerLastNameLength(Student s1, Student s2)
        {
            return s1.LastName.Length.CompareTo(s2.LastName.Length);
        }

        /// <summary>
        /// Сравнение студентов по имени (по алфавиту).
        /// </summary>
        /// <param name="s1"> первый студент </param>
        /// <param name="s2"> второй студент </param>
        /// <returns> Если результат "больше" : 1; "меньше" : -1; "равно" : 0 </returns>
        public static int ComparerFirstNameAlphabet(Student s1, Student s2)
        {
            return s1.FirstName.CompareTo(s2.FirstName);
        }

        /// <summary>
        /// Сравнение студентов по имени (по длине).
        /// </summary>
        /// <param name="s1"> первый студент </param>
        /// <param name="s2"> второй студент </param>
        /// <returns> Если результат "больше" : 1; "меньше" : -1; "равно" : 0 </returns>
        public static int ComparerFirstNameLength(Student s1, Student s2)
        {
            return s1.FirstName.Length.CompareTo(s2.FirstName.Length);
        }

        /// <summary>
        /// Сравнение студентов по отчеству (по алфавиту).
        /// </summary>
        /// <param name="s1"> первый студент </param>
        /// <param name="s2"> второй студент </param>
        /// <returns> Если результат "больше" : 1; "меньше" : -1; "равно" : 0 </returns>
        public static int ComparerPatronymicAlphabet(Student s1, Student s2)
        {
            return s1.Patronymic.CompareTo(s2.Patronymic);
        }

        /// <summary>
        /// Сравнение студентов по отчеству (по длине).
        /// </summary>
        /// <param name="s1"> первый студент </param>
        /// <param name="s2"> второй студент </param>
        /// <returns> Если результат "больше" : 1; "меньше" : -1; "равно" : 0 </returns>
        public static int ComparerPatronymicLength(Student s1, Student s2)
        {
            return s1.Patronymic.Length.CompareTo(s2.Patronymic.Length);
        }

        /// <summary>
        /// Сравнение студентов по возрасту.
        /// </summary>
        /// <param name="s1"> первый студент </param>
        /// <param name="s2"> второй студент </param>
        /// <returns> Если результат "больше" : 1; "меньше" : -1; "равно" : 0 </returns>
        public static int ComparerAge(Student s1, Student s2)
        {
            if (s1.Age > s2.Age)
                return 1;
            else if (s1.Age < s2.Age)
                return -1;
            else
                return 0;
        }

        /// <summary>
        /// Сравнение студентов по росту.
        /// </summary>
        /// <param name="s1"> первый студент </param>
        /// <param name="s2"> второй студент </param>
        /// <returns> Если результат "больше" : 1; "меньше" : -1; "равно" : 0 </returns>
        public static int ComparerHeight(Student s1, Student s2)
        {
            if (s1.Height > s2.Height)
                return 1;
            else if (s1.Height < s2.Height)
                return -1;
            else
                return 0;
        }

        /// <summary>
        /// Сравнение студентов по весу.
        /// </summary>
        /// <param name="s1"> первый студент </param>
        /// <param name="s2"> второй студент </param>
        /// <returns> Если результат "больше" : 1; "меньше" : -1; "равно" : 0 </returns>
        public static int ComparerWeight(Student s1, Student s2)
        {
            if (s1.Weight > s2.Weight)
                return 1;
            else if (s1.Weight < s2.Weight)
                return -1;
            else
                return 0;
        }

        /// <summary>
        /// Сравнение студентов по среднему баллу.
        /// </summary>
        /// <param name="s1"> первый студент </param>
        /// <param name="s2"> второй студент </param>
        /// <returns> Если результат "больше" : 1; "меньше" : -1; "равно" : 0 </returns>
        public static int ComparerAverageMark(Student s1, Student s2)
        {
            if (s1.AverageMark > s2.AverageMark)
                return 1;
            else if (s1.AverageMark < s2.AverageMark)
                return -1;
            else
                return 0;
        }

        /// <summary>
        /// Сравнение студентов в следующем порядке: средний балл - возраст - рост - вес.
        /// </summary>
        /// <param name="s1"> первый студент </param>
        /// <param name="s2"> второй студент </param>
        /// <returns> Если результат "больше" : 1; "меньше" : -1; "равно" : 0 </returns>
        public static int ComparerComplex(Student s1, Student s2)
        {
            int n = ComparerAverageMark(s1, s2);
            if (n != 0) return n;
            n = ComparerAge(s1, s2);
            if (n != 0) return n;
            n = ComparerHeight(s1, s2);
            if (n != 0) return n;
            return ComparerWeight(s1, s2);
        }
        #endregion
    }
}