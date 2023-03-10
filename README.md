# <p align="center">Web API for TicTacToe </p> 

```
Чтобы играть необходимо зарегистрироваться. Далее при создании игры, вы указываете Id друга. После того, как он примет приглашение, игра начнется. Первым ходит тот, кто создатель игры.
```

> Включена поддержка Swagger. Использовал locad Db.

## Описание API

1. `/api/User/Register` - *Регистрация на сайте. Необходимо указать логин и пароль, пароль должен содержать более пяти символов.*
2. `/api/User/Login` - *Вход в аккаунт.*
3. `/api/User/Logout` - *Выход из аккаунта.*
4. `/api/User/GetCurrentUserInformation` - *Возвращает информацию о текущей учетной записи.*
5. `/api/Game/CreateGame` - *Создание игры. Необходимо указать Id друга, идёт создание игры и отправка приглашения вашему оппоненту. Доступ только для авторизированных пользователей.*
6. `/api/Game/GetMyInvitations` - *Возвращает список активных приглашений к текущему пользователю. Доступ только для авторизованных пользователей.*
7. `/api/Game/AcceptInvitation` - *Принятие игры по gameId. После этого запроса можно начинать делать ходы. Доступ только для авторизованных пользователей.*
8. `/api/Game/GetCurrentGameInfo` - *Возвращает полную информацию об игре по gameId. Доступ только для авторизованных пользователей.*
9. `/api/Game/MakeStep` - *Сделать шаг. Принимает 2 параметра. Первый - gameId. Второй параметр - val - это значение от 0 до 8 включительно, указывающее клетку, в которую пользователь ставит крестик или нолик. Отсчет начинается с левого верхнего угла. Предусмотрены все ошибки, проверка на корректный ввод, на очередность пользователей, на то, что данная клетка является пустой. После конца игры все отправленные запросы будут возвращать false. В свойствах игры добавится победитель (если он есть), а также свойства finished станет равным true.*

*Поле игры:*

[1, 2, 4]

[8, 16, 32]

[64, 128, 256]

*Имеются два свойства у Game: PointPl1 и PointPl2. После хода в определенную ячейку к данным полям прибавляется число, которое в нем заложенно, в зависимости от пользователя. Если представлять в бинарной записи, наше чистое поле это 000000000. Выигрышные ситуации это 000000111, 000111000, 111000000, 001001001, 010010010, 100100100, 100010001, 001010100. Пользователи набираю очки, и когда они становятся равны на один из этих вариантов пользователь победил. Данный подход гарантирует уникальность очков у пользователей.*


