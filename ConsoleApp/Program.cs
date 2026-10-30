
using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Services;

AppDbContext context = new();

// Repositories
StudentRepository studentRepository = new(context);
GroupRepository groupRepository = new(context);
CourseRepository courseRepository = new(context);
MentorRepository mentorRepository = new(context);
StudentGroupRepository studentGroupRepository = new(context);
AnalyticsRepository analyticsRepository = new(context);
StatisticsRepository statisticsRepository = new(context);

// Services
StudentService studentService = new(studentRepository);
GroupService groupService = new(groupRepository);
CourseService courseService = new(courseRepository);
MentorService mentorService = new(mentorRepository);
StudentGroupService studentGroupService = new(studentGroupRepository);
AnalyticsService analyticsService = new(analyticsRepository);
StatisticsService statisticsService = new(statisticsRepository); 


while (true)
{
    System.Console.WriteLine("=============================");
    System.Console.WriteLine(@"
СТУДЕНТЫ!
1. Показать всех студентов.
2. Добавить студента.
3. Показать студента.
4. Удалить студента.
5. Изменить студента.
6. Получить отчисленных студентов.
7. Получить выпускников.
8. Получить студентов вместе с их группами.
9. Получить студентов без групп.

ГРУППЫ!
10. Показать все группы.
11. Добавить группу.
12. Показать группу.
13. Удалить группу.
14. Изменить группу.
15. Получить пустые группы.
16. Получить количество студентов в каждой группе.

УЧИТЕЛЯ!
17. Показать всех наставников.
18. Добавить наставника.
19. Показать наставника.
20. Удалить наставника.
21. Изменить наставника.
22. Получить наставников, которые ведут несколько курсов.
23. Получить наставника, у которого больше всего студентов.

КУРСЫ!
24. Показать все курсы.
25. Добавить курс.
26. Показать курс.
27. Удалить курс.
28. Изменить курс.
29. Получить наименее популярные курсы.
30. Получить самый популярный курс.
31. Получить количество студентов на каждом курсе.
32. Получить топ-3 курсов.

СТАТИСТИКИ!
33. Получить все даты начала занятий.
34. Получить общее количество курсов.
35. Получить общее количество групп.
36. Получить общее количество наставников.
37. Получить общее количество студентов.

АНАЛИТИКА!
38. Получить процент завершивших обучение.

РАСПРЕДЕЛЕНИЕ СТУДЕНТОВ!
33. Показать все записи студентов в группах.
34. Добавить студента в группу.
35. Показать запись студента в группе.
36. Удалить студента из группы.
37. Изменить статус студента в группе.

    ");
}